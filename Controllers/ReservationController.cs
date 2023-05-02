using Flight_Service.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Flight_Service.Controllers
{
    public class ReservationController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IReservationRepo _repo;

        public ReservationController(ILogger<HomeController> logger,IReservationRepo repo)
        {
            _logger = logger;
            _repo = repo;
        }

        public IActionResult Index()
        {
           return View();
        }


        public IActionResult ViewReservation(int id)
        {
            var res = _repo.GetReservation(id);

            return View(res);
        }

        public IActionResult GetAllReservations()
        {
            var res = _repo.GetAllReservations();

            return View(res);
        }

        public IActionResult InsertReservation(Reservation res)
        {
            return View(res);
        }

        public IActionResult InsertReservationToDatabase(Reservation res)
        {
            _repo.InsertReservation(res);
            return RedirectToAction("Index");
        }


        public IActionResult UpdateReservation(int id)
        {

            var res = _repo.GetReservation(id);

            if (res == null)
                return NotFound();

            return View(res);

            // return RedirectToAction("ViewReservation", new { FirstName = res.FirstName, LastName = res.LastName, Price = res.Price, SeatNumber = res.SeatNumber });
        }

        public IActionResult UpdateReservationToDatabase(Reservation res)
        {
            _repo.UpdateReservation(res);

            return RedirectToAction("ViewReservation", new { ID = res.ID });
        }


        public IActionResult DeleteReservation(Reservation res)
        {
            _repo.DeleteReservation(res);
            return RedirectToAction("GetAllReservations");
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}