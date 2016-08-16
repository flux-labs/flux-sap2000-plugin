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
            this.Start = new List<double>();
            this.End = new List<double>();
            
            this.LoadCase = new List<string>();
            System.Console.WriteLine("constructing element");
        }

        public static bool CanConvert(object data, Type objectType)
        {
            System.Console.WriteLine("data={0}, type={1}", data, objectType);

            return (typeof(SAP20001dElement) == objectType); 

        }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("primitive")]
        public string Primitive
        {
            get
            {
                return "line";
            }
        }

        [JsonProperty("start")]
        public List<Double> Start { get; set; }

        [JsonProperty("end")]
        public List<Double> End { get; set; }

        [JsonProperty("loadCase")]
        public List<string> LoadCase { get; set; }

        [JsonProperty("forces")]
        public FluxForces forces { get; set; }
        

        public void ApplyUnits()
        {
            
        }

        public void SetFluxObject(SAP20001dElement model)
        {
            //ingest a SAP20001dElement

            //these key/values should be organized under attributes
            this.Id = model.Id;
            this.forces = new FluxForces(model.Forces);
            this.Start = model.Start;
            this.End = model.End;
            
            this.LoadCase = model.Forces.loadCase;
        }

        public SAP20001dElement GetFluxObject()
        {
            return null;
        }
    }

    public class FluxForces
    {
        public List<double> P { get; set; }
        public List<double> V2 { get; set; }
        public List<double> V3 { get; set; }
        public List<double> T { get; set; }
        public List<double> M2 { get; set; }
        public List<double> M3 { get; set; }

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
