using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GOLLSYSTEM.EntityLayer
{
    public class Matricdetfac
    {
        public Int64 Id { get; set; }
        public Int64 IdDetFactura { get; set; }
        public Int64 IdCuota { get; set; }
        public Matricdetfac() { }
        public Matricdetfac(Int64 pId, Int64 pIdDetFactura, Int64 pIdCuota) {
            this.Id = pId;
            this.IdDetFactura = pIdDetFactura;
            this.IdCuota = pIdCuota;

        }

    }
}
