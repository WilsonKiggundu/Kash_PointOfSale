using System.Collections.Generic;

namespace PointOfSale.Models
{
    public class Stock : BaseModel
    {
        public StockCategory Category { get; set; }
        public int? SourceId { get; set; }
        public int? DestinationId { get; set; }
        public string Remarks { get; set; }
        public virtual ICollection<StockItem> StockItems { get; set; }  

        #region Navigation Properties
        public virtual Location Source { get; set; }
        public virtual Location Destination { get; set; }
        #endregion
    }
}
