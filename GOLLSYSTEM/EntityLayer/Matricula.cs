using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GOLLSYSTEM.EntityLayer
{
	public class Matricula
	{
		public Int64 Id { get; set; }
		public string FhRegistro { get; set; }
		public string Estado { get; set; }
		public int Becado { get; set; }
		public int DiaLimite { get; set; }
        public Int64 IdCurso { get; set; }
		public Int64 IdEstudiante { get; set; }
        public Estudiante Estudiante { get; set; }
        public Matricula(){}
		public Matricula(Int64 pId, string pFhRegistro, string pEstado, int pBecado, int pDiaLimite, Int64 pIdCurso, Int64 pIdEstudiante,Estudiante pEstudiante)
		{
			Id = pId;
			FhRegistro = pFhRegistro;
			Estado = pEstado;
			Becado = pBecado;
			DiaLimite = pDiaLimite;
			IdCurso = pIdCurso;
			IdEstudiante = pIdEstudiante;
            Estudiante = pEstudiante;
		}
	}
}
