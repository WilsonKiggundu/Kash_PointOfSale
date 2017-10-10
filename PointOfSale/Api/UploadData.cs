using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;
using Newtonsoft.Json;
using PointOfSale.Helpers;
using PointOfSale.Models;
using PointOfSale.Properties;

namespace PointOfSale.Api
{
    public class UploadData
    {
        private readonly PointOfSaleContext _context;
        private readonly string _username;
        private readonly string _password;
        public UploadData(string username, string password)
        {
            _username = username;
            _password = password;
            _context = new PointOfSaleContext();
        }

        private static string MakeRequest(Dictionary<string, string> @params)
        {
            var request = (HttpWebRequest)WebRequest.Create(Globals.ApiUrl);

            var query = string.Join("&", @params.Select(kvp => $"{kvp.Key}={kvp.Value}"));
            var data = Encoding.ASCII.GetBytes(query);

            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = data.Length;

            try
            {
                using (var stream = request.GetRequestStream())
                {
                    stream.Write(data, 0, data.Length);
                }

                try
                {
                    var response = (HttpWebResponse)request.GetResponse();

                    var objStream = response.GetResponseStream();
                    if (objStream == null) return null;

                    var streamReader = new StreamReader(objStream, Encoding.GetEncoding("utf-8"), true);
                    return streamReader.ReadToEnd();
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message, Resources.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(Resources.ConnectionError, Resources.NetworkAccess, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return null;
        }


        public bool Companies()
        {
            var companies =
                _context.Companies.Where(q => q.TenantId == Session.Tenant.Id && q.WebId == null)
                    .Select(s => new CompanyViewModel
                    {
                        Id = s.Id,
                        WebId = null,
                        TenantId = s.TenantId,
                        Telephone = s.Telephone,
                        Address = s.Address,
                        //Landlord = s.Landlord,
                        //Occupant = s.Occupant,
                        DateAdded = s.DateCreated,
                        Name = s.Name.Replace("&", " "),
                        //Currency = s.Currency
                    }).ToList();

            if (!companies.Any()) return false;

            var jsonString = JsonConvert.SerializeObject(companies);

            if (Session.Tenant.WebId != null)
            {
                var parameters = new Dictionary<string, string>
                {
                    {"email", _username},
                    {"password", _password},
                    {"type", "upload_companies"},
                    {"tenant_id", Session.Tenant.WebId.Value.ToString(CultureInfo.InvariantCulture)},
                    {"data", jsonString}
                };

                var responseStream = MakeRequest(parameters);
                var response = JsonConvert.DeserializeObject<List<UploadResponseViewModel>>(responseStream);

                foreach (var data in response)
                {
                    var company = _context.Companies.Find(data.Id);
                    if (company == null) continue;

                    company.WebId = data.WebId;
                    _context.Companies.Attach(company);

                    var entry = _context.Entry(company);
                    entry.Property(p => p.WebId).IsModified = true;
                    _context.SaveChanges();
                }
            }

            return true;
        }

        public bool Invoices()
        {
            // First make sure all the companies are uploaded first
            Companies();

            var invoiceList = _context.Invoices
                .Include(c => c.Company)
                .Where(q => q.TenantId == Session.Tenant.Id && !q.WebId.HasValue)
                .ToList();

            if (!invoiceList.Any()) return false;

            var invoices = (from invoice in invoiceList
                            let invoiceItems = _context.GeneralJournals.Include(p => p.Product)
                            .Where(p => p.InvoiceId == invoice.Id && p.Product.WebId.HasValue)
                            .Select(p => new InvoiceItemViewModel
                            {
                                Id = p.Id,
                                Amount = p.Amount,
                                Quantity = p.Quantity,
                                InvoiceId = invoice.Id,
                                Particulars = p.Particulars.Replace("&", " "),
                                ProductId = p.Product.WebId ?? 0,
                                WebId = null
                            }).ToList()
                            select new InvoiceViewModel
                            {
                                Id = invoice.Id,
                                WebId = null,
                                CompanyId = invoice.Company != null ? invoice.Company.WebId ?? 0 : 0,
                                Remarks = invoice.Remarks.Replace("&", " "),
                                AmountPaid = invoice.Journals.Sum(s => s.Amount),
                                DateAdded = invoice.DateCreated,
                                Discount = invoice.Discount,
                                Type = invoice.InvoiceType.ToString(),
                                InvoiceItems = invoiceItems
                            }).ToList();

            // remove all invoices without items
            invoices = invoices.Where(i => i.InvoiceItems != null && i.InvoiceItems.Any()).ToList();

            var count = invoices.Count();
            var loops = count > 15 ? count / 5 : 1;
            for (var i = 0; i < loops; i++)
            {
                var take = loops == 1 ? count : 15;
                var skip = i * take;

                var jsonString = JsonConvert.SerializeObject(invoices.Skip(skip).Take(take));
                if (Session.Tenant.WebId != null)
                {
                    var parameters = new Dictionary<string, string>
                    {
                        {"email", _username},
                        {"password", _password},
                        {"type", "upload_invoices"},
                        {"tenant_id", Session.Tenant.WebId.Value.ToString(CultureInfo.InvariantCulture)},
                        {"data", jsonString}
                    };

                    var responseStream = MakeRequest(parameters);
                    if (responseStream == null) return false;

                    var response = JsonConvert.DeserializeObject<List<UploadResponseViewModel>>(responseStream);

                    foreach (var data in response)
                    {
                        var invoice = _context.Invoices.Find(data.Id);
                        if (invoice == null) continue;

                        invoice.WebId = data.WebId;
                        _context.Invoices.Attach(invoice);

                        var entry = _context.Entry(invoice);
                        entry.Property(p => p.WebId).IsModified = true;
                        _context.SaveChanges();
                    }
                }
            }

            return true;
        }

        public bool Reciepts()
        {
            //Companies();

            var recieptList = _context.Receipts.Include(i => i.Invoice)
                .Include(c => c.Company)
                .Where(q => q.TenantId == Session.Tenant.Id && !q.WebId.HasValue)
                .ToList();

            if (!recieptList.Any()) return false;
            
            var reciepts = (from receipt in recieptList
                            let recieptItems = _context.GeneralJournals.Include(p => p.Product)
                            .Where(p => p.ReceiptId == receipt.Id && p.Product.WebId.HasValue).Select(r => new RecieptItemViewModel
                            {
                                Id = r.Id,
                                WebId = null,
                                Amount = r.Amount,
                                Quantity = r.Quantity,
                                RecieptId = receipt.Id,
                                Particulars = r.Particulars.Replace("&", " "),
                                ProductId = r.Product.WebId ?? 0
                            }).ToList()
                            select new ReceiptViewModel
                            {
                                Id = receipt.Id,
                                WebId = null,
                                CompanyId = receipt.Company != null ? receipt.Company.WebId ?? 0 : 0,
                                Remarks = receipt.Remarks,
                                AmountPaid = receipt.Journals.Sum(s => s.Amount),
                                InvoiceId = receipt.Invoice != null ? receipt.Invoice.WebId ?? 0 : 0,
                                DateAdded = receipt.DateCreated,
                                ReceiptItems = recieptItems
                            }).ToList();

            reciepts = reciepts.Where(i => i.ReceiptItems != null && i.ReceiptItems.Any()).ToList();

            var count = reciepts.Count;

            var loops = count > 15 ? count / 5 : 1;
            for (var i = 0; i < loops; i++)
            {
                var take = loops == 1 ? count : 15;
                var skip = i * take;
                if (Session.Tenant.WebId != null)
                {
                    var parameters = new Dictionary<string, string>
                    {
                        {"email", _username},
                        {"password", _password},
                        {"type", "upload_receipts"},
                        {"tenant_id", Session.Tenant.WebId.Value.ToString(CultureInfo.InvariantCulture)},
                        {"data", JsonConvert.SerializeObject(reciepts.Skip(skip).Take(take).ToList())}
                    };

                    var responseStream = MakeRequest(parameters);
                    if (responseStream == null) return false;

                    var response = JsonConvert.DeserializeObject<List<UploadResponseViewModel>>(responseStream);

                    foreach (var data in response)
                    {
                        var receipt = _context.Receipts.Find(data.Id);
                        if (receipt == null) continue;

                        receipt.WebId = data.WebId;
                        _context.Receipts.Attach(receipt);

                        var entry = _context.Entry(receipt);
                        entry.Property(p => p.WebId).IsModified = true;
                        _context.SaveChanges();
                    }
                }
            }

            return true;

        }

        public bool Vouchers()
        {
            // First make sure all the companies are uploaded first
            Companies();

            var voucherList = _context.Vouchers.Include(c => c.Company)
                .Where(q => q.TenantId == Session.Tenant.Id)
                .ToList();

            if (!voucherList.Any()) return false;
            var vouchers = (from voucher in voucherList
                            let voucherItems = _context.GeneralJournals.Include(p => p.Product)
                            .Where(p => p.VoucherId == voucher.Id && p.Product.WebId.HasValue).Select(p => new VoucherItemViewModel
                            {
                                Id = p.Id,
                                WebId = null,
                                Amount = p.Amount,
                                VoucherId = voucher.Id,
                                Quantity = p.Quantity,
                                Particulars = p.Particulars.Replace("&", " "),
                                ProductId = p.Product.WebId ?? 0,
                            }).ToList()
                            select new VoucherViewModel
                            {
                                Id = voucher.Id,
                                WebId = null,
                                CompanyId = voucher.Company != null ? voucher.Company.WebId ?? 0 : 0,
                                Remarks = voucher.Remarks,
                                VoucherItems = voucherItems
                            }).ToList();

            vouchers = vouchers.Where(i => i.VoucherItems != null && i.VoucherItems.Any()).ToList();

            if (Session.Tenant.WebId != null)
            {
                var parameters = new Dictionary<string, string>
                {
                    {"email", _username},
                    {"password", _password},
                    {"type", "upload_vouchers"},
                    {"tenant_id", Session.Tenant.WebId.Value.ToString(CultureInfo.InvariantCulture)},
                    {"data", JsonConvert.SerializeObject(vouchers)}
                };

                var responseStream = MakeRequest(parameters);
                if (responseStream == null) return false;

                var response = JsonConvert.DeserializeObject<List<UploadResponseViewModel>>(responseStream);

                foreach (var data in response)
                {
                    var voucher = _context.Vouchers.Find(data.Id);
                    if (voucher == null) continue;

                    voucher.WebId = data.WebId;
                    _context.Vouchers.Attach(voucher);

                    var entry = _context.Entry(voucher);
                    entry.Property(p => p.WebId).IsModified = true;
                    _context.SaveChanges();
                }
            }

            return true;
        }
    }
}
