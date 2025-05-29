using System.ComponentModel.DataAnnotations;

namespace Project_CarShope.Models
{
    public class Messages
    {
        public int Id { get; set; }
        [Required]
        public string FullName { get; set; }
        [Required, EmailAddress]
        public string Email { get; set; }
        [Required]
        public string TeaxMess { get; set; }
        public DateTime DateReceived { get; set; }
    }
}
