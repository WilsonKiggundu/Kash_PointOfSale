using System;
using System.Windows.Forms;
using PointOfSale.Models;

namespace PointOfSale.Forms.Settings.Locations
{
    public partial class AddLocationForm : Form
    {
        public AddLocationForm()
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
            var code = tbCode.Text;

            using (var db = new PointOfSaleContext())
            {
                db.Locations.Add(new Location
                {
                    Name = name,
                    Code = code
                });
                db.SaveChanges();
            }
            Close();
        }
    }
}
