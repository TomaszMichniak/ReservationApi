using AutoMapper;
using MediatR;
using ReservationApi.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservationApi.Application.CQRS.Reservation.Command.Edit
{
    public class EditReservationCommandHandler : IRequestHandler<EditReservationCommand, ReservationDto?>
    {
        private readonly IMapper _mapper;
        private readonly IReservationRepository _reservationRepository;
        private readonly IApartmentRepository _apartmentRepository;
        private readonly IGuestRepository _guestRepository;

        public EditReservationCommandHandler(IMapper mapper, IReservationRepository reservationRepository, IApartmentRepository apartmentRepository, IGuestRepository guestRepository)
        {
            _mapper = mapper;
            _reservationRepository = reservationRepository;
            _apartmentRepository = apartmentRepository;
            _guestRepository = guestRepository;
        }

        public async Task<ReservationDto?> Handle(EditReservationCommand request, CancellationToken cancellationToken)
        {
            if (! await _reservationRepository.isExist(request.Id)
                && !await _apartmentRepository.isExist(request.ApartmentId)
                &&!await _guestRepository.isExist(request.GuestId))
            {
                return null;
            }
            var reservation = _mapper.Map<Domain.Entities.Reservation>(request);
            var newReservation=await _reservationRepository.UpdateAsync(reservation);
            var reservationDto=_mapper.Map<ReservationDto>(newReservation);
            return reservationDto;
        }
    }
}
