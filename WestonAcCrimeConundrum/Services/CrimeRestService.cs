using System;
using System.Net;

using WestonAcCrimeConundrum.Models;
using WestonAcCrimeConundrum.Services.Interfaces;

namespace WestonAcCrimeConundrum.Services
{
    public class CrimeRestService : ICrimeRestService
    {
        public CrimeRestService()
        {

        }

        public string GetCrimeDataByLatLngDate(string lat, string lng, DateOnly date)
        {
            using (var httpClient = new HttpClient())
            {
                // httpClient.DefaultRequestHeaders.Add(RequestConstants.UserAgent, RequestConstants.UserAgentValue);
                var response = httpClient.GetStringAsync(new Uri("https://data.police.uk/api/crimes-street/all-crime?lat=51.3509&amp;lng=-2.9815&amp;date=2021-10")).Result;
                return response;
            }
        }

        public Task<List<CrimeData>> GetCrimeDataByLatLngDateAsync(string lat, string lng, DateOnly date)
        {
            throw new NotImplementedException();
        }
    }
}
