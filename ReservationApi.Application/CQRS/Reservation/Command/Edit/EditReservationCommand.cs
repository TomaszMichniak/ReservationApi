using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservationApi.Application.CQRS.Reservation.Command.Edit
{
    public class EditReservationCommand:ReservationDto,IRequest<ReservationDto>
    {

    }
}
