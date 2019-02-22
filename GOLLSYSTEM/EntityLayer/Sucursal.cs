using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GOLLSYSTEM.EntityLayer
{
	public class Sucursal
	{
		public Int64 Id { get; set; }
		public string FhRegistro { get; set; }
		public string Nombre { get; set; }
		public string Direccion { get; set; }
        public List<Curso> Cursos { get; set; }
        public Sucursal(){}
		public Sucursal(Int64 pId, string pFhRegistro, string pNombre, string pDireccion,List<Curso>pCursos)
		{
			Id = pId;
			FhRegistro = pFhRegistro;
			Nombre = pNombre;
			Direccion = pDireccion;
            Cursos = pCursos;
		}
	}
}
