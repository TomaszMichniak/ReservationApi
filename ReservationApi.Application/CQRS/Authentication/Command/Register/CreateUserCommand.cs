using MediatR;
using ReservationApi.Application.CQRS.AuthenticationCQRS;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservationApi.Application.CQRS.AuthenticationCQRS.Command.Register
{

    public class CreateUserCommand : IRequest
    {
        public string Email { get; set; } = default!;
        public string Password { get; set; } = default!;
        public string ConfirmPassword { get; set; } = default!;
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public string Phone { get; set; } = default!;
        public int RoleId { get; set; } = 2;

    }
}
