using FluentValidation.Results;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReservationApi.Application.CQRS.Apartment.Command.Edit;
using ReservationApi.Application.CQRS.Authentication.Command.Register;
using ReservationApi.Application.CQRS.AuthenticationCQRS;
using ReservationApi.Application.CQRS.AuthenticationCQRS.Command.Login;
using ReservationApi.Application.CQRS.AuthenticationCQRS.Command.Register;
using ReservationApi.Domain.Interfaces;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace ReservationApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IUserRepository _userRepository;

        public AuthenticationController(IMediator mediator, IUserRepository userRepository)
        {
            _mediator = mediator;
            _userRepository = userRepository;
        }

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register([FromBody] CreateUserCommand command)
        {
            CreateUserCommandHandlerValidator _validator = new CreateUserCommandHandlerValidator(_userRepository);
            ValidationResult result = await _validator.ValidateAsync(command);
            if (!result.IsValid)
                return BadRequest(command);
            await _mediator.Send(command);
            return Ok();
        }
        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] LoginUserCommand command)
        {
            var token = await _mediator.Send(command);
            return Ok(token);
        }
    }
}
