using System;
using System.Net;

namespace WestonAcCrimeConundrum.Services
{
    public class CrimeRestService
    {
        public CrimeRestService()
        {

        }

        public string GetCrimeDataByLatLngDate(string lat, string lng, DateOnly date)
        {
            using (var httpClient = new HttpClient())
            {
                // httpClient.DefaultRequestHeaders.Add(RequestConstants.UserAgent, RequestConstants.UserAgentValue);
                var response = httpClient.GetStringAsync(new Uri("https://data.police.uk/api/crimes-street/all-crime")).Result;
                return response;
            }
        }
    }
}
