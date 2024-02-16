using MediatR;
using ReservationApi.Application.Pagination;
using ReservationApi.Domain.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservationApi.Application.CQRS.Guest.Query.GetBySpecification
{
    public class GetBySpecificationGuestQuery: IRequest<PageResult<GuestDto>>
    {
        public PaginationDto Pagination { get; set; } = new();
        public string? Email { get; set; } = default!;
        public string? FirstName { get; set; } = default!;
        public string? LastName { get; set; } = default!;
        public string? Phone { get; set; } = default!;
        public GuestOrderBy GuestOrderBy { get; set; } = 0;
        public OrderBy OrderBy { get; set; } = 0;
    }
    public enum GuestOrderBy
    {
        Email,
        FirstName,
        LastName,
        Phone
    }

}
