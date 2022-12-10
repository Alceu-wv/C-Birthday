using BirthdayAT.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BirthdayAT.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ModelContext _db;

        public HomeController(
            ILogger<HomeController> logger,
            ModelContext db)
        {
            _logger = logger;
            _db = db;
        }

        public IActionResult Index()
        {
            var friends = _db.Friends.OrderByDescending(f => f.Birthday).ToList(); 
            return View(friends);
        }

        public IActionResult Edit()
        {
            var friends = _db.Friends.OrderByDescending(f => f.Birthday).ToList();
            return View(friends);
        }

        public IActionResult Privacy()
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