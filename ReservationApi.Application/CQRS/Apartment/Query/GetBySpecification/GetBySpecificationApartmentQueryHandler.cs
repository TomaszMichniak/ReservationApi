using AutoMapper;
using MediatR;
using ReservationApi.Application.Pagination;
using ReservationApi.Domain.Entities;
using ReservationApi.Domain.Interfaces;
using ReservationApi.Domain.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservationApi.Application.CQRS.Apartment.Query.GetBySpecification
{
    public class GetBySpecificationApartmentQueryHandler : IRequestHandler<GetBySpecificationApartmentQuery, PageResult<ApartmentDto>>
    {
        private readonly IMapper _mapper;
        private readonly IApartmentRepository _apartmentRepository;
       // private readonly ISpecification<Domain.Entities.Apartment> _specification;

        public GetBySpecificationApartmentQueryHandler(IMapper mapper
            , IApartmentRepository apartmentRepository
            //,ISpecification<Domain.Entities.Apartment> specification
            )
        {
            _mapper = mapper;
            _apartmentRepository = apartmentRepository;
           // _specification = specification;
        }

        public async Task<PageResult<ApartmentDto>> Handle(GetBySpecificationApartmentQuery request, CancellationToken cancellationToken)
        {
            //_specification.Criteria.Add(x => x.MaxGuests == 4);
            Specification<Domain.Entities.Apartment> specification = new();
            if (request.Name !=null)
            {
                specification.Criteria.Add(x => x.Name.ToLower()==request.Name.ToLower());
            }
            if (request.MaxGuests != null)
            {
                specification.Criteria.Add(x => x.MaxGuests == request.MaxGuests);
            }
            if (request.RatePerNight != null)
            {
                specification.Criteria.Add(x => x.RatePerNight == request.RatePerNight);
            }
            if (request.Description != null)
            {
                specification.Criteria.Add(x => x.Description == request.Description);
            }
            var apartment = await _apartmentRepository.FindBySpecification(specification);
            var apartmentDto = _mapper.Map<IEnumerable<ApartmentDto>>(apartment);
            PaginationDto paginationDto= new PaginationDto();
            var pagination = Paginator<ApartmentDto>.Create(apartmentDto,paginationDto);
            return pagination;
        }
    }
}
