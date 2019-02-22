using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GOLLSYSTEM.EntityLayer
{
	public class Empleado
	{
		public Int64 Id { get; set; }
		public string FhRegistro { get; set; }
		public string Telefono { get; set; }
		public string Correo { get; set; }
        public Cv CV { get; set; }
        public Int64 IdPersona { get; set; }
        public Persona Persona { get; set; }
        public Empleado(){}
		public Empleado(Int64 pId, string pFhRegistro, string pTelefono, string pCorreo, Cv pCv, Int64 pIdPersona, Persona pPersona)
		{
			Id = pId;
			FhRegistro = pFhRegistro;
			Telefono = pTelefono;
			Correo = pCorreo;
			CV = pCv;
			IdPersona = pIdPersona;
            Persona = pPersona;

		}
	}
}
