using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class Usuario
    {
        public DataTable TraerAD(string ID)
        {
            DataTable dt = new DataTable();
            SqlConnection cn = new SqlConnection(Conexion.strConexion);
            SqlDataAdapter objDataTraer = new SqlDataAdapter("proc_traer_ad", cn);
            objDataTraer.SelectCommand.CommandType = CommandType.StoredProcedure;
            objDataTraer.SelectCommand.Parameters.AddWithValue("@UsuariosABuscar", ID);
            objDataTraer.Fill(dt);
            return dt;
        }
    }
}
