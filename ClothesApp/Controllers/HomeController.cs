using ClothesApp.Db;
using ClothesApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ClothesApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DBContext oDb;

        public HomeController(ILogger<HomeController> logger , DBContext oDb)
        {
            _logger = logger;
            this.oDb = oDb;
        }

        public IActionResult Index()
        {
            var Data = oDb.Products.ToList();
            return View(Data);
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
