using MediatR;
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
        public IGuestRepository _guestRepository;

        public DeleteGuestCommandHandler(IGuestRepository guestRepository)
        {
            _guestRepository = guestRepository;
        }

        public async Task Handle(DeleteGuestCommand request, CancellationToken cancellationToken)
        {
            var guest = await _guestRepository.GetByIdAsync(request.Id);
            if (guest == null)
            {
                return;
            }
            await _guestRepository.DeleteAsync(guest);
        }
    }
}
