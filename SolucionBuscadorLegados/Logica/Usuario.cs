using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class Usuario
    {
        Datos.Usuario objDatos = new Datos.Usuario();

        public DataTable TraerAD(string ID)
        {
            return objDatos.TraerAD(ID);
        }
    }
}
