using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GOLLSYSTEM.EntityLayer
{
	public class Factura
	{
		public Int64 Id { get; set; }
		public string FhRegistro { get; set; }
		public string NFactura { get; set; }
		public string Observacion { get; set; }
		public decimal Total { get; set; }
        public string Estado { get; set; }
        public Int64 IdPersona { get; set; }
		public Int64 IdSucursal { get; set; }
        public List<Detfactura> DetsFactura { get; set; }
        public Factura(){}
		public Factura(Int64 pId, string pFhRegistro, string pNFactura, string pObservacion, decimal pTotal,string pEstado, Int64 pIdPersona, Int64 pIdSucursal, List<Detfactura> pDetsFactura)
		{
			Id = pId;
			FhRegistro = pFhRegistro;
			NFactura = pNFactura;
			Observacion = pObservacion;
			Total = pTotal;
            Estado = pEstado;
			IdPersona = pIdPersona;
			IdSucursal = pIdSucursal;
            DetsFactura = pDetsFactura;
		}
	}
}
