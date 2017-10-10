namespace PointOfSale.Forms.Stock
{
    partial class AddStockForm
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
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.cbSource = new System.Windows.Forms.ComboBox();
            this.cbDestination = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cbCategory = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dpDate = new System.Windows.Forms.DateTimePicker();
            this.gridView = new System.Windows.Forms.DataGridView();
            this.Item = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProductId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BatchNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ExpiryDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ManufactureDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Particulars = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cbSearch = new System.Windows.Forms.ComboBox();
            this.rtbRemarks = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnRefresh = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(270, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = "Source";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(513, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(94, 20);
            this.label5.TabIndex = 4;
            this.label5.Text = "Destination";
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.SteelBlue;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(395, 524);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 39);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(517, 524);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 39);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // cbSource
            // 
            this.cbSource.FormattingEnabled = true;
            this.cbSource.Location = new System.Drawing.Point(274, 34);
            this.cbSource.Name = "cbSource";
            this.cbSource.Size = new System.Drawing.Size(215, 28);
            this.cbSource.TabIndex = 3;
            this.cbSource.SelectionChangeCommitted += new System.EventHandler(this.cbSource_SelectionChangeCommitted);
            // 
            // cbDestination
            // 
            this.cbDestination.FormattingEnabled = true;
            this.cbDestination.Location = new System.Drawing.Point(517, 34);
            this.cbDestination.Name = "cbDestination";
            this.cbDestination.Size = new System.Drawing.Size(215, 28);
            this.cbDestination.TabIndex = 4;
            this.cbDestination.SelectionChangeCommitted += new System.EventHandler(this.cbSource_SelectionChangeCommitted);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(76, 20);
            this.label6.TabIndex = 13;
            this.label6.Text = "Category";
            // 
            // cbCategory
            // 
            this.cbCategory.FormattingEnabled = true;
            this.cbCategory.Location = new System.Drawing.Point(16, 34);
            this.cbCategory.Name = "cbCategory";
            this.cbCategory.Size = new System.Drawing.Size(234, 28);
            this.cbCategory.TabIndex = 0;
            this.cbCategory.SelectionChangeCommitted += new System.EventHandler(this.cbCategory_SelectionChangeCommitted);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(747, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 20);
            this.label1.TabIndex = 14;
            this.label1.Text = "Date";
            // 
            // dpDate
            // 
            this.dpDate.CustomFormat = "dd-MM-yyyy";
            this.dpDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dpDate.Location = new System.Drawing.Point(751, 34);
            this.dpDate.MaxDate = new System.DateTime(2017, 9, 28, 0, 0, 0, 0);
            this.dpDate.Name = "dpDate";
            this.dpDate.Size = new System.Drawing.Size(152, 27);
            this.dpDate.TabIndex = 5;
            this.dpDate.Value = new System.DateTime(2017, 9, 28, 0, 0, 0, 0);
            // 
            // gridView
            // 
            this.gridView.BackgroundColor = System.Drawing.Color.White;
            this.gridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Item,
            this.ProductId,
            this.BatchNo,
            this.Quantity,
            this.Amount,
            this.ExpiryDate,
            this.ManufactureDate,
            this.Particulars});
            this.gridView.Location = new System.Drawing.Point(16, 122);
            this.gridView.Name = "gridView";
            this.gridView.RowTemplate.Height = 24;
            this.gridView.Size = new System.Drawing.Size(972, 245);
            this.gridView.TabIndex = 17;
            // 
            // Item
            // 
            this.Item.HeaderText = "Item";
            this.Item.Name = "Item";
            this.Item.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // ProductId
            // 
            this.ProductId.HeaderText = "ProductId";
            this.ProductId.Name = "ProductId";
            this.ProductId.Visible = false;
            // 
            // BatchNo
            // 
            this.BatchNo.HeaderText = "Batch #";
            this.BatchNo.Name = "BatchNo";
            // 
            // Quantity
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.Format = "N0";
            dataGridViewCellStyle1.NullValue = null;
            this.Quantity.DefaultCellStyle = dataGridViewCellStyle1;
            this.Quantity.HeaderText = "Quantity";
            this.Quantity.Name = "Quantity";
            // 
            // Amount
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N0";
            dataGridViewCellStyle2.NullValue = null;
            this.Amount.DefaultCellStyle = dataGridViewCellStyle2;
            this.Amount.HeaderText = "Amount";
            this.Amount.Name = "Amount";
            // 
            // ExpiryDate
            // 
            this.ExpiryDate.HeaderText = "Expiry Date";
            this.ExpiryDate.Name = "ExpiryDate";
            // 
            // ManufactureDate
            // 
            this.ManufactureDate.HeaderText = "Manufacture Date";
            this.ManufactureDate.Name = "ManufactureDate";
            // 
            // Particulars
            // 
            this.Particulars.HeaderText = "Particulars";
            this.Particulars.Name = "Particulars";
            // 
            // cbSearch
            // 
            this.cbSearch.FormattingEnabled = true;
            this.cbSearch.Location = new System.Drawing.Point(16, 88);
            this.cbSearch.Name = "cbSearch";
            this.cbSearch.Size = new System.Drawing.Size(972, 28);
            this.cbSearch.TabIndex = 18;
            this.cbSearch.SelectionChangeCommitted += new System.EventHandler(this.cbSearch_SelectionChangeCommitted);
            // 
            // rtbRemarks
            // 
            this.rtbRemarks.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rtbRemarks.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.rtbRemarks.Location = new System.Drawing.Point(16, 422);
            this.rtbRemarks.Name = "rtbRemarks";
            this.rtbRemarks.Size = new System.Drawing.Size(972, 96);
            this.rtbRemarks.TabIndex = 19;
            this.rtbRemarks.Text = "";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 399);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 20);
            this.label2.TabIndex = 20;
            this.label2.Text = "Remarks";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(909, 32);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(79, 30);
            this.btnRefresh.TabIndex = 21;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // AddStockForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1000, 575);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.rtbRemarks);
            this.Controls.Add(this.cbSearch);
            this.Controls.Add(this.gridView);
            this.Controls.Add(this.dpDate);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbCategory);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cbDestination);
            this.Controls.Add(this.cbSource);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddStockForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "New Stock Transaction";
            this.Load += new System.EventHandler(this.AddStockForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ComboBox cbSource;
        private System.Windows.Forms.ComboBox cbDestination;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbCategory;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dpDate;
        private System.Windows.Forms.DataGridView gridView;
        private System.Windows.Forms.ComboBox cbSearch;
        private System.Windows.Forms.RichTextBox rtbRemarks;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.DataGridViewTextBoxColumn Item;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductId;
        private System.Windows.Forms.DataGridViewTextBoxColumn BatchNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Quantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn Amount;
        private System.Windows.Forms.DataGridViewTextBoxColumn ExpiryDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ManufactureDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Particulars;
    }
}