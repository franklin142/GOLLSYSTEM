using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GOLLSYSTEM.EntityLayer
{
	public class Cargo
	{
		public Int64 Id { get; set; }
        public string FhRegistro { get; set; }
		public string Nombre { get; set; }
		public Cargo(){}
		public Cargo(Int64 pId, string pFhRegistro, string pNombre)
		{
			Id = pId;
			Nombre = pNombre;
			FhRegistro = pFhRegistro;
		}
	}
}
