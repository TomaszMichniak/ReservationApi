using AutoMapper;
using MediatR;
using ReservationApi.Application.Exceptions;
using ReservationApi.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservationApi.Application.CQRS.Reservation.Query.GetById
{
    public class GetByIdReservationQueryHandler : IRequestHandler<GetByIdReservationQuery, ReservationDto>
    {
        private readonly IMapper _mapper;
        private readonly IReservationRepository _reservationRepository;

        public GetByIdReservationQueryHandler(IMapper mapper, IReservationRepository reservationRepository)
        {
            _mapper = mapper;
            _reservationRepository = reservationRepository;
        }

        public async Task<ReservationDto> Handle(GetByIdReservationQuery request, CancellationToken cancellationToken)
        {
            var reservation = await _reservationRepository.GetByIdAsync(request.Id);
            if (reservation == null)
            {
                throw new NotFoundExceptions("Reservation not found");
            }
            var reservationDto =_mapper.Map<ReservationDto>(reservation);
            return reservationDto;
        }
    }
}
