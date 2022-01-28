using Microsoft.AspNetCore.Mvc;

using System.Collections.Generic;
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
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CrimeClient crimeClient)
        {
            if (!ModelState.IsValid) 
                return View("Index");

            var lat = "51.3509";
            var lng = "-2.9815";
            crimeClient.MonthYear = new DateOnly(2021, 12, 1);

            var crimes = await _crime.GetCrimeDataByLatLngDateAsync(
                crimeClient.Latitude.ToString(), 
                crimeClient.Longitude.ToString(), 
                crimeClient.MonthYear.ToString("yyyy-MM"));

            // Here we need to query the results and asign to a CrimeResponses object
            // Sum, GroupBy category => crimeClient
            var temp = crimes
                .GroupBy(l => l.category)
                .Select(cl => new
                {
                    Category = cl.First().category,
                    Quantity = cl.Count()
                }).ToList();

            // crimeClient.CrimeResponseByCategories = new List<CrimeResponseByCategory>();

            crimeClient.CrimeResponseByCategories = crimes
                .GroupBy(l => l.category)
                .Select(cl => new CrimeResponseByCategory
                {
                    Category = cl.First().category, 
                    NumCrimes = cl.Count()
                }).ToList();

            return View("Index", crimeClient);
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}