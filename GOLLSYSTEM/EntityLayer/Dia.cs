using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GOLLSYSTEM.EntityLayer
{
	public class Dia
	{
		public Int64 Id { get; set; }
		public string Nombre { get; set; }
		public string HEntrada { get; set; }
		public string HSalida { get; set; }
		public Int64 IdCurso { get; set; }
		public Dia(){}
		public Dia(Int64 pId, string pNombre, string pHEntrada, string pHSalida, Int64 pIdCurso)
		{
			Id = pId;
			Nombre = pNombre;
			HEntrada = pHEntrada;
			HSalida = pHSalida;
			IdCurso = pIdCurso;
		}
	}
}
