using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageFormApi.Application.Features.Messages.Queries
{
    public class MessageDto
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public int ThemeId { get; set; }
        public int ContactId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
