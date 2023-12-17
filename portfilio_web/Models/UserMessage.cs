using System.ComponentModel.DataAnnotations;

namespace portfilio_web.Models
{
    public class UserMessage
    {
        [Key]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Object { get; set; }

        [Required]
        public string Message { get; set; }


    }
}
