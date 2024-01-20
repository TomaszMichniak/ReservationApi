using MediatR;
using ReservationApi.Application.CQRS.Apartment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservationApi.Application.CQRS.Apartment.Command.Create
{
    public class CreateApartmentCommand : IRequest<ApartmentDto?>
    {
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
        public int MaxGuests { get; set; }
        public decimal RatePerNight { get; set; }

        public CreateApartmentCommand(string name, string description, int maxGuests, decimal ratePerNight)
        {
            Name = name;
            Description = description;
            MaxGuests = maxGuests;
            RatePerNight = ratePerNight;
        }
    }
}
