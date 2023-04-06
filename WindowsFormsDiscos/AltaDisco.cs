using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dominio;
using Negocio;

namespace WindowsFormsDiscos
{
    public partial class AltaDisco : Form
    {
        public AltaDisco()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            Disco aux = new Disco();
            DiscoNegocio negocio = new DiscoNegocio();

            try
            {
                aux.Titulo = txtTitulo.Text;
                aux.FechaLanzamiento = dtpFecha.Value;
                aux.CantidadCanciones = int.Parse(txtCantidadCanciones.Text);

                negocio.agregar(aux);
                MessageBox.Show("Agregado exitosamente");
                Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void AltaDisco_Load(object sender, EventArgs e)
        {
            TipoNegocio tiponegocio = new TipoNegocio();
            try
            {
                cboEstilo.DataSource = tiponegocio.listar();
                cboTipo.DataSource = tiponegocio.ListarTipo();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void cargarImagen(string imagen)
        {
            try
            {
                pbxUrlImagen.Load(imagen);

            }
            catch (Exception ex)
            {

                pbxUrlImagen.Load("https://efectocolibri.com/wp-content/uploads/2021/01/placeholder.png");
            }
        }

        private void txtUrlImagen_Leave(object sender, EventArgs e)
        {
            cargarImagen(txtUrlImagen.Text);
        }
    }
}
