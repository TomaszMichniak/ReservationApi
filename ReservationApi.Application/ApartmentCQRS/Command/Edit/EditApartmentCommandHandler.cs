using AutoMapper;
using MediatR;
using ReservationApi.Domain.Entities;
using ReservationApi.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservationApi.Application.ApartmentCQRS.Command.Edit
{
    public class EditApartmentCommandHandler : IRequestHandler<EditApartmentCommand,ApartmentDto?>
    {
        private readonly IMapper _mapper;
        private readonly IApartmentRepository _apartmentRepository;

        public EditApartmentCommandHandler(IMapper mapper, IApartmentRepository apartmentRepository)
        {
            _mapper = mapper;
            _apartmentRepository = apartmentRepository;
        }

        public async Task<ApartmentDto?> Handle(EditApartmentCommand request, CancellationToken cancellationToken)
        {
            var apartment = _mapper.Map<Apartment>(request);
            var resultApartment=await _apartmentRepository.UpdateApartment(apartment);
            var apartmentDto=_mapper.Map<ApartmentDto>(resultApartment);
            return apartmentDto;
        }
        
    }
}
