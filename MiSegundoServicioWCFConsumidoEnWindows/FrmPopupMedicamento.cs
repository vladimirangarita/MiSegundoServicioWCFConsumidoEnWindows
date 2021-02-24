using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MiSegundoServicioWCFConsumidoEnWindows.ServiceMedicamento;
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
            MedicamentosClient oMedicamentosClient = new MedicamentosClient();
            oMedicamentosClient.ClientCredentials.UserName.UserName = "lhurol";
            oMedicamentosClient.ClientCredentials.UserName.Password = "1234";
            List<FormaFarmaceuticaCLS> ListaForma = oMedicamentosClient.ListaFormaFarmaceutica();
            ListaForma.Insert(0, new FormaFarmaceuticaCLS { IidFormaFarmaceutica = 0, NombreFormaFarmaceutica = "--Seleccion" });

            cboformaFarmaceutica.DataSource = ListaForma;
            cboformaFarmaceutica.DisplayMember = "NombreFormaFarmaceutica";
            cboformaFarmaceutica.ValueMember = "IidFormaFarmaceutica";
            //Todo bien
            if (iidmedicamento==0)
            {
                this.Text = "Agregrar Medicamento";
                //Pintamos la informacion
            }
            else
            {
                this.Text = "Editando Medicamento";
                MedicamentosClient oMedicamentosClientEditar = new MedicamentosClient();
                oMedicamentosClientEditar.ClientCredentials.UserName.UserName = "lhurol";
                oMedicamentosClientEditar.ClientCredentials.UserName.Password = "1234";
                
                MedicamentoCLS oMedicamento= oMedicamentosClientEditar.RecuperarMedicamento(iidmedicamento);
                txtIdMedicamento.Text = oMedicamento.IidMedicamento.ToString();
                txtnombre.Text = oMedicamento.Nombre;
                txtPrecio.Text = oMedicamento.Precio.ToString();
                txtStock.Text = oMedicamento.Stock.ToString();
                txtPresentacion.Text = oMedicamento.Presentacion;
                txtConcentracion.Text = oMedicamento.Concentracion;
                cboformaFarmaceutica.SelectedValue = oMedicamento.IidFormaFarmaceutica;

            }
        }

        private void SoloNumeros(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            } else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void SoloDecimales(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar) || e.KeyChar=='.' || e.KeyChar == ',')
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void cmdAceptar_Click(object sender, EventArgs e)
        {
            var exito = true;
            if (txtnombre.Text=="")
            {
                errorDatos.SetError(txtnombre, "Ingrese nombre");
                exito = false;
            }
            else
            {
                errorDatos.SetError(txtnombre, "");
            }


            if (txtStock.Text == "")
            {
                errorDatos.SetError(txtStock, "Ingrese Stock");
                exito = false;
            }
            else
            {
                errorDatos.SetError(txtnombre, "");
            }




            if (txtPrecio.Text == "")
            {
                errorDatos.SetError(txtPrecio, "Ingrese precio");
                exito = false;
            }
            else
            {
                errorDatos.SetError(txtPrecio, "");
            }

            if (txtPresentacion.Text == "")
            {
                errorDatos.SetError(txtPresentacion, "Ingrese Presentacion");
                exito = false;
            }
            else
            {
                errorDatos.SetError(txtPresentacion, "");
            }

            if ((int)cboformaFarmaceutica.SelectedValue==0)
            {
                errorDatos.SetError(cboformaFarmaceutica, "Ingrese Forma Farmaceutica");
                exito = false;
            }
            else
            {
                errorDatos.SetError(cboformaFarmaceutica, "");
            }


            if (exito==false)
            {
                this.DialogResult = DialogResult.None;
            }

            //ingresando o editando
            
            //Nuevo
            if (txtIdMedicamento.Text=="")
            {

            }
            else
            //Editar
            {

            }
        }
    }
}
