using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessWeb.Models
{
    public class FitnessProgram : BaseEntity
    {
        public string Type { get; set; } // change enum <--
        public List<Training> Trainings { get; set; }
        public List<FitnessTip> FitnessTips { get; set; }
        public List<PersonFitnessProgram> PersonFitnessPrograms { get; set; }
    }
}
