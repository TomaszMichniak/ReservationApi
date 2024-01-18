using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservationApi.Domain.Entities
{
    public class User:Guest
    {
        public string PasswordHash { get; set; } = default!;
        public int RoleId { get; set; } = 2;
        public virtual Role Role { get; set; } = default!;
    }
}
