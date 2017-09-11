using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PointOfSale.Helpers;
using PointOfSale.Models;

namespace PointOfSale.Forms.Products
{
    public partial class AddProductForm : Form
    {
        private readonly PointOfSaleContext context = new PointOfSaleContext();
        public AddProductForm()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var name = tbName.Text;
            var type = cbType.SelectedItem;
            var code = tbCode.Text;
            var barcode = tbBarcode.Text;
            var costPrice = tbCostPrice.Text;
            var sellPrice = tbSellPrice.Text;
            var minStock = tbMinStock.Text;
            var maxStock = tbMaxStock.Text;
            var openingStock = tbOpeningStock.Text;
            var sale = cbSale.Checked;
            var purchase = cbPurchase.Checked;
            var purchaseAccount = cbPurchaseAccount.SelectedValue;
            var saleAccount = cbSaleAccount.SelectedValue;
            
            context.Products.Add(new Product
            {
                Name = name,
                Barcode = barcode,
                Code = code,
                CostPrice = costPrice.ToDecimal(),
                SellPrice = sellPrice.ToDecimal(),
                MaxStock = maxStock.ToDecimal(),
                MinStock = minStock.ToDecimal(),
                OpeningStock = openingStock.ToDecimal() ?? 0,
                ProductType = type.GetEnumValue<ProductType>(),
                Purchase = purchase,
                PurchaseAccountId = purchaseAccount.ToInteger(),
                SaleAccountId = saleAccount.ToInteger(),
                Sale = sale,
                Stock = new Models.Stock
                {
                    Count = openingStock.ToDecimal() ?? 0
                }
            });

            context.SaveChanges();
        }

        private void AddProductForm_Load(object sender, EventArgs e)
        {
            cbType.DataSource = Enum.GetValues(typeof(ProductType));
        }

        private void cbPurchase_CheckedChanged(object sender, EventArgs e)
        {
            cbPurchaseAccount.Enabled = ((CheckBox) sender).Checked;
            if (cbPurchaseAccount.Enabled)
            {
                var accounts = context.Accounts.OrderBy(d => d.Name).Select(s => new
                {
                    Id = s.Id,
                    Name = s.Name
                }).ToList();

                cbPurchaseAccount.DataSource = accounts;
                cbPurchaseAccount.DisplayMember = "Name";
                cbPurchaseAccount.ValueMember = "Id";
            }
        }

        private void cbSale_CheckedChanged(object sender, EventArgs e)
        {
            cbSaleAccount.Enabled = ((CheckBox)sender).Checked;
            if (cbSaleAccount.Enabled)
            {
                var accounts = context.Accounts.OrderBy(d => d.Name).Select(s => new
                {
                    Id = s.Id,
                    Name = s.Name
                }).ToList();

                cbSaleAccount.DataSource = accounts;
                cbSaleAccount.DisplayMember = "Name";
                cbSaleAccount.ValueMember = "Id";
            }

        }
    }
}
