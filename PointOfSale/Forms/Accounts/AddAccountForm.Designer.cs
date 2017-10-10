namespace PointOfSale.Forms.Accounts
{
    partial class AddAccountForm
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.tbName = new System.Windows.Forms.TextBox();
            this.cbParentAccount = new System.Windows.Forms.ComboBox();
            this.tbDepreciation = new System.Windows.Forms.TextBox();
            this.cbCurrency = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.cbBalanceSheetCategory = new System.Windows.Forms.ComboBox();
            this.cbCashflowCategory = new System.Windows.Forms.ComboBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.cbBudget = new System.Windows.Forms.CheckBox();
            this.cbFees = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbCategory = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(197, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(200, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Name";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(197, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(200, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Parent Account";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(197, 104);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(200, 20);
            this.label7.TabIndex = 6;
            this.label7.Text = "Currency";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(197, 138);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(200, 20);
            this.label8.TabIndex = 7;
            this.label8.Text = "Depreciation";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(422, 34);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(320, 27);
            this.tbName.TabIndex = 0;
            // 
            // cbParentAccount
            // 
            this.cbParentAccount.FormattingEnabled = true;
            this.cbParentAccount.Location = new System.Drawing.Point(422, 67);
            this.cbParentAccount.Name = "cbParentAccount";
            this.cbParentAccount.Size = new System.Drawing.Size(320, 28);
            this.cbParentAccount.TabIndex = 1;
            // 
            // tbDepreciation
            // 
            this.tbDepreciation.Location = new System.Drawing.Point(422, 135);
            this.tbDepreciation.Name = "tbDepreciation";
            this.tbDepreciation.Size = new System.Drawing.Size(84, 27);
            this.tbDepreciation.TabIndex = 6;
            this.tbDepreciation.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // cbCurrency
            // 
            this.cbCurrency.DisplayMember = "Name";
            this.cbCurrency.FormattingEnabled = true;
            this.cbCurrency.Location = new System.Drawing.Point(422, 101);
            this.cbCurrency.Name = "cbCurrency";
            this.cbCurrency.Size = new System.Drawing.Size(320, 28);
            this.cbCurrency.TabIndex = 5;
            this.cbCurrency.ValueMember = "Id";
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(197, 205);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(200, 20);
            this.label9.TabIndex = 16;
            this.label9.Text = "Balance Sheet Category";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(197, 239);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(200, 20);
            this.label11.TabIndex = 18;
            this.label11.Text = "Cashflow Category";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cbBalanceSheetCategory
            // 
            this.cbBalanceSheetCategory.FormattingEnabled = true;
            this.cbBalanceSheetCategory.Items.AddRange(new object[] {
            "",
            "Asset",
            "Equity",
            "Liability"});
            this.cbBalanceSheetCategory.Location = new System.Drawing.Point(422, 202);
            this.cbBalanceSheetCategory.Name = "cbBalanceSheetCategory";
            this.cbBalanceSheetCategory.Size = new System.Drawing.Size(320, 28);
            this.cbBalanceSheetCategory.TabIndex = 7;
            // 
            // cbCashflowCategory
            // 
            this.cbCashflowCategory.FormattingEnabled = true;
            this.cbCashflowCategory.Location = new System.Drawing.Point(422, 236);
            this.cbCashflowCategory.Name = "cbCashflowCategory";
            this.cbCashflowCategory.Size = new System.Drawing.Size(320, 28);
            this.cbCashflowCategory.TabIndex = 9;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.SteelBlue;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(422, 352);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(121, 46);
            this.btnSave.TabIndex = 10;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(557, 352);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(121, 46);
            this.btnCancel.TabIndex = 11;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // cbBudget
            // 
            this.cbBudget.AutoSize = true;
            this.cbBudget.Location = new System.Drawing.Point(422, 295);
            this.cbBudget.Name = "cbBudget";
            this.cbBudget.Size = new System.Drawing.Size(84, 24);
            this.cbBudget.TabIndex = 19;
            this.cbBudget.Text = "Budget";
            this.cbBudget.UseVisualStyleBackColor = true;
            // 
            // cbFees
            // 
            this.cbFees.AutoSize = true;
            this.cbFees.Location = new System.Drawing.Point(573, 295);
            this.cbFees.Name = "cbFees";
            this.cbFees.Size = new System.Drawing.Size(68, 24);
            this.cbFees.TabIndex = 20;
            this.cbFees.Text = "Fees";
            this.cbFees.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(513, 140);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(24, 20);
            this.label1.TabIndex = 21;
            this.label1.Text = "%";
            // 
            // cbCategory
            // 
            this.cbCategory.FormattingEnabled = true;
            this.cbCategory.Location = new System.Drawing.Point(422, 168);
            this.cbCategory.Name = "cbCategory";
            this.cbCategory.Size = new System.Drawing.Size(320, 28);
            this.cbCategory.TabIndex = 22;
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(197, 171);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(200, 20);
            this.label10.TabIndex = 23;
            this.label10.Text = "Category";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // AddAccountForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(931, 426);
            this.Controls.Add(this.cbCategory);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbFees);
            this.Controls.Add(this.cbBudget);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.cbCashflowCategory);
            this.Controls.Add(this.cbBalanceSheetCategory);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.cbCurrency);
            this.Controls.Add(this.tbDepreciation);
            this.Controls.Add(this.cbParentAccount);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddAccountForm";
            this.RightToLeftLayout = true;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add account";
            this.Load += new System.EventHandler(this.AddAccountForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.ComboBox cbParentAccount;
        private System.Windows.Forms.TextBox tbDepreciation;
        private System.Windows.Forms.ComboBox cbCurrency;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cbBalanceSheetCategory;
        private System.Windows.Forms.ComboBox cbCashflowCategory;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.CheckBox cbBudget;
        private System.Windows.Forms.CheckBox cbFees;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbCategory;
        private System.Windows.Forms.Label label10;
    }
}