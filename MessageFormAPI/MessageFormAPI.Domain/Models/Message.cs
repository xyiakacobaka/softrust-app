using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MessageFormApi.Domain.Models
{
    public class Message
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public int ThemeId { get; set; }

        [ForeignKey(nameof(ThemeId))]
        public required Theme Theme { get; set; }

        public int ContactId { get; set; }

        [ForeignKey(nameof(ContactId))]
        public required Contact Contact { get; set; }

        [Required]
        public required string Content { get; set; }

    }
}
