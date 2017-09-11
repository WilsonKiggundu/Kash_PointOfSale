using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointOfSale.Models
{
    public class Product : BaseModel
    {
        public string Name { get; set; }
        public string Units { get; set; }   
        public decimal? CostPrice { get; set; }
        public decimal? SellPrice { get; set; }
        public string Barcode { get; set; }
        public decimal OpeningStock { get; set; }
        public string Code { get; set; }
        public ProductType? ProductType { get; set; }
        public decimal? MinStock { get; set; }
        public decimal? MaxStock { get; set; }
        public bool Sale { get; set; }
        public bool Purchase { get; set; }
        public int? SaleAccountId { get; set; }
        public Account SaleAccount { get; set; }    
        public int? PurchaseAccountId { get; set; }
        public Account PurchaseAccount { get; set; }
        public Stock Stock { get; set; }    
    }
}
