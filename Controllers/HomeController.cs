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
               bool isAuthenticated = HttpContext.Session.GetString("UserId") != null;

        
            ViewBag.IsAuthenticated = isAuthenticated;
            return View();
        }



      public async Task<IActionResult> AddContactUs(ContactUs contactUs){
            Console.WriteLine($"Nameeee: {contactUs.FirstName},LastName: {contactUs.LastName}, Email: {contactUs.Email}, Message: {contactUs.Message}");
            if(ModelState.IsValid){
               
                _context.Add(contactUs);
                await _context.SaveChangesAsync();
            }
             return View("Index", contactUs);
        }


       public IActionResult ReservationPage()
{
    return RedirectToAction("User/Login");
}
}
        
    }
    


    
