using Flight_Service.Models;

namespace Flight_Service
{
    public interface IReservationRepo
    {
        public IEnumerable<Reservation> GetAllReservations();
        public Reservation GetReservation(int id);
        public void UpdateReservation(Reservation res);
       
        public void DeleteReservation(Reservation res);
        public void InsertReservation(Reservation res);
    }
}