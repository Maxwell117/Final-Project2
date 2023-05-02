using Dapper;
using Flight_Service.Models;
using System.Data;

namespace Flight_Service
{
    public class ReservationRepo : IReservationRepo
    {
        private readonly IDbConnection _conn;

        public ReservationRepo(IDbConnection conn)
        {
            _conn = conn;
        }

        public IEnumerable<Reservation> GetAllReservations()
        {
            return _conn.Query<Reservation>("SELECT * FROM reservation");
        }

        public Reservation GetReservation(int id)
        {
            return _conn.QuerySingle<Reservation>("SELECT * FROM reservation WHERE ID=@id;", new { ID = id });
        }

    
        public void UpdateReservation(Reservation res)
        {                                                                                                                                               //res.Firstname is enough too
            _conn.Execute("UPDATE reservation SET FirstName=@FirstName,LastName=@LastName,Price=@Price,SeatNumber=@SeatNumber WHERE ID=@id;", new { FirstName = res.FirstName, LastName = res.LastName, Price = res.Price, SeatNumber = res.SeatNumber, ID=res.ID });
        }

        public void InsertReservation(Reservation res)
        {
            _conn.Execute("INSERT INTO reservation (FirstName,LastName,Price,SeatNumber) VALUES (@FirstName,@LastName,@Price,@SeatNumber);", new { FirstName = res.FirstName, LastName = res.LastName, Price = res.Price, SeatNumber = res.SeatNumber });

        }

        public void DeleteReservation(Reservation res)
        {
            _conn.Execute("DELETE FROM reservation WHERE ID=@id;", new { ID = res.ID });
        }


    }
}
