using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GOLLSYSTEM.EntityLayer
{
	public class Libro
	{
		public Int64 Id { get; set; }
		public string FhRegistro { get; set; }
		public string Nombre { get; set; }
		public string Edicion { get; set; }
		public int NActividades { get; set; }
		public int Nivel { get; set; }
		public Libro(){}
		public Libro(Int64 pId, string pFhRegistro, string pNombre, string pEdicion, int pNActividades, int pNivel)
		{
			Id = pId;
			FhRegistro = pFhRegistro;
			Nombre = pNombre;
			Edicion = pEdicion;
			NActividades = pNActividades;
			Nivel = pNivel;
		}
	}
}
