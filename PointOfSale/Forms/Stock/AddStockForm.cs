using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using PointOfSale.Forms.Products;
using PointOfSale.Forms.Settings.Locations;
using PointOfSale.Helpers;
using PointOfSale.Models;
using PointOfSale.Properties;

namespace PointOfSale.Forms.Stock
{
    public partial class AddStockForm : Form
    {
        private readonly PointOfSaleContext _db = new PointOfSaleContext();
        public AddStockForm()
        {
            InitializeComponent();

            cbCategory.DataSource = Enum.GetValues(typeof(StockCategory));

            for (var i = 0; i < gridView.ColumnCount; i++)
            {
                gridView.Columns[i].AutoSizeMode = i != 7
                    ? DataGridViewAutoSizeColumnMode.DisplayedCells
                    : DataGridViewAutoSizeColumnMode.Fill;
            }

        }

        private void LoadLocations()
        {
            var destLocations = _db.Locations.Where(q => !q.IsDeleted)
                .Where(q => q.TenantId == Session.TenantId)
                .Select(s => new { s.Id, s.Name }).ToList();

            destLocations.Insert(0, new { Id = -1, Name = "Choose location" });
            destLocations.Insert(1, new { Id = 0, Name = "+ Add New" });

            cbDestination.DataSource = destLocations;
            cbDestination.DisplayMember = "Name";
            cbDestination.ValueMember = "Id";

            var srcLocations = _db.Locations.Where(q => !q.IsDeleted)
                .Where(q => q.TenantId == Session.TenantId)
                .Select(s => new { s.Id, s.Name }).ToList();
            srcLocations.Insert(0, new { Id = -1, Name = "Choose location" });
            srcLocations.Insert(1, new { Id = 0, Name = "+ Add New" });

            cbSource.DataSource = srcLocations;
            cbSource.DisplayMember = "Name";
            cbSource.ValueMember = "Id";
        }

        private void LoadProducts()
        {
            var products = _db.Products.Where(q => q.ProductType == ProductType.Stockable && !q.IsDeleted && q.TenantId == Session.TenantId)
                .OrderBy(q => q.Name)
                .Select(s => new { s.Id, s.Name })
                .ToList();

            products.Insert(0, new { Id = -1, Name = "Select Item" });
            products.Insert(1, new { Id = 0, Name = "+ Add New" });

            cbSearch.DataSource = products;
            cbSearch.DisplayMember = "Name";
            cbSearch.ValueMember = "Id";
        }

        private void AddStockForm_Load(object sender, EventArgs e)
        {
            LoadProducts();
            LoadLocations();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var sourceLocationId = cbSource.SelectedValue.ToInteger();
            var destinationLocationId = cbDestination.SelectedValue.ToInteger();
            var category = cbCategory.SelectedItem.GetEnumValue<StockCategory>();
            var date = dpDate.Value;

            if (sourceLocationId < 1) sourceLocationId = null;
            if (destinationLocationId < 1) destinationLocationId = null;
            
            var stock = new Models.Stock
            {
                SourceId = sourceLocationId,
                DestinationId = destinationLocationId,
                Category = category,
                TenantId = Session.TenantId,
                DateCreated = date,
                Remarks = rtbRemarks.Text,
                StockItems = new List<StockItem>()
            };
            
            foreach (DataGridViewRow row in gridView.Rows)
            {
                if(row.IsNewRow) continue;
                stock.StockItems.Add(new StockItem
                {
                    Amount = row.Cells["Amount"].Value?.ToDecimal(),
                    Quantity = row.Cells["Quantity"].Value?.ToDecimal(),
                    DestinationLocationId = destinationLocationId,
                    SourceLocationId = sourceLocationId,
                    Category = category,
                    Particulars = row.Cells["Particulars"].Value?.ToString(),
                    ProductId = row.Cells["ProductId"].Value?.ToInteger(),
                    BatchNo = row.Cells["BatchNo"].Value?.ToString(),
                    ExpiryDate = row.Cells["ExpiryDate"].Value == null ? (DateTime?)null : Convert.ToDateTime(row.Cells["ExpiryDate"].Value),
                    ManufactureDate = row.Cells["ManufactureDate"].Value == null ? (DateTime?)null : Convert.ToDateTime(row.Cells["ManufactureDate"].Value),
                    DateCreated = date
                });
            }

            _db.Stock.Add(stock);
            try
            {
                _db.SaveChanges();
                Close();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, Resources.Failure, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cbCategory_SelectionChangeCommitted(object sender, EventArgs e)
        {

        }

        private void cbSource_SelectionChangeCommitted(object sender, EventArgs e)
        {
            var sourceLocation = (int)cbSource.SelectedValue;
            if (sourceLocation == 0)
            {
                new AddLocationForm().ShowDialog();
            }
        }

        private void cbSearch_SelectionChangeCommitted(object sender, EventArgs e)
        {
            var productId = (int) cbSearch.SelectedValue;
            if (productId == 0)
            {
                new AddProductForm().ShowDialog();
            }
            else
            {
                // Get product details
                var product = _db.Products.FirstOrDefault(q => q.Id == productId);
                if (product != null)
                {
                    // grid rows
                    var i = gridView.RowCount;

                    gridView.Rows.Add();

                    var addedRowIndex = i - 1;
                    gridView.Rows[addedRowIndex].Cells["ProductId"].Value = product.Id;
                    gridView.Rows[addedRowIndex].Cells["Item"].Value = product.Name;
                    gridView.Rows[addedRowIndex].Cells["Quantity"].Value = 1;
                    gridView.Rows[addedRowIndex].Cells["Amount"].Value = product.CostPrice;

                    gridView.CurrentCell = gridView.Rows[addedRowIndex].Cells["BatchNo"];
                }
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadLocations();
            LoadProducts();
        }
    }
}
