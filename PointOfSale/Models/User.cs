using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointOfSale.Models
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public DateTime? LastLoggedIn { get; set; }
        public virtual ICollection<UserAccessRight> UserAccessRights { get; set; }
    }

    public class TenantUser
    {
        [Key]
        public int Id { get; set; }

        public int TenantId { get; set; }
        public virtual Tenant Tenant { get; set; }

        public int UserId { get; set; }
        public virtual User User { get; set; }
    }

    public class UserAccessRight
    {
        public int Id { get; set; }
        public int AccessRightId { get; set; }
        [ForeignKey("AccessRightId")]
        public virtual AccessRight AccessRight { get; set; }
    }

    public class AccessRight
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
