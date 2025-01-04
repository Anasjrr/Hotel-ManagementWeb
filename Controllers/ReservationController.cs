using HotelReservationWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Linq;

namespace HotelReservationWeb.Controllers
{
    public class ReservationController : Controller
    {
        private readonly HotelDbContext _context;
        private readonly ILogger<ReservationController> _logger;

        // Constructor to inject the database context and logger
        public ReservationController(HotelDbContext context, ILogger<ReservationController> logger)
        {
            _context = context;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var roomName = Request.Query["roomName"].ToString();
            var price = Request.Query["price"].ToString();

            if(roomName=="Deluxe_Room"){
                ViewBag.image="room1.png";
            }
            else if(roomName=="Suite"){
                ViewBag.image="room2.png";
            }
            else if(roomName=="Family_Room"){
                ViewBag.image="room4.png";
            }
           ViewBag.roomName=roomName;
           ViewBag.price=price;

            return View();
        }

        private void SendEmailToClient(Reservation reservation)
        {
            try
            {
                using (var mail = new System.Net.Mail.MailMessage())
                {
                    // Fetch email credentials from configuration
                    var email = "anasjabri35@gmail.com"; // Replace with configuration access
                    var password = "brpw ioaf unau zpfp"; // Replace with configuration access

                    mail.From = new System.Net.Mail.MailAddress(email);
                    mail.To.Add(reservation.GuestEmail);
                    mail.Subject = "Reservation Confirmation";
                    mail.Body = $"Dear {reservation.GuestName},\n\n" +
                                 $"Thank you for making a reservation with us!\n" +
                                 $"Check-in Date: {reservation.DateDebut:MM/dd/yyyy}\n" +
                                 $"Check-out Date: {reservation.DateFin:MM/dd/yyyy}\n\n" +
                                 $"Best regards,\n Mimouna Hotel ";

                    using (var smtpClient = new System.Net.Mail.SmtpClient("smtp.gmail.com"))
                    {
                        smtpClient.Port = 587;
                        smtpClient.Credentials = new System.Net.NetworkCredential(email, password);
                        smtpClient.EnableSsl = true;
                        smtpClient.Send(mail);
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to send email: {ex.Message}");
                TempData["ErrorMessage"] = $"Failed to send email: {ex.Message}";
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddReservation(Reservation model)
        {
            var userId = HttpContext.Session.GetString("UserId");
            var intId=int.TryParse(userId, out var parsedId);
          

            var user = _context.Users.FirstOrDefault(u => u.Id == parsedId);
            if (user == null)
            {
                ModelState.AddModelError("", "User information could not be retrieved.");
                return View(model);
            }
          

            if (model.DateFin <= model.DateDebut)
            {
                ModelState.AddModelError("", "Check-out date must be after check-in date.");
                return View(model);
            }

            var newReservation = new Reservation
            {
                GuestName = user.Name,
                GuestEmail = user.Email,
                Guestadresse = user.Address,
                DateDebut = model.DateDebut,
                DateFin = model.DateFin,
            };

            try
            {
                _context.Reservation.Add(newReservation);
                _context.SaveChanges();

                SendEmailToClient(newReservation);
                TempData["SuccessMessage"] = "Reservation added successfully!";
                return RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error saving reservation: {ex.Message}");
                ModelState.AddModelError("", $"Error saving reservation: {ex.Message}");
                return View(model);
            }
        }
    }
}
