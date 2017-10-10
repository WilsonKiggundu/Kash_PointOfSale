using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Windows.Forms;
using Microsoft.Office.Interop;
using Microsoft.Office.Interop.Excel;
using PointOfSale.Forms.Accounts;
using PointOfSale.Forms.Invoices;
using PointOfSale.Forms.Products;
using PointOfSale.Forms.Receipts;
using PointOfSale.Forms.Settings.Company;
using PointOfSale.Forms.Settings.Currency;
using PointOfSale.Forms.Settings.Tax;
using PointOfSale.Forms.Stock;
using PointOfSale.Forms.Tenants;
using PointOfSale.Forms.User;
using PointOfSale.Helpers;
using PointOfSale.Models;
using PointOfSale.Properties;
using AddLocationForm = PointOfSale.Forms.Settings.Locations.AddLocationForm;
using Application = System.Windows.Forms.Application;
using CreateVoucherForm = PointOfSale.Forms.Voucher.CreateVoucherForm;
using CreateInvoiceForm = PointOfSale.Forms.Invoices.CreateInvoiceForm;
using Module = PointOfSale.Models.Module;

namespace PointOfSale.Forms
{
    public partial class MainForm : Form
    {
        private static readonly PointOfSaleContext _db = new PointOfSaleContext();
        private PrintDocument _pdoc = null;
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void msiViewProducts_Click(object sender, EventArgs e)
        {
            ViewMemos();
        }

        private void msiAddProduct_Click(object sender, EventArgs e)
        {
            // new CreateMemoForm().ShowDialog();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            dpFrom.Value = FirstDayOfMonth();
            dpTo.Value = DateTime.Now;

            ViewInvoices();

            ViewSummaries();
        }

        private void ViewSummaries()
        {
            // Summaries
            var today = DateTime.Today.AddDays(1);
            var startOfYear = new DateTime(today.Year, 1, 1);

            var totalCashReceived = _db.GeneralJournals
                .Where(q =>
                    q.Category == JournalCategory.Receipt &&
                    q.DateCreated >= startOfYear &&
                    q.DateCreated <= today)
                .Sum(s => s.Amount);
            lbCashReceived.Text = totalCashReceived.HasValue ? totalCashReceived.Value.ToString("N0") : "0";

            var totalCashSpent = _db.GeneralJournals
                .Where(q =>
                    q.Category == JournalCategory.Voucher &&
                    q.DateCreated >= startOfYear &&
                    q.DateCreated <= today)
                .Sum(s => s.Amount);
            lbTotalCashSpent.Text = totalCashSpent.HasValue ? totalCashSpent.Value.ToString("N0") : "0";

            var purchaseInvoices = _db.Invoices.Include(q => q.Journals)
                .Where(q =>
                    q.InvoiceType == InvoiceType.Purchase &&
                    q.DateCreated >= startOfYear &&
                    q.DateCreated <= today).ToList();

            decimal? purchaseInvoicesSum = 0;
            foreach (var invoice in purchaseInvoices)
            {
                purchaseInvoicesSum += invoice.Journals.Sum(q => q.Amount);
            }

            var balPurchase = purchaseInvoicesSum - totalCashSpent;
            lbPurchaseInvoiceBalance.Text = balPurchase.HasValue ? balPurchase.Value.ToString("N0") : "0";

            var salesInvoices = _db.Invoices.Include(q => q.Journals)
                .Where(q =>
                    q.InvoiceType == InvoiceType.Sale &&
                    q.DateCreated >= startOfYear &&
                    q.DateCreated <= today).ToList();

            decimal? salesInvoicesSum = 0;
            foreach (var invoice in salesInvoices)
            {
                salesInvoicesSum += invoice.Journals.Sum(q => q.Amount);
            }
            var balSales = salesInvoicesSum - totalCashReceived;
            lbSalesInvoiceBalance.Text = balSales.HasValue ? balSales.Value.ToString("N0") : "0";
        }

        private static void ResizeColumns(DataGridView grid)
        {
            if (grid.ColumnCount > 0)
            {
                for (var i = 0; i < grid.ColumnCount; i++)
                {
                    grid.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    grid.Columns[i].HeaderText = grid.Columns[i].HeaderText.SplitCamelCase();
                }
            }

            //grid.Columns[0].Visible = false;
            //grid.RowHeadersDefaultCellStyle = new DataGridViewCellStyle
            //{
            //    BackColor = Color.SteelBlue,
            //    ForeColor = Color.White
            //};
        }

        private void miViewInvoices_Click(object sender, EventArgs e)
        {
            ViewInvoices();
        }

        private void miCompanies_add_Click(object sender, EventArgs e)
        {
            new AddCompanyForm().ShowDialog();
        }

        private void miTenants_add_Click(object sender, EventArgs e)
        {
            new TenantCreateForm().ShowDialog();
        }

        private void miTaxes_add_Click(object sender, EventArgs e)
        {
            new AddTaxForm().ShowDialog();
        }

        private void miCurrencies_add_Click(object sender, EventArgs e)
        {
            new AddCurrencyForm().ShowDialog();
        }

        private void miUsers_add_Click(object sender, EventArgs e)
        {
            new AddUserForm().ShowDialog();
        }

        private void miLogout_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void miInventory_add_Click(object sender, EventArgs e)
        {
            new AddStockForm().ShowDialog();
        }

        private void miInventory_view_Click(object sender, EventArgs e)
        {
            ViewStock();
        }

        private void miProducts_add_Click(object sender, EventArgs e)
        {
            new AddProductForm().ShowDialog();
        }

        private void miViewReceipts_Click(object sender, EventArgs e)
        {
            ViewReceipts();
        }

        private void miViewVouchers_Click(object sender, EventArgs e)
        {
            ViewVouchers();
        }

        private void miAddReceipt_Click(object sender, EventArgs e)
        {
            new CreateReceiptForm(ReceiptType.Purchase).ShowDialog();
        }

        private void miAddVoucher_Click(object sender, EventArgs e)
        {
            new CreateVoucherForm(VoucherType.Purchase).ShowDialog();
        }

        private void menuOpen_Click(object sender, EventArgs e)
        {
            if (gridView.CurrentRow == null) return;

            var context = lbTitle.Text;
            var rowIndex = gridView.CurrentRow.Index;
            var id = gridView.Rows[rowIndex].Cells[0].Value.ToInteger();

            switch (context)
            {
                case "Invoices":
                    Printing.Preview(id, "Invoice");
                    break;

                case "Receipts":
                    Printing.Preview(id, "Receipt");
                    break;

                case "Vouchers":
                    Printing.Preview(id, "Voucher");
                    break;

                case "Memos":
                    Printing.Preview(id, "Memo");
                    break;
                default:
                    break;
            }

        }

        private void menuPurchaseInvoice_Click(object sender, EventArgs e)
        {
            new CreateInvoiceForm(InvoiceType.Purchase).ShowDialog();
        }

        private void menuSalesInvoice_Click(object sender, EventArgs e)
        {
            new CreateInvoiceForm(InvoiceType.Sale).ShowDialog(); // default is sales invoice
        }

        private void menuAddAccount_Click(object sender, EventArgs e)
        {
            new AddAccountForm().ShowDialog();
        }

        private void menuAddLocation_Click(object sender, EventArgs e)
        {
            new AddLocationForm().ShowDialog();
        }

        private void tbSearch_MouseDown(object sender, MouseEventArgs e)
        {
            if (tbSearch.Text.Equals(Resources.Search))
            {
                tbSearch.Text = "";
                tbSearch.ForeColor = Color.Black;
            }
        }

        private void tbSearch_KeyUp(object sender, KeyEventArgs e)
        {
            var context = Session.Module;
            var keyword = tbSearch.Text;
            switch (context)
            {
                case Module.Invoice:
                    ViewInvoices(keyword);
                    break;

                case Module.Receipt:
                    ViewReceipts(keyword);
                    break;

                case Module.Voucher:
                    ViewVouchers(keyword);
                    break;

                case Module.Memo:
                    ViewMemos(keyword);
                    break;
                case Module.Inventory:
                    ViewStock(keyword);
                    break;
                case Module.Users:
                    ViewUsers(keyword);
                    break;
                case Module.Companies:
                    ViewCompanies(keyword);
                    break;
                case Module.Tenants:
                    ViewTenants(keyword);
                    break;
                case Module.Taxes:
                    ViewTenants(keyword);
                    break;
                case Module.Currencies:
                    ViewCurrencies(keyword);
                    break;
                case Module.Accounts:
                    ViewAccounts(keyword);
                    break;
                case Module.Products:
                    ViewProducts(keyword);
                    break;
                case Module.Locations:
                    ViewLocations(keyword);
                    break;
            }
        }

        private void tbSearch_MouseLeave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tbSearch.Text)) return;

            tbSearch.Text = Resources.Search;
            tbSearch.ForeColor = Color.DarkGray;
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var context = lbTitle.Text;
            switch (context)
            {
                case "Invoices":
                    ViewInvoices();
                    break;

                case "Receipts":
                    ViewReceipts();
                    break;

                case "Vouchers":
                    ViewVouchers();
                    break;

                case "Memos":
                    ViewMemos();
                    break;
                default:
                    break;
            }
        }

        private void menuPrint_Click(object sender, EventArgs e)
        {
            if (gridView.CurrentRow == null) return;

            var context = lbTitle.Text;
            var rowIndex = gridView.CurrentRow.Index;
            var id = gridView.Rows[rowIndex].Cells[0].Value.ToInteger();

            switch (context)
            {
                case "Invoices":
                    Printing.Print(id, "Invoice", 340);
                    break;

                case "Receipts":
                    Printing.Print(id, "Receipt", 340);
                    break;

                case "Vouchers":
                    Printing.Print(id, "Voucher", 340);
                    break;

                case "Memos":
                    Printing.Print(id, "Memo", 340);
                    break;
                default:
                    break;
            }
        }

        private void menuPrintA4Paper_Click(object sender, EventArgs e)
        {
            if (gridView.CurrentRow == null) return;

            var context = lbTitle.Text;
            var rowIndex = gridView.CurrentRow.Index;
            var id = gridView.Rows[rowIndex].Cells[0].Value.ToInteger();

            _pdoc = new PrintDocument();
            var settings = new PrinterSettings();

            _pdoc.PrinterSettings = settings;
            var paperSizes = settings.PaperSizes.Cast<PaperSize>();
            var size = paperSizes.First<PaperSize>(s => s.Kind == PaperKind.A4);
            var width = size.Width;

            switch (context)
            {
                case "Invoices":
                    Printing.Print(id, "Invoice", width);
                    break;

                case "Receipts":
                    Printing.Print(id, "Receipt", width);
                    break;

                case "Vouchers":
                    Printing.Print(id, "Voucher", width);
                    break;

                case "Memos":
                    Printing.Print(id, "Memo", width);
                    break;
                default:
                    break;
            }
        }

        private void menuProducts_Click(object sender, EventArgs e)
        {
            ViewProducts();
        }

        private void menuUsers_Click(object sender, EventArgs e)
        {
            ViewUsers();
        }

        private void menuCompanies_Click(object sender, EventArgs e)
        {
            ViewCompanies();
        }

        private void menuTenants_Click(object sender, EventArgs e)
        {
            ViewTenants();
        }

        private void menuTaxes_Click(object sender, EventArgs e)
        {
            ViewTaxes();
        }

        private void menuCurrencies_Click(object sender, EventArgs e)
        {
            ViewCurrencies();
        }

        private void menuAccounts_Click(object sender, EventArgs e)
        {
            ViewAccounts();
        }

        private void menuLocations_Click(object sender, EventArgs e)
        {
            ViewLocations();
        }


        #region Helper methods

        private void ViewUsers(string search = null)
        {
            lbTitle.Text = EnumHelper<Module>.GetDisplayValue(Module.Users);
            Session.Module = Module.Users;

            var users = _db.TenantUsers.Include(q => q.User).Include(q => q.Tenant).Select(s => new
            {
                s.User.FirstName,
                s.User.LastName,
                s.User.Username,
                s.User.LastLoggedIn,
                s.Tenant.Name
            });

            if (!string.IsNullOrEmpty(search))
            {
                users = users.Where(q => q.FirstName.ToLower().Contains(search.ToLower())
                                         || q.LastName.ToLower().Contains(search.ToLower())
                                         || q.Username.ToLower().Contains(search.ToLower())
                                         || q.Name.ToLower().Contains(search.ToLower()));
            }

            gridView.DataSource = users.ToList();
            ResizeColumns(gridView);
        }

        private void ViewCompanies(string search = null)
        {
            lbTitle.Text = EnumHelper<Module>.GetDisplayValue(Module.Companies);
            Session.Module = Module.Companies;

            var query = _db.Companies.Include(q => q.Currency).Where(q => !q.IsDeleted).Select(s => new
            {
                s.Name,
                s.Telephone,
                s.Address,
                s.Email,
                Currency = s.Currency != null ? s.Currency.Code : null,
                s.DateCreated
            });

            if (!string.IsNullOrEmpty(search))
            {
                query = query.Where(q => q.Address.ToLower().Contains(search.ToLower()) ||
                                         q.Name.ToLower().Contains(search.ToLower()) ||
                                         q.Email.ToLower().Contains(search.ToLower()) ||
                                         q.Telephone.ToLower().Contains(search.ToLower())
                );
            }

            gridView.DataSource = query.ToList();
            ResizeColumns(gridView);
        }

        private void ViewTenants(string search = null)
        {
            lbTitle.Text = EnumHelper<Module>.GetDisplayValue(Module.Tenants);
            Session.Module = Module.Tenants;

            var query = _db.Tenants.Select(s => new
            {
                s.Address,
                s.Category,
                s.Email,
                s.Name,
                s.PostalAddress,
                s.Telephone,
                s.LastPaymentDate,
                s.Tin
            });

            if (!string.IsNullOrEmpty(search))
            {
                query = query.Where(q => q.Address.ToLower().Contains(search.ToLower()) ||
                                         q.Name.ToLower().Contains(search.ToLower()) ||
                                         q.Email.ToLower().Contains(search.ToLower()) ||
                                         q.Telephone.ToLower().Contains(search.ToLower()) ||
                                         q.Tin.ToLower().Contains(search.ToLower()));
            }

            gridView.DataSource = query.ToList();
            ResizeColumns(gridView);
        }

        private void ViewTaxes(string search = null)
        {
            lbTitle.Text = EnumHelper<Module>.GetDisplayValue(Module.Taxes);
            Session.Module = Module.Taxes;

            var query = _db.Taxes.Include(q => q.Tenant).Where(q => !q.IsDeleted).Select(s => new
            {
                s.Name,
                s.Percentage,
                Tenant = s.Tenant.Name
            });
            if (!string.IsNullOrEmpty(search))
            {
                query = query.Where(q => q.Name.ToLower().Contains(search.ToLower())
                || q.Tenant.ToLower().Contains(search.ToLower()));
            }

            gridView.DataSource = query.ToList();
            ResizeColumns(gridView);
        }

        private void ViewCurrencies(string search = null)
        {
            lbTitle.Text = EnumHelper<Module>.GetDisplayValue(Module.Currencies);
            Session.Module = Module.Currencies;

            var query = _db.Currencies.Where(q => !q.IsDeleted).Select(s => new
            {
                s.Code,
                s.Name,
                s.Rate,
                Tenant = s.Tenant.Name
            });

            if (!string.IsNullOrEmpty(search))
            {
                query = query.Where(q => q.Name.ToLower().Contains(search.ToLower())
                                        || q.Code.ToLower().Contains(search.ToLower())
                                        || q.Tenant.ToLower().Contains(search.ToLower()));
            }
            gridView.DataSource = query.ToList();
            ResizeColumns(gridView);
        }

        private void ViewAccounts(string search = null)
        {
            lbTitle.Text = EnumHelper<Module>.GetDisplayValue(Module.Accounts);
            Session.Module = Module.Accounts;

            var accounts = _db.Accounts.Include(q => q.ParentAccount).Include(q => q.PurchaseAccount).Where(q => !q.IsDeleted).Select(s => new
            {
                s.Name,
                s.Category,
                s.Depreciation,
                s.Fees,
                s.Budget,
                s.BalanceSheetCategory,
                s.CashflowCategory,
                ParentAccount = s.ParentAccount != null ? s.ParentAccount.Name : null,
                PurchaseAccount = s.PurchaseAccount != null ? s.PurchaseAccount.Name : null,
            });
            if (!string.IsNullOrEmpty(search))
            {
                accounts = accounts.Where(q => q.Name.ToLower().Contains(search.ToLower()));
            }

            gridView.DataSource = accounts.ToList();
            ResizeColumns(gridView);
        }

        private void ViewLocations(string search = null)
        {
            lbTitle.Text = EnumHelper<Module>.GetDisplayValue(Module.Locations);
            Session.Module = Module.Locations;

            var locations = _db.Locations.Include(q => q.Tenant).Where(q => !q.IsDeleted).Select(s => new
            {
                s.Name,
                s.Code,
                Tenant = s.Tenant.Name
            });
            if (!string.IsNullOrEmpty(search))
            {
                locations = locations.Where(q => q.Name.ToLower().Contains(search.ToLower())
                                                 || q.Code.ToLower().Contains(search.ToLower())
                                                 || q.Tenant.ToLower().Contains(search.ToLower()));
            }
            gridView.DataSource = locations.ToList();
            ResizeColumns(gridView);
        }

        private void ViewInvoices(string search = null)
        {
            lbTitle.Text = EnumHelper<Module>.GetDisplayValue(Module.Invoice);
            Session.Module = Module.Invoice;

            var from = dpFrom.Value;
            var to = dpTo.Value.AddDays(1);

            var query = _db.Invoices.Include(q => q.Company)
                .Include(q => q.Currency)
                .Include(q => q.Receipts)
                .Include(q => q.Receipts.Select(r => r.Journals))
                .Include(q => q.Vouchers)
                .Include(q => q.Vouchers.Select(v => v.Journals))
                .Where(q => !q.IsDeleted && q.TenantId == Session.TenantId)
                .Where(q => q.DateCreated >= from && q.DateCreated <= to);

            if (!string.IsNullOrEmpty(search))
            {
                query = query.Where(q =>
                            q.Company.Name.ToLower().Contains(search.ToLower()) ||
                            q.Currency.Code.ToLower().Contains(search.ToLower()) ||
                            q.Currency.Name.ToLower().Contains(search.ToLower()) ||
                            q.Remarks.ToLower().Contains(search.ToLower())
                        );
            }

            var invoices = query.OrderByDescending(q => q.DateCreated).ToList();

            var data = new List<object>();
            foreach (var s in invoices)
            {
                var paid = s.InvoiceType == InvoiceType.Purchase
                    ? s.Vouchers.Sum(v => v.Journals.Sum(q => q.Amount))
                    : s.Receipts.Sum(r => r.Journals.Sum(q => q.Amount));

                var total = s.Journals.Sum(q => q.Amount);
                var balance = total - paid;

                data.Add(new
                {
                    s.Id,
                    DateCreated = s.DateCreated.ToString("yyyy-MM-dd"),
                    Type = s.InvoiceType,
                    Company = s.Company?.Name,
                    Currency = s.Currency?.Code,
                    Total = total,
                    Paid = paid,
                    Balance = balance,
                    s.Remarks
                });
            }

            gridView.DataSource = data;
            ResizeColumns(gridView);
        }

        private void ViewReceipts(string search = null)
        {
            lbTitle.Text = EnumHelper<Module>.GetDisplayValue(Module.Receipt);
            Session.Module = Module.Receipt;

            var from = dpFrom.Value;
            var to = dpTo.Value.AddDays(1);

            var query = _db.Receipts.Include(q => q.Company)
                .Include(q => q.Currency)
                .Where(q => !q.IsDeleted && q.TenantId == Session.TenantId)
                .Where(q => q.DateCreated >= from && q.DateCreated <= to);

            if (!string.IsNullOrEmpty(search))
            {
                query = query.Where(q =>
                    q.Company.Name.ToLower().Contains(search.ToLower()) ||
                    q.Currency.Code.ToLower().Contains(search.ToLower()) ||
                    q.Currency.Name.ToLower().Contains(search.ToLower()) ||
                    q.Remarks.ToLower().Contains(search.ToLower())
                );
            }

            var receipts = query.OrderByDescending(q => q.DateCreated).ToList();
            var data = receipts.Select(s => new
            {
                No = s.Id,
                //Type = s.Type,
                Company = s.Company?.Name,
                Currency = s.Currency?.Code,
                s.Remarks,
                Amount = s.Journals.Sum(q => q.Amount),
                DateCreated = s.DateCreated.ToString("yyyy-MM-dd")
            }).ToList();

            gridView.DataSource = data;
            ResizeColumns(gridView);
        }

        private void ViewVouchers(string search = null)
        {
            lbTitle.Text = EnumHelper<Module>.GetDisplayValue(Module.Voucher);
            Session.Module = Module.Voucher;

            var from = dpFrom.Value;
            var to = dpTo.Value.AddDays(1);

            var query = _db.Vouchers.Include(q => q.Company)
                .Include(q => q.Currency)
                .Where(q => !q.IsDeleted && q.TenantId == Session.TenantId)
                .Where(q => q.DateCreated >= from && q.DateCreated <= to);

            if (!string.IsNullOrEmpty(search))
            {
                query = query.Where(q =>
                    q.Company.Name.ToLower().Contains(search.ToLower()) ||
                    q.Currency.Code.ToLower().Contains(search.ToLower()) ||
                    q.Currency.Name.ToLower().Contains(search.ToLower()) ||
                    q.Remarks.ToLower().Contains(search.ToLower())
                );
            }

            var vouchers = query.OrderByDescending(q => q.DateCreated).ToList();
            var data = vouchers.Select(s => new
            {
                No = s.Id,
                s.Type,
                Company = s.Company?.Name,
                Currency = s.Currency?.Code,
                s.Remarks,
                Amount = s.Journals.Sum(q => q.Amount),
                DateCreated = s.DateCreated.ToString("yyyy-MM-dd")
            }).ToList();

            gridView.DataSource = data;
            ResizeColumns(gridView);
        }

        private void ViewMemos(string search = null)
        {
            lbTitle.Text = EnumHelper<Module>.GetDisplayValue(Module.Memo);
            Session.Module = Module.Memo;

            var from = dpFrom.Value;
            var to = dpTo.Value.AddDays(1);

            var memos = _db.Memos.Include(q => q.Company)
                .Include(q => q.Currency)
                .Where(q => !q.IsDeleted && q.TenantId == Session.TenantId)
                .Where(q => q.DateCreated >= from && q.DateCreated <= to)
                .Select(s => new
                {
                    No = s.Id,
                    s.Type,
                    Company = s.Company == null ? null : s.Company.Name,
                    Currency = s.Currency == null ? null : s.Currency.Name,
                    s.Remarks,
                    Amount = s.Journals.Sum(q => q.Amount),
                    DateCreated = s.DateCreated.ToString("yyyy-MM-dd")
                });

            if (!string.IsNullOrEmpty(search))
            {
                memos = memos.Where(q =>
                    q.Company.ToLower().Contains(search.ToLower()) ||
                    q.Currency.ToLower().Contains(search.ToLower()) ||
                    q.Remarks.ToLower().Contains(search.ToLower())
                );
            }

            gridView.DataSource = memos.OrderByDescending(q => q.DateCreated).ToList();
            ResizeColumns(gridView);
        }

        private void ViewStock(string search = null)
        {
            lbTitle.Text = EnumHelper<Module>.GetDisplayValue(Module.Inventory);
            Session.Module = Module.Inventory;

            gridView.ContextMenu = null;

            var from = dpFrom.Value;
            var to = dpTo.Value.AddDays(1);

            var stock = _db.StockItems
                .Include(p => p.Product)
                .Include(p => p.Stock)
                .Include(p => p.User)
                .Include(p => p.SourceLocation)
                .Include(p => p.DestinationLocation)
                .Where(p => !p.IsDeleted)
                .Where(q => q.DateCreated >= from && q.DateCreated <= to)
                .OrderByDescending(d => d.DateCreated)
                .Select(s => new
                {
                    StockId = s.StockId,
                    Date = s.DateCreated,
                    Code = s.Product.Code,
                    ProductName = s.Product.Name,
                    BatchNo = s.BatchNo,
                    StockIn = s.Category == StockCategory.In ? s.Quantity : null,
                    StockOut = s.Category == StockCategory.Out ? s.Quantity : null,
                    StockTransfer = s.Category == StockCategory.Transfer ? s.Quantity : null,
                    Amount = s.Amount,
                    Source = s.SourceLocation == null ? null : s.SourceLocation.Name,
                    Destination = s.DestinationLocation == null ? null : s.DestinationLocation.Name,
                    User = s.User.FirstName + " " + s.User.LastName,
                });

            if (!string.IsNullOrEmpty(search))
            {
                stock = stock.Where(q => q.Code.ToLower().Contains(search.ToLower())
                                         || q.ProductName.ToLower().Contains(search.ToLower())
                                         || q.BatchNo.ToLower().Contains(search.ToLower())
                                         || q.Source.ToLower().Contains(search.ToLower())
                                         || q.Destination.ToLower().Contains(search.ToLower())
                                         || q.User.ToLower().Contains(search.ToLower()));
            }

            gridView.DataSource = stock.ToList();
            ResizeColumns(gridView);
        }


        private void ViewProducts(string search = null)
        {
            lbTitle.Text = EnumHelper<Module>.GetDisplayValue(Module.Products);
            Session.Module = Module.Products;

            var from = dpFrom.Value;
            var to = dpTo.Value.AddDays(1);

            var query = _db.Products.Where(p => !p.IsDeleted);

            if (!string.IsNullOrEmpty(search))
            {
                query = query.Where(q => q.Code.ToLower().Contains(search.ToLower())
                || q.Code.ToLower().Contains(search.ToLower())
                || q.Name.ToLower().Contains(search.ToLower()));
            }

            var data = new List<object>();

            var products = query.ToList();
            foreach (var product in products)
            {
                var stock = _db.StockItems.Where(p => p.ProductId == product.Id).ToList();
                var stockIn = stock.Where(q => q.Category == StockCategory.In).Sum(s => s.Quantity);
                var stockOut = stock.Where(q => q.Category == StockCategory.Out).Sum(s => s.Quantity);

                data.Add(new
                {
                    product.Id,
                    product.Code,
                    product.Name,
                    Type = product.ProductType,
                    product.CostPrice,
                    product.SellPrice,
                    product.MinStock,
                    product.MaxStock,
                    // product.OpeningStock,
                    AvailableStock = stockIn - stockOut + product.OpeningStock
                });
            }

            gridView.DataSource = data.ToList();
            ResizeColumns(gridView);
        }

        #endregion

        private void gridView_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                switch (Session.Module)
                {
                    case Module.Invoice:
                        cmMenu.Items[1].Visible = true;
                        cmMenu.Show(Cursor.Position);
                        break;
                    case Module.Receipt:
                    case Module.Voucher:
                    case Module.Memo:
                        cmMenu.Items[1].Visible = false;
                        cmMenu.Show(Cursor.Position);
                        break;
                    case Module.Inventory:
                    case Module.Users:
                    case Module.Companies:
                    case Module.Tenants:
                    case Module.Taxes:
                    case Module.Currencies:
                    case Module.Accounts:
                    case Module.Products:
                    case Module.Locations:
                        cmMenu.Hide();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }

        private void dpFrom_ValueChanged(object sender, EventArgs e)
        {
            switch (Session.Module)
            {
                case Module.Invoice:
                    ViewInvoices();
                    break;
                case Module.Receipt:
                    ViewReceipts();
                    break;
                case Module.Voucher:
                    ViewVouchers();
                    break;
                case Module.Memo:
                    ViewMemos();
                    break;
                case Module.Inventory:
                    ViewStock();
                    break;
                case Module.Users:
                    break;
                case Module.Companies:
                    break;
                case Module.Tenants:
                    break;
                case Module.Taxes:
                    break;
                case Module.Currencies:
                    break;
                case Module.Accounts:
                    break;
                case Module.Products:
                    break;
                case Module.Locations:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private DateTime FirstDayOfMonth()
        {
            var date = DateTime.Now;
            var month = date.Month;
            var year = date.Year;
            return new DateTime(year, month, 1);
        }

        private void menuPurchaseVoucher_Click(object sender, EventArgs e)
        {
            new CreateVoucherForm(VoucherType.Purchase).ShowDialog();
        }

        private void menuSaleVoucher_Click(object sender, EventArgs e)
        {
            new CreateVoucherForm(VoucherType.Sale).ShowDialog();
        }

        private void menuPurchaseReceipt_Click(object sender, EventArgs e)
        {
            new CreateReceiptForm(ReceiptType.Purchase).ShowDialog();
        }

        private void menuSaleReceipt_Click(object sender, EventArgs e)
        {
            new CreateReceiptForm(ReceiptType.Sale).ShowDialog();
        }

        private void cmPayment_Click(object sender, EventArgs e)
        {
            if (gridView.CurrentRow == null) return;

            var rowIndex = gridView.CurrentRow.Index;
            var id = gridView.Rows[rowIndex].Cells[0].Value.ToInteger();

            var invoice = _db.Invoices
                .Include(q => q.Journals)
                .Include(q => q.Receipts)
                .Include(q => q.Receipts.Select(r => r.Journals))
                .Include(q => q.Vouchers)
                .Include(q => q.Vouchers.Select(v => v.Journals))
                .FirstOrDefault(q => q.Id == id);

            if (invoice == null) return;
            if (invoice.InvoiceType == InvoiceType.Sale)
            {
                new CreateReceiptForm(invoice).ShowDialog();
            }
            else
            {
                new CreateVoucherForm(invoice).ShowDialog();
            }
        }

        private void homeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Home().ShowDialog();
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            ViewSummaries();
        }

        private void btnExcelExport_Click(object sender, EventArgs e)
        {
            var sfd = new SaveFileDialog
            {
                Filter = Resources.ExcelDocuments,
                FileName = $"{Session.Module}s_{DateTime.Now:yyyyMMddHHmmss}.xlsx"
            };

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                var xlExcel = new Microsoft.Office.Interop.Excel.Application { Visible = false};
                xlExcel.Workbooks.Add();

                for (int i = 1; i < gridView.ColumnCount + 1; i++)
                {
                    if (gridView.Columns[i - 1].Visible == false) continue;
                    xlExcel.Cells[1, i] = gridView.Columns[i - 1].Name;
                }

                var currentCell = xlExcel.ActiveCell;
                currentCell.EntireRow.Font.Bold = true;
                currentCell.EntireRow.Locked = true;

                for (int i = 0; i < gridView.Rows.Count; i++)
                {
                    for (int j = 0; j < gridView.ColumnCount; j++)
                    {
                        if (gridView.Columns[j].Visible == false) continue;
                        xlExcel.Cells[i + 2, j + 1] = gridView.Rows[i].Cells[j].Value?.ToString();
                    }
                }

                xlExcel.Columns.AutoFit();
                xlExcel.ActiveWorkbook.SaveCopyAs(sfd.FileName);
            }
        }
    }
}
