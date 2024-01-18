using MediatR;
using ReservationApi.Application.Pagination;

namespace ReservationApi.Application.ApartmentCQRS.Query.GetAll
{
    public class GetAllApartmentQuery :IRequest<PageResult<ApartmentDto>>
    {
        public PaginationDto Pagination { get; set; }

        public GetAllApartmentQuery(PaginationDto pagination)
        {
            Pagination = pagination;
        }
    }
}
