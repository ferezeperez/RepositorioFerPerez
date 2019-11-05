using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class ConsultaDeLegados
    {
        public string TraerAD(string ID)
        {

            string Valores = string.Empty;
            using (SqlConnection cn = new SqlConnection(Conexion.strConexion))
            {
                cn.Open();

                SqlCommand cmd1 = new SqlCommand("proc_buscar_dni_AD", cn);
                cmd1.CommandType = CommandType.StoredProcedure;
                cmd1.Parameters.AddWithValue("@UsuariosABuscar", ID);

                SqlDataReader reader1 = cmd1.ExecuteReader();
                while (reader1.Read())
                {
                    if (reader1.IsDBNull(0))
                    {
                        Valores = null;
                    }
                    else
                    {
                        Valores += reader1.GetString(0);
                    }
                }
                return Valores;
            }
        }

        public string TraerLegajo(string ID)
        {

            string Valores = string.Empty;
            using (SqlConnection cn = new SqlConnection(Conexion.strConexion))
            {
                cn.Open();

                SqlCommand cmd1 = new SqlCommand("proc_buscar_Legajo_AD", cn);
                cmd1.CommandType = CommandType.StoredProcedure;
                cmd1.Parameters.AddWithValue("@UsuariosABuscar", ID);

                SqlDataReader reader1 = cmd1.ExecuteReader();
                while (reader1.Read())
                {
                    if (reader1.IsDBNull(0))
                    {
                        Valores = null;
                    }
                    else
                    {
                        Valores += reader1.GetString(0);
                    }
                }
                return Valores;
            }
        }

        public string TraerNombre(string ID)
        {

            string Valores = string.Empty;
            using (SqlConnection cn = new SqlConnection(Conexion.strConexion))
            {
                cn.Open();

                SqlCommand cmd1 = new SqlCommand("proc_buscar_Nombre_AD", cn);
                cmd1.CommandType = CommandType.StoredProcedure;
                cmd1.Parameters.AddWithValue("@UsuariosABuscar", ID);

                SqlDataReader reader1 = cmd1.ExecuteReader();
                while (reader1.Read())
                {
                    if (reader1.IsDBNull(0))
                    {
                        Valores = null;
                    }
                    else
                    {
                        Valores += reader1.GetString(0);
                    }
                }
                return Valores;
            }
        }

        public string TraerMail(string ID)
        {

            string Valores = string.Empty;
            using (SqlConnection cn = new SqlConnection(Conexion.strConexion))
            {
                cn.Open();

                SqlCommand cmd1 = new SqlCommand("proc_buscar_mail_AD", cn);
                cmd1.CommandType = CommandType.StoredProcedure;
                cmd1.Parameters.AddWithValue("@UsuariosABuscar", ID);

                SqlDataReader reader1 = cmd1.ExecuteReader();
                while (reader1.Read())
                {
                    if (reader1.IsDBNull(0))
                    {
                        Valores = null;
                    }
                    else
                    {
                        Valores += reader1.GetString(0);
                    }
                }
                return Valores;
            }
        }


        public string TraerIDPorDNI(string ID)
        {

            string Valores = string.Empty;
            char[] charsToTrim = { '0' };

            ID = ID.TrimStart(charsToTrim);

            using (SqlConnection cn = new SqlConnection(Conexion.strConexion))
            {
                cn.Open();

                SqlCommand cmd1 = new SqlCommand("proc_buscar_AD_pordni", cn);
                cmd1.CommandType = CommandType.StoredProcedure;
                cmd1.Parameters.AddWithValue("@UsuariosABuscar", ID);

                SqlDataReader reader1 = cmd1.ExecuteReader();
                while (reader1.Read())
                {
                    if (reader1.IsDBNull(0))
                    {
                        Valores = null;
                    }
                    else
                    {
                        Valores += reader1.GetString(0)+ "-";
                    }
                }
                return Valores;
            }

        }

        public string TraerIDporLegajo(string ID)
        {

            string Valores = string.Empty;
            using (SqlConnection cn = new SqlConnection(Conexion.strConexion))
            {
                cn.Open();

                SqlCommand cmd1 = new SqlCommand("proc_buscar_AD_porlegajo", cn);
                cmd1.CommandType = CommandType.StoredProcedure;
                cmd1.Parameters.AddWithValue("@UsuariosABuscar", ID);

                SqlDataReader reader1 = cmd1.ExecuteReader();
                while (reader1.Read())
                {
                    if (reader1.IsDBNull(0))
                    {
                        Valores = null;
                    }
                    else
                    {
                        Valores += reader1.GetString(0) + "-";
                    }
                }
                return Valores;
            }

        }

        public string TraerIDporNombre(string ID)
        {
            string Valores = string.Empty;
            using (SqlConnection cn = new SqlConnection(Conexion.strConexion))
            {
                cn.Open();

                SqlCommand cmd1 = new SqlCommand("proc_buscar_AD_pornombre", cn);
                cmd1.CommandType = CommandType.StoredProcedure;
                cmd1.Parameters.AddWithValue("@UsuariosABuscar", ID);

                if (ID !="")
                {
                    SqlDataReader reader2 = cmd1.ExecuteReader();
                    while (reader2.Read())
                    {
                        if (reader2.IsDBNull(0))
                        {
                            Valores = null;
                        }
                        else
                        {
                            Valores += reader2.GetString(0) + "-";
                        }
                    }
                }
                return Valores;
            }
        }

        public string TraerIDporMail(string ID)
        {

            string Valores = string.Empty;
            using (SqlConnection cn = new SqlConnection(Conexion.strConexion))
            {
                cn.Open();

                SqlCommand cmd1 = new SqlCommand("proc_buscar_AD_pormail", cn);
                cmd1.CommandType = CommandType.StoredProcedure;
                cmd1.Parameters.AddWithValue("@UsuariosABuscar", ID);

                SqlDataReader reader1 = cmd1.ExecuteReader();
                while (reader1.Read())
                {
                    if (reader1.IsDBNull(0))
                    {
                        Valores = null;
                    }
                    else
                    {
                        Valores += reader1.GetString(0) + "-";
                    }
                }
                return Valores;
            }

        }

        public string TraerLegadosInactividad(string ID)
        {
            string Valores = string.Empty;
            using (SqlConnection cn = new SqlConnection(Conexion.strConexion))
            {
                cn.Open();

                SqlCommand cmd1 = new SqlCommand("proc_buscar_AD_Inactividad", cn);
                cmd1.CommandType = CommandType.StoredProcedure;
                cmd1.Parameters.AddWithValue("@UsuariosABuscar", ID);

                SqlDataReader reader2 = cmd1.ExecuteReader();
                while (reader2.Read())
                {
                    if (reader2.IsDBNull(0))
                    {
                        Valores = null;
                    }
                    else
                    {
                        Valores += reader2.GetString(0) + "-";
                    }
                }
                return Valores;
            }
        }

        public string TraerLegados(string ID)
        {
            string Valores = string.Empty;
            using (SqlConnection cn = new SqlConnection(Conexion.strConexion))
            {
                cn.Open();

                SqlCommand cmd1 = new SqlCommand("proc_consulta_legados", cn);
                cmd1.CommandType = CommandType.StoredProcedure;
                cmd1.Parameters.AddWithValue("@UsuariosABuscar", ID);

                SqlDataReader reader2 = cmd1.ExecuteReader();
                while (reader2.Read())
                {
                    if (reader2.IsDBNull(0))
                    {
                        Valores = null;
                    }
                    else
                    {
                        Valores += reader2.GetString(0)+"-";
                    }
                }
                return Valores;
            }
        }

        public string TraerLegadosPorIDverApp(string ID)
        {

            string Valores = string.Empty;
            using (SqlConnection cn = new SqlConnection(Conexion.strConexion))
            {
                try
                {
                    cn.Open();

                    SqlCommand cmd1 = new SqlCommand("proc_consulta_legados_porid_verapp", cn);
                    cmd1.CommandType = CommandType.StoredProcedure;
                    cmd1.Parameters.AddWithValue("@UsuariosABuscar", ID);

                    SqlDataReader reader1 = cmd1.ExecuteReader();
                    while (reader1.Read())
                    {
                        if (reader1.IsDBNull(0))
                        {
                            Valores = null;
                        }
                        else
                        {
                            Valores += reader1.GetString(0) + "-";
                            Valores += reader1.GetString(1) + "-";
                        }
                    }

                }
                catch (Exception)
                {

                    Valores += "";
                }

                return Valores;

            }

        }

        public string TraerLegadosPorMail(string ID)
        {
            string Valores = string.Empty;
            using (SqlConnection cn = new SqlConnection(Conexion.strConexion))
            {
                cn.Open();

                SqlCommand cmd1 = new SqlCommand("proc_consulta_legados_pormail", cn);
                cmd1.CommandType = CommandType.StoredProcedure;
                cmd1.Parameters.AddWithValue("@UsuariosABuscar", ID);

                 SqlDataReader reader1 = cmd1.ExecuteReader();
                 while (reader1.Read())
                 {
                    if (reader1.IsDBNull(0))
                    {
                        Valores = null;
                    }
                    else
                    {
                        Valores += reader1.GetString(0) + "-";
                    }
                 }
                return Valores;
            }

        }

        public string TraerLegadosPorDNI(string ID)
        {

            string Valores = string.Empty;
            using (SqlConnection cn = new SqlConnection(Conexion.strConexion))
            {
                try
                {
                    cn.Open();

                    SqlCommand cmd1 = new SqlCommand("proc_consulta_legados_pordni", cn);
                    cmd1.CommandType = CommandType.StoredProcedure;
                    cmd1.Parameters.AddWithValue("@UsuariosABuscar", ID);

                    SqlDataReader reader1 = cmd1.ExecuteReader();
                    while (reader1.Read())
                    {
                        if (reader1.IsDBNull(0))
                        {
                            Valores = null;
                        }
                        else
                        {
                            Valores += reader1.GetString(0) + "-";
                            Valores += reader1.GetString(1) + "-";
                        }
                    }
                    
                }
                catch (Exception)
                {

                    Valores+="";
                }

                return Valores;

            }

        }

        public string TraerLegadosPorDNIVerApp(string ID)
        {

            string Valores = string.Empty;
            using (SqlConnection cn = new SqlConnection(Conexion.strConexion))
            {
                cn.Open();

                SqlCommand cmd1 = new SqlCommand("proc_consulta_legados_pordni_verapp", cn);
                cmd1.CommandType = CommandType.StoredProcedure;
                cmd1.Parameters.AddWithValue("@UsuariosABuscar", ID);

                SqlDataReader reader1 = cmd1.ExecuteReader();
                while (reader1.Read())
                {
                    if (reader1.IsDBNull(0))
                    {
                        Valores = null;
                    }
                    else
                    {
                        Valores += reader1.GetString(0) + "-";
                    }
                }
                return Valores;
            }

        }

        public string TraerLegadosPorLegajo(string ID)
        {
            string Valores = string.Empty;
            using (SqlConnection cn = new SqlConnection(Conexion.strConexion))
            {
                cn.Open();

                SqlCommand cmd1 = new SqlCommand("proc_consulta_legados_porlegajo", cn);
                cmd1.CommandType = CommandType.StoredProcedure;
                cmd1.Parameters.AddWithValue("@UsuariosABuscar", ID);

                if (ID != "EXTERNO" || ID != "-" || ID !="")
                {
                    SqlDataReader reader1 = cmd1.ExecuteReader();
                    while (reader1.Read())
                    {
                        if (reader1.IsDBNull(0))
                        {
                            Valores = null;
                        }
                        else
                        {
                            Valores += reader1.GetString(0) + "-";
                        }
                    }
                }
                return Valores;
            }

        }

        public string TraerLegadosPorNombre(string ID)
        {
            string Valores = string.Empty;
            try
            {
                using (SqlConnection cn = new SqlConnection(Conexion.strConexion))
                {
                    cn.Open();

                    SqlCommand cmd1 = new SqlCommand("proc_valido_usuario_pornombre", cn);
                    cmd1.CommandType = CommandType.StoredProcedure;
                    cmd1.Parameters.AddWithValue("@UsuariosABuscar", ID);
                    if (ID != "")
                    {
                        SqlDataReader reader1 = cmd1.ExecuteReader();
                        while (reader1.Read())
                        {
                            if (reader1.IsDBNull(0))
                            {
                                Valores = null;
                            }
                            else
                            {
                                Valores += reader1.GetString(0) + "-";
                            }
                        }
                    }
                    

                }
            }
            catch (Exception)
            {

                Valores += "error";
            }

            return Valores;

        }

        public string TraerSAP1(string ID)
        {
            string Valores= string.Empty;
            using (SqlConnection cn = new SqlConnection(Conexion.strConexion))
            {
                cn.Open();
                SqlCommand cmd2 = new SqlCommand("proc_consulta_sap", cn);
                cmd2.CommandType = CommandType.StoredProcedure;
                cmd2.Parameters.AddWithValue("@UsuariosABuscar", ID);
                SqlDataReader reader2 = cmd2.ExecuteReader();
                while (reader2.Read())
                {
                    if (reader2.IsDBNull(0))
                    {
                        Valores = null;
                    }
                    else
                    {
                        Valores += reader2.GetString(0) + "-";
                        Valores += reader2.GetString(1) + ",";
                    }

                }
            }
            return Valores;
        }

        public string TraerSAP2(string ID)
        {
            string Valores = string.Empty;

            using (SqlConnection cn = new SqlConnection(Conexion.strConexion))
            {
                cn.Open();
                SqlCommand cmd2 = new SqlCommand("proc_consulta_sap_pordni", cn);
                cmd2.CommandType = CommandType.StoredProcedure;
                cmd2.Parameters.AddWithValue("@UsuariosABuscar", ID);

                SqlDataReader reader2 = cmd2.ExecuteReader();
                while (reader2.Read())
                {
                    if (reader2.IsDBNull(0))
                    {
                        Valores = null;
                    }
                    else
                    {
                        Valores += reader2.GetString(0) + "-";
                        Valores += reader2.GetString(1) + ",";
                    }
                }
            }
            return Valores;
        }

    }
}
