namespace AnimalMatcher.Web.Controllers
{
    using System.Diagnostics;
    using Microsoft.AspNetCore.Mvc;
    using AnimalMatcher.Web.Models;
    using AnimalMatcher.Services.Location.Interfaces;

    public class HomeController : Controller
    {
        private readonly ILocationService locationService;
        
        public HomeController(ILocationService locationService)
        {
            this.locationService = locationService;
        }

        public IActionResult Index()
        {
            double latitude = 42.67841870;
            double longitude = 23.29487976;
            double radius = 5;

            this.locationService.GetPetsInRadius(latitude, longitude, radius);

            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
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
