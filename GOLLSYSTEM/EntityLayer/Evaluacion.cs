using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GOLLSYSTEM.EntityLayer
{
	public class Evaluacion
	{
		public Int64 Id { get; set; }
		public string FhRegistro { get; set; }
		public string Nombre { get; set; }
		public string Tipo { get; set; }
		public string Porcentaje { get; set; }
		public Int64 IdDetCurso { get; set; }
        public List<Calificacion> calificaciones { get; set; }
        public Evaluacion(){}
		public Evaluacion(Int64 pId, string pFhRegistro, string pNombre, string pTipo, string pPorcentaje, Int64 pIdDetCurso, List<Calificacion> pCalificaciones)
		{
			Id = pId;
			FhRegistro = pFhRegistro;
			Nombre = pNombre;
			Tipo = pTipo;
			Porcentaje = pPorcentaje;
			IdDetCurso = pIdDetCurso;
            calificaciones = pCalificaciones;
		}
	}
}
