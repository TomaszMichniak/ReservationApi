using AutoMapper;
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
using MediatR;

namespace ReservationApi.Application.CQRS.Reservation.Query.GetBySpecification
{
    public class GetBySpecificationReservationQueryHandler : IRequestHandler<GetBySpecificationReservationQuery, PageResult<ReservationDto>>
    {
        private readonly IMapper _mapper;
        private readonly IReservationRepository _reservationRepository;

        public GetBySpecificationReservationQueryHandler(IMapper mapper, IReservationRepository reservationRepository)
        {
            _mapper = mapper;
            _reservationRepository = reservationRepository;
        }

        public async Task<PageResult<ReservationDto>> Handle(GetBySpecificationReservationQuery request, CancellationToken cancellationToken)
        {
            Specification<Domain.Entities.Reservation> specification = new();
            specification = AddCriteria(request, specification);
            AddOrderBy(request, specification);
            var reservation = await _reservationRepository.FindBySpecification(specification);
            var reservationDto = _mapper.Map<IEnumerable<ReservationDto>>(reservation);
            PaginationDto paginationDto = new PaginationDto();
            var pagination = Paginator<ReservationDto>.Create(reservationDto, paginationDto);
            return pagination;
        }
        private void AddOrderBy(GetBySpecificationReservationQuery request, Specification<Domain.Entities.Reservation> specification)
        {
            switch (request.ReservationOrderBy)
            {
                case ReservationOrderBy.CheckInDate:
                    specification.SetOrderBy(request.OrderBy, x => x.CheckInDate);
                    break;
                case ReservationOrderBy.CheckOutDate:
                    specification.SetOrderBy(request.OrderBy, x => x.CheckOutDate);
                    break;
                case ReservationOrderBy.ReservationDate:
                    specification.SetOrderBy(request.OrderBy, x => x.ReservationDate);
                    break;
                case ReservationOrderBy.TotalPrice:
                    specification.SetOrderBy(request.OrderBy, x => x.TotalPrice);
                    break;
                case ReservationOrderBy.TotalGuests:
                    specification.SetOrderBy(request.OrderBy, x => x.TotalGuests);
                    break;
                default:
                    break;
            }
        }
        private Specification<Domain.Entities.Reservation> AddCriteria(GetBySpecificationReservationQuery request, Specification<Domain.Entities.Reservation> specification)
        {
            if (request.CheckInDate != null)
            {
                specification.Criteria.Add(x => x.CheckInDate==request.CheckInDate);
            }
            if (request.CheckOutDate != null)
            {
                specification.Criteria.Add(x => x.CheckOutDate == request.CheckOutDate);
            }
            if (request.ReservationDate != null)
            {
                specification.Criteria.Add(x => x.ReservationDate == request.ReservationDate);
            }
            if (request.TotalPrice != null)
            {
                specification.Criteria.Add(x => x.TotalPrice == request.TotalPrice);
            } if (request.TotalGuests != null)
            {
                specification.Criteria.Add(x => x.TotalGuests == request.TotalGuests);
            }
            return specification;
        }
    }
}
