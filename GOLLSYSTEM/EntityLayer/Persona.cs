using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GOLLSYSTEM.EntityLayer
{
	public class Persona
	{
		public Int64 Id { get; set; }
		public string Nombre { get; set; }
		public string Dui { get; set; }
		public string Nit { get; set; }
		public string Direccion { get; set; }
        public string FechaNac { get; set; }

        public Persona(){}
		public Persona(Int64 pId, string pNombre, string pDui, string pNit, string pDireccion, string pFechaNac)
		{
			Id = pId;
			Nombre = pNombre;
			Dui = pDui;
			Nit = pNit;
			Direccion = pDireccion;
            FechaNac = pFechaNac;

        }
    }
}
