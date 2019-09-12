using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GOLLSYSTEM.EntityLayer
{
	public class Contrato
	{
		public Int64 Id { get; set; }
		public string FhRegistro { get; set; }
		public string FhInicio { get; set; }
		public string FhFin { get; set; }
        public string Estado { get; set; }
        public Int64 IdCargo { get; set; }
		public Int64 IdEmpleado { get; set; }
        public Int64 IdSucursal { get; set; }
        public Cargo Cargo { get; set; }
        public Empleado Empleado { get; set; }

        public Contrato(){}
		public Contrato(Int64 pId, string pFhRegistro, string pFhInicio, string pFhFin, string pEstado, Int64 pIdCargo, Int64 pIdEmpleado,Int64 pIdSucursal, Cargo pCargo, Empleado pEmpleado)
		{
			Id = pId;
			FhRegistro = pFhRegistro;
			FhInicio = pFhInicio;
			FhFin = pFhFin;
            Estado = pEstado;
			IdCargo = pIdCargo;
			IdEmpleado = pIdEmpleado;
            IdSucursal = pIdSucursal;
            Cargo = pCargo;
            Empleado = pEmpleado;
        }
	}
}
