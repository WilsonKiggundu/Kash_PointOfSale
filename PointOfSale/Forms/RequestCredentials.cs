using System;
using System.Linq;
using System.Windows.Forms;
using PointOfSale.Api;
using PointOfSale.Models;
using PointOfSale.Properties;

namespace PointOfSale.Forms
{
    public partial class RequestCredentials : Form
    {
        private readonly string _category;
        private readonly SyncAction _action;
        private readonly PointOfSaleContext _db;
        public RequestCredentials(string category = "tenant", SyncAction action = SyncAction.Download)
        {
            _db = new PointOfSaleContext();
            _category = category;
            _action = action;
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnContinue_Click(object sender, EventArgs e)
        {
            // The username and password must be provided
            if (string.IsNullOrEmpty(tbEmail.Text))
            {
                MessageBox.Show(Resources.Provide_Username, Resources.AuthError, MessageBoxButtons.OK);
                tbEmail.Focus();
            }
            else if (string.IsNullOrEmpty(tbPassword.Text))
            {
                MessageBox.Show(Resources.Provide_Password, Resources.AuthError, MessageBoxButtons.OK);
                tbPassword.Focus();
            }
            else
            {
                bool result;
                var fetchData = new FetchData(tbEmail.Text, tbPassword.Text);
                var uploadData = new UploadData(tbEmail.Text, tbPassword.Text);
                switch (_category)
                {
                    case "invoice":
                        switch (_action)
                        {
                            case SyncAction.Upload:
                                result = uploadData.Invoices();
                                if (result)
                                {
                                    MessageBox.Show(Resources.InvoicesDownloadedSuccessfully, Resources.Success, MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                                    Hide();
                                }
                                break;
                        }

                        break;

                    case "reciept":
                        switch (_action)
                        {
                            case SyncAction.Upload:
                                result = uploadData.Reciepts();
                                if (result)
                                {
                                    MessageBox.Show(Resources.ReceiptsUploadedSuccessfully, Resources.Success, MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                                    Hide();
                                }
                                break;
                        }

                        break;

                    case "voucher":
                        switch (_action)
                        {
                            case SyncAction.Upload:
                                result = uploadData.Vouchers();
                                if (result)
                                {
                                    MessageBox.Show(Resources.VoucherUploadedSuccessfully, Resources.Success, MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                                    Hide();
                                }
                                break;
                        }

                        break;

                    case "tenant":
                        // Fetch Tenants
                        switch (_action)
                        {
                            case SyncAction.Download:
                                var tenants = fetchData.Tenants().Select(s => new Tenant
                                {
                                    Name = s.Name,
                                    Active = true,
                                    Address = s.Address,
                                    Category = TenantCategory.General,
                                    Email = s.Email,
                                    WebId = s.Id,
                                    Telephone = s.Telephone,
                                    Tin = s.Tin
                                }).ToList();

                                if (tenants.Any())
                                {
                                    _db.Tenants.AddRange(tenants);
                                    _db.SaveChanges();
                                }
                                else
                                {
                                    MessageBox.Show(
                                        Resources.InvalidCredentials,
                                        Resources.AuthFailure, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                break;

                            case SyncAction.Upload:
                                break;
                        }

                        break;

                    case "product":
                        // Fetch Products
                        result = fetchData.Products();
                        if (result)
                        {
                            MessageBox.Show(Resources.PorductsUpdated, Resources.Success, MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                            Hide();
                        }
                        else
                        {
                            MessageBox.Show(Resources.ProductsNotUpdated, Resources.Error, MessageBoxButtons.OK,
                                MessageBoxIcon.Stop);
                        }
                        break;
                    case "company":
                        // Fetch Companies
                        result = fetchData.Companies();
                        if (result)
                        {
                            MessageBox.Show(Resources.CompaniesUpdated, Resources.Success, MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                            Hide();
                        }
                        else
                        {
                            MessageBox.Show(Resources.CompaniesNotUpdated, Resources.Error, MessageBoxButtons.OK,
                                MessageBoxIcon.Stop);
                        }
                        break;
                    case "location":
                        // Fetch Products
                        result = fetchData.Locations();
                        if (result)
                        {
                            MessageBox.Show(Resources.LocationsUpdated, Resources.Success, MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                            Hide();
                        }
                        else
                        {
                            MessageBox.Show(Resources.LocationsNotUpdated, Resources.Error, MessageBoxButtons.OK,
                                MessageBoxIcon.Stop);
                        }
                        break;
                }
            }
        }
    }
}
