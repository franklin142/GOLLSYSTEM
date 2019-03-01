using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GOLLSYSTEM.EntityLayer
{
	public class Estudiante
	{
		public Int64 Id { get; set; }
        public string FhRegistro { get; set; }
        public string ApMaterno { get; set; }
        public string ApPaterno { get; set; }
        public string Telefono { get; set; }
		public string Enfermedad { get; set; }
		public string Correo { get; set; }
		public string TelEmergencia { get; set; }
		public string ParentEmergencia { get; set; }
		public Int64 IdPersona { get; set; }
        public Persona Persona { get; set; }
        public Estudiante(){}
		public Estudiante(Int64 pId, string pFhRegistro, string pApMaterno,string pApPaterno,  string pTelefono, string pEnfermedad, string pCorreo, string pTelEmergencia, string pParentEmergencia, Int64 pIdPersona, Persona pPersona)
		{
			Id = pId;
            FhRegistro = pFhRegistro;
            ApMaterno = pApMaterno;
            ApPaterno = pApPaterno;
			Telefono = pTelefono;
			Enfermedad = pEnfermedad;
			Correo = pCorreo;
			TelEmergencia = pTelEmergencia;
			ParentEmergencia = pParentEmergencia;
			IdPersona = pIdPersona;
            Persona = pPersona;
		}
	}
}
