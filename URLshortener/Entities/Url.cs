using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using URLshortener.Models;

namespace URLshortener.Entities
{
    public class Url
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string? ShortUrls { get; set; }
        [Required]
        [StringLength(500)]
        public string? LongUrl { get; set; } = string.Empty;
        public User User { get; set; }
        public int? UsageCount { get; set; }
        public Categories Category { get; set; }
    }
}
