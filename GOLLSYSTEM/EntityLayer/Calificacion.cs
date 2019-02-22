using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GOLLSYSTEM.EntityLayer
{
	public class Calificacion
	{
		public Int64 Id { get; set; }
		public string FhRegistro { get; set; }
		public string Nota { get; set; }
		public Int64 IdEvaluacion { get; set; }
		public Int64 IdMatricula { get; set; }
		public Calificacion(){}
		public Calificacion(Int64 pId, string pFhRegistro, string pNota, Int64 pIdEvaluacion, Int64 pIdMatricula)
		{
			Id = pId;
			FhRegistro = pFhRegistro;
			Nota = pNota;
			IdEvaluacion = pIdEvaluacion;
			IdMatricula = pIdMatricula;
		}
	}
}
