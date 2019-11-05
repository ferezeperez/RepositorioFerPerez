using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class ConsultaDeLegados
    {
        Datos.ConsultaDeLegados objDatos = new Datos.ConsultaDeLegados();

        public string TraerAD(string pUsuarios)
        {
            return objDatos.TraerAD(pUsuarios);
        }

        public string TraerLegajo(string pUsuarios)
        {
            return objDatos.TraerLegajo(pUsuarios);
        }

        public string TraerNombre(string pUsuarios)
        {
            return objDatos.TraerNombre(pUsuarios);
        }

        public string TraerMail(string pUsuarios)
        {
            return objDatos.TraerMail(pUsuarios);
        }

        public string TraerLegadosInactividad(string listaID)
        {

            return objDatos.TraerLegadosInactividad(listaID);
        }

        public string TraerLegados(string listaID)
        {

            return objDatos.TraerLegados(listaID);
        }

        public string TraerLegadosPorIdverApp(string listaID)
        {
            return objDatos.TraerLegadosPorIDverApp(listaID);
        }

        public string TraerLegadosPorMail(string pUsuarios)
        {
            return objDatos.TraerLegadosPorMail(pUsuarios);
        }

        public string TraerLegadosPorDNI(string pUsuarios)
        {
            return objDatos.TraerLegadosPorDNI(pUsuarios);
        }

        public string TraerLegadosPorDNIverapp(string pUsuarios)
        {
            return objDatos.TraerLegadosPorDNIVerApp(pUsuarios);
        }

        public string TraerLegadosPorLegajo(string pUsuarios)
        {
            return objDatos.TraerLegadosPorLegajo(pUsuarios);
        }

        public string TraerLegadosPorNombre(string pUsuarios)
        {
            return objDatos.TraerLegadosPorNombre(pUsuarios);
        }

        public string TraerIDporDNI(string pusuarios)
        {
            return objDatos.TraerIDPorDNI(pusuarios);
        }

        public string TraerIDporLegajo(string pusuarios)
        {
            return objDatos.TraerIDporLegajo(pusuarios);
        }

        public string TraerIDporNombre(string pusuarios)
        {
            return objDatos.TraerIDporNombre(pusuarios);
        }

        public string TraerIDporMail(string pusuarios)
        {
            return objDatos.TraerIDporMail(pusuarios);
        }

        public string TraerSAP(string pUsuarios)
        {
            return objDatos.TraerSAP1(pUsuarios);
        }

        public string TraerSAP2(string pUsuarios)
        {
            return objDatos.TraerSAP2(pUsuarios);

        }
    }
}
