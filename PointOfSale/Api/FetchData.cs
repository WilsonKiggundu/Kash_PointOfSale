using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;
using Microsoft.JScript;
using Newtonsoft.Json;
using PointOfSale.Helpers;
using PointOfSale.Models;
using PointOfSale.Properties;

namespace PointOfSale.Api
{
    public class FetchData
    {
        private readonly PointOfSaleContext _context;
        private string _parameters;

        public FetchData(string username, string password)
        {
            _context = new PointOfSaleContext();
            _parameters = "&email=" + username + "&password=" + password;
        }

        public bool Products()
        {
            _parameters += "&type=product&tenant_id=" + Session.Tenant.WebId;
            var url = new Uri(Globals.ApiUrl + "?" + _parameters);
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";

            try
            {
                var response = (HttpWebResponse)request.GetResponse();
                var objStream = response.GetResponseStream();
                if (objStream == null) return false;

                var streamReader = new StreamReader(objStream, Encoding.GetEncoding("utf-8"), true);
                var res = streamReader.ReadToEnd();

                var products = JsonConvert.DeserializeObject<List<ProductViewModel>>(res);

                foreach (var product in products)
                {
                    var originalProduct = _context.Products.FirstOrDefault(p => p.WebId.Value == product.WebId);
                    if (originalProduct != null)
                    {
                        product.Sale = product.Sale.HasValue && product.Sale.Value;
                        product.Purchase = product.Purchase.HasValue && product.Purchase.Value;
                        product.Active = product.Active.HasValue && product.Active.Value;
                        product.Id = originalProduct.Id;
                        product.TenantId = Session.Tenant.Id;
                        _context.Entry(originalProduct).CurrentValues.SetValues(product);
                    }
                    else
                    {
                        _context.Products.Add(new Product
                        {
                            WebId = product.WebId,
                            Name = product.Name,
                            TenantId = Session.Tenant.Id,
                            CostPrice = product.Price,
                            Purchase = product.Purchase.HasValue && product.Purchase.Value,
                            Sale = product.Sale.HasValue && product.Sale.Value,
                            Barcode = product.Barcode,
                            DateCreated = DateTime.Now,
                        });
                    }
                }

                try
                {
                    _context.SaveChanges();
                    return true;

                }
                catch (Exception ex)
                {
                    MessageBox.Show(Resources.FetchDataError, Resources.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(Resources.FetchDataError, Resources.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return false;

        }

        public bool Users()
        {
            _parameters += "&type=user&tenant_id=" + Session.Tenant.WebId;
            try
            {
                var response = new HttpRequestResponse(_parameters, Globals.ApiUrl).SendRequest();
                var users = JsonConvert.DeserializeObject<List<User>>(response);

                foreach (var user in users)
                {
                    _context.Users.Add(user);
                }

                try
                {
                    _context.SaveChanges();
                    return true;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message + Resources.ConnectionError, Resources.NetworkAccess,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return false;

        }

        private bool CompanyExists(int webId)
        {
            return _context.Companies.Any(q => q.WebId.Value == webId);
        }

        public bool Companies()
        {
            _parameters += "&type=company&tenant_id=" + Session.Tenant.WebId;
            var url = new Uri(Globals.ApiUrl + "?" + _parameters);
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";

            try
            {
                var response = (HttpWebResponse)request.GetResponse();
                var objStream = response.GetResponseStream();
                if (objStream == null) return false;

                var streamReader = new StreamReader(objStream, Encoding.GetEncoding("utf-8"), true);
                var res = streamReader.ReadToEnd();

                var companies = JsonConvert.DeserializeObject<List<OrganizationViewModel>>(res);

                foreach (var company in companies)
                {
                    if (CompanyExists(company.WebId))
                    {
                        var c = _context.Companies.First(d => d.WebId.Value == company.WebId);
                        company.Occupant = company.Occupant ?? false;
                        company.LandLord = company.LandLord ?? false;
                        company.TenantId = Session.Tenant.Id;
                        company.Id = c.Id;
                        _context.Entry(c).CurrentValues.SetValues(company);
                    }
                    else
                        _context.Companies.Add(new Company
                        {
                            WebId = company.WebId,
                            DateCreated = DateTime.Now,
                            Landlord = company.LandLord != null && company.LandLord.Value,
                            Name = company.Name,
                            Occupant = company.Occupant != null && company.Occupant.Value,
                            Telephone = company.Telephone,
                            TenantId = Session.Tenant.Id,
                            Currency = null,
                            Address = company.Address
                        });
                }

                try
                {
                    _context.SaveChanges();
                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(Resources.FetchDataError, Resources.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(Resources.FetchDataError, Resources.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return false;
        }

        public bool Locations()
        {
            _parameters += "&type=location&tenant_id=" + Session.Tenant.WebId;
            var url = new Uri(Globals.ApiUrl + "?" + _parameters);
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";

            try
            {
                var response = (HttpWebResponse)request.GetResponse();
                var objStream = response.GetResponseStream();
                if (objStream == null) return false;

                var streamReader = new StreamReader(objStream, Encoding.GetEncoding("utf-8"), true);
                var res = streamReader.ReadToEnd();
                var locations = JsonConvert.DeserializeObject<List<Location>>(res);

                foreach (var location in locations)
                {
                    _context.Locations.Add(location);
                }

                try
                {
                    _context.SaveChanges();
                    return true;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(Resources.ConnectionError, Resources.NetworkAccess,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return false;
        }

        public List<TenantViewModel> Tenants()
        {
            _parameters += "&type=tenant";
            var url = new Uri(Globals.ApiUrl + "?" + _parameters);
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";

            try
            {
                var response = (HttpWebResponse)request.GetResponse();
                var objStream = response.GetResponseStream();
                if (objStream == null) return null;

                var streamReader = new StreamReader(objStream, Encoding.GetEncoding("utf-8"), true);
                var res = streamReader.ReadToEnd();

                var tenants = JsonConvert.DeserializeObject<List<TenantViewModel>>(res);
                return tenants;

            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message + Resources.ConnectionError, Resources.NetworkAccess,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return null;
        }

        //public bool PropertyTenants()
        //{
        //    _parameters = "&email=" + _username + "&password=" + _password;
        //    _parameters += "&type=propertytenant&tenant_id=" + Globals.Tenant.WebId;
        //    var url = new Uri(Globals.ApiUrl + "?" + _parameters);
        //    var request = (HttpWebRequest)WebRequest.Create(url);
        //    request.Method = "GET";

        //    try
        //    {
        //        var response = (HttpWebResponse)request.GetResponse();
        //        var objStream = response.GetResponseStream();
        //        if (objStream == null) return false;

        //        var streamReader = new StreamReader(objStream, Encoding.GetEncoding("utf-8"), true);
        //        var res = streamReader.ReadToEnd();

        //        var tenants = JsonConvert.DeserializeObject<List<PropTenantViewModel>>(res);

        //        foreach (var tenant in tenants)
        //        {
        //            var company =
        //                _context.Companies.FirstOrDefault(c => c.WebId == tenant.CompanyId.Value);

        //            var originaltenant = _context.PropertyTenants.FirstOrDefault(p => p.WebId.Value == tenant.WebId);
        //            var propertyunit = _context.PropertyUnits.FirstOrDefault(c => c.WebId == tenant.PropertyUnitId);
        //            if (originaltenant != null)
        //            {
        //                tenant.Id = originaltenant.Id;
        //                tenant.CompanyId = originaltenant.CompanyId;
        //                tenant.TenantId = Globals.Tenant.Id;
        //                _context.Entry(originaltenant).CurrentValues.SetValues(tenant);
        //            }
        //            else
        //            {
        //                if (propertyunit != null && company != null)
        //                    _context.PropertyTenants.Add(new PropertyTenant
        //                    {
        //                        WebId = tenant.WebId,
        //                        TenantId = Globals.Tenant.Id,
        //                        DateAdded = DateTime.Now,
        //                        Rent = tenant.Rent,
        //                        Active = tenant.Active.HasValue && tenant.Active.Value,
        //                        PropertyUnitId = propertyunit.Id,
        //                        StartDate = tenant.Startdate.HasValue ? tenant.Startdate.Value : DateTime.Now,
        //                        EndDate = tenant.Enddate.HasValue ? tenant.Enddate.Value : DateTime.Now.AddMonths(3),
        //                        CompanyId = company.Id,
        //                        DateCreated = DateTime.Now,
        //                        InvoicePeriod = "3 Months"
        //                    });
        //            }
        //        }
        //        try
        //        {
        //            _context.SaveChanges();
        //            return true;

        //        }
        //        catch (Exception ex)
        //        {
        //            MessageBox.Show(Resources.FetchDataError + " property tenants.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        }
        //    }
        //    catch (Exception exception)
        //    {
        //        MessageBox.Show(Resources.FetchDataError + " property tenants.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //    return false;
        //}

        //public bool PropertyUnits()
        //{
        //    _parameters = "&email=" + _username + "&password=" + _password;
        //    _parameters += "&type=propertyunit&tenant_id=" + Globals.Tenant.WebId;
        //    var url = new Uri(Globals.ApiUrl + "?" + _parameters);
        //    var request = (HttpWebRequest)WebRequest.Create(url);
        //    request.Method = "GET";

        //    try
        //    {
        //        var response = (HttpWebResponse)request.GetResponse();
        //        var objStream = response.GetResponseStream();
        //        if (objStream == null) return false;

        //        var streamReader = new StreamReader(objStream, Encoding.GetEncoding("utf-8"), true);
        //        var res = streamReader.ReadToEnd();

        //        var units = JsonConvert.DeserializeObject<List<PropUnitViewModel>>(res);

        //        foreach (var unit in units)
        //        {
        //            var originalunit = _context.Products.FirstOrDefault(p => p.WebId.Value == unit.WebId);

        //            var property =_context.Properties.FirstOrDefault(c => c.WebId == unit.PropertyId);
        //            if (originalunit != null)
        //            {
        //                unit.Id = originalunit.Id;
        //                unit.TenantId = Globals.Tenant.Id;
        //                _context.Entry(originalunit).CurrentValues.SetValues(unit);
        //            }
        //            else
        //            {
        //                if (property != null)
        //                    _context.PropertyUnits.Add(new PropertyUnit
        //                    {
        //                        WebId = unit.WebId,
        //                        TenantId = Globals.Tenant.Id,
        //                        DateAdded = DateTime.Now,
        //                        Code = unit.Code,
        //                        PropertyId = property.Id,
        //                        Rent = unit.Rent,
        //                        Active = unit.Active.HasValue && unit.Active.Value
        //                    });
        //            }
        //        }
        //        try
        //        {
        //            _context.SaveChanges();
        //            return true;

        //        }
        //        catch (Exception ex)
        //        {
        //            MessageBox.Show(Resources.FetchDataError + " property units.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        }
        //    }
        //    catch (Exception exception)
        //    {
        //        MessageBox.Show(Resources.FetchDataError + " property units.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //    return false;
        //}

        //public bool Properties()
        //{
        //    // First ensure that all comapnies are synched
        //    Companies();

        //    _parameters = "&email=" + _username + "&password=" + _password;
        //    _parameters += "&type=property&tenant_id=" + Globals.Tenant.WebId;
        //    var url = new Uri(Globals.ApiUrl + "?" + _parameters);
        //    var request = (HttpWebRequest)WebRequest.Create(url);
        //    request.Method = "GET";

        //    try
        //    {
        //        var response = (HttpWebResponse)request.GetResponse();
        //        var objStream = response.GetResponseStream();
        //        if (objStream == null) return false;

        //        var streamReader = new StreamReader(objStream, Encoding.GetEncoding("utf-8"), true);
        //        var res = streamReader.ReadToEnd();

        //        var properties = JsonConvert.DeserializeObject<List<PropViewModel>>(res);

        //        foreach (var property in properties)
        //        {
        //            var originalproperty = _context.Products.FirstOrDefault(p => p.WebId.Value == property.WebId);

        //            if (!property.CompanyId.HasValue) continue;

        //            var company =
        //                _context.Companies.FirstOrDefault(c => c.WebId == property.CompanyId.Value);
        //            if (originalproperty != null)
        //            {
        //                property.Id = originalproperty.Id;
        //                property.TenantId = Globals.Tenant.Id;
        //                _context.Entry(originalproperty).CurrentValues.SetValues(property);
        //            }
        //            else
        //            {
        //                if (company != null)
        //                    _context.Properties.Add(new Property
        //                    {
        //                        WebId = property.WebId,
        //                        Name = property.Name,
        //                        TenantId = Globals.Tenant.Id,
        //                        DateAdded = DateTime.Now,
        //                        Address = property.Address,
        //                        CompanyId = company.Id,
        //                        Created = DateTime.Now,
        //                        Expiry = DateTime.Now.AddYears(5),
        //                        Percentage = !property.Percentage.HasValue ? 0 : property.Percentage.Value,
        //                        UserId = Globals.UserId,
        //                        Remarks = property.Remarks
        //                    });
        //            }
        //        }

        //        try
        //        {
        //            _context.SaveChanges();
        //            PropertyUnits();
        //            return PropertyTenants();
        //        }
        //        catch (Exception ex)
        //        {
        //            MessageBox.Show(Resources.FetchDataError + " properties.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        }
        //    }
        //    catch (Exception exception)
        //    {
        //        MessageBox.Show(Resources.FetchDataError + " properties.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //    return false;
        //}
    }
}
