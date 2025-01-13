using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MessageFormApi.Domain.Models
{
    public class Theme
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        public required string ThemeLabel { get; set; }

        // Навигационное свойство для связи с Messages
        public ICollection<Message> Messages { get; set; } = new List<Message>();
    }
}
