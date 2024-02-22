using AutoMapper;
using MediatR;
using ReservationApi.Application.CQRS.Apartment;
using ReservationApi.Application.Exceptions;
using ReservationApi.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservationApi.Application.CQRS.Apartment.Query.GetById
{
    public class GetByIdApartmentQueryHandler : IRequestHandler<GetByIdApartmentQuery, ApartmentDto>
    {
        private readonly IMapper _mapper;
        private readonly IApartmentRepository _apartmentRepository;

        public GetByIdApartmentQueryHandler(IMapper mapper, IApartmentRepository apartmentRepository)
        {
            _mapper = mapper;
            _apartmentRepository = apartmentRepository;
        }

        public async Task<ApartmentDto> Handle(GetByIdApartmentQuery request, CancellationToken cancellationToken)
        {
            var apartment = await _apartmentRepository.GetByIdAsync(request.Id);
            if (apartment == null)
            {
                throw new NotFoundExceptions("Apartment not found");
            }
            var apartmentDto = _mapper.Map<ApartmentDto>(apartment);
            return apartmentDto;
        }
    }
}
