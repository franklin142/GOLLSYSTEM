using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GOLLSYSTEM.EntityLayer
{
    public class Permiso
    {
        public Int64 Id { get; set; }
        public string Nombre { get; set; }
        public string Categoria { get; set; }
        public Permiso() { }
        public Permiso(Int64 pId, string pNombre, string pCategoria)
        {
            Id = pId;
            Nombre = pNombre;
            Categoria = pCategoria;
        }
    }
}
