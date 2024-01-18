namespace ReservationApi.Domain.Entities
{
    public class Reservation
    {
        public Guid Id { get; set; }=Guid.NewGuid();
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set;}
        public DateTime ReservationDate {  get; set; }
        public int TotalGuests {  get; set; }
        public decimal TotalPrice { get; set; }
        public Guid ApartmentId {  get; set; }
        public Apartment Apartment { get; set; } = default!;
        public Guid GuestId { get; set; }
        public Guest Guest { get; set; } = default!;
    }
}