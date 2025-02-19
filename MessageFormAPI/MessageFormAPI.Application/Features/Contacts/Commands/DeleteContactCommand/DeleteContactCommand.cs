﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageFormApi.Application.Features.Contacts.Commands.DeleteContactCommand
{
    public class DeleteContactCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }
}
