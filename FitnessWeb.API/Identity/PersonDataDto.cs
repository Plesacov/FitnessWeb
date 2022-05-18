using FitnessWeb.API.ViewModels;
using FitnessWeb.Models;

namespace FitnessWeb.API.Identity
{
    public class PersonDataDto
    {
        public string FirstName { get; set; }
     
        public string LastName { get; set; }

        public DateTime BirthdayDate { get; set; }

        public int Height { get; set; }
     
        public int Weight { get; set; }
        public string Gender { get; set; }

        public FitnessProgramViewModel? CurrentFitnessProgram { get; set; }

        public string FitnessLevel { get; set; }
    }
}
