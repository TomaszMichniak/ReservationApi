using AutoMapper;
using MediatR;
using ReservationApi.Domain.Interfaces;
using ReservationApi.Domain.Entities;
using Microsoft.Extensions.Logging;

namespace ReservationApi.Application.CQRS.Apartment.Command.Create
{
    public class CreateApartmentCommandHandler : IRequestHandler<CreateApartmentCommand, ApartmentDto>
    {
        private readonly IMapper _mapper;
        private readonly IApartmentRepository _apartmentRepository;
        private readonly ILogger<CreateApartmentCommandHandler> _logger;

        public CreateApartmentCommandHandler(IMapper mapper, IApartmentRepository apartmentRepository, ILogger<CreateApartmentCommandHandler> logger)
        {
            _mapper = mapper;
            _apartmentRepository = apartmentRepository;
            _logger = logger;
        }

        public async Task<ApartmentDto> Handle(CreateApartmentCommand request, CancellationToken cancellationToken)
        {
            var apartment = _mapper.Map<Domain.Entities.Apartment>(request);
            var newApartment = await _apartmentRepository.CreateAsync(apartment);
            var apartmentDto = _mapper.Map<ApartmentDto>(newApartment);
            _logger.LogInformation($"Apartment with id {newApartment.Id} created");
            return apartmentDto;
        }
    }
}
