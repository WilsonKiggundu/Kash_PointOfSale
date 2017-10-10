using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using PointOfSale.Forms.Settings.Company;
using PointOfSale.Forms.Settings.Currency;
using PointOfSale.Forms.Settings.Locations;
using PointOfSale.Forms.Settings.Tax;
using PointOfSale.Helpers;
using PointOfSale.Models;
using PointOfSale.Properties;

namespace PointOfSale.Forms.Receipts
{
    public partial class CreateReceiptForm : Form
    {
        private readonly PointOfSaleContext _db = new PointOfSaleContext();
        private int? invoiceId = null;

        public CreateReceiptForm(Invoice invoice)
        {
            InitializeComponent();

            invoiceId = invoice.Id;

            var accounts = _db.Accounts.Where(q => !q.IsDeleted).Select(s => new { s.Id, s.Name }).ToList();
            cbAccount.DataSource = accounts;
            cbAccount.DisplayMember = "Name";
            cbAccount.ValueMember = "Id";
            cbAccount.SelectedValue = GetCashAccount();

            var companies = _db.Companies.Where(q => !q.IsDeleted).Select(s => new { s.Id, s.Name }).ToList();
            cbCompany.DataSource = companies;
            cbCompany.DisplayMember = "Name";
            cbCompany.ValueMember = "Id";
            cbCompany.SelectedValue = invoice.CompanyId;

            var total = invoice.Journals.Sum(s => s.Amount);
            var paid = invoice.InvoiceType == InvoiceType.Purchase
                ? invoice.Vouchers.Sum(v => v.Journals.Sum(q => q.Amount))
                : invoice.Receipts.Sum(r => r.Journals.Sum(q => q.Amount));

            var balance = total - paid;

            var account = GetAccountsReceivable();
            var row = new Product
            {
                Name = $"Payment for invoice #{invoice.Id}",
                SaleAccountId = account.Id,
                SaleAccount = account,
                SellPrice = balance
            };

            PopulateGrid(row);

        }

        public CreateReceiptForm(ReceiptType? type = null)
        {
            InitializeComponent();

            cbAccount.DataSource = _db.Accounts.Where(q => q.TenantId == Session.TenantId)
                .Select(s => new
                {
                    s.Id,
                    s.Name
                }).ToList();


            cbAccount.DisplayMember = "Name";
            cbAccount.ValueMember = "Id";

            cbAccount.SelectedValue = GetCashAccount();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void CreateReceiptForm_Load(object sender, EventArgs e)
        {
            for (var i = 0; i < dgvReceiptItems.ColumnCount; i++)
            {
                dgvReceiptItems.Columns[i].AutoSizeMode = i == 0
                    ? DataGridViewAutoSizeColumnMode.DisplayedCells
                    : DataGridViewAutoSizeColumnMode.Fill;
            }

            dgvReceiptItems.Columns[0].Visible = false; // hide the product id column

            //cbType.DataSource = Enum.GetValues(typeof(InvoiceType));

            LoadProducts();
            LoadCurrencies();
            LoadTaxes();
            LoadCompanies();

            if (cbCurrency.SelectedValue != null)
            {
                var currencyId = (int)cbCurrency.SelectedValue;
                UpdateExchangeRate(currencyId);
            }

        }

        private Account GetAccountsReceivable()
        {
            return _db.Accounts.FirstOrDefault(q => q.Name.Equals("Accounts Receivable"));
        }

        private int? GetAccountsPayable()
        {
            return _db.Accounts.Where(q => q.Name.Equals("Accounts Payable")).Select(s => s.Id).FirstOrDefault();
        }

        private int? GetCashAccount()
        {
            return _db.Accounts.Where(q => q.Name.Equals("Cash Account")).Select(s => s.Id).FirstOrDefault();
        }

        private void LoadProducts()
        {
            var products = _db.Products.Select(s => new { s.Id, s.Name }).ToList();
            products.Insert(0, new { Id = 0, Name = "Choose an item ..." });

            cbSearch.DataSource = products;
            cbSearch.DisplayMember = "Name";
            cbSearch.ValueMember = "Id";
        }

        private void LoadCompanies()
        {
            var companies = _db.Companies.OrderBy(d => d.Name).Select(s => new { s.Id, s.Name }).ToList();
            cbCompany.DataSource = companies;
            cbCompany.DisplayMember = "Name";
            cbCompany.ValueMember = "Id";
        }

        private void LoadTaxes()
        {
            var taxes = _db.Taxes.Select(s => new { s.Id, s.Name }).ToList();
            cbTax.DataSource = taxes;
            cbTax.DisplayMember = "Name";
            cbTax.ValueMember = "Id";
        }

        private void LoadCurrencies()
        {
            var currencies = _db.Currencies.Select(s => new { s.Id, s.Code }).ToList();
            cbCurrency.DataSource = currencies;
            cbCurrency.DisplayMember = "Code";
            cbCurrency.ValueMember = "Id";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var account = cbAccount.SelectedValue.ToInteger();
            var tax = cbTax.SelectedValue.ToInteger();
            var company = cbCompany.SelectedValue.ToInteger();
            var currency = cbCurrency.SelectedValue.ToInteger();
            var date = dpDate.Value;

            var rate = tbExchangeRate.Text;
            var number = tbInvoiceNumber.Text;

            var items = dgvReceiptItems.Rows;

            var receipt = new Receipt
            {
                AccountId = account.ToInteger(),
                TaxId = tax.ToInteger(),
                CompanyId = company.ToInteger(),
                CurrencyId = currency.ToInteger(),
                ExchangeRate = rate.ToDecimal(),
                Number = number,
                Paid = true,
                DateCreated = date,
                InvoiceId = invoiceId,
                Journals = new List<GeneralJournal>()
            };

            foreach (DataGridViewRow row in items)
            {
                if (row.IsNewRow) continue; // remove the last row. it is always empty

                var journal = new GeneralJournal
                {
                    CompanyId = receipt.CompanyId,
                    Particulars = row.Cells["Item"].Value.ToString(),
                    Quantity = row.Cells["Quantity"].Value.ToInteger(),
                    Amount = row.Cells["Total"].Value.ToDecimal(),
                    ExchangeRate = receipt.ExchangeRate,
                    DateCreated = date,
                    TaxId = row.Cells["Tax"].Value.ToInteger(),
                    CreditAccountId = row.Cells["AccountId"].Value.ToInteger(),
                    DebitAccountId = cbAccount.SelectedValue.ToInteger()
                };

                if (!invoiceId.HasValue)
                {
                    journal.ProductId = row.Cells["ProductId"].Value.ToInteger();
                }
                
                receipt.Journals.Add(journal);
            }

            if (!receipt.Journals.Any())
            {
                MessageBox.Show(Resources.NoReceiptItems, Resources.Failure, MessageBoxButtons.OK,
                    MessageBoxIcon.Stop);

                return;
            }

            // Add the receipt
            _db.Receipts.Add(receipt);
            _db.SaveChanges(); // save the receipt

            Close();
        }

        private void cbSearch_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cbSearch.SelectedItem == null) return;

            var productId = int.Parse(cbSearch.SelectedValue.ToString());
            var item = _db.Products
                        .Include(p => p.PurchaseAccount)
                        .Include(p => p.SaleAccount)
                        .FirstOrDefault(p => p.Id == productId && p.TenantId == Session.TenantId);

            if (item == null) return;

            PopulateGrid(item);
        }

        private void PopulateGrid(Product item)
        {
            // grid
            var gridView = dgvReceiptItems;

            // grid rows
            var i = gridView.RowCount;

            gridView.Rows.Add();

            var addedRowIndex = i - 1;

            if (invoiceId.HasValue)
            {
                gridView.Rows[addedRowIndex].Cells["ProductId"].Value = null;
            }

            else
            {
                gridView.Rows[addedRowIndex].Cells["ProductId"].Value = item.Id;
            }

            
            gridView.Rows[addedRowIndex].Cells["Item"].Value = item.Name;
            gridView.Rows[addedRowIndex].Cells["Quantity"].Value = 1;

            gridView.Rows[addedRowIndex].Cells["Account"].Value = item.SaleAccount.Name;
            gridView.Rows[addedRowIndex].Cells["AccountId"].Value = item.SaleAccountId;

            var taxCell = (DataGridViewComboBoxCell)gridView.Rows[addedRowIndex].Cells["Tax"];
            taxCell.DataSource = _db.Taxes.Where(q => !q.IsDeleted && q.TenantId == Session.TenantId)
                .Select(s => new { s.Id, Name = s.Name }).ToList();
            taxCell.ValueMember = "Id";
            taxCell.DisplayMember = "Name";

            gridView.Rows[addedRowIndex].Cells["UnitPrice"].Value = item.SellPrice;
            gridView.Rows[addedRowIndex].Cells["ProductId"].Value = item.Id;

            var quantity = gridView.Rows[addedRowIndex].Cells["Quantity"].Value.ToDecimal();
            var price = gridView.Rows[addedRowIndex].Cells["UnitPrice"].Value.ToDecimal();

            var amount = price * quantity;
            gridView.Rows[addedRowIndex].Cells["Total"].Value = amount;

            gridView.CurrentCell = gridView.Rows[addedRowIndex].Cells["Quantity"];

            try
            {
                gridView.BeginEdit(true);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }

            CalculateTotals();
        }

        private void dgvReceiptItems_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex <= -1) return;

            var row = e.RowIndex;

            if (e.ColumnIndex == 3 || e.ColumnIndex == 4 || e.ColumnIndex == 6)
            {
                var quantity = dgvReceiptItems.Rows[row].Cells["Quantity"].Value.ToDecimal();
                var price = dgvReceiptItems.Rows[row].Cells["UnitPrice"].Value.ToDecimal();
                var total = dgvReceiptItems.Rows[row].Cells["Total"].Value.ToDecimal();

                if (e.ColumnIndex == 6)
                {
                    price = total / (quantity == 0 ? 1 : quantity);
                }
                var amount = quantity * price;

                dgvReceiptItems.Rows[row].Cells["Quantity"].Value = quantity;
                dgvReceiptItems.Rows[row].Cells["UnitPrice"].Value = price;
                dgvReceiptItems.Rows[row].Cells["Total"].Value = amount;

                CalculateTotals();
            }
        }

        private void CalculateTotals()
        {
            decimal total = 0;
            var i = 0;
            var rows = dgvReceiptItems.Rows;
            foreach (DataGridViewRow row in rows)
            {
                if (row.IsNewRow) continue;
                total += dgvReceiptItems.Rows[i].Cells["Total"].Value.ToDecimal() ?? 0;
                i++;
            }

            tbGrandTotal.Text = total.ToString(CultureInfo.InvariantCulture);
        }

        private void llAddCompany_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new AddCompanyForm().ShowDialog();
        }

        private void llAddTax_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new AddTaxForm().ShowDialog();
        }

        private void llAddCurrency_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new AddCurrencyForm().ShowDialog();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            // LoadProducts();
            LoadCurrencies();
            LoadTaxes();
            LoadCompanies();
        }

        private void cbCurrency_SelectionChangeCommitted(object sender, EventArgs e)
        {
            var currencyId = (int)((ComboBox)sender).SelectedValue;
            UpdateExchangeRate(currencyId);
        }

        private void UpdateExchangeRate(int currencyId)
        {
            var currency = _db.Currencies.First(q => q.Id == currencyId);
            tbExchangeRate.Text = currency.Rate.ToString();
        }

        private void llAddLocation_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new AddLocationForm().ShowDialog();
        }

        private void dgvInvoiceItems_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }
    }
}
