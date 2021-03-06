using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessWeb.Models
{
    public class Training
    {

        public int Id { get; set; }
        [Required]
        [MaxLength(30)]
        public string Type { get; set; }
        public List<Exercise> Exercises { get; set; }
        [Required]
        public int Duration { get; set; }
        public FitnessProgram FitnessProgram { get; set; } 
        public int FitnessProgramId { get; set; }
    }
}
