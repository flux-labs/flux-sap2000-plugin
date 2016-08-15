using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flux.SAP2000.Interop
{
    public class SAP20001dElementForces
    {
        public List<string> loadCase { get; set; }
        public List<double> P { get; set; }
        public List<double> V2 { get; set; }
        public List<double> V3 { get; set; }
        public List<double> T { get; set; }
        public List<double> M2 { get; set; }
        public List<double> M3 { get; set; }

        public SAP20001dElementForces()
        {
            this.loadCase = new List<string>();
            this.P = new List<double>();
            this.V2 = new List<double>();
            this.V3 = new List<double>();
            this.T = new List<double>();
            this.M2 = new List<double>();
            this.M3 = new List<double>();
        }
    }
}
