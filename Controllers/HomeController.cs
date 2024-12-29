using HotelReservationWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace HotelReservationWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly HotelDbContext _context;

        public HomeController(HotelDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
       
            return View();
        }
    }
}
