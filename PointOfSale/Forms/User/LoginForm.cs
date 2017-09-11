using System;
using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;
using PointOfSale.Helpers;

namespace PointOfSale.Forms.User
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            var username = tbUsername.Text;
            var password = tbPassword.Text;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please provide your username and password", "Authentication Failed",
                    MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            else
            {
                using (var db = new PointOfSaleContext())
                {
                    password = Encryption.GetMd5Hash(password);
                    var user = db.TenantUsers.Include(q => q.User)
                        .FirstOrDefault(q => q.User.Username == username && q.User.Password == password);

                    if (user == null)
                    {
                        MessageBox.Show("Invalid username and/or password", "Authentication Failed",
                            MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                    else
                    {
                        this.Hide();

                        Session.TenantId = user.TenantId;
                        Session.UserId = user.UserId;

                        // Open the main form
                        new MainForm().Show();
                    }

                }
            }
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            ActiveControl = tbUsername;
        }
    }
}
