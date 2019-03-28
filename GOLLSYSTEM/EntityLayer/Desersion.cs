using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GOLLSYSTEM.EntityLayer
{
    public class Desersion
    {
        public Int64 Id { get; set; }
        public string FhRegistro { get; set; }
        public string Nota { get; set; }
        public Int64 IdMatricula { get; set; }
        public Desersion() { }
        public Desersion(Int64 pId, string pFhRegistro, string pNombre, Int64 pIdMatricula)
        {
            Id = pId;
            Nota = pNombre;
            FhRegistro = pFhRegistro;
            IdMatricula = pIdMatricula;
        }
    }
}
