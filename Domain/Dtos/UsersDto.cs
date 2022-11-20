using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Dtos
{
    public class UsersDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "User name is required")]
        [MaxLength(50, ErrorMessage = "Maximum length for the name is 30 characters")]
        public string Name { get; set; }


        [Required(ErrorMessage = "Email is required")]
        [MaxLength(50, ErrorMessage = "Maximum length for the email is 30 characters")]
        public string Email { get; set; }

        [RegularExpression(@"^(\d*\.)?\d+$")]
        [Column(TypeName = "decimal(14, 2)")]
        public decimal Income { get; set; } = 0.00M;

        [RegularExpression(@"^(\d*\.)?\d+$")]
        [Column(TypeName = "decimal(14, 2)")]
        public decimal Expenses { get; set; } = 0.0M;
    }
}
