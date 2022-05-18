using FitnessWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitness.Core.Models
{
    public class Image
    {
        public int Id { get; set; }
        public string ImageTitle { get; set; }
        public byte[] ImageData { get; set; }

        public Person Person { get; set; }
        public int PersonId { get; set; }

    }
}
