using System;
using System.Collections.Generic;
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
        public string Estado { get; set; }
		public Int64 IdContrato { get; set; }
        public Contrato Contrato { get; set; }
        public List<AcsSucursal> Sucursales { get; set; }
        public Useremp(){}
		public Useremp(Int64 pId, string pLogin, string pPass, string pEstado, Int64 pIdContrato, Contrato pContrato, List<AcsSucursal> pSucursales)
		{
			Id = pId;
			Login = pLogin;
			Pass = pPass;
            Estado = pEstado;
			IdContrato = pIdContrato;
            Contrato = pContrato;
            Sucursales = pSucursales;
        }
	}
}
