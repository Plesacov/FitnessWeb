using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessWeb.Models
{
    public class Person : BaseEntity, IUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthdayDate { get; set; }
        public int Height { get; set; }
        public int Weight { get; set; }
        public FitnessLevel FitnessLevel { get; set; }
        public List<Achievement> Achievements { get; set; }
        public bool? IsVip { get; set; }
        public List<PersonFitnessProgram> PersonFitnessPrograms { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
    }
    public enum FitnessLevel
    {
        Beginner,
        Middle,
        Advanced
    }
}
