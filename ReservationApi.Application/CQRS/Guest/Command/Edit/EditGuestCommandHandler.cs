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

namespace ReservationApi.Application.CQRS.Guest.Command.Edit
{
    public class EditGuestCommandHandler : IRequestHandler<EditGuestCommand, GuestDto>
    {
        private readonly IMapper _mapper;
        private readonly IGuestRepository _guestRepository;
        private readonly ILogger<EditGuestCommandHandler> _logger;

        public EditGuestCommandHandler(IMapper mapper, IGuestRepository guestRepository, ILogger<EditGuestCommandHandler> logger)
        {
            _mapper = mapper;
            _guestRepository = guestRepository;
            _logger = logger;
        }

        public async Task<GuestDto> Handle(EditGuestCommand request, CancellationToken cancellationToken)
        {
            if (!await _guestRepository.isExist(request.Id))
            {
                throw new NotFoundExceptions("Guest not found");
            }
            
            var guest = _mapper.Map<Domain.Entities.Guest>(request);
            var updatedGuest = await _guestRepository.UpdateAsync(guest);
            var guestDto=_mapper.Map<GuestDto>(updatedGuest);
            _logger.LogWarning($"Guest with id {guest.Id} edited");
            return guestDto;
        }
    }
}
