using System;
using System.Linq;
using System.Windows.Forms;
using PointOfSale.Helpers;
using PointOfSale.Models;
using PointOfSale.Properties;

namespace PointOfSale.Forms.Products
{
    public partial class AddProductForm : Form
    {
        private readonly PointOfSaleContext context = new PointOfSaleContext();
        public AddProductForm()
        {
            InitializeComponent();

            var accounts = context.Accounts.OrderBy(d => d.Name).Select(s => new
            {
                Id = s.Id,
                Name = s.Name
            }).ToList();

            accounts.Insert(0, new {Id = 0, Name = "--Select Account--"});

            cbSaleAccount.DataSource = new BindingSource(accounts, null);
            cbSaleAccount.DisplayMember = "Name";
            cbSaleAccount.ValueMember = "Id";

            cbPurchaseAccount.DataSource = new BindingSource(accounts, null);
            cbPurchaseAccount.DisplayMember = "Name";
            cbPurchaseAccount.ValueMember = "Id";
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
            var purchaseAccount = cbPurchaseAccount.SelectedValue.ToInteger();
            var saleAccount = cbSaleAccount.SelectedValue.ToInteger();

            var product = new Product
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
                Sale = sale
            };

            if (purchase && purchaseAccount < 1)
            {
                product.PurchaseAccount = new Account
                {
                    Category = AccountCategory.Expense,
                    Name = $"{product.Name} (Purchase)",
                    CashflowCategory = CashflowCategory.Operating,
                    Budget = true
                };
            }

            if (sale && saleAccount < 1)
            {
                product.SaleAccount = new Account
                {
                    Category = AccountCategory.Expense,
                    Name = $"{product.Name} (Revenue)",
                    CashflowCategory = CashflowCategory.Operating,
                    Budget = true
                };
            }

            context.Products.Add(product);
            context.SaveChanges();

            Close();
        }

        private void AddProductForm_Load(object sender, EventArgs e)
        {
            cbType.DataSource = Enum.GetValues(typeof(ProductType));
        }

        private void cbPurchase_CheckedChanged(object sender, EventArgs e)
        {
           
        }

        private void cbSale_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void cbPurchaseAccount_MouseClick(object sender, MouseEventArgs e)
        {

        }
    }
}
