using Microsoft.AspNetCore.Mvc;

using System.Diagnostics;

using WestonAcCrimeConundrum.Models;
using WestonAcCrimeConundrum.Services.Interfaces;

namespace WestonAcCrimeConundrum.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICrimeRestService _crime;

        public HomeController(ILogger<HomeController> logger, ICrimeRestService crime)
        {
            _logger = logger;
            _crime = crime;
        }

        public IActionResult Index()
        {
            var lat = "51.3509";
            var lng = "-2.9815";
            var date = new DateOnly(2021,10,1);

            var retVal = _crime.GetCrimeDataByLatLngDate(lat, lng, date);

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