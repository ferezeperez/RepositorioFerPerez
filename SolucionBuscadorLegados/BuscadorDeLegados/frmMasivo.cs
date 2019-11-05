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
    public partial class frmMasivo : Form
    {
        Logica.ConsultaDeLegados objLogica = new Logica.ConsultaDeLegados();
        Datos.ConsultaDeLegados objDatos = new Datos.ConsultaDeLegados();

        public frmMasivo()
        {
            InitializeComponent();
            cboBusqueda.SelectedIndex = 0;
           
        }

        public void btnBuscar_Click(object sender, EventArgs e)
        {
            if (cboBusqueda.SelectedItem.ToString()=="SAP")
            {
                TraerSAP(txtMasivo.Text);

            }
            else
            {
                if (cboBusqueda.SelectedItem.ToString()=="Legados")
                {
                    TraerLegados(txtMasivo.Text);

                }
                else
                {
                    // aca va a ir el metodo de inactividad
                    TraerInactividad(txtMasivo.Text);
                }
                
            }
        }

        private void btnMasivo_Click(object sender, EventArgs e)
        {
            txtMasivo.Visible = true;
            txtMasivo.Focus();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        public void TraerSAP(string pUsuario)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("ID");
            dt.Columns.Add("AmbienteporID");
            dt.Columns.Add("DNI");
            dt.Columns.Add("AmbientePorDNI");


            foreach (var linea in txtMasivo.Lines)
            {
                if (linea == " ")
                {

                }
                else
                {
                    DataRow row = dt.NewRow();
                    row["ID"] = linea;
                    row["AmbienteporID"] = objLogica.TraerSAP(linea);
                    row["DNI"] = objLogica.TraerAD(linea);
                    string DNI = objLogica.TraerAD(linea);
                    row["AmbientePorDNI"] = objLogica.TraerSAP2(DNI);
                    dt.Rows.Add(row);
                }
            }

            dgvUsuarios.DataSource = dt;
        }

        public void TraerLegados(string pUsuarios)
        {

            DataTable dt = new DataTable();
            dt.Columns.Add("Id");
            dt.Columns.Add("DNI");
            dt.Columns.Add("APP");
            dt.Columns.Add("ID legados");
            dt.Columns.Add("APPporNombre");
            dt.Columns.Add("Ambiente");
            dt.Columns.Add("AmbientePorDNI");


            foreach (var linea in txtMasivo.Lines)
            {
                if (linea == " ")
                {

                }
                else
                {
                    DataRow row = dt.NewRow();
                    row["Id"] = linea;
                    row["DNI"] = objLogica.TraerAD(linea);
                    row["APP"] = objLogica.TraerLegados(linea);
                    string DNI = objLogica.TraerAD(linea);
                    string Mail = objLogica.TraerMail(linea);
                    if (DNI != " " || DNI != "-" || DNI != "")
                    {
                        row["ID legados"] = objLogica.TraerLegadosPorDNI(DNI);
                    }
                    string Legajo = objLogica.TraerLegajo(linea);
                    if (Legajo !="-")
                    {
                        row["APP"] += objLogica.TraerLegadosPorLegajo(Legajo);
                    }
                    if (Mail == "")
                    {

                    }
                    else
                    {
                        row["APP"] += objLogica.TraerLegadosPorMail(Mail);
                    }
                    string Nombre = objLogica.TraerNombre(linea);
                    if (Nombre != "-" || Nombre != "")
                    {
                        row["APP"] += objLogica.TraerLegadosPorNombre(Nombre);
                    }
                    else
                    {
                        row["APPporNombre"] = "NA";
                    }
                    if (DNI == "")
                    {

                    }
                    else
                    {
                        row["APP"] += objLogica.TraerLegadosPorDNIverapp(DNI);
                    }
                    row["ID legados"] += objLogica.TraerLegadosPorIdverApp(linea);
                    row["Ambiente"] = objLogica.TraerSAP(linea);
                    row["AmbientePorDNI"] = objLogica.TraerSAP2(DNI);
                    dt.Rows.Add(row);
                }
                    
            }
            dgvUsuarios.DataSource = dt;
        }

        public void TraerInactividad(string pUsuario)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("ID");
            dt.Columns.Add("DNI");
            dt.Columns.Add("Legados");


            foreach (var linea in txtMasivo.Lines)
            {
                if (linea == " ")
                {

                }
                else
                {
                    DataRow row = dt.NewRow();
                    row["ID"] = linea;
                    row["DNI"] = objLogica.TraerAD(linea);
                    row["Legados"] = objLogica.TraerLegadosInactividad(linea);
                    dt.Rows.Add(row);
                }
            }

            dgvUsuarios.DataSource = dt;
        }

        //public void ExportarDataGridViewExcel(DataGridView grd)
        //{
        //    try
        //    {
        //        SaveFileDialog archivo = new SaveFileDialog();
        //        archivo.Filter = "Excel (*.xls)|*.xls";
        //        archivo.FileName = "Registro de produccion " + DateTime.Now.Date.ToShortDateString().Replace('/', '-');
        //        if (archivo.ShowDialog() == DialogResult.OK)
        //        {
        //            Microsoft.Office.Interop.Excel.Application aplicacion;
        //            Microsoft.Office.Interop.Excel.Workbook libroDeTrabajo;
        //            Microsoft.Office.Interop.Excel.Worksheet hojaDeTrabajo;
        //            aplicacion = new Microsoft.Office.Interop.Excel.Application();
        //            libroDeTrabajo = aplicacion.Workbooks.Add();
        //            hojaDeTrabajo = (Microsoft.Office.Interop.Excel.Worksheet)libroDeTrabajo.Worksheets.get_Item(1);

        //            hojaDeTrabajo.Cells[1, "A"] = grd.Columns[0].HeaderText;
        //            hojaDeTrabajo.Cells[1, "B"] = grd.Columns[1].HeaderText;
        //            hojaDeTrabajo.Cells[1, "C"] = grd.Columns[2].HeaderText;
        //            hojaDeTrabajo.Cells[1, "D"] = grd.Columns[3].HeaderText;
        //            hojaDeTrabajo.Cells[1, "E"] = grd.Columns[4].HeaderText;
        //            hojaDeTrabajo.Cells[1, "F"] = grd.Columns[5].HeaderText;
        //            hojaDeTrabajo.Cells[1, "G"] = grd.Columns[6].HeaderText;
        //            hojaDeTrabajo.Cells[1, "H"] = grd.Columns[7].HeaderText;
        //            hojaDeTrabajo.Cells[1, "I"] = grd.Columns[8].HeaderText;
        //            hojaDeTrabajo.Cells[1, "J"] = grd.Columns[9].HeaderText;
        //            hojaDeTrabajo.Cells[1, "K"] = grd.Columns[10].HeaderText;
        //            hojaDeTrabajo.Cells[1, "l"] = grd.Columns[11].HeaderText;
        //            hojaDeTrabajo.Cells[1, "M"] = grd.Columns[12].HeaderText;
        //            hojaDeTrabajo.Cells[1, "M"] = grd.Columns[13].HeaderText;
        //            hojaDeTrabajo.Cells[1, "M"] = grd.Columns[14].HeaderText;

        //            hojaDeTrabajo.Columns[1].AutoFit();
        //            hojaDeTrabajo.Columns[2].AutoFit();
        //            hojaDeTrabajo.Columns[3].AutoFit();
        //            hojaDeTrabajo.Columns[4].AutoFit();
        //            hojaDeTrabajo.Columns[5].AutoFit();
        //            hojaDeTrabajo.Columns[6].AutoFit();
        //            hojaDeTrabajo.Columns[7].AutoFit();
        //            hojaDeTrabajo.Columns[8].AutoFit();
        //            hojaDeTrabajo.Columns[9].AutoFit();
        //            hojaDeTrabajo.Columns[10].AutoFit();
        //            hojaDeTrabajo.Columns[11].AutoFit();
        //            hojaDeTrabajo.Columns[12].AutoFit();
        //            hojaDeTrabajo.Columns[13].AutoFit();
        //            hojaDeTrabajo.Columns[14].AutoFit();
        //            hojaDeTrabajo.Name = "Exportacion";
        //            //Recorremos el DataGridView rellenando la hoja de trabajo
        //            for (int i = 0; i < grd.Rows.Count - 1; i++)
        //            {
        //                for (int j = 0; j < grd.Columns.Count; j++)
        //                {
        //                    if (grd.Rows[i].Cells[j].Value != null)
        //                    {
        //                        hojaDeTrabajo.Cells[i + 2, j + 1] = grd.Rows[i].Cells[j].Value.ToString();
        //                    }
        //                }
        //            }
        //            libroDeTrabajo.SaveAs(archivo.FileName,
        //                Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal);
        //            libroDeTrabajo.Close(true);
        //            aplicacion.Quit();
        //            MessageBox.Show("Registro de produccion Exportado a Excel", "AMMNSA");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Error al exportar la informacion debido a: " + ex.ToString());
        //    }
        //}
    }
}
