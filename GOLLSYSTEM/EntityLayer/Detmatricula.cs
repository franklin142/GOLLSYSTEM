using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GOLLSYSTEM.EntityLayer
{
	public class Detmatricula
	{
		public Int64 Id { get; set; }
		public Int64 IdMatricula { get; set; }
		public Int64 IdEncargado { get; set; }
        public Encargado encargado { get; set; }
		public Detmatricula(){}
		public Detmatricula(Int64 pId, Int64 pIdMatricula, Int64 pIdEncargado,Encargado pEncargado)
		{
			Id = pId;
			IdMatricula = pIdMatricula;
			IdEncargado = pIdEncargado;
            encargado = pEncargado;
		}
	}
}
