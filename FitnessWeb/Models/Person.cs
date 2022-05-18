using Fitness.Core.Models;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;


namespace FitnessWeb.Models
{
    public class Person : IdentityUser
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(20)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(20)]
        public string LastName { get; set; }
        [Required]
        public DateTime BirthdayDate { get; set; }
        [Required]
        public int Height { get; set; }
        [Required]
        public int Weight { get; set; }
        public FitnessLevel FitnessLevel { get; set; }

        public Gender Gender { get; set; }
        public List<Achievement> Achievements { get; set; }
        public bool IsAdmin { get; set; } = false;
        public List<PersonFitnessProgram> PersonFitnessPrograms { get; set; }

        public List<Image> Images { get; set; }
    }
    public enum FitnessLevel
    {
        Beginner,
        Middle,
        Advanced
    }

    public enum Gender
    {
        Male,
        Female,
        Child
    }
}
