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
using PointOfSale.Helpers;

namespace PointOfSale.Forms.Stock
{
    public partial class AddStockForm : Form
    {
        private readonly PointOfSaleContext _db = new PointOfSaleContext();
        public AddStockForm()
        {
            InitializeComponent();
        }

        private void AddStockForm_Load(object sender, EventArgs e)
        {
            var products = _db.Products.Where(q => !q.IsDeleted && q.TenantId == Session.TenantId)
                                .OrderBy(q => q.Name)
                                .ToList();

            cbProduct.DataSource = products;
            cbProduct.DisplayMember = "Name";
            cbProduct.ValueMember = "Id";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var productId = (int)cbProduct.SelectedValue;
            var quantity = tbQuantity.Text;
            var costPrice = tbCostPrice.Text;
            var sellPrice = tbSellPrice.Text;

            var stock = _db.Stock.FirstOrDefault(q => q.Id == productId && q.TenantId == Session.TenantId);
            if (stock != null)
            {
                stock.Count += quantity.ToDecimal() ?? 0;
                _db.Entry(stock).State = EntityState.Modified;
            }
            else
            {
                _db.Stock.Add(new Models.Stock
                {
                    Id = productId,
                    Count = quantity.ToDecimal() ?? 0,
                    TenantId = Session.TenantId
                });
            }

            // update the product cost/sell price
            var product = _db.Products.First(p => p.Id == productId);
            product.CostPrice = costPrice.ToDecimal();
            product.SellPrice = sellPrice.ToDecimal();
            _db.Entry(product).State = EntityState.Modified;

            _db.SaveChanges();
        }

        private void cbProduct_SelectionChangeCommitted(object sender, EventArgs e)
        {
            var id = cbProduct.SelectedValue.ToInteger();
            if (id.HasValue)
            {
                var product = _db.Products.First(q => q.Id == id);
                tbSellPrice.Text = product.SellPrice.ToString();
                tbCostPrice.Text = product.CostPrice.ToString();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
