using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GOLLSYSTEM.EntityLayer
{
    public class Rol
    {
        public Int64 Id { get; set; }
        public string Nombre { get; set; }
        public Rol() { }
        public Rol(Int64 pId, string pNombre)
        {
            Id = pId;
            Nombre = pNombre;
        }
    }
}
