using System.ComponentModel.DataAnnotations.Schema;

namespace UMS.Api.Models
{
    [Table("avRoles", Schema = "auth")]
    public class Role
    {
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public ICollection<UserRole> UserRoles { get; set; }
    }
}
