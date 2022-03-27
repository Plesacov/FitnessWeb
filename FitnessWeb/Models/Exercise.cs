using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessWeb.Models
{
    public class Exercise : BaseEntity
    {
        public string Name { get; set; }
        public int CountOfRepeats { get; set; }
        public Training Training { get; set; }
        public int TrainingId   { get; set; }
        public string VideoUrl { get; set; }
    }
}
