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
    public partial class frmMenu : Form
    {
        public frmMenu()
        {
            InitializeComponent();
        }

        private void btnBuscarUno_Click(object sender, EventArgs e)
        {
            frmBuscadorDeLegados objfrmbuscadordelegados = new frmBuscadorDeLegados();
            MostrarForm(objfrmbuscadordelegados);
        }

        private void btnBuscarMasivo_Click(object sender, EventArgs e)
        {
            frmMasivo objfrmmasivo = new frmMasivo();
            MostrarForm(objfrmmasivo);
        }

        void MostrarForm(Form pForm)
        {
            // que se muestre en el centro
            pForm.StartPosition = FormStartPosition.CenterScreen;
            // mostrar
            pForm.Show();
        }

    }
}
