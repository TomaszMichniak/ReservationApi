using MediatR;
using ReservationApi.Application.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservationApi.Application.CQRS.Reservation.Query.GetAll
{
    public class GetAllReservationQuery : IRequest<PageResult<ReservationDto>>
    {
        public PaginationDto Pagination { get; set; }

        public GetAllReservationQuery(PaginationDto pagination)
        {
            Pagination = pagination;
        }
    }
}
