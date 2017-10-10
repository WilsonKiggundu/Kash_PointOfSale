using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using PointOfSale.Helpers;
using PointOfSale.Models;
using PointOfSale.Properties;
using PointOfSale.ViewModels;

namespace PointOfSale.Forms.User
{
    public partial class AddUserForm : Form
    {
        private readonly PointOfSaleContext _db;
        public AddUserForm()
        {
            _db = new PointOfSaleContext();
            InitializeComponent();
        }

        private void Register_Load(object sender, EventArgs e)
        {
            var tenants = _db.Tenants.OrderBy(q => q.Name).Select(s => new
            {
                s.Id,
                s.Name
            }).ToList();

            // tenants.Insert(0, new {Id = 0, Name = "--Select Tenant--"});

            cbTenant.DataSource = tenants;
            cbTenant.DisplayMember = "Name";
            cbTenant.ValueMember = "Id";

            var accessRights = _db.AccessRights.OrderBy(d => d.Id).Select(s => new AccessRightsViewModel
            {
                Id = s.Id,
                RoleName = s.Name,
                Description = s.Description
            }).ToList();

            dgvAccessRights.DataSource = accessRights;

            dgvAccessRights.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvAccessRights.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvAccessRights.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dgvAccessRights.Columns[0].Visible = false;

            btnSave.Text = tcRegister.SelectedTab == tpDetails ? "& Next >" : Resources.Save;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var password = tbPassword.Text;
            var confPassword = tbConfirmPassword.Text;

            if (tcRegister.SelectedTab == tpDetails)
            {
                var comparer = StringComparer.Ordinal;
                if (0 != comparer.Compare(password, confPassword))
                {
                    // Passwords don't match

                    MessageBox.Show("Passwords don't match", "Password Mismatch", MessageBoxButtons.OK,
                        MessageBoxIcon.Stop);
                }
                else
                {
                    tcRegister.SelectTab(tpAccessRights);
                    btnSave.Text = Resources.Save;
                }
            }
            else
            {

                var user = new Models.User
                {
                    FirstName = tbFirstName.Text,
                    LastName = tbLastName.Text,
                    Password = Encryption.GetMd5Hash(password),
                    Username = tbUsername.Text,
                    LastLoggedIn = null,
                    UserAccessRights = new List<UserAccessRight>()
                };

                var tenantUser = new TenantUser
                {
                    TenantId = cbTenant.SelectedValue.ToInteger() ?? 0,
                    User = user
                };

                var selectedRights = dgvAccessRights.SelectedRows;
                foreach (DataGridViewRow role in selectedRights)
                {
                    user.UserAccessRights.Add(new UserAccessRight
                    {
                        AccessRightId = Convert.ToInt32(role.Cells[0].Value)
                    });
                }

                _db.TenantUsers.Add(tenantUser);
                try
                {
                    _db.SaveChanges();
                    var dialogResult = MessageBox.Show(Resources.UserReg_SuccessMessage,
                        Resources.RegisterUser, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (dialogResult == DialogResult.Yes)
                    {
                        tcRegister.SelectedTab = tpDetails;
                        tbFirstName.Text = null;
                        tbLastName.Text = null;
                        tbConfirmPassword.Text = null;
                        tbPassword.Text = null;
                        tbUsername.Text = null;

                        dgvAccessRights.ClearSelection();
                    }
                    else
                    {
                        Close();
                    }
                }
                catch (Exception exception)
                {
                    MessageBox.Show(Resources.InternalServerError,
                        Resources.RegisterUser, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        private void tbFirstName_Validating(object sender, CancelEventArgs e)
        {
            // First name is required
            if (tbFirstName.Text.Trim() == "")
            {
                errorProvider.SetError(tbFirstName, "First name is required");
                return;
            }

            errorProvider.SetError(tbFirstName, "");
        }

        private void tbLastName_Validating(object sender, CancelEventArgs e)
        {
            if (tbLastName.Text.Trim() == "")
            {
                errorProvider.SetError(tbLastName, "Last name is required");
                return;
            }

            errorProvider.SetError(tbLastName, "");
        }

        private void tbUsername_Validating(object sender, CancelEventArgs e)
        {
            if (tbUsername.Text.Trim() == "")
            {
                errorProvider.SetError(tbUsername, "Username is required");
                return;
            }

            errorProvider.SetError(tbUsername, "");
        }

        private void tbPassword_Validating(object sender, CancelEventArgs e)
        {
            if (tbPassword.Text.Trim() == "")
            {
                errorProvider.SetError(tbPassword, "Password is required");
                return;
            }

            errorProvider.SetError(tbPassword, "");
        }

        private void tbConfirmPassword_Validating(object sender, CancelEventArgs e)
        {
            var comparer = StringComparer.Ordinal;
            if (0 != comparer.Compare(tbPassword.Text, tbConfirmPassword.Text))
            {
                errorProvider.SetError(tbConfirmPassword, "Passwords don't match");
                return;
            }

            errorProvider.SetError(tbPassword, "");
        }

        private void tpDetails_Click(object sender, EventArgs e)
        {

        }
    }
}
