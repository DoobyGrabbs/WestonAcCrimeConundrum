using System.ComponentModel.DataAnnotations;

// Viewmodel to handle post and response data with view
namespace WestonAcCrimeConundrum.Models.ViewModels
{
    public class CrimeClient
    {
        [Required]
        [Display(Name = "Latitude")]
        [Range(-90, 90, ErrorMessage = "Range for {0} must be between {1} and {2}.")]
        public float Latitude { get; set; }

        [Required]
        [Display(Name = "Longitude")]
        [Range(-180, 180, ErrorMessage = "Range for {0} must be between {1} and {2}.")]
        public float Longitude { get; set; }

        [Required]
        [Display(Name = "Month")]
        [Range(1, 12, ErrorMessage = "Range for {0} must be between {1} and {2}.")]
        public int Month { get; set; } = DateTime.Today.Month;

        [Required]
        [Display(Name = "Year")]
        [Range(1900, 2099, ErrorMessage = "Range for {0} must be between {1} and {2}.")]
        public int Year { get; set; } = DateTime.Today.Year;

        public string MonthYear { get; set; } = String.Empty;

        public List<CrimeResponseByCategory> CrimeResponseByCategories { get; set; } = new List<CrimeResponseByCategory>(); 
    }

    public class CrimeResponseByCategory
    {
        public string? Category { get; set; }
        public int NumCrimes { get; set; }
    }

}
