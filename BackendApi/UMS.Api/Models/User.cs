using System.ComponentModel.DataAnnotations.Schema;

namespace UMS.Api.Models
{
    [Table("avUsers", Schema = "auth")]
    public class User
    { 
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedOn { get; set; }
        public ICollection<UserRole> UserRoles { get; set; }
    }
}
