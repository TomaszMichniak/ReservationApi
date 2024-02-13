using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservationApi.Application.CQRS.Reservation.Command.Delete
{
    public class DeleteReservationCommand:IRequest
    {
        public Guid Id { get; set; }

        public DeleteReservationCommand(Guid id)
        {
            Id = id;
        }
    }
}
