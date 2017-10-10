using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using PointOfSale.Forms.Products;
using PointOfSale.Forms.Settings.Company;
using PointOfSale.Forms.Settings.Currency;
using PointOfSale.Forms.Settings.Locations;
using PointOfSale.Forms.Settings.Tax;
using PointOfSale.Helpers;
using PointOfSale.Models;
using PointOfSale.Properties;

namespace PointOfSale.Forms.Invoices
{
    public partial class CreateInvoiceForm : Form
    {
        private readonly PointOfSaleContext _db = new PointOfSaleContext();

        public CreateInvoiceForm(InvoiceType? type = null)
        {
            InitializeComponent();

            cbType.DataSource = Enum.GetValues(typeof(InvoiceType));
            cbType.SelectedItem = type;

            switch (type)
            {
                case InvoiceType.Purchase:
                    cbAccount.DataSource = _db.Accounts.Where(q => q.Name.Equals("Accounts Payable"))
                        .Select(s => new
                        {
                            s.Id,
                            s.Name
                        }).ToList();
                    break;

                case InvoiceType.Sale:
                    cbAccount.DataSource = _db.Accounts.Where(q => q.Name.Equals("Accounts Receivable"))
                        .Select(s => new
                        {
                            s.Id,
                            s.Name
                        }).ToList();
                    break;
            }

            cbAccount.DisplayMember = "Name";
            cbAccount.ValueMember = "Id";
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void CreateInvoiceForm_Load(object sender, EventArgs e)
        {
            for (var i = 0; i < dgvInvoiceItems.ColumnCount; i++)
            {
                dgvInvoiceItems.Columns[i].AutoSizeMode = i == 0
                    ? DataGridViewAutoSizeColumnMode.DisplayedCells
                    : DataGridViewAutoSizeColumnMode.Fill;
            }

            dgvInvoiceItems.Columns[0].Visible = false; // hide the product id column

            //cbType.DataSource = Enum.GetValues(typeof(InvoiceType));

            LoadProducts();
            LoadCurrencies();
            LoadTaxes();
            LoadCompanies();
            LoadLocations();

            if (cbCurrency.SelectedValue != null)
            {
                var currencyId = (int)cbCurrency.SelectedValue;
                UpdateExchangeRate(currencyId);
            }

        }

        private int? GetAccountsReceivable()
        {
            return _db.Accounts.Where(q => q.Name.Equals("Accounts Receivable")).Select(s => s.Id).FirstOrDefault();
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

            products.Insert(0, new { Id = -1, Name = "Choose an item ..." });
            products.Insert(1, new { Id = 0, Name = "+ Add New Item" });

            cbSearch.DataSource = products;
            cbSearch.DisplayMember = "Name";
            cbSearch.ValueMember = "Id";
        }

        private void LoadLocations()
        {
            var locations = _db.Locations.OrderBy(d => d.Name).Select(s => new { s.Id, s.Code }).ToList();
            cbLocation.DataSource = locations;
            cbLocation.DisplayMember = "Code";
            cbLocation.ValueMember = "Id";
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
            var type = cbType.SelectedValue;
            var locationId = cbLocation.SelectedValue.ToInteger();
            var date = dpDate.Value;
            var remarks = rtbRemarks.Text;

            if (locationId < 1) locationId = null;

            var discount = tbDiscount.Text;
            var rate = tbExchangeRate.Text;
            var number = tbInvoiceNumber.Text;
            var paid = cbPaid.Checked;

            var items = dgvInvoiceItems.Rows;

            var invoice = new Invoice
            {
                AccountId = account.ToInteger(),
                TaxId = tax.ToInteger(),
                CompanyId = company.ToInteger(),
                CurrencyId = currency.ToInteger(),
                Discount = discount.ToDecimal(),
                ExchangeRate = rate.ToDecimal(),
                Number = number,
                InvoiceType = type.GetEnumValue<InvoiceType>(),
                LocationId = locationId,
                Paid = paid,
                DateCreated = date,
                Journals = new List<GeneralJournal>(),
                Remarks = remarks
            };

            foreach (DataGridViewRow row in items)
            {
                if (row.IsNewRow) continue; // remove the last row. it is always empty

                var journal = new GeneralJournal
                {
                    CompanyId = invoice.CompanyId,
                    ProductId = row.Cells["ProductId"].Value.ToInteger(),
                    Particulars = row.Cells["Item"].Value.ToString(),
                    Quantity = row.Cells["Quantity"].Value.ToInteger(),
                    Amount = row.Cells["Total"].Value.ToDecimal(),
                    ExchangeRate = invoice.ExchangeRate,
                    DateCreated = date,
                    TaxId = row.Cells["Tax"].Value.ToInteger()
                };

                if ((InvoiceType)type == InvoiceType.Purchase)
                {
                    journal.DebitAccountId = row.Cells["AccountId"].Value?.ToInteger();
                    journal.CreditAccountId = cbAccount.SelectedValue.ToInteger();
                }
                else
                {
                    journal.CreditAccountId = row.Cells["AccountId"].Value?.ToInteger();
                    journal.DebitAccountId = cbAccount.SelectedValue.ToInteger();
                }

                invoice.Journals.Add(journal);
            }

            if (!invoice.Journals.Any())
            {
                MessageBox.Show(Resources.NoInvoiceItems, Resources.Failure, MessageBoxButtons.OK,
                    MessageBoxIcon.Stop);

                return;
            }

            // Add the invoice
            _db.Invoices.Add(invoice);
            _db.SaveChanges(); // save the invoice

            if (cbUpdateStock.Checked)
            {
                int? sourceLocationId = null;
                int? destinationLocationId = null;
                StockCategory stockCategory;

                if (invoice.InvoiceType == InvoiceType.Purchase)
                {
                    destinationLocationId = locationId;
                    stockCategory = StockCategory.In;
                }
                else
                {
                    sourceLocationId = locationId;
                    stockCategory = StockCategory.Out;
                }

                // Update the stock

                var stock = new Models.Stock
                {
                    SourceId = sourceLocationId,
                    DestinationId = destinationLocationId,
                    Category = stockCategory,
                    TenantId = Session.TenantId,
                    DateCreated = invoice.DateCreated,
                    Remarks = null,
                    StockItems = new List<StockItem>()
                };

                var lines = invoice.Journals;
                foreach (var line in lines)
                {
                    var product = _db.Products.Find(line.ProductId);

                    if (product?.ProductType == null ||
                        product.ProductType.Value != ProductType.Stockable) continue;

                    stock.StockItems.Add(new StockItem
                    {
                        Amount = line.Amount,
                        Quantity = line.Quantity,
                        DestinationLocationId = destinationLocationId,
                        SourceLocationId = sourceLocationId,
                        Category = stockCategory,
                        Particulars = line.Particulars,
                        ProductId = line.ProductId,
                        BatchNo = null, // Where does this come from?
                        ExpiryDate = null,
                        ManufactureDate = null,
                        DateCreated = stock.DateCreated
                    });
                }
                _db.Stock.Add(stock);
                _db.SaveChanges();
            }

            if (cbPaid.Checked)
            {
                // Generate receipt or voucher
                if (invoice.InvoiceType == InvoiceType.Sale)
                {
                    var receipt = new Receipt
                    {
                        InvoiceId = invoice.Id,
                        CompanyId = invoice.CompanyId,
                        CurrencyId = invoice.CurrencyId,
                        ExchangeRate = invoice.ExchangeRate,
                        Discount = invoice.Discount,
                        Paid = true,
                        Journals = new List<GeneralJournal>
                        {
                            new GeneralJournal
                            {
                                Amount = tbAmountPaid.Text.ToDecimal(),
                                CreditAccountId = GetAccountsReceivable(),
                                DebitAccountId = GetCashAccount(),
                                Particulars = $"Payment for invoice #{invoice.Id}",
                                Category = JournalCategory.Receipt,
                                // InvoiceId = invoice.Id
                            }
                        }
                    };
                    _db.Receipts.Add(receipt);
                }
                else
                {
                    var voucher = new Models.Voucher
                    {
                        InvoiceId = invoice.Id,
                        CompanyId = invoice.CompanyId,
                        CurrencyId = invoice.CurrencyId,
                        ExchangeRate = invoice.ExchangeRate,
                        Discount = invoice.Discount,
                        Paid = true,
                        Journals = new List<GeneralJournal>
                        {
                            new GeneralJournal
                            {
                                Amount = tbAmountPaid.Text.ToDecimal(),
                                CreditAccountId = GetCashAccount(),
                                DebitAccountId = GetAccountsPayable(),
                                Particulars = $"Payment for invoice #{invoice.Id}",
                                Category = JournalCategory.Voucher,
                                // InvoiceId = invoice.Id
                            }
                        }
                    };
                    _db.Vouchers.Add(voucher);
                }

                _db.SaveChanges();
            }

            Close();
        }

        private void cbSearch_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cbSearch.SelectedValue.ToInteger() < 0) return;
            if (cbSearch.SelectedValue.ToInteger() == 0)
            {
                new AddProductForm().ShowDialog();
            }

            var productId = int.Parse(cbSearch.SelectedValue.ToString());
            var item = _db.Products
                        .Include(p => p.PurchaseAccount)
                        .Include(p => p.SaleAccount)
                        .FirstOrDefault(p => p.Id == productId && p.TenantId == Session.TenantId);

            if (item == null) return;

            // grid
            var gridView = dgvInvoiceItems;

            // grid rows
            var i = gridView.RowCount;

            gridView.Rows.Add();

            var addedRowIndex = i - 1;

            var invoiceType = (InvoiceType)cbType.SelectedItem;

            gridView.Rows[addedRowIndex].Cells["ProductId"].Value = item.Id;
            gridView.Rows[addedRowIndex].Cells["Item"].Value = item.Name;
            gridView.Rows[addedRowIndex].Cells["Quantity"].Value = 1;
            
            switch (invoiceType)
            {
                case InvoiceType.Purchase when item.PurchaseAccountId.HasValue:
                    gridView.Rows[addedRowIndex].Cells["AccountId"].Value = item.PurchaseAccountId.Value;
                    gridView.Rows[addedRowIndex].Cells["Account"].Value = item.PurchaseAccount.Name;
                    break;
                case InvoiceType.Sale when item.SaleAccountId.HasValue:
                    gridView.Rows[addedRowIndex].Cells["Account"].Value = item.SaleAccount.Name;
                    gridView.Rows[addedRowIndex].Cells["AccountId"].Value = item.SaleAccountId.Value;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

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

        private void dgvInvoiceItems_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex <= -1) return;

            var row = e.RowIndex;

            // ProductId = 0, Account = 1, Item = 2, Quantity = 3, UnitPrice = 4, Tax = 5, Total = 6

            if (e.ColumnIndex == 3 || e.ColumnIndex == 4 || e.ColumnIndex == 6)
            {
                var quantity = dgvInvoiceItems.Rows[row].Cells["Quantity"].Value.ToDecimal();
                var price = dgvInvoiceItems.Rows[row].Cells["UnitPrice"].Value.ToDecimal();
                var total = dgvInvoiceItems.Rows[row].Cells["Total"].Value.ToDecimal();

                if (e.ColumnIndex == 6)
                {
                    price = total / (quantity == 0 ? 1 : quantity);
                }
                var amount = quantity * price;

                dgvInvoiceItems.Rows[row].Cells["Quantity"].Value = quantity;
                dgvInvoiceItems.Rows[row].Cells["UnitPrice"].Value = price;
                dgvInvoiceItems.Rows[row].Cells["Total"].Value = amount;

                CalculateTotals();
            }
        }

        private void CalculateTotals()
        {
            decimal total = 0;
            var i = 0;
            var rows = dgvInvoiceItems.Rows;
            foreach (DataGridViewRow row in rows)
            {
                if (row.IsNewRow) continue;
                total += dgvInvoiceItems.Rows[i].Cells["Total"].Value.ToDecimal() ?? 0;
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
            LoadProducts();
            LoadCurrencies();
            LoadTaxes();
            LoadCompanies();
            LoadLocations();
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

        private void cbPaid_CheckedChanged(object sender, EventArgs e)
        {
            var isChecked = ((CheckBox)sender).Checked;
            if (isChecked)
            {
                lbAmountPaid.Visible = tbAmountPaid.Visible = true;
                tbAmountPaid.Text = tbGrandTotal.Text;
            }
            else
            {
                lbAmountPaid.Visible = tbAmountPaid.Visible = false;
                tbAmountPaid.Text = null;
            }
        }

        private void llAddLocation_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new AddLocationForm().ShowDialog();
        }

        private void dgvInvoiceItems_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void lbTotal_Click(object sender, EventArgs e)
        {

        }

        private void tbGrandTotal_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
