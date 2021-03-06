using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GOLLSYSTEM.EntityLayer
{
	public class Detfactura
	{
		public Int64 Id { get; set; }
		public string Concepto { get; set; }
		public decimal Total { get; set; }
		public decimal Descuento { get; set; }
        public string Tipo { get; set; }
        public string RefNFactura { get; set; }

        public Int64 IdFactura { get; set; }
		public Int64 IdProducto { get; set; }
        public Producto Producto { get; set; }
        public Matricdetfac Matricdetfac { get; set; }
        public Detfactura(){}
		public Detfactura(Int64 pId, string pConcepto, decimal pTotal, decimal pDescuento,string pTipo,string pRefNFactura, Int64 pIdFactura, Int64 pIdProducto,Producto pProducto, Matricdetfac pMatricdetfac)
		{
			Id = pId;
			Concepto = pConcepto;
			Total = pTotal;
			Descuento = pDescuento;
            Tipo = pTipo;
            RefNFactura = pRefNFactura;
            IdFactura = pIdFactura;
			IdProducto = pIdProducto;
            Producto = pProducto;
            Matricdetfac = pMatricdetfac;
        }
	}
}
