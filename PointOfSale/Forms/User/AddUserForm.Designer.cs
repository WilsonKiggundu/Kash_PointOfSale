namespace PointOfSale.Forms.User
{
    partial class AddUserForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lbFirstName = new System.Windows.Forms.Label();
            this.tbFirstName = new System.Windows.Forms.TextBox();
            this.tbPassword = new System.Windows.Forms.TextBox();
            this.lbPassword = new System.Windows.Forms.Label();
            this.tbUsername = new System.Windows.Forms.TextBox();
            this.lnUsername = new System.Windows.Forms.Label();
            this.tbLastName = new System.Windows.Forms.TextBox();
            this.lbLastName = new System.Windows.Forms.Label();
            this.tbConfirmPassword = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvAccessRights = new System.Windows.Forms.DataGridView();
            this.tcRegister = new System.Windows.Forms.TabControl();
            this.tpDetails = new System.Windows.Forms.TabPage();
            this.cbTenant = new System.Windows.Forms.ComboBox();
            this.lbTenant = new System.Windows.Forms.Label();
            this.tpAccessRights = new System.Windows.Forms.TabPage();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAccessRights)).BeginInit();
            this.tcRegister.SuspendLayout();
            this.tpDetails.SuspendLayout();
            this.tpAccessRights.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // lbFirstName
            // 
            this.lbFirstName.Location = new System.Drawing.Point(165, 70);
            this.lbFirstName.Name = "lbFirstName";
            this.lbFirstName.Size = new System.Drawing.Size(200, 20);
            this.lbFirstName.TabIndex = 0;
            this.lbFirstName.Text = "First Name";
            this.lbFirstName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tbFirstName
            // 
            this.tbFirstName.Location = new System.Drawing.Point(371, 67);
            this.tbFirstName.Name = "tbFirstName";
            this.tbFirstName.Size = new System.Drawing.Size(277, 27);
            this.tbFirstName.TabIndex = 1;
            this.tbFirstName.CausesValidationChanged += new System.EventHandler(this.btnSave_Click);
            this.tbFirstName.Validating += new System.ComponentModel.CancelEventHandler(this.tbFirstName_Validating);
            // 
            // tbPassword
            // 
            this.tbPassword.Location = new System.Drawing.Point(371, 166);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.PasswordChar = '*';
            this.tbPassword.Size = new System.Drawing.Size(277, 27);
            this.tbPassword.TabIndex = 4;
            this.tbPassword.CausesValidationChanged += new System.EventHandler(this.btnSave_Click);
            this.tbPassword.Validating += new System.ComponentModel.CancelEventHandler(this.tbPassword_Validating);
            // 
            // lbPassword
            // 
            this.lbPassword.Location = new System.Drawing.Point(165, 169);
            this.lbPassword.Name = "lbPassword";
            this.lbPassword.Size = new System.Drawing.Size(200, 20);
            this.lbPassword.TabIndex = 12;
            this.lbPassword.Text = "Password";
            this.lbPassword.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tbUsername
            // 
            this.tbUsername.Location = new System.Drawing.Point(371, 133);
            this.tbUsername.Name = "tbUsername";
            this.tbUsername.Size = new System.Drawing.Size(277, 27);
            this.tbUsername.TabIndex = 3;
            this.tbUsername.CausesValidationChanged += new System.EventHandler(this.btnSave_Click);
            this.tbUsername.Validating += new System.ComponentModel.CancelEventHandler(this.tbUsername_Validating);
            // 
            // lnUsername
            // 
            this.lnUsername.Location = new System.Drawing.Point(165, 136);
            this.lnUsername.Name = "lnUsername";
            this.lnUsername.Size = new System.Drawing.Size(200, 20);
            this.lnUsername.TabIndex = 14;
            this.lnUsername.Text = "Username";
            this.lnUsername.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tbLastName
            // 
            this.tbLastName.Location = new System.Drawing.Point(371, 100);
            this.tbLastName.Name = "tbLastName";
            this.tbLastName.Size = new System.Drawing.Size(277, 27);
            this.tbLastName.TabIndex = 2;
            this.tbLastName.CausesValidationChanged += new System.EventHandler(this.btnSave_Click);
            this.tbLastName.Validating += new System.ComponentModel.CancelEventHandler(this.tbLastName_Validating);
            // 
            // lbLastName
            // 
            this.lbLastName.Location = new System.Drawing.Point(165, 103);
            this.lbLastName.Name = "lbLastName";
            this.lbLastName.Size = new System.Drawing.Size(200, 20);
            this.lbLastName.TabIndex = 16;
            this.lbLastName.Text = "Last Name";
            this.lbLastName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tbConfirmPassword
            // 
            this.tbConfirmPassword.Location = new System.Drawing.Point(371, 199);
            this.tbConfirmPassword.Name = "tbConfirmPassword";
            this.tbConfirmPassword.PasswordChar = '*';
            this.tbConfirmPassword.Size = new System.Drawing.Size(277, 27);
            this.tbConfirmPassword.TabIndex = 5;
            this.tbConfirmPassword.CausesValidationChanged += new System.EventHandler(this.btnSave_Click);
            this.tbConfirmPassword.Validating += new System.ComponentModel.CancelEventHandler(this.tbConfirmPassword_Validating);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(165, 202);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(200, 20);
            this.label1.TabIndex = 18;
            this.label1.Text = "Confirm Password";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dgvAccessRights
            // 
            this.dgvAccessRights.AllowUserToAddRows = false;
            this.dgvAccessRights.AllowUserToDeleteRows = false;
            this.dgvAccessRights.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgvAccessRights.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvAccessRights.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAccessRights.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvAccessRights.GridColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dgvAccessRights.Location = new System.Drawing.Point(3, 3);
            this.dgvAccessRights.Name = "dgvAccessRights";
            this.dgvAccessRights.ReadOnly = true;
            this.dgvAccessRights.RowTemplate.Height = 24;
            this.dgvAccessRights.Size = new System.Drawing.Size(841, 288);
            this.dgvAccessRights.TabIndex = 21;
            // 
            // tcRegister
            // 
            this.tcRegister.Controls.Add(this.tpDetails);
            this.tcRegister.Controls.Add(this.tpAccessRights);
            this.tcRegister.Location = new System.Drawing.Point(12, 12);
            this.tcRegister.Name = "tcRegister";
            this.tcRegister.SelectedIndex = 0;
            this.tcRegister.Size = new System.Drawing.Size(855, 295);
            this.tcRegister.TabIndex = 22;
            // 
            // tpDetails
            // 
            this.tpDetails.BackColor = System.Drawing.SystemColors.Control;
            this.tpDetails.Controls.Add(this.cbTenant);
            this.tpDetails.Controls.Add(this.lbTenant);
            this.tpDetails.Controls.Add(this.tbLastName);
            this.tpDetails.Controls.Add(this.lbFirstName);
            this.tpDetails.Controls.Add(this.tbFirstName);
            this.tpDetails.Controls.Add(this.tbConfirmPassword);
            this.tpDetails.Controls.Add(this.lbPassword);
            this.tpDetails.Controls.Add(this.label1);
            this.tpDetails.Controls.Add(this.tbPassword);
            this.tpDetails.Controls.Add(this.lnUsername);
            this.tpDetails.Controls.Add(this.lbLastName);
            this.tpDetails.Controls.Add(this.tbUsername);
            this.tpDetails.Location = new System.Drawing.Point(4, 29);
            this.tpDetails.Name = "tpDetails";
            this.tpDetails.Padding = new System.Windows.Forms.Padding(3);
            this.tpDetails.Size = new System.Drawing.Size(847, 262);
            this.tpDetails.TabIndex = 0;
            this.tpDetails.Text = "User Details";
            this.tpDetails.Click += new System.EventHandler(this.tpDetails_Click);
            // 
            // cbTenant
            // 
            this.cbTenant.FormattingEnabled = true;
            this.cbTenant.Location = new System.Drawing.Point(371, 33);
            this.cbTenant.Name = "cbTenant";
            this.cbTenant.Size = new System.Drawing.Size(277, 28);
            this.cbTenant.TabIndex = 0;
            this.cbTenant.TabStop = false;
            // 
            // lbTenant
            // 
            this.lbTenant.Location = new System.Drawing.Point(165, 36);
            this.lbTenant.Name = "lbTenant";
            this.lbTenant.Size = new System.Drawing.Size(200, 20);
            this.lbTenant.TabIndex = 19;
            this.lbTenant.Text = "Tenant";
            this.lbTenant.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tpAccessRights
            // 
            this.tpAccessRights.Controls.Add(this.dgvAccessRights);
            this.tpAccessRights.Location = new System.Drawing.Point(4, 29);
            this.tpAccessRights.Name = "tpAccessRights";
            this.tpAccessRights.Padding = new System.Windows.Forms.Padding(3);
            this.tpAccessRights.Size = new System.Drawing.Size(847, 294);
            this.tpAccessRights.TabIndex = 1;
            this.tpAccessRights.Text = "Access Rights";
            this.tpAccessRights.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.SteelBlue;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(386, 318);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(105, 40);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "Next >";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(512, 318);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(105, 40);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // AddUserForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(879, 371);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.tcRegister);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddUserForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add New User";
            this.Load += new System.EventHandler(this.Register_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAccessRights)).EndInit();
            this.tcRegister.ResumeLayout(false);
            this.tpDetails.ResumeLayout(false);
            this.tpDetails.PerformLayout();
            this.tpAccessRights.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbFirstName;
        private System.Windows.Forms.TextBox tbFirstName;
        private System.Windows.Forms.TextBox tbPassword;
        private System.Windows.Forms.Label lbPassword;
        private System.Windows.Forms.TextBox tbUsername;
        private System.Windows.Forms.Label lnUsername;
        private System.Windows.Forms.TextBox tbLastName;
        private System.Windows.Forms.Label lbLastName;
        private System.Windows.Forms.TextBox tbConfirmPassword;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvAccessRights;
        private System.Windows.Forms.TabControl tcRegister;
        private System.Windows.Forms.TabPage tpDetails;
        private System.Windows.Forms.TabPage tpAccessRights;
        private System.Windows.Forms.Button btnCancel;
        public System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.ComboBox cbTenant;
        private System.Windows.Forms.Label lbTenant;
    }
}