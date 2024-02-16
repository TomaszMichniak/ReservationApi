using MediatR;
using ReservationApi.Application.Pagination;
using ReservationApi.Domain.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservationApi.Application.CQRS.Reservation.Query.GetBySpecification
{
    public class GetBySpecificationReservationQuery : IRequest<PageResult<ReservationDto>>
    {
        public PaginationDto Pagination { get; set; } = new();
        public DateTime? CheckInDate { get; set; }
        public DateTime? CheckOutDate { get; set; }
        public DateTime? ReservationDate { get; set; }
        public int? TotalGuests { get; set; }
        public decimal? TotalPrice { get; set; }
        public ReservationOrderBy ReservationOrderBy { get; set; } = 0;
        public OrderBy OrderBy { get; set; } = 0;
    }
    public enum ReservationOrderBy
    {
        CheckInDate,
        CheckOutDate,
        ReservationDate,
        TotalGuests,
        TotalPrice
    }
}

