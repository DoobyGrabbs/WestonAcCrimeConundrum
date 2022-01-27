
namespace WestonAcCrimeConundrum.Services.Interfaces
{
    public interface ICrimeRestService
    {
        string GetCrimeDataByLatLngDate(string lat, string lng, DateOnly date);
    }
}