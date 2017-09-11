using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PointOfSale.Helpers;

namespace PointOfSale.Models
{
    public class BaseModel
    {
        [Key]
        public int Id { get; set; }
        public int? WebId { get; set; }
        public int TenantId { get; set; }   
        public virtual Tenant Tenant { get; set; }
        public int? UserId { get; set; }
        public virtual User User { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateModified { get; set; }
        public bool IsDeleted { get; set; }

        public BaseModel()
        {
            DateCreated = DateTime.Now;
            IsDeleted = false;
            TenantId = Session.TenantId;
            UserId = Session.UserId;
        }

    }
}
