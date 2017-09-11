using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PointOfSale.Helpers;
using PointOfSale.Models;

namespace PointOfSale.Forms.Invoices
{
    public partial class CreateInvoiceForm : Form   
    {
        private readonly PointOfSaleContext _db = new PointOfSaleContext();

        public CreateInvoiceForm()
        {
            InitializeComponent();
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


            // Id 0, Name 1, Quantity 2, Price 3, Total 4, ProductId 5

            dgvInvoiceItems.Columns[5].Visible = false; // hide the product id column
            dgvInvoiceItems.Columns[0].ReadOnly = true;
            dgvInvoiceItems.Columns[1].ReadOnly = true;

            cbType.DataSource = Enum.GetValues(typeof(MemoType));
            cbType.SelectedItem = MemoType.Purchase;

            var products = _db.Products.Select(s => new
            {
                Id = s.Id,
                Name = s.Name
            }).ToList();

            products.Insert(0, new { Id = 0, Name = "Choose an item ..." });
            
            cbSearch.DataSource = products;
            cbSearch.DisplayMember = "Name";
            cbSearch.ValueMember = "Id";

            var accounts = _db.Accounts.Select(s => new
            {
                Id = s.Id,
                Name = s.Name
            }).ToList();
            cbAccount.DataSource = accounts;
            cbAccount.DisplayMember = "Name";
            cbAccount.ValueMember = "Id";

            var currencies = _db.Currencies.Select(s => new
            {
                Id = s.Id,
                Code = s.Code
            }).ToList();
            cbCurrency.DataSource = currencies;
            cbCurrency.DisplayMember = "Code";
            cbCurrency.ValueMember = "Id";

            var taxes = _db.Taxes.Select(s => new
            {
                Id = s.Id,
                Name = s.Name
            }).ToList();
            cbTax.DataSource = taxes;
            cbTax.DisplayMember = "Name";
            cbTax.ValueMember = "Id";

            var companies = _db.Companies.OrderBy(d => d.Name).Select(s => new
            {
                Id = s.Id,
                Name = s.Name
            }).ToList();
            cbCompany.DataSource = companies;
            cbCompany.DisplayMember = "Name";
            cbCompany.ValueMember = "Id";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var account = cbAccount.SelectedValue;
            var tax = cbTax.SelectedValue;
            var company = cbCompany.SelectedValue;
            var currency = cbCurrency.SelectedValue;
            var type = cbType.SelectedValue;

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
                InvoiceType = type.GetEnumValue<MemoType>(),
                Paid = paid,
                Journals = new List<GeneralJournal>()
            };
            
            foreach (DataGridViewRow row in items)
            {
                if (row.IsNewRow) continue; // remove the last row. it is always empty

                var journal = new GeneralJournal
                {
                    CompanyId = invoice.CompanyId,
                    ProductId = row.Cells[5].Value.ToInteger(),
                    Particulars = row.Cells[1].Value.ToString(),
                    Quantity = row.Cells[2].Value.ToInteger(),
                    Amount = row.Cells[4].Value.ToDecimal(),
                    ExchangeRate = invoice.ExchangeRate,
                    TaxId = invoice.TaxId
                };

                invoice.Journals.Add(journal);
            }

            // Add the invoice
            _db.Invoices.Add(invoice);

            // Update the stock
            var lines = invoice.Journals;
            foreach (var line in lines)
            {
                var stock = _db.Stock.FirstOrDefault(q => q.Id == line.ProductId);
                if (stock != null && line.ProductId.HasValue && line.Quantity.HasValue)
                {
                    stock.Count = stock.Count - line.Quantity.Value;
                    _db.Entry(stock).State = EntityState.Modified;
                }
            }

            _db.SaveChanges();
        }

        private void cbSearch_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cbSearch.SelectedItem == null) return;

            var productId = int.Parse(cbSearch.SelectedValue.ToString());
            var item = _db.Products.FirstOrDefault(p => p.Id == productId);

            if (item == null) return;

            // grid
            var gridView = dgvInvoiceItems;

            // grid rows
            var i = gridView.RowCount;

            gridView.Rows.Add();

            var addedRowIndex = i - 1;

            // Id 0, Name 1, Quantity 2, Price 3, Total 4, ProductId 5

            gridView.Rows[addedRowIndex].Cells[0].Value = i;
            gridView.Rows[addedRowIndex].Cells[1].Value = item.Name;
            gridView.Rows[addedRowIndex].Cells[2].Value = 1;
            gridView.Rows[addedRowIndex].Cells[3].Value = item.SellPrice;
            gridView.Rows[addedRowIndex].Cells[5].Value = item.Id;

            gridView.CurrentCell = gridView.Rows[addedRowIndex].Cells[2];
            gridView.BeginEdit(true);
        }

        private void dgvInvoiceItems_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex <= -1) return;

            var row = e.RowIndex;

            // Id 0, Name 1, Quantity 2, Price 3, Total 4, ProductId 5

            if (e.ColumnIndex == 2 || e.ColumnIndex == 3 || e.ColumnIndex == 4)
            {
                var quantity = dgvInvoiceItems.Rows[row].Cells[2].Value.ToDecimal();
                var price = dgvInvoiceItems.Rows[row].Cells[3].Value.ToDecimal();
                var total = dgvInvoiceItems.Rows[row].Cells[4].Value.ToDecimal();

                if (e.ColumnIndex == 4)
                {
                    price = total / (quantity == 0 ? 1 : quantity);
                }
                var amount = quantity * price;

                dgvInvoiceItems.Rows[row].Cells[2].Value = quantity;
                dgvInvoiceItems.Rows[row].Cells[3].Value = price;
                dgvInvoiceItems.Rows[row].Cells[4].Value = amount;

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
                total += dgvInvoiceItems.Rows[i].Cells[4].Value.ToDecimal() ?? 0;
                i++;
            }

            tbGrandTotal.Text = total.ToString(CultureInfo.InvariantCulture);
        }
    }
}
