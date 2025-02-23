using System.ComponentModel.DataAnnotations;
using System.Text;

namespace UserManagement.API.Models
{
    public class User
    {
        private static int SEQUENCIAL = 0;
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string? Name { get; set; }
        [Required]
        [MaxLength(100)]
        [EmailAddress]
        public string? Email { get; set; }
        [Required]
        [MaxLength(30)]
        public string? Password { get; set; }

        public static int GenerateId()
        {
            return ++SEQUENCIAL;
        }
    }
}
