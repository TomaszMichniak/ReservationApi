using MediatR;
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
        public IApartmentRepository _apartmentRepository;

        public DeleteApartmentCommandHandler(IApartmentRepository apartmentRepository)
        {
            _apartmentRepository = apartmentRepository;
        }

        public async Task Handle(DeleteApartmentCommand request, CancellationToken cancellationToken)
        {
            var apartment = await _apartmentRepository.GetByIdAsync(request.Id);
            if (apartment != null)
            {
                await _apartmentRepository.DeleteAsync(apartment);
            }
            return;
        }
    }
}
