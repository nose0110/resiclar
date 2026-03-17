using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace capaentidad
{
    internal class detalle_compra
    {
        public int detallecompraid { get; set; }
        public compra ocompra { get; set; }
        public producto oproducto { get; set; }
        public string cantidad { get; set; }
        public string precio { get; set; }
        public string subtotal { get; set; }

    }
}
