using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GOLLSYSTEM.EntityLayer
{
    public class AcsSucursal
    {
        public Int64 Id { get; set; }
        public string FhRegistro { get; set; }
        public int IdUserEmp { get; set; }
        public Int64 IdRol { get; set; }
        public Int64 IdSucursal { get; set; }
        public Sucursal Sucursal { get; set; }
        public Rol Rol { get; set; }
        public List<LstPermiso> Permisos { get; set; }
        public AcsSucursal() { }
        public AcsSucursal(Int64 pId, string pFhRegistro, int pIdUserEmp, Int64 pIdRol, Int64 pIdSucursal, Rol pRol, Sucursal pSucursal, List<LstPermiso> pPermisos)
        {
            Id = pId;
            FhRegistro = pFhRegistro;
            IdUserEmp = pIdUserEmp;
            IdRol = pIdRol;
            IdSucursal = pIdSucursal;
            Rol = pRol;
            Sucursal = pSucursal;
            Permisos = pPermisos;
        }
        
    }
    
}
