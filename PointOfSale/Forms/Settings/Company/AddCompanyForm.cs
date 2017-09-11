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

namespace PointOfSale.Forms.Settings.Company
{
    public partial class AddCompanyForm : Form
    {
        private readonly PointOfSaleContext _db = new PointOfSaleContext();
        public AddCompanyForm()
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
            var currency = cbCurrency.SelectedValue;
            var email = tbEmail.Text;
            var telephone = tbTelephone.Text;
            var address = rtAddress.Text;

            var company = new Models.Company
            {
                Name = name,
                Address = address,
                Telephone = telephone,
                Email = email,
                CurrencyId = currency.ToInteger()
            };

            _db.Companies.Add(company);
            _db.SaveChanges();
        }

        private void AddCompanyForm_Load(object sender, EventArgs e)
        {
            var currencies = _db.Currencies.OrderBy(d => d.Code).Select(s => new {Id = s.Id, Code = s.Code}).ToList();
            cbCurrency.DataSource = currencies;
            cbCurrency.DisplayMember = "Code";
            cbCurrency.ValueMember = "Id";
        }
    }
}
