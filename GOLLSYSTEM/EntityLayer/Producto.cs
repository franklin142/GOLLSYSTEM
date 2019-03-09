using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GOLLSYSTEM.EntityLayer
{
	public class Producto
	{
		public Int64 Id { get; set; }
		public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public Producto(){}
		public Producto(Int64 pId, string pNombre,decimal pPrecio)
		{
			Id = pId;
			Nombre = pNombre;
            Precio = pPrecio;
        }
	}
}
