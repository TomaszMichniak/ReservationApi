using AutoMapper;
using MediatR;
using ReservationApi.Application.CQRS.Guest;
using ReservationApi.Application.Pagination;
using ReservationApi.Domain.Entities;
using ReservationApi.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservationApi.Application.CQRS.Reservation.Query.GetAll
{
    public class GetAllReservationQueryHandler : IRequestHandler<GetAllReservationQuery, PageResult<ReservationDto>>
    {
        private readonly IMapper _mapper;
        private readonly IReservationRepository _reservationRepository;

        public GetAllReservationQueryHandler(IMapper mapper, IReservationRepository reservationRepository)
        {
            _mapper = mapper;
            _reservationRepository = reservationRepository;
        }

        public async Task<PageResult<ReservationDto>> Handle(GetAllReservationQuery request, CancellationToken cancellationToken)
        {
            var reservation = await _reservationRepository.GetAllAsync();
            var reservationDto = _mapper.Map<IEnumerable<ReservationDto>>(reservation);
            var paggedReservation = Paginator<ReservationDto>.Create(reservationDto, request.Pagination);
            return paggedReservation;
        }
    }
}
