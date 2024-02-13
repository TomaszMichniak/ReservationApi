using AutoMapper;
using MediatR;
using ReservationApi.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservationApi.Application.CQRS.Guest.Command.Create
{
    public class CreateGuestCommandHandler : IRequestHandler<CreateGuestCommand, GuestDto>
    {
        private readonly IMapper _mapper;
        private readonly IGuestRepository _guestRepository;

        public CreateGuestCommandHandler(IMapper mapper, IGuestRepository guestRepository)
        {
            _mapper = mapper;
            _guestRepository = guestRepository;
        }

        public async Task<GuestDto> Handle(CreateGuestCommand request, CancellationToken cancellationToken)
        {
            var guest = _mapper.Map<Domain.Entities.Guest>(request);
            var newGuest=await _guestRepository.CreateAsync(guest);
            var guestDto=_mapper.Map<GuestDto>(newGuest);
            return guestDto;
        }
    }
}
