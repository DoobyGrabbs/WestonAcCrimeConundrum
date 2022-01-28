
using Refit;

using WestonAcCrimeConundrum.Models;

namespace WestonAcCrimeConundrum.Services.Interfaces
{
    public interface ICrimeRestService
    {
        //"https://data.police.uk/api/crimes-street/all-crime?lat=51.3509&amp;lng=-2.9815&amp;date=2021-10"

        [Get("/crimes-street/all-crime?lat={lat}&lng={lng}&date={date}")]
        Task<List<CrimeData>> GetCrimeDataByLatLngDateAsync(string lat, string lng, string date);
    }
}