﻿using AutoMapper;
using MediatR;
using ReservationApi.Domain.Entities;
using ReservationApi.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservationApi.Application.CQRS.Reservation.Command.Create
{
    public class CreateReservationCommandHander : IRequestHandler<CreateReservationCommand, ReservationDto?>
    {
        private readonly IMapper _mapper;
        private readonly IReservationRepository _reservationRepository;
        private readonly IApartmentRepository _apartmentRepository;
        private readonly IGuestRepository _guestRepository;

        public CreateReservationCommandHander(IMapper mapper, IReservationRepository reservationRepository, IApartmentRepository apartmentRepository, IGuestRepository guestRepository)
        {
            _mapper = mapper;
            _reservationRepository = reservationRepository;
            _apartmentRepository = apartmentRepository;
            _guestRepository = guestRepository;
        }

        public async Task<ReservationDto?> Handle(CreateReservationCommand request, CancellationToken cancellationToken)
        {
            if (!await _apartmentRepository.isExist(request.ApartmentId)
                &&!await _guestRepository.isExist(request.GuestId))
            {
                return null;
            }
            var reservation=_mapper.Map<Domain.Entities.Reservation>(request);
            if (reservation.TotalPrice==0)
            {
                var apartmentPrice =_apartmentRepository.GetPrice(reservation.ApartmentId);
                var days=(reservation.CheckOutDate.Day-reservation.CheckInDate.Day);
                reservation.TotalPrice = apartmentPrice * days;
            }
            var newReservation=await _reservationRepository.CreateAsync(reservation);
            var reservationDto=_mapper.Map<ReservationDto>(newReservation);
            return reservationDto;
        }
        //TODO better Create
    }
}
