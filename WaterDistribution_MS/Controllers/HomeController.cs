using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WaterDistribution_MS.Data;
using WaterDistribution_MS.Models;

namespace WaterDistribution_MS.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context; // ? ??? DbContext

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context; // ? ???? ??????
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        // ? ?????? ??????? ?????? ????????
        public IActionResult TestDb()
        {
            try
            {
                int customerCount = _context.Customers.Count();  // ??????? ????
                ViewBag.Message = $"Contact success, number of customers: {customerCount}";
            }
            catch (Exception ex)
            {
                ViewBag.Message = $"Communication failed {ex.Message}";
            }

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
