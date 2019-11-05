using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BuscadorDeLegados
{
    public partial class frmBuscadorDeLegados : Form
    {
        Logica.Usuario objUsuario = new Logica.Usuario();
        Logica.ConsultaDeLegados objLogica = new Logica.ConsultaDeLegados();

        public frmBuscadorDeLegados()
        {
            InitializeComponent();
            cboBusqueda.SelectedIndex = 0;
            txtMasivo.Visible = false;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            txtMasivo.Visible = true;
        }


        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (cboBusqueda.SelectedItem.ToString() == "ID")
            {
                TraerAD(txtMasivo.Text);
            }
            else
            {
                if (cboBusqueda.SelectedItem.ToString() == "DNI")
                {
                    // traer ad por dni
                    TraerIDporDNI(txtMasivo.Text);
                }
                else
                {
                    if (cboBusqueda.SelectedItem.ToString() == "Legajo")
                    {
                        //traer ad por legajo
                        TraerIDpOrLegajo(txtMasivo.Text);
                    }
                    else
                    {
                        if (cboBusqueda.SelectedItem.ToString() == "Nombre")
                        {
                            // traer ad por nombre
                            TraerIDporNombre(txtMasivo.Text);
                        }
                        else
                        {
                            TraerIDpOrMail(txtMasivo.Text);
                        }
                        
                    }
                }
            }

        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        void TraerAD(string pUsuario)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("samaccountname");
            dt.Columns.Add("Employeeid");
            dt.Columns.Add("Employeenumber");
            dt.Columns.Add("displayname");

            foreach (var linea in txtMasivo.Lines)
            {
                DataRow row = dt.NewRow();
                row["samaccountname"] = linea;
                row["Employeeid"] = objLogica.TraerAD(linea);
                row["Employeenumber"] = objLogica.TraerLegajo(linea);
                row["displayname"] = objLogica.TraerNombre(linea);
                dt.Rows.Add(row);
            }

            dgvUsuarios.DataSource = dt;
        }

        void TraerIDporDNI(string pUsuario)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("DNI");
            dt.Columns.Add("ID");

            foreach (var linea in txtMasivo.Lines)
            {
                DataRow row = dt.NewRow();
                row["DNI"] = linea;
                row["ID"] = objLogica.TraerIDporDNI(linea);
                dt.Rows.Add(row);
            }

            dgvUsuarios.DataSource = dt;
        }

        void TraerIDpOrLegajo(string pUsuario)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("LEGAJO");
            dt.Columns.Add("ID");

            foreach (var linea in txtMasivo.Lines)
            {
                DataRow row = dt.NewRow();
                row["LEGAJO"] = linea;
                row["ID"] = objLogica.TraerIDporLegajo(linea);
                dt.Rows.Add(row);
            }

            dgvUsuarios.DataSource = dt;
        }

        void TraerIDporNombre(string pUsuario)
        {
           DataTable dt = new DataTable();
            dt.Columns.Add("Nombre");
            dt.Columns.Add("ID");

           foreach (var linea in txtMasivo.Lines)
            {
                DataRow row = dt.NewRow();
                row["Nombre"] = linea;
                row["ID"] = objLogica.TraerIDporNombre(linea);
                dt.Rows.Add(row);
            }

            dgvUsuarios.DataSource = dt;
        }

        void TraerIDpOrMail(string pUsuario)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("MAIL");
            dt.Columns.Add("ID");

            foreach (var linea in txtMasivo.Lines)
            {
                DataRow row = dt.NewRow();
                row["MAIL"] = linea;
                row["ID"] = objLogica.TraerIDporMail(linea);
                dt.Rows.Add(row);
            }

            dgvUsuarios.DataSource = dt;
        }
    }
}
