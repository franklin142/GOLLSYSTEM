using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GOLLSYSTEM.EntityLayer
{
	public class Curso
	{
		public Int64 Id { get; set; }
		public string FhRegistro { get; set; }
		public string Nombre { get; set; }
		public string Seccion { get; set; }
		public string Publico { get; set; }
		public string Desde { get; set; }
		public string Hasta { get; set; }
		public string Estado { get; set; }
		public Int64 IdContrato { get; set; }
		public Int64 IdSucursal { get; set; }
		public Int64 IdYear { get; set; }
        public Contrato Contrato { get; set; }
        public Year Year { get; set; }
        public List<Dia> Horario { get; set; }
        public List<Detcurso> Libros { get; set; } 
        public Curso(){}
		public Curso(Int64 pId, string pFhRegistro, string pNombre, string pSeccion, string pPublico, string pDesde, string pHasta, string pEstado, Int64 pIdContrato, Int64 pIdSucursal, Int64 pIdYear, Contrato pContrato,Year pYear, List<Dia> pHorario,List<Detcurso >pLibros)
		{
			Id = pId;
			FhRegistro = pFhRegistro;
			Nombre = pNombre;
			Seccion = pSeccion;
			Publico = pPublico;
			Desde = pDesde;
			Hasta = pHasta;
			Estado = pEstado;
			IdContrato = pIdContrato;
			IdSucursal = pIdSucursal;
			IdYear = pIdYear;
            Contrato = pContrato;
            Year = pYear;
            Horario = pHorario;
            Libros = pLibros;
        }
	}
}
