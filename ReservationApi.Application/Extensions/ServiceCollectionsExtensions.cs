using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using ReservationApi.Application.CQRS.Apartment.Command.Create;
using ReservationApi.Application.Mapping;
using ReservationApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ReservationApi.Application.Extensions
{
    public static class ServiceCollectionsExtensions
    {
        public static void AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            services.AddScoped(provider => new MapperConfiguration(cfg =>
            {
                var scope = provider.CreateScope();
                cfg.AddProfile(new MappingProfile());
            }).CreateMapper()
            );
            services.AddValidatorsFromAssemblyContaining<CreateApartmentCommandValidator>();
            services.AddScoped<IPasswordHasher<User>, PasswordHasher<User>>();

        }
    }
}
