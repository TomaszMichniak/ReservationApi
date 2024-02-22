using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using ReservationApi.Application.Exceptions;
using ReservationApi.Domain.Entities;
using ReservationApi.Domain.Interfaces;

namespace ReservationApi.Application.CQRS.Apartment.Command.Edit
{
    public class EditApartmentCommandHandler : IRequestHandler<EditApartmentCommand, ApartmentDto>
    {
        private readonly IMapper _mapper;
        private readonly IApartmentRepository _apartmentRepository;
        private readonly ILogger<EditApartmentCommandHandler> _logger;

        public EditApartmentCommandHandler(IMapper mapper, IApartmentRepository apartmentRepository, ILogger<EditApartmentCommandHandler> logger)
        {
            _mapper = mapper;
            _apartmentRepository = apartmentRepository;
            _logger = logger;
        }

        public async Task<ApartmentDto> Handle(EditApartmentCommand request, CancellationToken cancellationToken)
        {
            if (!await _apartmentRepository.isExist(request.Id))
            {
                throw new NotFoundExceptions("Apartment not Found");
            }
            var apartment = _mapper.Map<Domain.Entities.Apartment>(request);
            var resultApartment =await _apartmentRepository.UpdateAsync(apartment);
            var apartmentDto = _mapper.Map<ApartmentDto>(resultApartment);
            _logger.LogInformation($"Apartment with id {apartmentDto.Id} edited");
            return apartmentDto;
        }

    }
}
