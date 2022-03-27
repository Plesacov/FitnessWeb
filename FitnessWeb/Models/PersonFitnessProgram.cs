using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessWeb.Models
{
    public class PersonFitnessProgram : BaseEntity
    {
        public Person Person { get; set; }
        public int PersonId { get; set; }
        public FitnessProgram FitnessProgram { get; set; }
        public int FitnessProgramId { get; set; }
    }
}
