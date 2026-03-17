using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace capaentidad
{
    internal class detalle_venta

    {
        public int detalleid{ get; set; }
        public venta oventa { get; set; }
        public string nombre { get; set; }
        public producto oproducto { get; set; }
        public string cantidad { get; set; }


    }
}
