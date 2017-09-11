using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointOfSale.ViewModels
{
    public class AccessRightsViewModel
    {
        public int Id { get; set; }
        public string RoleName { get; set; }    
        public string Description { get; set; }
        // public bool HasAccessRight { get; set; }
    }
}
