using AutoMapper;
using MediatR;
using ReservationApi.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservationApi.Application.CQRS.Guest.Command.Edit
{
    public class EditGuestCommandHandler : IRequestHandler<EditGuestCommand, GuestDto?>
    {
        private readonly IMapper _mapper;
        private readonly IGuestRepository _guestRepository;

        public EditGuestCommandHandler(IMapper mapper, IGuestRepository guestRepository)
        {
            _mapper = mapper;
            _guestRepository = guestRepository;
        }

        public async Task<GuestDto?> Handle(EditGuestCommand request, CancellationToken cancellationToken)
        {
            if (!await _guestRepository.isExist(request.Id))
            {
                return null;
            }
            var guest = _mapper.Map<Domain.Entities.Guest>(request);
            var updatedGuest = await _guestRepository.UpdateAsync(guest);
            var guestDto=_mapper.Map<GuestDto>(updatedGuest);
            return guestDto;
        }
    }
}
