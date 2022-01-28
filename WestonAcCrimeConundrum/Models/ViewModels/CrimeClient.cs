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
        [Display(Name = "Month/Year")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateOnly MonthYear { get; set; }

        public List<CrimeResponseByCategory>? CrimeResponseByCategories { get; set; }
    }

    public class CrimeResponseByCategory
    {
        public string? Category { get; set; }
        public int NumCrimes { get; set; }
    }

}
