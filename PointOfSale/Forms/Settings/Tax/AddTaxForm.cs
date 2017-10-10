using System;
using System.Windows.Forms;
using PointOfSale.Helpers;

namespace PointOfSale.Forms.Settings.Tax
{
    public partial class AddTaxForm : Form
    {
        private readonly PointOfSaleContext _db = new PointOfSaleContext();
        public AddTaxForm()
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
            var percentage = tbPercentage.Text;

            var tax = new Models.Tax
            {
                Name = name,
                Percentage = percentage.ToDecimal()
            };

            _db.Taxes.Add(tax);
            _db.SaveChanges();

            Close();
        }
    }
}
