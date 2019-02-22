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
		public Producto(){}
		public Producto(Int64 pId, string pNombre)
		{
			Id = pId;
			Nombre = pNombre;
		}
	}
}
