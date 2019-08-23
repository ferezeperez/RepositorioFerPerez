using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace frmBuscandoAD
{
    public class Log
    {
        public string ID { get; set; }

        public string FechaExpiracion { get; set; }

        public string Habilitado { get; set; }

        public DateTime Creacion { get; set; }

        public DateTime Modificado { get; set; }

        public string UltimoAcceso { get; set; }

        public string UltimoAccesoMarcado { get; set; }

        public string UltimoCambioPassword { get; set; }
    }
}
