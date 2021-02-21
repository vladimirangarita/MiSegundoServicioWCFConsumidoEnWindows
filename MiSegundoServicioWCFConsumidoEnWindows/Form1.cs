using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MiSegundoServicioWCFConsumidoEnWindows.ServiceMedicamento;
namespace MiSegundoServicioWCFConsumidoEnWindows
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Listar();

        }

        private void Listar()
        {
            ServicePointManager.ServerCertificateValidationCallback = new System.Net.Security.RemoteCertificateValidationCallback(remove);
            MedicamentosClient oMedicamentosClient = new MedicamentosClient();
            oMedicamentosClient.ClientCredentials.UserName.UserName = "lhurol";
            oMedicamentosClient.ClientCredentials.UserName.Password = "1234";

            List<MedicamentoCLS> Lista = oMedicamentosClient.ListarMedicamentos().Where(p => p.BHabilitado == 1).ToList();
            dgvMedicamento.DataSource = Lista;
            dgvMedicamento.Columns["IidFormaFarmaceutica"].Visible = false;
            dgvMedicamento.Columns["bhabilitado"].Visible = false;
        }

        private bool remove(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
        {
            return true;
        }

        private void toolStripNuevo_Click(object sender, EventArgs e)
        {
            FrmPopupMedicamento ofrmPopupMedicmento = new FrmPopupMedicamento();
            ofrmPopupMedicmento.iidmedicamento = 0;
         
            ofrmPopupMedicmento.ShowDialog();
        }

        private void toolStripEditar_Click(object sender, EventArgs e)
        {
            FrmPopupMedicamento ofrmPopupMedicmento = new FrmPopupMedicamento();
            int idMedicamento = (int)dgvMedicamento.CurrentRow.Cells[0].Value;
            ofrmPopupMedicmento.iidmedicamento = idMedicamento;
            ofrmPopupMedicmento.ShowDialog();
        }

        private void toolStripEliminar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Eliminar?","",MessageBoxButtons.YesNo).Equals(DialogResult.Yes))
            {
                int idMedicamento = (int)dgvMedicamento.CurrentRow.Cells[0].Value;
                MedicamentosClient oMedicamentosClient = new MedicamentosClient();
                oMedicamentosClient.ClientCredentials.UserName.UserName = "lhurol";
                oMedicamentosClient.ClientCredentials.UserName.Password = "1234";
                int rpta=  oMedicamentosClient.EliminarMedicamento(idMedicamento);
                if (rpta==1)
                {
                    Listar();
                    MessageBox.Show("Eliminado");
                }
                else
                {
                    MessageBox.Show("Error");
                }
                
            }
        }
    }
}
