using MediatR;
using Microsoft.Extensions.Logging;
using ReservationApi.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservationApi.Application.CQRS.AuthenticationCQRS.Command.Login
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, string>
    {
        private readonly IUserRepository _userRepository;
        private readonly ILogger<LoginUserCommandHandler> _logger;

        public LoginUserCommandHandler(IUserRepository userRepository, ILogger<LoginUserCommandHandler> logger)
        {
            _userRepository = userRepository;
            _logger = logger;
        }

        public async Task<string> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            var login=await _userRepository.GenerateJWt(request.Email, request.Password);
            _logger.LogInformation($"Loggning with email {request.Email} successful");
            return login;
        }
    }
}
