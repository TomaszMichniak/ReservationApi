using AutoMapper;
using MediatR;
using ReservationApi.Application.Pagination;
using ReservationApi.Domain.Entities;
using ReservationApi.Domain.Interfaces;
using ReservationApi.Domain.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace ReservationApi.Application.CQRS.Apartment.Query.GetBySpecification
{
    public class GetBySpecificationApartmentQueryHandler : IRequestHandler<GetBySpecificationApartmentQuery, PageResult<ApartmentDto>>
    {
        private readonly IMapper _mapper;
        private readonly IApartmentRepository _apartmentRepository;

        public GetBySpecificationApartmentQueryHandler(IMapper mapper
            , IApartmentRepository apartmentRepository
            )
        {
            _mapper = mapper;
            _apartmentRepository = apartmentRepository;
        }

        public async Task<PageResult<ApartmentDto>> Handle(GetBySpecificationApartmentQuery request, CancellationToken cancellationToken)
        {
            Specification<Domain.Entities.Apartment> specification = new();
            specification = AddCriteria(request, specification);
            AddOrderBy(request, specification);
            var apartment = await _apartmentRepository.FindBySpecification(specification);
            var apartmentDto = _mapper.Map<IEnumerable<ApartmentDto>>(apartment);
            var pagination = Paginator<ApartmentDto>.Create(apartmentDto,request.Pagination);
            return pagination;
        }
        private void AddOrderBy(GetBySpecificationApartmentQuery request, Specification<Domain.Entities.Apartment> specification)
        {
            switch (request.ApartmentOrderBy)
            {
                case ApartmentOrderBy.Name:
                    specification.SetOrderBy(request.OrderBy, x => x.Name);
                    break;
                case ApartmentOrderBy.Description:
                    specification.SetOrderBy(request.OrderBy, x => x.Description);
                    break;
                case ApartmentOrderBy.MaxGuests:
                    specification.SetOrderBy(request.OrderBy, x => x.MaxGuests);
                    break;
                case ApartmentOrderBy.RatePerNight:
                    specification.SetOrderBy(request.OrderBy, x => x.RatePerNight);
                    break;
                default:
                    break;
            }
        }
        private Specification<Domain.Entities.Apartment>  AddCriteria(GetBySpecificationApartmentQuery request,Specification<Domain.Entities.Apartment> specification)
        {
            if (request.Name != null)
            {
                specification.Criteria.Add(x => x.Name.ToLower().Contains(request.Name.ToLower()));
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
                specification.Criteria.Add(x => x.Description.ToLower().Contains(request.Description.ToLower()));
            }
            return specification;
        }
    }
}
