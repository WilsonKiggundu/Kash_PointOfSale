using System;
using System.Linq;
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
            var currency = cbCurrency.SelectedValue.ToInteger();
            var email = tbEmail.Text;
            var telephone = tbTelephone.Text;
            var address = rtAddress.Text;

            if(string.IsNullOrEmpty(name)) return;

            var company = new Models.Company
            {
                Name = name,
                Address = address,
                Telephone = telephone,
                Email = email,
                CurrencyId = currency < 1 ? null : currency
            };

            _db.Companies.Add(company);
            _db.SaveChanges();

            Close();
        }

        private void AddCompanyForm_Load(object sender, EventArgs e)
        {
            var currencies = _db.Currencies.OrderBy(d => d.Code).Select(s => new {s.Id, s.Code}).ToList();

            currencies.Insert(0, new {Id = 0, Code = "--Select Currency--"});

            cbCurrency.DataSource = currencies;
            cbCurrency.DisplayMember = "Code";
            cbCurrency.ValueMember = "Id";
        }
    }
}
