using AutoMapper;
using MediatR;
using ReservationApi.Application.CQRS.Apartment;
using ReservationApi.Application.Pagination;
using ReservationApi.Domain.Interfaces;

namespace ReservationApi.Application.CQRS.Apartment.Query.GetAll
{
    public class GetAllApartmentQueryHandler : IRequestHandler<GetAllApartmentQuery, PageResult<ApartmentDto>>
    {
        private readonly IMapper _mapper;
        private readonly IApartmentRepository _apartmentReposity;

        public GetAllApartmentQueryHandler(IMapper mapper, IApartmentRepository apartmentReposity)
        {
            _mapper = mapper;
            _apartmentReposity = apartmentReposity;
        }

        public async Task<PageResult<ApartmentDto>> Handle(GetAllApartmentQuery request, CancellationToken cancellationToken)
        {
            var apartments = await _apartmentReposity.GetAllAsync();
            var apartmentsDto = _mapper.Map<IEnumerable<ApartmentDto>>(apartments);
            var pagination = Paginator<ApartmentDto>.Create(apartmentsDto, request.Pagination);
            return pagination;
        }
    }
}
