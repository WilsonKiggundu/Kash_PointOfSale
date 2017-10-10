namespace PointOfSale.Forms.Tenants
{
    partial class TenantCreateForm
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
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.cbActive = new System.Windows.Forms.CheckBox();
            this.tbName = new System.Windows.Forms.TextBox();
            this.tbEmail = new System.Windows.Forms.TextBox();
            this.tbTelephone = new System.Windows.Forms.TextBox();
            this.rtAddress = new System.Windows.Forms.RichTextBox();
            this.rtPostalAddress = new System.Windows.Forms.RichTextBox();
            this.dpPaymentDate = new System.Windows.Forms.DateTimePicker();
            this.ofdLogo = new System.Windows.Forms.OpenFileDialog();
            this.tbLogoPath = new System.Windows.Forms.TextBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.cbCategory = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.SteelBlue;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(378, 422);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(84, 33);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(481, 422);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(84, 33);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(172, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(200, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Name";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(172, 100);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(200, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Email";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(172, 134);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(200, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "Telephone";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(172, 66);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(200, 20);
            this.label4.TabIndex = 6;
            this.label4.Text = "Category";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(172, 166);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(200, 20);
            this.label5.TabIndex = 7;
            this.label5.Text = "Address";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(172, 333);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(200, 20);
            this.label6.TabIndex = 8;
            this.label6.Text = "Logo";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(172, 229);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(200, 20);
            this.label7.TabIndex = 9;
            this.label7.Text = "Postal Address";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(172, 289);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(200, 20);
            this.label8.TabIndex = 10;
            this.label8.Text = "Date of Last Payment";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cbActive
            // 
            this.cbActive.AutoSize = true;
            this.cbActive.Location = new System.Drawing.Point(378, 377);
            this.cbActive.Name = "cbActive";
            this.cbActive.Size = new System.Drawing.Size(77, 24);
            this.cbActive.TabIndex = 12;
            this.cbActive.Text = "Active";
            this.cbActive.UseVisualStyleBackColor = true;
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(378, 29);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(298, 27);
            this.tbName.TabIndex = 13;
            // 
            // tbEmail
            // 
            this.tbEmail.Location = new System.Drawing.Point(378, 97);
            this.tbEmail.Name = "tbEmail";
            this.tbEmail.Size = new System.Drawing.Size(298, 27);
            this.tbEmail.TabIndex = 15;
            // 
            // tbTelephone
            // 
            this.tbTelephone.Location = new System.Drawing.Point(378, 131);
            this.tbTelephone.Name = "tbTelephone";
            this.tbTelephone.Size = new System.Drawing.Size(298, 27);
            this.tbTelephone.TabIndex = 16;
            // 
            // rtAddress
            // 
            this.rtAddress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rtAddress.Location = new System.Drawing.Point(378, 164);
            this.rtAddress.Name = "rtAddress";
            this.rtAddress.Size = new System.Drawing.Size(298, 56);
            this.rtAddress.TabIndex = 17;
            this.rtAddress.Text = "";
            // 
            // rtPostalAddress
            // 
            this.rtPostalAddress.Location = new System.Drawing.Point(378, 226);
            this.rtPostalAddress.Name = "rtPostalAddress";
            this.rtPostalAddress.Size = new System.Drawing.Size(298, 56);
            this.rtPostalAddress.TabIndex = 18;
            this.rtPostalAddress.Text = "";
            // 
            // dpPaymentDate
            // 
            this.dpPaymentDate.Location = new System.Drawing.Point(378, 289);
            this.dpPaymentDate.Name = "dpPaymentDate";
            this.dpPaymentDate.Size = new System.Drawing.Size(298, 27);
            this.dpPaymentDate.TabIndex = 19;
            // 
            // ofdLogo
            // 
            this.ofdLogo.FileName = "logo";
            // 
            // tbLogoPath
            // 
            this.tbLogoPath.Location = new System.Drawing.Point(378, 330);
            this.tbLogoPath.Name = "tbLogoPath";
            this.tbLogoPath.ReadOnly = true;
            this.tbLogoPath.Size = new System.Drawing.Size(265, 27);
            this.tbLogoPath.TabIndex = 20;
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(645, 330);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(34, 27);
            this.btnBrowse.TabIndex = 21;
            this.btnBrowse.Text = "...";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // cbCategory
            // 
            this.cbCategory.FormattingEnabled = true;
            this.cbCategory.Location = new System.Drawing.Point(378, 63);
            this.cbCategory.Name = "cbCategory";
            this.cbCategory.Size = new System.Drawing.Size(187, 28);
            this.cbCategory.TabIndex = 1;
            // 
            // TenantCreateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(844, 476);
            this.Controls.Add(this.cbCategory);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.tbLogoPath);
            this.Controls.Add(this.dpPaymentDate);
            this.Controls.Add(this.rtPostalAddress);
            this.Controls.Add(this.rtAddress);
            this.Controls.Add(this.tbTelephone);
            this.Controls.Add(this.tbEmail);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.cbActive);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TenantCreateForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Create Tenant";
            this.Load += new System.EventHandler(this.TenantCreateForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckBox cbActive;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.TextBox tbEmail;
        private System.Windows.Forms.TextBox tbTelephone;
        private System.Windows.Forms.RichTextBox rtAddress;
        private System.Windows.Forms.RichTextBox rtPostalAddress;
        private System.Windows.Forms.DateTimePicker dpPaymentDate;
        private System.Windows.Forms.OpenFileDialog ofdLogo;
        private System.Windows.Forms.TextBox tbLogoPath;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.ComboBox cbCategory;
    }
}