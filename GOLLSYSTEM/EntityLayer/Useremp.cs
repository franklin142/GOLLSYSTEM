using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GOLLSYSTEM.EntityLayer
{
	public class Useremp
	{
		public Int64 Id { get; set; }
		public string Login { get; set; }
		public string Pass { get; set; }
		public string Rol { get; set; }
        public string Estado { get; set; }

        public Int64 IdSucursal { get; set; }
		public Int64 IdContrato { get; set; }
        public Contrato Contrato { get; set; }
        public Useremp(){}
		public Useremp(Int64 pId, string pLogin, string pPass, string pRol, string pEstado, Int64 pIdSucursal, Int64 pIdContrato, Contrato pContrato)
		{
			Id = pId;
			Login = pLogin;
			Pass = pPass;
			Rol = pRol;
            Estado = pEstado;
			IdSucursal = pIdSucursal;
			IdContrato = pIdContrato;
            Contrato = pContrato;
        }
	}
}
