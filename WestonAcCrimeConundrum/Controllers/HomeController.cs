using Microsoft.AspNetCore.Mvc;

using System.Diagnostics;

using WestonAcCrimeConundrum.Models;
using WestonAcCrimeConundrum.Models.ViewModels;
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
            CrimeClient crimeClient = new();
            return View(crimeClient);
        }

        public IActionResult About()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CrimeClient crimeClient)
        {
            if (!ModelState.IsValid) 
                return View("Index");

            crimeClient.MonthYear = $"{crimeClient.Year}-{crimeClient.Month}";

            try
            {
                // Call the rest API to get the raw data
                var crimes = await _crime.GetCrimeDataByLatLngDateAsync(
                    crimeClient.Latitude.ToString(),
                    crimeClient.Longitude.ToString(),
                    crimeClient.MonthYear);

                // GroupBy & Sum the results for our summary data and assign to the crimeClient object
                crimeClient.CrimeResponseByCategories = crimes
                    .GroupBy(l => l.category)
                    .Select(cl => new CrimeResponseByCategory
                    {
                        Category = cl.First().category,
                        NumCrimes = cl.Count()
                    })
                    .OrderByDescending(a => a.NumCrimes)
                    .ToList();
            }
            catch (Refit.ApiException)
            {

            }

            return View("Index", crimeClient);
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}