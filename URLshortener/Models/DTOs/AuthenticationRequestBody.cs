using System.ComponentModel.DataAnnotations;

namespace URLshortener.Models.DTOs
{
    public class AuthenticationRequestBody
    {
        [Required]
        public string? Email { get; set; }
        [Required]
        public string? Password { get; set; }
    }
}
