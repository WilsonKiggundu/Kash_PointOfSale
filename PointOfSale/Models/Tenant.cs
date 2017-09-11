using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointOfSale.Models
{
    public class Tenant
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public TenantCategory Category { get; set; }
        public bool Active { get; set; }
        public DateTime? LastPaymentDate { get; set; }
        public string Telephone { get; set; }
        public string Address { get; set; }
        public string PostalAddress { get; set; }
        public string Logo { get; set; }    
    }
}
