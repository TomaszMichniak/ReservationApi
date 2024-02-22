using MediatR;
using Microsoft.Extensions.Logging;
using ReservationApi.Application.Exceptions;
using ReservationApi.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservationApi.Application.CQRS.Apartment.Command.Delete
{
    public class DeleteApartmentCommandHandler : IRequestHandler<DeleteApartmentCommand>
    {
        private readonly IApartmentRepository _apartmentRepository;
        private readonly ILogger<DeleteApartmentCommandHandler> _logger;

        public DeleteApartmentCommandHandler(IApartmentRepository apartmentRepository, ILogger<DeleteApartmentCommandHandler> logger)
        {
            _apartmentRepository = apartmentRepository;
            _logger = logger;
        }

        public async Task Handle(DeleteApartmentCommand request, CancellationToken cancellationToken)
        {
            var apartment = await _apartmentRepository.GetByIdAsync(request.Id);
            if (apartment == null)
            {
                throw new NotFoundExceptions("Apartment not found");
            }
            await _apartmentRepository.DeleteAsync(apartment);
            _logger.LogInformation($"Apartment with id{apartment.Id} deleted");
            return;
        }
    }
}
