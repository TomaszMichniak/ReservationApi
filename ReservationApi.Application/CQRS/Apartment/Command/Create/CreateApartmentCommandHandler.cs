using AutoMapper;
using MediatR;
using ReservationApi.Domain.Interfaces;
using ReservationApi.Domain.Entities;

namespace ReservationApi.Application.CQRS.Apartment.Command.Create
{
    public class CreateApartmentCommandHandler : IRequestHandler<CreateApartmentCommand, ApartmentDto?>
    {
        private readonly IMapper _mapper;
        private readonly IApartmentRepository _apartmentRepository;

        public CreateApartmentCommandHandler(IMapper mapper, IApartmentRepository apartmentRepository)
        {
            _mapper = mapper;
            _apartmentRepository = apartmentRepository;
        }

        public async Task<ApartmentDto?> Handle(CreateApartmentCommand request, CancellationToken cancellationToken)
        {
            var apartment = _mapper.Map<Domain.Entities.Apartment>(request);
            var newApartment = await _apartmentRepository.CreateAsync(apartment);
            var apartmentDto = _mapper.Map<ApartmentDto>(newApartment);
            return apartmentDto;
        }
    }
}
