using MediatR;
using ReservationApi.Application.CQRS.Apartment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservationApi.Application.CQRS.Apartment.Command.Edit
{
    public class EditApartmentCommand : ApartmentDto, IRequest<ApartmentDto>
    {

    }
}
