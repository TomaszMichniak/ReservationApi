using ReservationApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservationApi.Domain.Interfaces
{
    public interface IUserRepository:IGenericRepository<User>
    {
        public Task<string> GenerateJWt(string email, string password);
        public bool UniqueEmail(string email);
    }
}
