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

namespace ReservationApi.Application.CQRS.Reservation.Command.Delete
{
    public class DeleteReservationCommandHandler : IRequestHandler<DeleteReservationCommand>
    {
        private readonly IReservationRepository _reservationRepository;
        private readonly ILogger<DeleteReservationCommandHandler> _logger;

        public DeleteReservationCommandHandler(IReservationRepository reservationRepository, ILogger<DeleteReservationCommandHandler> logger)
        {
            _reservationRepository = reservationRepository;
            _logger = logger;
        }

        public async Task Handle(DeleteReservationCommand request, CancellationToken cancellationToken)
        {
            var reservation = await _reservationRepository.GetByIdAsync(request.Id);
            if (reservation == null)
            {
                throw new NotFoundExceptions("Guest not found");
            }
            await _reservationRepository.DeleteAsync(reservation);
            _logger.LogInformation($"Reservation with id {reservation.Id} deleted");
        }
    }
}
