using System.ComponentModel.DataAnnotations.Schema;

namespace UMS.Api.Models
{
    [Table("avProjectMember", Schema = "project")]
    public class ProjectMember
    {
        public int Id { get; set; }

        public int ProjectId { get; set; }

        public required Project Project { get; set; } 

        public int UserId { get; set; }

        public required User User { get; set; }

        public required string Role { get; set; }
    }
}
