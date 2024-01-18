﻿namespace ReservationApi.Domain.Entities
{
    public class Guest
    {
        public Guid Id { get; set; }=Guid.NewGuid();
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string Phone { get; set; }= default!;
        public ICollection<Reservation> Reservations { get; set; } =new List<Reservation>();

    }
}