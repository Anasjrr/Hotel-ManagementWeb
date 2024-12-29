using HotelReservationWeb.Models;
using Microsoft.AspNetCore.Mvc;

public class UserController : Controller
{
    private readonly HotelDbContext _context;

    public UserController(HotelDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Login(LoginViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        var user = _context.Users
            .FirstOrDefault(u => u.Email == model.Email && u.Password == model.Password);

        if (user == null)
        {
            ViewData["Error"] = "Invalid email or password.";
            return View(model);
        }

        // Store user info in session
        HttpContext.Session.SetString("UserId", user.Id.ToString());
        HttpContext.Session.SetString("UserRole", user.Role);

        return RedirectToAction("Index", "Home");
    }

    public IActionResult Logout()
    {
        HttpContext.Session.Clear();
        return RedirectToAction("Login");
    }
}
