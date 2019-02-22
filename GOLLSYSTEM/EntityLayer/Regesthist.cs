using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GOLLSYSTEM.EntityLayer
{
	public class Regesthist
	{
		public Int64 Id { get; set; }
		public string FhRegistro { get; set; }
		public string Detalle { get; set; }
		public string TipoRegistro { get; set; }
		public string Accion { get; set; }
		public Int64 IdUserEst { get; set; }
		public Regesthist(){}
		public Regesthist(Int64 pId, string pFhRegistro, string pDetalle, string pTipoRegistro, string pAccion, Int64 pIdUserEst)
		{
			Id = pId;
			FhRegistro = pFhRegistro;
			Detalle = pDetalle;
			TipoRegistro = pTipoRegistro;
			Accion = pAccion;
			IdUserEst = pIdUserEst;
		}
	}
}
