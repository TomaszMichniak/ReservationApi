using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using ReservationApi.Application.Exceptions;
using ReservationApi.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservationApi.Application.CQRS.Reservation.Command.Edit
{
    public class EditReservationCommandHandler : IRequestHandler<EditReservationCommand, ReservationDto>
    {
        private readonly IMapper _mapper;
        private readonly IReservationRepository _reservationRepository;
        private readonly IApartmentRepository _apartmentRepository;
        private readonly IGuestRepository _guestRepository;
        private readonly ILogger<EditReservationCommandHandler> _logger;

        public EditReservationCommandHandler(IMapper mapper, IReservationRepository reservationRepository, IApartmentRepository apartmentRepository, IGuestRepository guestRepository, ILogger<EditReservationCommandHandler> logger)
        {
            _mapper = mapper;
            _reservationRepository = reservationRepository;
            _apartmentRepository = apartmentRepository;
            _guestRepository = guestRepository;
            _logger = logger;
        }

        public async Task<ReservationDto> Handle(EditReservationCommand request, CancellationToken cancellationToken)
        {
            if (! await _reservationRepository.isExist(request.Id)
                && !await _apartmentRepository.isExist(request.ApartmentId)
                &&!await _guestRepository.isExist(request.GuestId))
            {
                 throw new NotFoundExceptions("Reservation not found");
            }
            var reservation = _mapper.Map<Domain.Entities.Reservation>(request);
            var newReservation=await _reservationRepository.UpdateAsync(reservation);
            var reservationDto=_mapper.Map<ReservationDto>(newReservation);
            _logger.LogInformation($"Reservation with id {reservation.Id} edited");
            return reservationDto;
        }
    }
}
