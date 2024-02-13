using AutoMapper;
using MediatR;
using ReservationApi.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservationApi.Application.CQRS.Guest.Query.GetById
{
    public class GetByIdGuestQueryHandler : IRequestHandler<GetByIdGuestQuery, GuestDto?>
    {
        private readonly IMapper _mapper;
        private readonly IGuestRepository _guestRepository;

        public GetByIdGuestQueryHandler(IMapper mapper, IGuestRepository guestRepository)
        {
            _mapper = mapper;
            _guestRepository = guestRepository;
        }

        public async Task<GuestDto?> Handle(GetByIdGuestQuery request, CancellationToken cancellationToken)
        {
            var guest = await _guestRepository.GetByIdAsync(request.Id);
            if (guest == null)
            {
                return null;
            }
            var guestDto=_mapper.Map<GuestDto>(guest);
            return guestDto;
        }
    }
}
