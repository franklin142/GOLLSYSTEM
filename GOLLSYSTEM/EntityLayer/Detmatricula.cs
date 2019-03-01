using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GOLLSYSTEM.EntityLayer
{
	public class Detmatricula
	{
		public Int64 Id { get; set; }
        public string Parentesco { get; set; }
        public Int64 IdMatricula { get; set; }
		public Int64 IdEncargado { get; set; }
        public Encargado encargado { get; set; }
		public Detmatricula(){}
		public Detmatricula(Int64 pId,string pParentesco, Int64 pIdMatricula, Int64 pIdEncargado,Encargado pEncargado)
		{
			Id = pId;
            Parentesco = pParentesco;
            IdMatricula = pIdMatricula;
			IdEncargado = pIdEncargado;
            encargado = pEncargado;
		}
	}
}
