﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservationApi.Application.CQRS.Guest.Command.Edit
{
    public class EditGuestCommand :GuestDto, IRequest<GuestDto?>
    {
       
    }
}
