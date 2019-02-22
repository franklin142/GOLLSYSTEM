using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GOLLSYSTEM.EntityLayer
{
	public class Cv
	{
		public Int64 Id { get; set; }
		public string FhRegistro { get; set; }
		public string Nombre { get; set; }
		public int FileSize { get; set; }
		public byte[] Archivo { get; set; }
		public Int64 IdEmpleado { get; set; }
		public Cv(){}
		public Cv(Int64 pId, string pFhRegistro, string pNombre, int pFileSize, byte[] pArchivo, Int64 pIdEmpleado)
		{
			Id = pId;
			FhRegistro = pFhRegistro;
			Nombre = pNombre;
			FileSize = pFileSize;
			Archivo = pArchivo;
			IdEmpleado = pIdEmpleado;
		}
	}
}
