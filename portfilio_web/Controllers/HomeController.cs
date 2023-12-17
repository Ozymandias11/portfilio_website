using Microsoft.AspNetCore.Mvc;
using portfilio_web.Data;
using portfilio_web.Models;
using System.Diagnostics;

namespace portfilio_web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _db;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext db)
        {
            _logger = logger;
            _db = db;
        }



        [HttpPost]
        public IActionResult SendMessage([FromBody] UserMessage userMessage)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // Assuming UserMessages is the DbSet property in your DbContext
                    _db.UserMessages.Add(userMessage);
                    _db.SaveChanges();
                    return Json(new { success = true });
                }
                catch (Exception ex)
                {
                    _logger.LogError($"Error inserting message into the database: {ex.Message}");
                    return Json(new { success = false, error = "Error inserting message into the database." });
                }
            }

            return Json(new { success = false, error = "Invalid data. Please check the input and try again." });
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }
        public IActionResult Contacts()
        {
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
