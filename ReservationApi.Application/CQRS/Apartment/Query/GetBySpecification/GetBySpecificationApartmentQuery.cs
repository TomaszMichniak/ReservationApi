using MediatR;
using ReservationApi.Application.Pagination;
using ReservationApi.Domain.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ReservationApi.Application.CQRS.Apartment.Query.GetBySpecification
{
    public class GetBySpecificationApartmentQuery : IRequest<PageResult<ApartmentDto>>
    {
        //public PaginationDto Pagination { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int? MaxGuests { get; set; }
        public decimal? RatePerNight { get; set; }
        public ApartmentOrderBy ApartmentOrderBy { get; set; } =0;
        public OrderBy OrderBy { get; set; } = 0;
    } 
    public enum ApartmentOrderBy {
        Name,
        Description,
        MaxGuests,
        RatePerNight
    }
    
}
