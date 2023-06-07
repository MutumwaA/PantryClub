using System.ComponentModel.DataAnnotations;

namespace PantryClub.Services.Users.Models
{
    public class User
    {
        [Key]
        public Guid UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
