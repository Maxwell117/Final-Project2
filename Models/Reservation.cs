namespace Flight_Service.Models
{
    public class Reservation
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public double Price { get; set; }
        public int SeatNumber { get; set; }
    }
}
