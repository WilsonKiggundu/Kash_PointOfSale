using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PointOfSale.Forms.Invoices;
using PointOfSale.Forms.Memos;
using PointOfSale.Forms.Products;
using PointOfSale.Forms.Receipts;
using PointOfSale.Forms.Settings.Company;
using PointOfSale.Forms.Settings.Currency;
using PointOfSale.Forms.Settings.Tax;
using PointOfSale.Forms.Stock;
using PointOfSale.Forms.Tenants;
using PointOfSale.Forms.User;
using PointOfSale.Helpers;
using PointOfSale.Properties;
using CreateVoucherForm = PointOfSale.Forms.Voucher.CreateVoucherForm;

namespace PointOfSale.Forms
{
    public partial class MainForm : Form
    {
        private readonly PointOfSaleContext _db = new PointOfSaleContext();
        public MainForm()
        {
            InitializeComponent();
        }

        private void msiAddNewUser_Click(object sender, EventArgs e)
        {
            new AddUserForm().ShowDialog();
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
            new CreateMemoForm().ShowDialog();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            ViewInvoices();
        }

        private void ResizeColumns(DataGridView grid)
        {
            if (grid.ColumnCount > 0)
            {
                for (var i = 0; i < grid.ColumnCount; i++)
                {
                    grid.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    grid.Columns[i].HeaderText = grid.Columns[i].HeaderText.SplitCamelCase();
                }
            }
        }

        private void miAddInvoice_Click(object sender, EventArgs e)
        {
            new CreateVoucherForm().ShowDialog();
        }

        private void miViewInvoices_Click(object sender, EventArgs e)
        {
            ViewInvoices();
        }

        private void ViewInvoices()
        {
            lbTitle.Text = Resources.Invoices;

            var invoices = _db.Invoices.Include(q => q.Company)
                                       .Include(q => q.Currency)
                                       .Where(q => !q.IsDeleted)
                                       .OrderByDescending(q => q.DateCreated)
                                       .ToList();

            var data = invoices.Select(s => new
            {
                No = s.Id,
                Type = s.InvoiceType,
                Company = s.Company?.Name,
                Currency = s.Currency?.Code,
                Paid = s.Paid,
                Remarks = s.Remarks,
                Amount = s.Journals.Sum(q => q.Amount),
                DateCreated = s.DateCreated.ToLongDateString()
            }).ToList();

            gridView.DataSource = data;
            ResizeColumns(gridView);
        }

        private void ViewReceipts()
        {
            lbTitle.Text = Resources.Receipts;

            var receipts = _db.Receipts.Include(q => q.Company)
                .Include(q => q.Currency)
                .Where(q => !q.IsDeleted)
                .OrderByDescending(q => q.DateCreated)
                .ToList();

            var data = receipts.Select(s => new
            {
                No = s.Id,
                Type = s.Type,
                Company = s.Company?.Name,
                Currency = s.Currency?.Code,
                Remarks = s.Remarks,
                Amount = s.Journals.Sum(q => q.Amount),
                DateCreated = s.DateCreated.ToLongDateString()
            }).ToList();

            gridView.DataSource = data;
            ResizeColumns(gridView);
        }

        private void ViewVouchers()
        {
            lbTitle.Text = Resources.Vouchers;

            var vouchers = _db.Vouchers.Include(q => q.Company)
                .Include(q => q.Currency)
                .Where(q => !q.IsDeleted)
                .OrderByDescending(q => q.DateCreated)
                .ToList();  

            var data = vouchers.Select(s => new
            {
                No = s.Id,
                Type = s.Type,
                Company = s.Company?.Name,
                Currency = s.Currency?.Code,
                Remarks = s.Remarks,
                Amount = s.Journals.Sum(q => q.Amount),
                DateCreated = s.DateCreated.ToLongDateString()
            }).ToList();

            gridView.DataSource = data;
            ResizeColumns(gridView);
        }

        private void ViewMemos()
        {   
            lbTitle.Text = Resources.Memos;

            var memos = _db.Memos.Include(q => q.Company)
                .Include(q => q.Currency)
                .Where(q => !q.IsDeleted)
                .OrderByDescending(q => q.DateCreated)
                .ToList();

            var data = memos.Select(s => new
            {
                No = s.Id,
                Type = s.Type,
                Company = s.Company?.Name,
                Currency = s.Currency?.Code,
                Remarks = s.Remarks,
                Amount = s.Journals.Sum(q => q.Amount),
                DateCreated = s.DateCreated.ToLongDateString()
            }).ToList();

            gridView.DataSource = data;
            ResizeColumns(gridView);
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

        private void miUsers_view_Click(object sender, EventArgs e)
        {
            new UsersListForm().ShowDialog();
        }

        private void miLogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            new LoginForm().Show();
        }

        private void miProducts_view_Click(object sender, EventArgs e)
        {
            lbTitle.Text = Resources.Products;

            var products = _db.Products.Include(p => p.Stock)
                .Where(p => !p.IsDeleted).OrderBy(d => d.Name).Select(s => new
                {
                    Code = s.Code,
                    Name = s.Name,
                    Type = s.ProductType,
                    CostPrice = s.CostPrice,
                    SellPrice = s.SellPrice,
                    MinStock = s.MinStock,
                    MaxStock = s.MaxStock,
                    Stock = s.Stock == null ? 0 : s.Stock.Count

                }).ToList();
            gridView.DataSource = products;
            ResizeColumns(gridView);
        }

        private void miInventory_add_Click(object sender, EventArgs e)
        {
            new AddStockForm().ShowDialog();
        }

        private void miInventory_view_Click(object sender, EventArgs e)
        {
            lbTitle.Text = Resources.Inventory;

            var stock = _db.Stock.Include(p => p.Product)
                .Where(p => !p.IsDeleted).OrderBy(d => d.Product.Name).Select(s => new
                {
                    Code = s.Product.Code,
                    Name = s.Product.Name,
                    Type = s.Product.ProductType,
                    Quantity = s.Count  

                }).ToList();
            gridView.DataSource = stock;
            ResizeColumns(gridView);
        }

        private void miProducts_add_Click(object sender, EventArgs e)
        {
            new AddProductForm().ShowDialog();
        }

        private void miTenants_view_Click(object sender, EventArgs e)
        {
            
        }

        private void miCompanies_view_Click(object sender, EventArgs e)
        {
            lbTitle.Text = Resources.Companies;

            var companies = _db.Companies.Where(q => !q.IsDeleted).OrderBy(q => q.Name).ToList();
            gridView.DataSource = companies;
            ResizeColumns(gridView);
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
            new CreateReceiptForm().ShowDialog();
        }

        private void miAddVoucher_Click(object sender, EventArgs e)
        {
            new CreateVoucherForm().ShowDialog();
        }
    }
}
