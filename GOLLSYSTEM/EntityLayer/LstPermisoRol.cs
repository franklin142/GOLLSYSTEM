using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GOLLSYSTEM.EntityLayer
{
    public class LstPermisoRol
    {
        public Int64 Id { get; set; }
        public string FhRegistro { get; set; }
        public int IdRol { get; set; }
        public int IdPermiso { get; set; }
        public Permiso Permiso { get; set; }
        public LstPermisoRol() { }
        public LstPermisoRol(Int64 pId, string pFhRegistro, int pIdRol, int pIdPermiso, Permiso pPermiso)
        {
            Id = pId;
            FhRegistro = pFhRegistro;
            IdRol = pIdRol;
            IdPermiso = pIdPermiso;
            Permiso = pPermiso;
        }
    }
}
