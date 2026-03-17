using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace capaentidad
{
    internal class compra
    {
        public int idcompra{ get; set; }
        public provedor oprovedor { get; set; }
        public string tipodocumento { get; set; }
        public string documento { get; set; }
        public List<detalle_compra> odetallescompra{ get; set; }

        public decimal montototal { get; set; }
        public string fecharegistro { get; set; }

    }
}
