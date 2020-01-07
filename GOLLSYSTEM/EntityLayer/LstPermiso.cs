
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GOLLSYSTEM.EntityLayer
{
    public class LstPermiso
    {
        public Int64 Id { get; set; }
        public string FhRegistro { get; set; }
        public bool Otorgado { get; set; }
        public int IdPermiso { get; set; }
        public int IdAscSucursal { get; set; }
        public Permiso Permiso { get; set; }
        public LstPermiso() { }
        public LstPermiso(Int64 pId, string pFhRegistro, bool pOtorgado, int pIdPermiso, int pIdAscSucursal, Permiso pPermiso)
        {
            Id = pId;
            FhRegistro = pFhRegistro;
            Otorgado = pOtorgado;
            IdPermiso = pIdPermiso;
            IdAscSucursal = pIdAscSucursal;
            Permiso = pPermiso;
        }
    }
}
