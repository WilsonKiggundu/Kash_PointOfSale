namespace PointOfSale.Forms.Settings.Company
{
    partial class AddCompanyForm
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
            this.cbCurrency = new System.Windows.Forms.ComboBox();
            this.ofdLogo = new System.Windows.Forms.OpenFileDialog();
            this.rtAddress = new System.Windows.Forms.RichTextBox();
            this.tbTelephone = new System.Windows.Forms.TextBox();
            this.tbEmail = new System.Windows.Forms.TextBox();
            this.tbName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cbCurrency
            // 
            this.cbCurrency.FormattingEnabled = true;
            this.cbCurrency.Location = new System.Drawing.Point(324, 61);
            this.cbCurrency.Name = "cbCurrency";
            this.cbCurrency.Size = new System.Drawing.Size(187, 28);
            this.cbCurrency.TabIndex = 1;
            // 
            // ofdLogo
            // 
            this.ofdLogo.FileName = "logo";
            // 
            // rtAddress
            // 
            this.rtAddress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rtAddress.Location = new System.Drawing.Point(324, 162);
            this.rtAddress.Name = "rtAddress";
            this.rtAddress.Size = new System.Drawing.Size(298, 56);
            this.rtAddress.TabIndex = 4;
            this.rtAddress.Text = "";
            // 
            // tbTelephone
            // 
            this.tbTelephone.Location = new System.Drawing.Point(324, 129);
            this.tbTelephone.Name = "tbTelephone";
            this.tbTelephone.Size = new System.Drawing.Size(298, 27);
            this.tbTelephone.TabIndex = 3;
            // 
            // tbEmail
            // 
            this.tbEmail.Location = new System.Drawing.Point(324, 95);
            this.tbEmail.Name = "tbEmail";
            this.tbEmail.Size = new System.Drawing.Size(298, 27);
            this.tbEmail.TabIndex = 2;
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(324, 27);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(298, 27);
            this.tbName.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(151, 164);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(150, 20);
            this.label5.TabIndex = 30;
            this.label5.Text = "Address";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(151, 64);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(150, 20);
            this.label4.TabIndex = 29;
            this.label4.Text = "Currency";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(151, 132);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(150, 20);
            this.label3.TabIndex = 28;
            this.label3.Text = "Telephone";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(151, 98);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(150, 20);
            this.label2.TabIndex = 27;
            this.label2.Text = "Email";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(151, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(150, 20);
            this.label1.TabIndex = 26;
            this.label1.Text = "Name";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(427, 245);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(84, 33);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.SteelBlue;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(324, 245);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(84, 33);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // AddCompanyForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(729, 306);
            this.Controls.Add(this.cbCurrency);
            this.Controls.Add(this.rtAddress);
            this.Controls.Add(this.tbTelephone);
            this.Controls.Add(this.tbEmail);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddCompanyForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add a company";
            this.Load += new System.EventHandler(this.AddCompanyForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbCurrency;
        private System.Windows.Forms.OpenFileDialog ofdLogo;
        private System.Windows.Forms.RichTextBox rtAddress;
        private System.Windows.Forms.TextBox tbTelephone;
        private System.Windows.Forms.TextBox tbEmail;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
    }
}