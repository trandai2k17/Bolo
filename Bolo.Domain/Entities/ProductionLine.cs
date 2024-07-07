using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Bolo.Domain.Entities
{
    public class ProductionLine
    {
        public int RecID { get; set; }
        public string ProductionGroup { get; set; }
        public string ProductionLineName { get; set; }
        public string LocationLine { get; set; }
        public string Location { get; set; }
    }
}
