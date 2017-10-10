using System.ComponentModel.DataAnnotations.Schema;

namespace PointOfSale.Models
{
    public class Tax : BaseModel
    {
        public string Name { get; set; }
        public decimal? Percentage { get; set; }

        [NotMapped]
        public string Display => $"{Name} ({Percentage} %)";
    }
}
