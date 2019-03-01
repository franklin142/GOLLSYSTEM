using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GOLLSYSTEM.EntityLayer
{
	public class Detcurso
	{
		public Int64 Id { get; set; }
		public string FhRegistro { get; set; }
        public string Estado { get; set; }
        public Int64 IdLibro { get; set; }
		public Int64 IdCurso { get; set; }
        public Libro Libro { get; set; }
		public Detcurso(){}
		public Detcurso(Int64 pId, string pFhRegistro, string pEstado, Int64 pIdLibro, Int64 pIdCurso,Libro pLibro)
		{
			Id = pId;
			FhRegistro = pFhRegistro;
            Estado = pEstado;
			IdLibro = pIdLibro;
			IdCurso = pIdCurso;
            Libro = pLibro;
		}
	}
}
