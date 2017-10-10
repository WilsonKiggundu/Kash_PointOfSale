using System;
using System.Windows.Forms;
using PointOfSale.Helpers;
using PointOfSale.Models;

namespace PointOfSale.Forms.Tenants
{
    public partial class TenantCreateForm : Form
    {
        private readonly PointOfSaleContext db = new PointOfSaleContext();
        public TenantCreateForm()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            ofdLogo.ShowDialog();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var name = tbName.Text;
            var category = cbCategory.SelectedItem;
            var email = tbEmail.Text;
            var telephone = tbTelephone.Text;
            var address = rtAddress.Text;
            var postalAddress = rtPostalAddress.Text;
            var date = dpPaymentDate.Value;
            var active = cbActive.Checked;

            var tenant = new Tenant
            {
                Name = name,
                Active = active,
                Address = address,
                PostalAddress = postalAddress,
                LastPaymentDate = date,
                Telephone = telephone,
                Email = email,
                Category = category.GetEnumValue<TenantCategory>()
            };

            db.Tenants.Add(tenant);
            db.SaveChanges();
        }

        private void TenantCreateForm_Load(object sender, EventArgs e)
        {
            var categories = Enum.GetValues(typeof(TenantCategory));
            cbCategory.DataSource = categories;
        }
    }
}
