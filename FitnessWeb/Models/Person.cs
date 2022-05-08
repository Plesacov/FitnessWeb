using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace FitnessWeb.Models
{
    public class Person : IdentityUser, IUser
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
        [Required]
        public FitnessLevel FitnessLevel { get; set; }
        public List<Achievement> Achievements { get; set; }
        public bool? IsVip { get; set; }
        public List<PersonFitnessProgram> PersonFitnessPrograms { get; set; }
    }
    public enum FitnessLevel
    {
        Beginner,
        Middle,
        Advanced
    }
}
