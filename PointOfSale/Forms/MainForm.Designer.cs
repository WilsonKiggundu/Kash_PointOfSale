namespace PointOfSale.Forms
{
    partial class MainForm
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
            this.mainMenu = new System.Windows.Forms.MenuStrip();
            this.invoicesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.miAddInvoice = new System.Windows.Forms.ToolStripMenuItem();
            this.miViewInvoices = new System.Windows.Forms.ToolStripMenuItem();
            this.receiptsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.miAddReceipt = new System.Windows.Forms.ToolStripMenuItem();
            this.miViewReceipts = new System.Windows.Forms.ToolStripMenuItem();
            this.vouchersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.miAddVoucher = new System.Windows.Forms.ToolStripMenuItem();
            this.miViewVouchers = new System.Windows.Forms.ToolStripMenuItem();
            this.productsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.miMemo_add = new System.Windows.Forms.ToolStripMenuItem();
            this.miMemo_view = new System.Windows.Forms.ToolStripMenuItem();
            this.inventoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.miInventory_add = new System.Windows.Forms.ToolStripMenuItem();
            this.miInventory_view = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.productsToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.addToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.miUsers = new System.Windows.Forms.ToolStripMenuItem();
            this.miUsers_add = new System.Windows.Forms.ToolStripMenuItem();
            this.miUsers_view = new System.Windows.Forms.ToolStripMenuItem();
            this.miCompanies = new System.Windows.Forms.ToolStripMenuItem();
            this.miCompanies_add = new System.Windows.Forms.ToolStripMenuItem();
            this.miCompanies_view = new System.Windows.Forms.ToolStripMenuItem();
            this.miTenants = new System.Windows.Forms.ToolStripMenuItem();
            this.miTenants_add = new System.Windows.Forms.ToolStripMenuItem();
            this.miTenants_view = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.miTaxes = new System.Windows.Forms.ToolStripMenuItem();
            this.miTaxes_add = new System.Windows.Forms.ToolStripMenuItem();
            this.miTaxes_view = new System.Windows.Forms.ToolStripMenuItem();
            this.miCurrencies = new System.Windows.Forms.ToolStripMenuItem();
            this.miCurrencies_add = new System.Windows.Forms.ToolStripMenuItem();
            this.miCurrencies_view = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.productsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.miProducts_add = new System.Windows.Forms.ToolStripMenuItem();
            this.miProducts_view = new System.Windows.Forms.ToolStripMenuItem();
            this.miLogout = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbTitle = new System.Windows.Forms.Label();
            this.gridView = new System.Windows.Forms.DataGridView();
            this.mainMenu.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
            this.SuspendLayout();
            // 
            // mainMenu
            // 
            this.mainMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.invoicesToolStripMenuItem,
            this.receiptsToolStripMenuItem,
            this.vouchersToolStripMenuItem,
            this.productsToolStripMenuItem,
            this.inventoryToolStripMenuItem,
            this.settingsToolStripMenuItem,
            this.miLogout});
            this.mainMenu.Location = new System.Drawing.Point(0, 0);
            this.mainMenu.Name = "mainMenu";
            this.mainMenu.Size = new System.Drawing.Size(1190, 28);
            this.mainMenu.TabIndex = 0;
            this.mainMenu.Text = "msMainMenu";
            // 
            // invoicesToolStripMenuItem
            // 
            this.invoicesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miAddInvoice,
            this.miViewInvoices});
            this.invoicesToolStripMenuItem.Name = "invoicesToolStripMenuItem";
            this.invoicesToolStripMenuItem.Size = new System.Drawing.Size(74, 24);
            this.invoicesToolStripMenuItem.Text = "Invoices";
            // 
            // miAddInvoice
            // 
            this.miAddInvoice.Name = "miAddInvoice";
            this.miAddInvoice.Size = new System.Drawing.Size(116, 26);
            this.miAddInvoice.Text = "Add";
            this.miAddInvoice.Click += new System.EventHandler(this.miAddInvoice_Click);
            // 
            // miViewInvoices
            // 
            this.miViewInvoices.Name = "miViewInvoices";
            this.miViewInvoices.Size = new System.Drawing.Size(116, 26);
            this.miViewInvoices.Text = "View";
            this.miViewInvoices.Click += new System.EventHandler(this.miViewInvoices_Click);
            // 
            // receiptsToolStripMenuItem
            // 
            this.receiptsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miAddReceipt,
            this.miViewReceipts});
            this.receiptsToolStripMenuItem.Name = "receiptsToolStripMenuItem";
            this.receiptsToolStripMenuItem.Size = new System.Drawing.Size(77, 24);
            this.receiptsToolStripMenuItem.Text = "Receipts";
            // 
            // miAddReceipt
            // 
            this.miAddReceipt.Name = "miAddReceipt";
            this.miAddReceipt.Size = new System.Drawing.Size(181, 26);
            this.miAddReceipt.Text = "Add";
            this.miAddReceipt.Click += new System.EventHandler(this.miAddReceipt_Click);
            // 
            // miViewReceipts
            // 
            this.miViewReceipts.Name = "miViewReceipts";
            this.miViewReceipts.Size = new System.Drawing.Size(181, 26);
            this.miViewReceipts.Text = "View";
            this.miViewReceipts.Click += new System.EventHandler(this.miViewReceipts_Click);
            // 
            // vouchersToolStripMenuItem
            // 
            this.vouchersToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miAddVoucher,
            this.miViewVouchers});
            this.vouchersToolStripMenuItem.Name = "vouchersToolStripMenuItem";
            this.vouchersToolStripMenuItem.Size = new System.Drawing.Size(80, 24);
            this.vouchersToolStripMenuItem.Text = "Vouchers";
            // 
            // miAddVoucher
            // 
            this.miAddVoucher.Name = "miAddVoucher";
            this.miAddVoucher.Size = new System.Drawing.Size(181, 26);
            this.miAddVoucher.Text = "Add";
            this.miAddVoucher.Click += new System.EventHandler(this.miAddVoucher_Click);
            // 
            // miViewVouchers
            // 
            this.miViewVouchers.Name = "miViewVouchers";
            this.miViewVouchers.Size = new System.Drawing.Size(181, 26);
            this.miViewVouchers.Text = "View";
            this.miViewVouchers.Click += new System.EventHandler(this.miViewVouchers_Click);
            // 
            // productsToolStripMenuItem
            // 
            this.productsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miMemo_add,
            this.miMemo_view});
            this.productsToolStripMenuItem.Name = "productsToolStripMenuItem";
            this.productsToolStripMenuItem.Size = new System.Drawing.Size(70, 24);
            this.productsToolStripMenuItem.Text = "Memos";
            // 
            // miMemo_add
            // 
            this.miMemo_add.Name = "miMemo_add";
            this.miMemo_add.Size = new System.Drawing.Size(181, 26);
            this.miMemo_add.Text = "Add";
            this.miMemo_add.Click += new System.EventHandler(this.msiAddProduct_Click);
            // 
            // miMemo_view
            // 
            this.miMemo_view.Name = "miMemo_view";
            this.miMemo_view.Size = new System.Drawing.Size(181, 26);
            this.miMemo_view.Text = "View";
            this.miMemo_view.Click += new System.EventHandler(this.msiViewProducts_Click);
            // 
            // inventoryToolStripMenuItem
            // 
            this.inventoryToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miInventory_add,
            this.miInventory_view,
            this.toolStripSeparator1,
            this.productsToolStripMenuItem2});
            this.inventoryToolStripMenuItem.Name = "inventoryToolStripMenuItem";
            this.inventoryToolStripMenuItem.Size = new System.Drawing.Size(82, 24);
            this.inventoryToolStripMenuItem.Text = "Inventory";
            // 
            // miInventory_add
            // 
            this.miInventory_add.Name = "miInventory_add";
            this.miInventory_add.Size = new System.Drawing.Size(156, 26);
            this.miInventory_add.Text = "New Stock";
            this.miInventory_add.Click += new System.EventHandler(this.miInventory_add_Click);
            // 
            // miInventory_view
            // 
            this.miInventory_view.Name = "miInventory_view";
            this.miInventory_view.Size = new System.Drawing.Size(156, 26);
            this.miInventory_view.Text = "View Stock";
            this.miInventory_view.Click += new System.EventHandler(this.miInventory_view_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(153, 6);
            // 
            // productsToolStripMenuItem2
            // 
            this.productsToolStripMenuItem2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addToolStripMenuItem,
            this.viewToolStripMenuItem});
            this.productsToolStripMenuItem2.Name = "productsToolStripMenuItem2";
            this.productsToolStripMenuItem2.Size = new System.Drawing.Size(156, 26);
            this.productsToolStripMenuItem2.Text = "Products";
            // 
            // addToolStripMenuItem
            // 
            this.addToolStripMenuItem.Name = "addToolStripMenuItem";
            this.addToolStripMenuItem.Size = new System.Drawing.Size(116, 26);
            this.addToolStripMenuItem.Text = "Add";
            this.addToolStripMenuItem.Click += new System.EventHandler(this.msiAddProduct_Click);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(116, 26);
            this.viewToolStripMenuItem.Text = "View";
            this.viewToolStripMenuItem.Click += new System.EventHandler(this.msiViewProducts_Click);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miUsers,
            this.miCompanies,
            this.miTenants,
            this.toolStripSeparator3,
            this.miTaxes,
            this.miCurrencies,
            this.toolStripSeparator2,
            this.productsToolStripMenuItem1});
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(74, 24);
            this.settingsToolStripMenuItem.Text = "Settings";
            // 
            // miUsers
            // 
            this.miUsers.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miUsers_add,
            this.miUsers_view});
            this.miUsers.Name = "miUsers";
            this.miUsers.Size = new System.Drawing.Size(158, 26);
            this.miUsers.Text = "Users";
            // 
            // miUsers_add
            // 
            this.miUsers_add.Name = "miUsers_add";
            this.miUsers_add.Size = new System.Drawing.Size(116, 26);
            this.miUsers_add.Text = "Add";
            this.miUsers_add.Click += new System.EventHandler(this.miUsers_add_Click);
            // 
            // miUsers_view
            // 
            this.miUsers_view.Name = "miUsers_view";
            this.miUsers_view.Size = new System.Drawing.Size(116, 26);
            this.miUsers_view.Text = "View";
            this.miUsers_view.Click += new System.EventHandler(this.miUsers_view_Click);
            // 
            // miCompanies
            // 
            this.miCompanies.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miCompanies_add,
            this.miCompanies_view});
            this.miCompanies.Name = "miCompanies";
            this.miCompanies.Size = new System.Drawing.Size(158, 26);
            this.miCompanies.Text = "Companies";
            // 
            // miCompanies_add
            // 
            this.miCompanies_add.Name = "miCompanies_add";
            this.miCompanies_add.Size = new System.Drawing.Size(116, 26);
            this.miCompanies_add.Text = "Add";
            this.miCompanies_add.Click += new System.EventHandler(this.miCompanies_add_Click);
            // 
            // miCompanies_view
            // 
            this.miCompanies_view.Name = "miCompanies_view";
            this.miCompanies_view.Size = new System.Drawing.Size(116, 26);
            this.miCompanies_view.Text = "View";
            this.miCompanies_view.Click += new System.EventHandler(this.miCompanies_view_Click);
            // 
            // miTenants
            // 
            this.miTenants.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miTenants_add,
            this.miTenants_view});
            this.miTenants.Name = "miTenants";
            this.miTenants.Size = new System.Drawing.Size(158, 26);
            this.miTenants.Text = "Tenants";
            // 
            // miTenants_add
            // 
            this.miTenants_add.Name = "miTenants_add";
            this.miTenants_add.Size = new System.Drawing.Size(116, 26);
            this.miTenants_add.Text = "Add";
            this.miTenants_add.Click += new System.EventHandler(this.miTenants_add_Click);
            // 
            // miTenants_view
            // 
            this.miTenants_view.Name = "miTenants_view";
            this.miTenants_view.Size = new System.Drawing.Size(116, 26);
            this.miTenants_view.Text = "View";
            this.miTenants_view.Click += new System.EventHandler(this.miTenants_view_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(155, 6);
            // 
            // miTaxes
            // 
            this.miTaxes.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miTaxes_add,
            this.miTaxes_view});
            this.miTaxes.Name = "miTaxes";
            this.miTaxes.Size = new System.Drawing.Size(158, 26);
            this.miTaxes.Text = "Taxes";
            // 
            // miTaxes_add
            // 
            this.miTaxes_add.Name = "miTaxes_add";
            this.miTaxes_add.Size = new System.Drawing.Size(116, 26);
            this.miTaxes_add.Text = "Add";
            this.miTaxes_add.Click += new System.EventHandler(this.miTaxes_add_Click);
            // 
            // miTaxes_view
            // 
            this.miTaxes_view.Name = "miTaxes_view";
            this.miTaxes_view.Size = new System.Drawing.Size(116, 26);
            this.miTaxes_view.Text = "View";
            // 
            // miCurrencies
            // 
            this.miCurrencies.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miCurrencies_add,
            this.miCurrencies_view});
            this.miCurrencies.Name = "miCurrencies";
            this.miCurrencies.Size = new System.Drawing.Size(158, 26);
            this.miCurrencies.Text = "Currencies";
            // 
            // miCurrencies_add
            // 
            this.miCurrencies_add.Name = "miCurrencies_add";
            this.miCurrencies_add.Size = new System.Drawing.Size(116, 26);
            this.miCurrencies_add.Text = "Add";
            this.miCurrencies_add.Click += new System.EventHandler(this.miCurrencies_add_Click);
            // 
            // miCurrencies_view
            // 
            this.miCurrencies_view.Name = "miCurrencies_view";
            this.miCurrencies_view.Size = new System.Drawing.Size(116, 26);
            this.miCurrencies_view.Text = "View";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(155, 6);
            // 
            // productsToolStripMenuItem1
            // 
            this.productsToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miProducts_add,
            this.miProducts_view});
            this.productsToolStripMenuItem1.Name = "productsToolStripMenuItem1";
            this.productsToolStripMenuItem1.Size = new System.Drawing.Size(158, 26);
            this.productsToolStripMenuItem1.Text = "Products";
            // 
            // miProducts_add
            // 
            this.miProducts_add.Name = "miProducts_add";
            this.miProducts_add.Size = new System.Drawing.Size(116, 26);
            this.miProducts_add.Text = "Add";
            this.miProducts_add.Click += new System.EventHandler(this.miProducts_add_Click);
            // 
            // miProducts_view
            // 
            this.miProducts_view.Name = "miProducts_view";
            this.miProducts_view.Size = new System.Drawing.Size(116, 26);
            this.miProducts_view.Text = "View";
            this.miProducts_view.Click += new System.EventHandler(this.miProducts_view_Click);
            // 
            // miLogout
            // 
            this.miLogout.Name = "miLogout";
            this.miLogout.Size = new System.Drawing.Size(68, 24);
            this.miLogout.Text = "Logout";
            this.miLogout.Click += new System.EventHandler(this.miLogout_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip.Location = new System.Drawing.Point(0, 587);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(1190, 24);
            this.statusStrip.TabIndex = 1;
            this.statusStrip.Text = "statusStrip";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Italic);
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(62, 19);
            this.toolStripStatusLabel1.Text = "Eygo Ltd";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SteelBlue;
            this.panel1.Controls.Add(this.lbTitle);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.ForeColor = System.Drawing.Color.White;
            this.panel1.Location = new System.Drawing.Point(0, 28);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1190, 50);
            this.panel1.TabIndex = 2;
            // 
            // lbTitle
            // 
            this.lbTitle.AutoSize = true;
            this.lbTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTitle.Location = new System.Drawing.Point(12, 10);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(124, 29);
            this.lbTitle.TabIndex = 0;
            this.lbTitle.Text = "Page Title";
            // 
            // gridView
            // 
            this.gridView.AllowUserToAddRows = false;
            this.gridView.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(5);
            this.gridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.gridView.BackgroundColor = System.Drawing.Color.White;
            this.gridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridView.Location = new System.Drawing.Point(0, 78);
            this.gridView.Name = "gridView";
            this.gridView.ReadOnly = true;
            this.gridView.RowTemplate.Height = 24;
            this.gridView.Size = new System.Drawing.Size(1190, 509);
            this.gridView.TabIndex = 3;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1190, 611);
            this.Controls.Add(this.gridView);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.mainMenu);
            this.MainMenuStrip = this.mainMenu;
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Kash - Point of Sale";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.mainMenu.ResumeLayout(false);
            this.mainMenu.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mainMenu;
        private System.Windows.Forms.ToolStripMenuItem productsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem invoicesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem receiptsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem vouchersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripMenuItem miMemo_view;
        private System.Windows.Forms.ToolStripMenuItem miMemo_add;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbTitle;
        private System.Windows.Forms.DataGridView gridView;
        private System.Windows.Forms.ToolStripMenuItem miAddInvoice;
        private System.Windows.Forms.ToolStripMenuItem miViewInvoices;
        private System.Windows.Forms.ToolStripMenuItem miAddReceipt;
        private System.Windows.Forms.ToolStripMenuItem miViewReceipts;
        private System.Windows.Forms.ToolStripMenuItem miAddVoucher;
        private System.Windows.Forms.ToolStripMenuItem miViewVouchers;
        private System.Windows.Forms.ToolStripMenuItem miCompanies;
        private System.Windows.Forms.ToolStripMenuItem miCompanies_add;
        private System.Windows.Forms.ToolStripMenuItem miCompanies_view;
        private System.Windows.Forms.ToolStripMenuItem miTenants;
        private System.Windows.Forms.ToolStripMenuItem miTenants_add;
        private System.Windows.Forms.ToolStripMenuItem miTenants_view;
        private System.Windows.Forms.ToolStripMenuItem miTaxes;
        private System.Windows.Forms.ToolStripMenuItem miTaxes_add;
        private System.Windows.Forms.ToolStripMenuItem miTaxes_view;
        private System.Windows.Forms.ToolStripMenuItem miCurrencies;
        private System.Windows.Forms.ToolStripMenuItem miCurrencies_add;
        private System.Windows.Forms.ToolStripMenuItem miCurrencies_view;
        private System.Windows.Forms.ToolStripMenuItem miUsers;
        private System.Windows.Forms.ToolStripMenuItem miUsers_add;
        private System.Windows.Forms.ToolStripMenuItem miUsers_view;
        private System.Windows.Forms.ToolStripMenuItem inventoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem miInventory_add;
        private System.Windows.Forms.ToolStripMenuItem miInventory_view;
        private System.Windows.Forms.ToolStripMenuItem productsToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem miProducts_add;
        private System.Windows.Forms.ToolStripMenuItem miProducts_view;
        private System.Windows.Forms.ToolStripMenuItem miLogout;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem productsToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem addToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
    }
}