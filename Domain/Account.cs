using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Emit;
using System.Reflection.Metadata;

namespace Domain
{
    /// <summary>
    /// Account Entity
    /// </summary>
    public class Account :BaseEntity
    {
        [ForeignKey(nameof(AccountUser))]
        [Required]        
        public int UserId { get; set; }

        public User AccountUser { get; set; }
       
    }
}
