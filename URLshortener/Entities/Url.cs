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
        public string? ShortUrls { get; set; }
        [Required]
        public string? LongUrls { get; set; }
        [Required]
        public int? UsageCount { get; set; }
        [Required]
        public Categories Category { get; set; }
        public string UserId { get; set; }
    }
}
