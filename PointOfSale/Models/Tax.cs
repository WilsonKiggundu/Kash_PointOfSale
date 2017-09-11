using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointOfSale.Models
{
    public class Tax : BaseModel
    {
        public string Name { get; set; }
        public decimal? Percentage { get; set; }
    }
}
