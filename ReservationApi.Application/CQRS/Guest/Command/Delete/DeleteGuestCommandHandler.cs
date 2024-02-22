using MediatR;
using Microsoft.Extensions.Logging;
using ReservationApi.Application.Exceptions;
using ReservationApi.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservationApi.Application.CQRS.Guest.Command.Delete
{
    public class DeleteGuestCommandHandler : IRequestHandler<DeleteGuestCommand>
    {
        private readonly IGuestRepository _guestRepository;
        private readonly ILogger<DeleteGuestCommandHandler> _logger;

        public DeleteGuestCommandHandler(IGuestRepository guestRepository, ILogger<DeleteGuestCommandHandler> logger)
        {
            _guestRepository = guestRepository;
            _logger = logger;
        }

        public async Task Handle(DeleteGuestCommand request, CancellationToken cancellationToken)
        {
            var guest = await _guestRepository.GetByIdAsync(request.Id);
            if (guest == null)
            {
                throw new NotFoundExceptions("Guest not found");
            }
            await _guestRepository.DeleteAsync(guest);
            _logger.LogWarning($"Guest with id {guest.Id} deleted");
        }
    }
}
