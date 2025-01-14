﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageFormApi.Application.Features.DTOs
{
    public class PagedResponse<T>
    {
        public IEnumerable<T> Data { get; set; } 
        public int Page { get; set; } 
        public int PageSize { get; set; }
        public int TotalCount { get; set; } 
        public int TotalPages => (int)Math.Ceiling(TotalCount / (double)PageSize);
    }
}
