using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GOLLSYSTEM.EntityLayer
{
	public class Year
	{
		public Int64 Id { get; set; }
		public string Desde { get; set; }
		public string Hasta { get; set; }
		public Year(){}
		public Year(Int64 pId, string pDesde, string pHasta)
		{
			Id = pId;
			Desde = pDesde;
			Hasta = pHasta;
		}
	}
}
