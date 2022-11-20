using System.ComponentModel.DataAnnotations;

namespace Domain.Dtos
{
    public class AccountsDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "UserId is a required field")]
        [Range(1, int.MaxValue, ErrorMessage = "UserId required and it can't be lower than 0")]
        public int UserId { get; set; }
    }
}
