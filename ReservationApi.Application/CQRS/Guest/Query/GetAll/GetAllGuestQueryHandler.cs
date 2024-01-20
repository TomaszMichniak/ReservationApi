using AutoMapper;
using MediatR;
using ReservationApi.Application.Pagination;
using ReservationApi.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservationApi.Application.CQRS.Guest.Query.GetAll
{
    public class GetAllGuestQueryHandler : IRequestHandler<GetAllGuestQuery, PageResult<GuestDto>>
    {
        private readonly IMapper _mapper;
        private readonly IGuestRepository _guestRepository;

        public GetAllGuestQueryHandler(IMapper mapper, IGuestRepository guestRepository)
        {
            _mapper = mapper;
            _guestRepository = guestRepository;
        }

        public async Task<PageResult<GuestDto>> Handle(GetAllGuestQuery request, CancellationToken cancellationToken)
        {
            var guests = await _guestRepository.GetAllAsync();
            var guestDto=_mapper.Map<IEnumerable<GuestDto>>(guests);
            var paggedGuest = Paginator<GuestDto>.Create(guestDto,request.Pagination);
            return paggedGuest;
        }
    }
}
