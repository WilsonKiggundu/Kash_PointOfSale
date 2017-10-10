using System;

namespace PointOfSale.Models
{
    public class StockItem : BaseModel
    {
        public decimal? Quantity { get; set; }
        public decimal? Amount { get; set; }
        public string BatchNo { get; set; }
        public StockCategory Category { get; set; }
        public string Particulars { get; set; }
        public int? StockId { get; set; }
        public int? ProductId { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public DateTime? ManufactureDate { get; set; }
        public int? SourceLocationId { get; set; }
        public int? DestinationLocationId { get; set; } 

        #region Navigation properties
        public virtual Stock Stock { get; set; }
        public virtual Product Product { get; set; }
        public virtual Location SourceLocation { get; set; }
        public virtual Location DestinationLocation { get; set; }
        #endregion
    }
}
