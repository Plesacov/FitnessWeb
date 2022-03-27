using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessWeb.Models
{
    public class FitnessTip : BaseEntity 
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public FitnessProgram FitnessProgram { get; set; }
        public int FitnessProgramId  { get; set; }
    }
}
