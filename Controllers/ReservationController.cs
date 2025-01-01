using HotelReservationWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace HotelReservationWeb.Controllers
{
    public class ReservationController : Controller
    {
        private readonly HotelDbContext _context;

        public ReservationController(HotelDbContext context)
        {
            _context = context;
        }

        public IActionResult Index(){
            return View();
        }



    

      
}
        
    }
    


    
