using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using ReservationApi.Application.Exceptions;
using ReservationApi.Domain.Entities;
using ReservationApi.Domain.Interfaces;
using ReservationApi.Infrastructure.Authentication;
using ReservationApi.Infrastructure.Database;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ReservationApi.Infrastructure.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        private readonly IPasswordHasher<User> _passwordHasher;
        private readonly AuthenticationSettings _authenticationSettings;
        public UserRepository(ReservationApiDbContext dbContext, IPasswordHasher<User> passwordHasher, AuthenticationSettings authenticationSettings) : base(dbContext)
        {
            _passwordHasher = passwordHasher;
            _authenticationSettings = authenticationSettings;
        }

        public async Task<string> GenerateJWt(string email, string password)
        {
            var user = await _dbContext.Users
                .Include(x => x.Role)
                .FirstOrDefaultAsync(u => u.Email == email);
            if (user == null)
            {
                throw new NotFoundExceptions("User with this email and password not exist");
            }
            var result = _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, password);
            if (result == PasswordVerificationResult.Failed)
            {
                throw new NotFoundExceptions("User with this email and password not exist");
            }
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier,user.Id.ToString()),
                new Claim(ClaimTypes.Name,$"{user.FirstName} {user.LastName}"),
                new Claim(ClaimTypes.Role,$"{user.Role.Name}"),
                new Claim("Reservations",user.Reservations.ToString())
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_authenticationSettings.JwtKey));
            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddDays(_authenticationSettings.JwtExpireDays);
            var token = new JwtSecurityToken(_authenticationSettings.JwtIssuer,
                _authenticationSettings.JwtIssuer,
                claims,
                expires: expires,
                signingCredentials: cred);
            var tokenHandler = new JwtSecurityTokenHandler();
            return tokenHandler.WriteToken(token);
        }
    }
}
