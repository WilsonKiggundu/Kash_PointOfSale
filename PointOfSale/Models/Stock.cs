using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointOfSale.Models
{
    public class Stock : BaseModel
    {
        public virtual Product Product { get; set; }
        public decimal Count { get; set; }  
    }
}
