using MediatR;
using ReservationApi.Application.ApartmentCQRS.Command.Create;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservationApi.Application.ApartmentCQRS.Command.Edit
{
    public class EditApartmentCommand : ApartmentDto, IRequest<ApartmentDto?>
    {
        
    }
}
