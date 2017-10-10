namespace PointOfSale.Forms.Receipts
{
    partial class CreateReceiptForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvReceiptItems = new System.Windows.Forms.DataGridView();
            this.ProductId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Account = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AccountId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Item = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UnitPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tax = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.tbGrandTotal = new System.Windows.Forms.TextBox();
            this.lbTotal = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbSearch = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbCurrency = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbTax = new System.Windows.Forms.ComboBox();
            this.cbAccount = new System.Windows.Forms.ComboBox();
            this.cbCompany = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbExchangeRate = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tbInvoiceNumber = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.llAddCompany = new System.Windows.Forms.LinkLabel();
            this.llAddTax = new System.Windows.Forms.LinkLabel();
            this.llAddCurrency = new System.Windows.Forms.LinkLabel();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.gbSummary = new System.Windows.Forms.GroupBox();
            this.gbSettings = new System.Windows.Forms.GroupBox();
            this.dpDate = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReceiptItems)).BeginInit();
            this.gbSummary.SuspendLayout();
            this.gbSettings.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvReceiptItems
            // 
            this.dgvReceiptItems.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvReceiptItems.BackgroundColor = System.Drawing.Color.White;
            this.dgvReceiptItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReceiptItems.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ProductId,
            this.Account,
            this.AccountId,
            this.Item,
            this.Quantity,
            this.UnitPrice,
            this.Tax,
            this.Total});
            this.dgvReceiptItems.Location = new System.Drawing.Point(17, 212);
            this.dgvReceiptItems.Margin = new System.Windows.Forms.Padding(4);
            this.dgvReceiptItems.Name = "dgvReceiptItems";
            this.dgvReceiptItems.RowTemplate.Height = 24;
            this.dgvReceiptItems.Size = new System.Drawing.Size(1028, 243);
            this.dgvReceiptItems.TabIndex = 1;
            this.dgvReceiptItems.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvReceiptItems_CellValueChanged);
            this.dgvReceiptItems.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvInvoiceItems_DataError);
            // 
            // ProductId
            // 
            this.ProductId.HeaderText = "Product Id";
            this.ProductId.Name = "ProductId";
            this.ProductId.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // Account
            // 
            this.Account.HeaderText = "Account";
            this.Account.Name = "Account";
            this.Account.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Account.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // AccountId
            // 
            this.AccountId.HeaderText = "AccountId";
            this.AccountId.Name = "AccountId";
            this.AccountId.Visible = false;
            // 
            // Item
            // 
            this.Item.HeaderText = "Item";
            this.Item.Name = "Item";
            // 
            // Quantity
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Quantity.DefaultCellStyle = dataGridViewCellStyle1;
            this.Quantity.HeaderText = "Quantity";
            this.Quantity.Name = "Quantity";
            // 
            // UnitPrice
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N0";
            dataGridViewCellStyle2.NullValue = null;
            this.UnitPrice.DefaultCellStyle = dataGridViewCellStyle2;
            this.UnitPrice.HeaderText = "Unit Price";
            this.UnitPrice.Name = "UnitPrice";
            // 
            // Tax
            // 
            this.Tax.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.Tax.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Tax.HeaderText = "Tax";
            this.Tax.Name = "Tax";
            this.Tax.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Tax.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // Total
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N0";
            dataGridViewCellStyle3.NullValue = null;
            this.Total.DefaultCellStyle = dataGridViewCellStyle3;
            this.Total.HeaderText = "Total";
            this.Total.Name = "Total";
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.BackColor = System.Drawing.Color.SteelBlue;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(384, 588);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(138, 49);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(543, 588);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(128, 48);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // tbGrandTotal
            // 
            this.tbGrandTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tbGrandTotal.BackColor = System.Drawing.Color.White;
            this.tbGrandTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbGrandTotal.Enabled = false;
            this.tbGrandTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbGrandTotal.ForeColor = System.Drawing.Color.Black;
            this.tbGrandTotal.Location = new System.Drawing.Point(16, 49);
            this.tbGrandTotal.Margin = new System.Windows.Forms.Padding(4);
            this.tbGrandTotal.Name = "tbGrandTotal";
            this.tbGrandTotal.ReadOnly = true;
            this.tbGrandTotal.Size = new System.Drawing.Size(156, 27);
            this.tbGrandTotal.TabIndex = 4;
            this.tbGrandTotal.Text = "0.00";
            this.tbGrandTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lbTotal
            // 
            this.lbTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbTotal.AutoSize = true;
            this.lbTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTotal.Location = new System.Drawing.Point(12, 20);
            this.lbTotal.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbTotal.Name = "lbTotal";
            this.lbTotal.Size = new System.Drawing.Size(51, 20);
            this.lbTotal.TabIndex = 5;
            this.lbTotal.Text = "Total";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(15, 24);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "Account";
            // 
            // cbSearch
            // 
            this.cbSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cbSearch.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbSearch.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbSearch.DisplayMember = "Name";
            this.cbSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbSearch.FormattingEnabled = true;
            this.cbSearch.Location = new System.Drawing.Point(16, 175);
            this.cbSearch.Margin = new System.Windows.Forms.Padding(4);
            this.cbSearch.MaxDropDownItems = 20;
            this.cbSearch.Name = "cbSearch";
            this.cbSearch.Size = new System.Drawing.Size(1027, 28);
            this.cbSearch.Sorted = true;
            this.cbSearch.TabIndex = 8;
            this.cbSearch.ValueMember = "Id";
            this.cbSearch.SelectionChangeCommitted += new System.EventHandler(this.cbSearch_SelectionChangeCommitted);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(482, 25);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 20);
            this.label3.TabIndex = 9;
            this.label3.Text = "Tax";
            // 
            // cbCurrency
            // 
            this.cbCurrency.FormattingEnabled = true;
            this.cbCurrency.Location = new System.Drawing.Point(16, 112);
            this.cbCurrency.Margin = new System.Windows.Forms.Padding(4);
            this.cbCurrency.Name = "cbCurrency";
            this.cbCurrency.Size = new System.Drawing.Size(201, 28);
            this.cbCurrency.TabIndex = 12;
            this.cbCurrency.SelectionChangeCommitted += new System.EventHandler(this.cbCurrency_SelectionChangeCommitted);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(11, 89);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 20);
            this.label4.TabIndex = 11;
            this.label4.Text = "Currency";
            // 
            // cbTax
            // 
            this.cbTax.FormattingEnabled = true;
            this.cbTax.Location = new System.Drawing.Point(487, 47);
            this.cbTax.Margin = new System.Windows.Forms.Padding(4);
            this.cbTax.Name = "cbTax";
            this.cbTax.Size = new System.Drawing.Size(241, 28);
            this.cbTax.TabIndex = 13;
            // 
            // cbAccount
            // 
            this.cbAccount.FormattingEnabled = true;
            this.cbAccount.Location = new System.Drawing.Point(17, 47);
            this.cbAccount.Margin = new System.Windows.Forms.Padding(4);
            this.cbAccount.Name = "cbAccount";
            this.cbAccount.Size = new System.Drawing.Size(200, 28);
            this.cbAccount.TabIndex = 14;
            // 
            // cbCompany
            // 
            this.cbCompany.FormattingEnabled = true;
            this.cbCompany.Location = new System.Drawing.Point(252, 47);
            this.cbCompany.Margin = new System.Windows.Forms.Padding(4);
            this.cbCompany.Name = "cbCompany";
            this.cbCompany.Size = new System.Drawing.Size(200, 28);
            this.cbCompany.TabIndex = 16;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(247, 24);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 20);
            this.label5.TabIndex = 15;
            this.label5.Text = "Company";
            // 
            // tbExchangeRate
            // 
            this.tbExchangeRate.Location = new System.Drawing.Point(252, 113);
            this.tbExchangeRate.Name = "tbExchangeRate";
            this.tbExchangeRate.Size = new System.Drawing.Size(200, 27);
            this.tbExchangeRate.TabIndex = 20;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(247, 88);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(122, 20);
            this.label7.TabIndex = 19;
            this.label7.Text = "Exchange Rate";
            // 
            // tbInvoiceNumber
            // 
            this.tbInvoiceNumber.Location = new System.Drawing.Point(759, 48);
            this.tbInvoiceNumber.Name = "tbInvoiceNumber";
            this.tbInvoiceNumber.Size = new System.Drawing.Size(250, 27);
            this.tbInvoiceNumber.TabIndex = 22;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(754, 23);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(130, 20);
            this.label8.TabIndex = 21;
            this.label8.Text = "Receipt Number";
            // 
            // llAddCompany
            // 
            this.llAddCompany.AutoSize = true;
            this.llAddCompany.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.llAddCompany.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.llAddCompany.Location = new System.Drawing.Point(369, 26);
            this.llAddCompany.Name = "llAddCompany";
            this.llAddCompany.Size = new System.Drawing.Size(80, 18);
            this.llAddCompany.TabIndex = 26;
            this.llAddCompany.TabStop = true;
            this.llAddCompany.Text = "+ Add New";
            this.llAddCompany.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llAddCompany_LinkClicked);
            // 
            // llAddTax
            // 
            this.llAddTax.AutoSize = true;
            this.llAddTax.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.llAddTax.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.llAddTax.Location = new System.Drawing.Point(648, 26);
            this.llAddTax.Name = "llAddTax";
            this.llAddTax.Size = new System.Drawing.Size(80, 18);
            this.llAddTax.TabIndex = 27;
            this.llAddTax.TabStop = true;
            this.llAddTax.Text = "+ Add New";
            this.llAddTax.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llAddTax_LinkClicked);
            // 
            // llAddCurrency
            // 
            this.llAddCurrency.AutoSize = true;
            this.llAddCurrency.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.llAddCurrency.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.llAddCurrency.Location = new System.Drawing.Point(91, 90);
            this.llAddCurrency.Name = "llAddCurrency";
            this.llAddCurrency.Size = new System.Drawing.Size(80, 18);
            this.llAddCurrency.TabIndex = 28;
            this.llAddCurrency.TabStop = true;
            this.llAddCurrency.Text = "+ Add New";
            this.llAddCurrency.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llAddCurrency_LinkClicked);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(759, 89);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(250, 50);
            this.btnRefresh.TabIndex = 29;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // gbSummary
            // 
            this.gbSummary.Controls.Add(this.tbGrandTotal);
            this.gbSummary.Controls.Add(this.lbTotal);
            this.gbSummary.Location = new System.Drawing.Point(15, 468);
            this.gbSummary.Name = "gbSummary";
            this.gbSummary.Size = new System.Drawing.Size(1028, 92);
            this.gbSummary.TabIndex = 37;
            this.gbSummary.TabStop = false;
            // 
            // gbSettings
            // 
            this.gbSettings.Controls.Add(this.label1);
            this.gbSettings.Controls.Add(this.dpDate);
            this.gbSettings.Controls.Add(this.cbCurrency);
            this.gbSettings.Controls.Add(this.label2);
            this.gbSettings.Controls.Add(this.label3);
            this.gbSettings.Controls.Add(this.label4);
            this.gbSettings.Controls.Add(this.cbTax);
            this.gbSettings.Controls.Add(this.btnRefresh);
            this.gbSettings.Controls.Add(this.llAddCurrency);
            this.gbSettings.Controls.Add(this.cbAccount);
            this.gbSettings.Controls.Add(this.label5);
            this.gbSettings.Controls.Add(this.llAddTax);
            this.gbSettings.Controls.Add(this.cbCompany);
            this.gbSettings.Controls.Add(this.llAddCompany);
            this.gbSettings.Controls.Add(this.label7);
            this.gbSettings.Controls.Add(this.tbExchangeRate);
            this.gbSettings.Controls.Add(this.label8);
            this.gbSettings.Controls.Add(this.tbInvoiceNumber);
            this.gbSettings.Location = new System.Drawing.Point(12, 2);
            this.gbSettings.Name = "gbSettings";
            this.gbSettings.Size = new System.Drawing.Size(1031, 158);
            this.gbSettings.TabIndex = 38;
            this.gbSettings.TabStop = false;
            // 
            // dpDate
            // 
            this.dpDate.CustomFormat = "dd-MM-yyyy";
            this.dpDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dpDate.Location = new System.Drawing.Point(487, 112);
            this.dpDate.Name = "dpDate";
            this.dpDate.Size = new System.Drawing.Size(241, 27);
            this.dpDate.TabIndex = 40;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(482, 89);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 20);
            this.label1.TabIndex = 41;
            this.label1.Text = "Date";
            // 
            // CreateReceiptForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1058, 664);
            this.Controls.Add(this.gbSettings);
            this.Controls.Add(this.gbSummary);
            this.Controls.Add(this.cbSearch);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.dgvReceiptItems);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CreateReceiptForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Create Receipt";
            this.Load += new System.EventHandler(this.CreateReceiptForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvReceiptItems)).EndInit();
            this.gbSummary.ResumeLayout(false);
            this.gbSummary.PerformLayout();
            this.gbSettings.ResumeLayout(false);
            this.gbSettings.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView dgvReceiptItems;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox tbGrandTotal;
        private System.Windows.Forms.Label lbTotal;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbSearch;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbCurrency;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbTax;
        private System.Windows.Forms.ComboBox cbAccount;
        private System.Windows.Forms.ComboBox cbCompany;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbExchangeRate;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbInvoiceNumber;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.LinkLabel llAddCompany;
        private System.Windows.Forms.LinkLabel llAddTax;
        private System.Windows.Forms.LinkLabel llAddCurrency;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.GroupBox gbSummary;
        private System.Windows.Forms.GroupBox gbSettings;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductId;
        private System.Windows.Forms.DataGridViewTextBoxColumn Account;
        private System.Windows.Forms.DataGridViewTextBoxColumn AccountId;
        private System.Windows.Forms.DataGridViewTextBoxColumn Item;
        private System.Windows.Forms.DataGridViewTextBoxColumn Quantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn UnitPrice;
        private System.Windows.Forms.DataGridViewComboBoxColumn Tax;
        private System.Windows.Forms.DataGridViewTextBoxColumn Total;
        private System.Windows.Forms.DateTimePicker dpDate;
        private System.Windows.Forms.Label label1;
    }
}