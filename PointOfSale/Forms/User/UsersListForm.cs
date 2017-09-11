using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PointOfSale.Forms.User
{
    public partial class UsersListForm : Form   
    {
        private readonly PointOfSaleContext _context = new PointOfSaleContext();
        public UsersListForm()
        {
            InitializeComponent();
        }

        private void UsersListForm_Load(object sender, EventArgs e)
        {
            var users = _context.TenantUsers.Include(q => q.User).Include(q => q.Tenant)
                .OrderBy(q => q.User.FirstName)
                .ThenBy(q => q.User.LastName)
                .Select(s => new
                {
                    // Id = s.Id,
                    Tenant = s.Tenant.Name,
                    FirstName = s.User.FirstName,
                    LastName = s.User.LastName,
                    Username = s.User.Username,
                    LastLoggedIn = s.User.LastLoggedIn
                }).ToList();

            dgvUsers.DataSource = users;

            for (var i = 0; i < dgvUsers.ColumnCount; i++)
            {
                dgvUsers.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            dgvUsers.Columns[0].Visible = false;
        }
    }
}
