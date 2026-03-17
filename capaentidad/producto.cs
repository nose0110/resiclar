using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace capaentidad
{
    internal class producto
    {
        public int idproducto{ get; set; }
        public string codigo { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public cateria ocateria { get; set; }
        public string preciocompra { get; set; }
        public string precioventa { get; set; }
        public string fecharegistro{ get; set; }


    }
}