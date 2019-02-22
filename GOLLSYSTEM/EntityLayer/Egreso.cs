using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GOLLSYSTEM.EntityLayer
{
	public class Egreso
	{
		public Int64 Id { get; set; }
		public string FhRegistro { get; set; }
		public string Tipo { get; set; }
		public string Nombre { get; set; }
		public decimal Total { get; set; }
        public string Estado { get; set; }

        public Int64 IdSucursal { get; set; }
		public Egreso(){}
		public Egreso(Int64 pId, string pFhRegistro, string pTipo, string pNombre, decimal pTotal,string pEstado, Int64 pIdSucursal)
		{
			Id = pId;
			FhRegistro = pFhRegistro;
			Tipo = pTipo;
			Nombre = pNombre;
			Total = pTotal;
            Estado = pEstado;
			IdSucursal = pIdSucursal;
		}
	}
}
