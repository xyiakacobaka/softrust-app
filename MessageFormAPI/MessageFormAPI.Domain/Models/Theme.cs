using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace MessageFormApi.Domain.Models
{
    public class Theme
    {
        [Key]
        [JsonPropertyName("id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        [JsonPropertyName("label")]
        public required string ThemeLabel { get; set; }

        // Навигационное свойство для связи с Messages
        public ICollection<Message> Messages { get; set; } = new List<Message>();
    }
}
