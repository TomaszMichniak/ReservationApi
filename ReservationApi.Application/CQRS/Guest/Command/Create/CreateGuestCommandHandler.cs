using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
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
        private readonly ILogger<CreateGuestCommandHandler> _logger;

        public CreateGuestCommandHandler(IMapper mapper, IGuestRepository guestRepository, ILogger<CreateGuestCommandHandler> logger)
        {
            _mapper = mapper;
            _guestRepository = guestRepository;
            _logger = logger;
        }

        public async Task<GuestDto> Handle(CreateGuestCommand request, CancellationToken cancellationToken)
        {
            var guest = _mapper.Map<Domain.Entities.Guest>(request);
            var newGuest=await _guestRepository.CreateAsync(guest);
            var guestDto=_mapper.Map<GuestDto>(newGuest);
            _logger.LogInformation($"Guest with id {guestDto.Id} created");
            return guestDto;
        }
    }
}
