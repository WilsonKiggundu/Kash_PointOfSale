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

namespace PointOfSale.Forms.Settings.Currency
{
    public partial class AddCurrencyForm : Form
    {
        public AddCurrencyForm()
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
            var rate = tbRate.Text.ToDecimal();

            using (var db = new PointOfSaleContext())
            {
                db.Currencies.Add(new Models.Currency
                {
                    Name = name,
                    Code = code,
                    Rate = rate
                });
                db.SaveChanges();
            }
        }
    }
}
