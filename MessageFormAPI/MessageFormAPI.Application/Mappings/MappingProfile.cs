using AutoMapper;
using MessageFormApi.Application.Features.DTOs;
using MessageFormApi.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageFormApi.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Theme, ThemeDto>().ReverseMap();
            CreateMap<Contact, ContactDto>().ReverseMap();
            CreateMap<Message, MessageDto>().ReverseMap();
        }
    }
}
