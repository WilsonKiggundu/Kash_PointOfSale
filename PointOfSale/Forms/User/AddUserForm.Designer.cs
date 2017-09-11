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
            this.tpAccessRights = new System.Windows.Forms.TabPage();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.panelHeader = new System.Windows.Forms.Panel();
            this.lbTitle = new System.Windows.Forms.Label();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.lbTenant = new System.Windows.Forms.Label();
            this.cbTenant = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAccessRights)).BeginInit();
            this.tcRegister.SuspendLayout();
            this.tpDetails.SuspendLayout();
            this.tpAccessRights.SuspendLayout();
            this.panelHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // lbFirstName
            // 
            this.lbFirstName.AutoSize = true;
            this.lbFirstName.Location = new System.Drawing.Point(250, 76);
            this.lbFirstName.Name = "lbFirstName";
            this.lbFirstName.Size = new System.Drawing.Size(92, 20);
            this.lbFirstName.TabIndex = 0;
            this.lbFirstName.Text = "First Name";
            // 
            // tbFirstName
            // 
            this.tbFirstName.Location = new System.Drawing.Point(371, 73);
            this.tbFirstName.Name = "tbFirstName";
            this.tbFirstName.Size = new System.Drawing.Size(277, 27);
            this.tbFirstName.TabIndex = 1;
            this.tbFirstName.CausesValidationChanged += new System.EventHandler(this.btnSave_Click);
            this.tbFirstName.Validating += new System.ComponentModel.CancelEventHandler(this.tbFirstName_Validating);
            // 
            // tbPassword
            // 
            this.tbPassword.Location = new System.Drawing.Point(371, 198);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.PasswordChar = '*';
            this.tbPassword.Size = new System.Drawing.Size(277, 27);
            this.tbPassword.TabIndex = 4;
            this.tbPassword.CausesValidationChanged += new System.EventHandler(this.btnSave_Click);
            this.tbPassword.Validating += new System.ComponentModel.CancelEventHandler(this.tbPassword_Validating);
            // 
            // lbPassword
            // 
            this.lbPassword.AutoSize = true;
            this.lbPassword.Location = new System.Drawing.Point(259, 201);
            this.lbPassword.Name = "lbPassword";
            this.lbPassword.Size = new System.Drawing.Size(83, 20);
            this.lbPassword.TabIndex = 12;
            this.lbPassword.Text = "Password";
            // 
            // tbUsername
            // 
            this.tbUsername.Location = new System.Drawing.Point(371, 155);
            this.tbUsername.Name = "tbUsername";
            this.tbUsername.Size = new System.Drawing.Size(277, 27);
            this.tbUsername.TabIndex = 3;
            this.tbUsername.CausesValidationChanged += new System.EventHandler(this.btnSave_Click);
            this.tbUsername.Validating += new System.ComponentModel.CancelEventHandler(this.tbUsername_Validating);
            // 
            // lnUsername
            // 
            this.lnUsername.AutoSize = true;
            this.lnUsername.Location = new System.Drawing.Point(256, 158);
            this.lnUsername.Name = "lnUsername";
            this.lnUsername.Size = new System.Drawing.Size(86, 20);
            this.lnUsername.TabIndex = 14;
            this.lnUsername.Text = "Username";
            // 
            // tbLastName
            // 
            this.tbLastName.Location = new System.Drawing.Point(371, 114);
            this.tbLastName.Name = "tbLastName";
            this.tbLastName.Size = new System.Drawing.Size(277, 27);
            this.tbLastName.TabIndex = 2;
            this.tbLastName.CausesValidationChanged += new System.EventHandler(this.btnSave_Click);
            this.tbLastName.Validating += new System.ComponentModel.CancelEventHandler(this.tbLastName_Validating);
            // 
            // lbLastName
            // 
            this.lbLastName.AutoSize = true;
            this.lbLastName.Location = new System.Drawing.Point(251, 117);
            this.lbLastName.Name = "lbLastName";
            this.lbLastName.Size = new System.Drawing.Size(91, 20);
            this.lbLastName.TabIndex = 16;
            this.lbLastName.Text = "Last Name";
            // 
            // tbConfirmPassword
            // 
            this.tbConfirmPassword.Location = new System.Drawing.Point(371, 241);
            this.tbConfirmPassword.Name = "tbConfirmPassword";
            this.tbConfirmPassword.PasswordChar = '*';
            this.tbConfirmPassword.Size = new System.Drawing.Size(277, 27);
            this.tbConfirmPassword.TabIndex = 5;
            this.tbConfirmPassword.CausesValidationChanged += new System.EventHandler(this.btnSave_Click);
            this.tbConfirmPassword.Validating += new System.ComponentModel.CancelEventHandler(this.tbConfirmPassword_Validating);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(195, 244);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(147, 20);
            this.label1.TabIndex = 18;
            this.label1.Text = "Confirm Password";
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
            this.tcRegister.Location = new System.Drawing.Point(12, 68);
            this.tcRegister.Name = "tcRegister";
            this.tcRegister.SelectedIndex = 0;
            this.tcRegister.Size = new System.Drawing.Size(855, 327);
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
            this.tpDetails.Size = new System.Drawing.Size(847, 294);
            this.tpDetails.TabIndex = 0;
            this.tpDetails.Text = "User Details";
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
            this.btnSave.Location = new System.Drawing.Point(387, 410);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(103, 43);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "Next >";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(513, 410);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(103, 43);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.SteelBlue;
            this.panelHeader.Controls.Add(this.lbTitle);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panelHeader.ForeColor = System.Drawing.Color.White;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(879, 58);
            this.panelHeader.TabIndex = 23;
            // 
            // lbTitle
            // 
            this.lbTitle.AutoSize = true;
            this.lbTitle.Location = new System.Drawing.Point(12, 12);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(151, 32);
            this.lbTitle.TabIndex = 0;
            this.lbTitle.Text = "Add a user";
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // lbTenant
            // 
            this.lbTenant.AutoSize = true;
            this.lbTenant.Location = new System.Drawing.Point(282, 36);
            this.lbTenant.Name = "lbTenant";
            this.lbTenant.Size = new System.Drawing.Size(60, 20);
            this.lbTenant.TabIndex = 19;
            this.lbTenant.Text = "Tenant";
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
            // AddUserForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(879, 476);
            this.Controls.Add(this.panelHeader);
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
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
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
        private System.Windows.Forms.Label lbTitle;
        public System.Windows.Forms.Panel panelHeader;
        public System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.ComboBox cbTenant;
        private System.Windows.Forms.Label lbTenant;
    }
}