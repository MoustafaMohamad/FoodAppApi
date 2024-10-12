using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodAppApi.Models
{
    public class User:BaseModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Phone { get; set; }
        public string Country { get; set; }
        public string Password { get; set; }
        [ForeignKey("Role")]
        public int RoleID {  get; set; }
        public Role Role { get; set; }
    }
}
