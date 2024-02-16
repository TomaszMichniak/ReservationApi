using AutoMapper;
using MediatR;
using ReservationApi.Application.CQRS.Apartment.Query.GetBySpecification;
using ReservationApi.Application.CQRS.Apartment;
using ReservationApi.Application.Pagination;
using ReservationApi.Domain.Interfaces;
using ReservationApi.Domain.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservationApi.Application.CQRS.Guest.Query.GetBySpecification
{
    public class GetBySpecificationGuestQueryHandler : IRequestHandler<GetBySpecificationGuestQuery, PageResult<GuestDto>>
    {
        private readonly IMapper _mapper;
        private readonly IGuestRepository _guestRepository;

        public GetBySpecificationGuestQueryHandler(IMapper mapper, IGuestRepository guestRepository)
        {
            _mapper = mapper;
            _guestRepository = guestRepository;
        }

        public async Task<PageResult<GuestDto>> Handle(GetBySpecificationGuestQuery request, CancellationToken cancellationToken)
        {
            Specification<Domain.Entities.Guest> specification = new();
            specification = AddCriteria(request, specification);
            AddOrderBy(request, specification);
            var guests = await _guestRepository.FindBySpecification(specification);
            var guestDto = _mapper.Map<IEnumerable<GuestDto>>(guests);
            var pagination = Paginator<GuestDto>.Create(guestDto, request.Pagination);
            return pagination;
        }
        private void AddOrderBy(GetBySpecificationGuestQuery request, Specification<Domain.Entities.Guest> specification)
        {
            switch (request.GuestOrderBy)
            {
                case GuestOrderBy.FirstName:
                    specification.SetOrderBy(request.OrderBy, x => x.FirstName);
                    break;
                case GuestOrderBy.LastName:
                    specification.SetOrderBy(request.OrderBy, x => x.LastName);
                    break;
                case GuestOrderBy.Phone:
                    specification.SetOrderBy(request.OrderBy, x => x.Phone);
                    break;
                case GuestOrderBy.Email:
                    specification.SetOrderBy(request.OrderBy, x => x.Email);
                    break;
                default:
                    break;
            }
        }
        private Specification<Domain.Entities.Guest> AddCriteria(GetBySpecificationGuestQuery request, Specification<Domain.Entities.Guest> specification)
        {
            if (request.FirstName != null)
            {
                specification.Criteria.Add(x => x.FirstName.ToLower().Contains(request.FirstName.ToLower()));
            }
            if (request.LastName != null)
            {
                specification.Criteria.Add(x => x.LastName.ToLower().Contains(request.LastName.ToLower()));
            }
            if (request.Phone != null)
            {
                specification.Criteria.Add(x => x.Phone.Contains(request.Phone));
            }
            if (request.Email != null)
            {
                specification.Criteria.Add(x => x.Email.ToLower().Contains(request.Email.ToLower()));
            }
            return specification;
        }
    }
}
