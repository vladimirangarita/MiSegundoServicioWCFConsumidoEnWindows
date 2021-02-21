using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiSegundoServicioWCFConsumidoEnWindows
{
    public partial class FrmPopupMedicamento : Form
    {
        public int iidmedicamento { get; set; }
        public FrmPopupMedicamento()
        {
            InitializeComponent();
        }

        private void FrmPopupMedicamento_Load(object sender, EventArgs e)
        {
            if (iidmedicamento==0)
            {
                this.Text = "Agregrar Medicamento";
            }
            else
            {
                this.Text = "Editando Medicamento";
            }
        }
    }
}
