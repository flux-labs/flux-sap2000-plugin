using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flux.SAP2000.Interop
{
    public class SAP20001dElementForces
    {
        public string[] loadCase { get; set; }
        public double[] P { get; set; }
        public double[] V2 { get; set; }
        public double[] V3 { get; set; }
        public double[] T { get; set; }
        public double[] M2 { get; set; }
        public double[] M3 { get; set; }
    }
}
