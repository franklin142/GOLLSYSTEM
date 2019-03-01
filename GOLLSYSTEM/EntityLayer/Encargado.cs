using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GOLLSYSTEM.EntityLayer
{
	public class Encargado
	{
		public Int64 Id { get; set; }
        public string LugarTrabajo { get; set; }
        public string Trabajo { get; set; }
        public string Telefono { get; set; }
		public Int64 IdPersona { get; set; }
        public Persona Persona { get; set; }
        public Encargado(){}
		public Encargado(Int64 pId,string pLugarTrabajo,string pTrabajo, string pTelefono, Int64 pIdPersona, Persona pPersona)
		{
			Id = pId;
            LugarTrabajo = pLugarTrabajo;
            Trabajo = pTrabajo;
            Telefono = pTelefono;
			IdPersona = pIdPersona;
            Persona = pPersona;
		}
	}
}
