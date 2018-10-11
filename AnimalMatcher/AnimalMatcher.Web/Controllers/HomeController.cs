namespace AnimalMatcher.Web.Controllers
{
    using System.Diagnostics;
    using AnimalMatcher.Services.Location.Interfaces;
    using AnimalMatcher.Web.Models;
    using Microsoft.AspNetCore.Mvc;

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
            double radius = 0.5;

            var petsInRadius = this.locationService.GetPetsInRadius(latitude, longitude, radius);
            
            return this.View();
        }

        public IActionResult About()
        {
            this.ViewData["Message"] = "Your application description page.";

            return this.View();
        }

        public IActionResult Contact()
        {
            this.ViewData["Message"] = "Your contact page.";

            return this.View();
        }

        public IActionResult Privacy()
        {
            return this.View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return this.View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
