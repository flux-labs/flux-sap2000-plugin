using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Flux.SDK.Serialization;
using Flux.SAP2000.Interop;

namespace Flux.SAP2000.Converters
{
    //change to FluxPoint
    [FluxConverter]
    public class FluxPoint : IConverter<SAP2000Point>
    {
        public static bool CanConvert(object data, Type objectType)
        {
            return (typeof(SAP2000Point) == objectType);
        }

        public void SetFluxObject(SAP2000Point data)
        {
            
        }

        public SAP2000Point GetFluxObject()
        {
            return null;
        }

        public void ApplyUnits()
        {
            
        }

        public string id { get; set; }
        public string primitive
        {
            get
            {
                return "point";
            }
        }
        public double[] point { get; set; }

        public Dictionary<string, object> Units
        {
            get; set;
        }
    }
}
