using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MessageFormApi.Domain.Models
{
   
    public class Contact
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        public required string UserName { get; set; }

        [Required]
        [MaxLength(255)]
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "Invalid email format.")]
        public required string Email { get; set; }

        [MaxLength(20)]
        [RegularExpression(@"^8\d{10}", ErrorMessage = "Invalid phone format.")]
        public required string PhoneNumber { get; set; }

        public ICollection<Message> Messages { get; set; } = new List<Message>();
    }
}
