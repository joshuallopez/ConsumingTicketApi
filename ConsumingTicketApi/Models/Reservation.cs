namespace ConsumingTicketApi.Models
{
    public class Reservation
    {
        public int ReservationId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? StartLocation { get; set; }
        public string? EndLocation { get; set; }
    }
}
