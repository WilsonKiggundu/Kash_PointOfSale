using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PointOfSale.Forms.Products
{
    public partial class ProductsListForm : Form
    {
        public ProductsListForm()
        {
            InitializeComponent();
        }

        private void ProductsListForm_Load(object sender, EventArgs e)
        {
            using (var db = new PointOfSaleContext())
            {
                dgvProducts.DataSource = db.Products.OrderBy(q => q.Name).ToList();
                dgvProducts.ClearSelection();
            }
        }
    }
}
