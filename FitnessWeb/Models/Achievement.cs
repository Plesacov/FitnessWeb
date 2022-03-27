using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessWeb.Models
{
    public class Achievement : BaseEntity
    {
        public Person Person { get; set; }
        public int PersonId { get; set; }
        public  List<Award> Awards { get; set; }
        public List<Training> Trainings { get; set; }
        public int? Period { get; set; }

    }

}
