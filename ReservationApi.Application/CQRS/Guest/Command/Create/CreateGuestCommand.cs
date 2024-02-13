using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservationApi.Application.CQRS.Guest.Command.Create
{
    public class CreateGuestCommand : IRequest<GuestDto>
    {
        public string Email { get; set; } = default!;
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public string Phone { get; set; } = default!;

        public CreateGuestCommand(string email, string firstName, string lastName, string phone)
        {
            Email = email;
            FirstName = firstName;
            LastName = lastName;
            Phone = phone;
        }
    }
}
