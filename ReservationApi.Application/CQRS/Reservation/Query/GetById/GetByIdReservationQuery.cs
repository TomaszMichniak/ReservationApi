using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservationApi.Application.CQRS.Reservation.Query.GetById
{
    public class GetByIdReservationQuery: IRequest<ReservationDto>
    {
        public Guid Id { get; set; }

        public GetByIdReservationQuery(Guid id)
        {
            Id = id;
        }
    }
}
