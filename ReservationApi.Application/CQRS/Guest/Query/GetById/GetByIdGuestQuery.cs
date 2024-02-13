using MediatR;
using ReservationApi.Application.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservationApi.Application.CQRS.Guest.Query.GetById
{
    public class GetByIdGuestQuery :IRequest<GuestDto?>
    {
        public Guid Id { get; set; }

        public GetByIdGuestQuery(Guid id)
        {
            Id = id;
        }
    }
}
