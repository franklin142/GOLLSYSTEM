using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GOLLSYSTEM.EntityLayer
{
	public class Cuota
	{
		public Int64 Id { get; set; }
		public string FhRegistro { get; set; }
		public decimal Precio { get; set; }
		public decimal Total { get; set; }
		public Int64 IdMatricula { get; set; }
		public Cuota(){}
		public Cuota(Int64 pId, string pFhRegistro, decimal pPrecio, decimal pTotal, Int64 pIdMatricula)
		{
			Id = pId;
			FhRegistro = pFhRegistro;
			Precio = pPrecio;
			Total = pTotal;
			IdMatricula = pIdMatricula;
		}
	}
}
