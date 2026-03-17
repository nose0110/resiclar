using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace capaentidad
{
    internal class venta
    {
        public int idventa{ get; set;}
        public cliente ocliente { get; set; }
        public string tipodocumento { get; set; }
        public string docuento{ get; set; }
        public decimal montototal { get; set; }
        public List<detalle_venta> odetallesventa { get; set; }
        public string fecharegistrp { get; set; }






    }
}
