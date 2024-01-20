using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ReservationApi.Domain.Interfaces;
using ReservationApi.Infrastructure.Database;
using ReservationApi.Infrastructure.Repositories;
using ReservationApi.Infrastructure.Seeder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservationApi.Infrastructure.Extensions
{
    public static class ServiceCollectionsExtensions
    {
        public static void AddInfrastructures(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ReservationApiDbContext>();
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IApartmentRepository,ApartmentRepository>();
            services.AddScoped<ReservationApiSeeder>();
            services.AddScoped<IUserRepository, UserRepository>();
        }
    }
}
