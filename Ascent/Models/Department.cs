using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ascent.Models
{
    public class Department
    {
        public int Id { get; set; }

        // Name of a department, e.g. Department of Computer Science
        public string Name { get; set; }

        // Abbreviated department name in lower case, e.g. cs.
        public string Abbreviation { get; set; }
    }
}
