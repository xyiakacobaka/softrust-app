using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageFormApi.Application.Features.DTOs
{
    public class DeleteResultDto
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
    }
}
