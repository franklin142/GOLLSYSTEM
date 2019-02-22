using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GOLLSYSTEM.EntityLayer
{
	public class Userest
	{
		public Int64 Id { get; set; }
		public string Login { get; set; }
		public string Pass { get; set; }
		public string Rol { get; set; }
        public string Estado { get; set; }

        public Int64 IdSucursal { get; set; }
		public Int64 IdEstudiante { get; set; }
        public Estudiante Estudiante { get; set; }
        public Userest(){}
		public Userest(Int64 pId, string pLogin, string pPass, string pRol,string pEstado, Int64 pIdSucursal, Int64 pIdEstudiante, Estudiante pEstudiante)
		{
			Id = pId;
			Login = pLogin;
			Pass = pPass;
			Rol = pRol;
            Estado = pEstado;
            IdSucursal = pIdSucursal;
			IdEstudiante = pIdEstudiante;
            Estudiante = pEstudiante;
        }
	}
}
