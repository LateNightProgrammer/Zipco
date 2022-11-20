using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    /// <summary>
    /// User Entity
    /// </summary>
    public class User : BaseEntity
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [MaxLength(50)]
        [EmailAddress]
        public string Email { get; set; }

        // The following regular expression accepts only positive values
        [RegularExpression(@"^(\d*\.)?\d+$")]        
        [Column(TypeName = "decimal(14, 2)")]
        public decimal Income { get; set; } = 0.00M;

        // The following regular expression accepts only positive values
        [RegularExpression(@"^(\d*\.)?\d+$")]
        [Column(TypeName = "decimal(14, 2)")]
        public decimal Expenses { get; set; } = 0.00M;

    }
}
