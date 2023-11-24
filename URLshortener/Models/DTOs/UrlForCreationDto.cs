using System.ComponentModel.DataAnnotations;
using URLshortener.Models;

namespace UrlShorterer.Models
{
    public class UrlForCreationDto
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string? ShortUrls { get; set; }
        [Required]
        public string? LongUrls { get; set; }
        public int UsageCount { get; set; }
        public Categories Category { get; set; }
    }
}