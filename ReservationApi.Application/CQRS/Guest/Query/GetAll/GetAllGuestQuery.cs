using MediatR;
using ReservationApi.Application.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservationApi.Application.CQRS.Guest.Query.GetAll
{
    public class GetAllGuestQuery:IRequest<PageResult<GuestDto>>
    {
        public PaginationDto Pagination { get; set; }

    public GetAllGuestQuery(PaginationDto pagination)
    {
        Pagination = pagination;
    }
}
}
