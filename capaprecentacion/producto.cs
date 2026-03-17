using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace capaprecentacion
{
    
        public class Producto
        {
            public int IdProducto { get; set; }
            public string Codigo { get; set; }
            public string Nombre { get; set; }
            public int Stock { get; set; }
            public decimal PrecioCompra { get; set; }
            public decimal PrecioVenta { get; set; }
            // Puedes agregar otras propiedades según sea necesario, como la categoría
            public string Categoria { get; set; }
        }

    
}
