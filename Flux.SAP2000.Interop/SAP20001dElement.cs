using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flux.SAP2000.Interop
{
    public class SAP20001dElement
    {
        public string Id { get; set; }
        public List<double> Start { get; set; }
        public List<double> End { get; set; }
        public SAP20001dElementForces Forces { get; set; }

        public SAP20001dElement()
        {
            this.Id = "";
            this.Start = new List<double>();
            this.End = new List<double>();
            this.Forces = new SAP20001dElementForces();
        }

//        public SAP20001dElement(string id, double []start, double[]end, SAP20001dElementForces forces)
        public SAP20001dElement(string id, List<double> start, List<double> end, SAP20001dElementForces forces)
        {
            this.Forces = forces;
            this.Start = start;
            this.End = end;
            this.Id = id;
            //this.Forces.loadCase = forces.loadCase;
        }
    }

    /*
    public class SAP2000Forces
    {
        public double[] P { get; set; }
        public double[] V2 { get; set; }
        public double[] V3 { get; set; }
        public double[] T { get; set; }
        public double[] M2 { get; set; }
        public double[] M3 { get; set; }
    }*/
}
