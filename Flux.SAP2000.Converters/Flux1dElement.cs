using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Flux.SAP2000.Interop;
using Flux.SDK.Serialization;

namespace Flux.SAP2000.Converters
{
    //[FluxType("line", typeof(SAP20001dElement))]

    [FluxConverter]
    public class Flux1dElement : IConverter<SAP20001dElement>
    {

        public Flux1dElement()
        {
            System.Console.WriteLine("constructing element");
        }

        public static bool CanConvert(object data, Type objectType)
        {
            return (typeof(SAP20001dElement) == objectType);
        }

        [Newtonsoft.Json.JsonProperty("id")]
        public string Id { get; set; }

        [Newtonsoft.Json.JsonProperty("primitive")]
        public string Primitive
        {
            get
            {
                return "line";
            }
        }

        [Newtonsoft.Json.JsonProperty("start")]
        public double[] Start { get; set; }

        [Newtonsoft.Json.JsonProperty("end")]
        public double[] End { get; set; }

        [Newtonsoft.Json.JsonProperty("loadCase")]
        public string[] LoadCase { get; set; }

        //[Newtonsoft.Json.JsonProperty("forces")]
        //public FluxForces forces { get; set; }

        Dictionary<string, object> IConverter<SAP20001dElement>.Units
        {
            get; set;
        }

        public void ApplyUnits()
        {
            
        }

        public void SetFluxObject(SAP20001dElement model)
        {
            //ingest a SAP20001dElement

            //these key/values should be organized under attributes
            this.Id = model.Id;
            //this.forces = new FluxForces(model.forces);
            this.Start = model.Start;
            this.End = model.End;
            //this.loadCase = model.forces.loadCase;
        }

        public SAP20001dElement GetFluxObject()
        {
            return null;
        }
    }

    public class FluxForces
    {
        public double[] P { get; set; }
        public double[] V2 { get; set; }
        public double[] V3 { get; set; }
        public double[] T { get; set; }
        public double[] M2 { get; set; }
        public double[] M3 { get; set; }

        public FluxForces()
        {

        }

        public FluxForces(SAP20001dElementForces forces)
        {
            this.P = forces.P;
            this.V2 = forces.V2;
            this.V3 = forces.V3;
            this.T = forces.T;
            this.M2 = forces.M2;
            this.M3 = forces.M3;
        }
    }
}
