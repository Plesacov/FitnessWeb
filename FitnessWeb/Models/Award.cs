using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessWeb.Models
{
    public class Award : BaseEntity
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public Achievement Achievement { get; set; }
        public int AchievementId { get; set; }
    }
}
