using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessWeb.Models
{
    public class Training : BaseEntity
    {
        public string Type { get; set; }
        public List<Exercise> Exercises { get; set; }
        public int Duration { get; set; }
        public FitnessProgram FitnessProgram { get; set; } 
        public int FitnessProgramId { get; set; }
    }
}
