using Gestion.Core.Business;
using Gestion.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsGestion
{
    public partial class Form2 : Form
    {

        private ProductoBusiness _productoBusiness { get; set; }
        private OperacionesBusiness _operacionesBusiness { get; set; }

        public DataGridView DataGridViewForm1 { get; set; }

        public Form2(ProductoBusiness productoBusiness, OperacionesBusiness operacionesBusiness)
        {
            _productoBusiness = productoBusiness;
            _operacionesBusiness = operacionesBusiness;
            InitializeComponent();
            InitControl();
        }

        public void InitControl()
        {
            cBoxCategoria.DataSource = _productoBusiness.GetAllCategoria();
            cBoxCategoria.DisplayMember = "Nombre";
        }

        private void btnCerrar_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            var producto = new Producto();
            var productoExistente = _productoBusiness.GetAll().Items;
            bool existeNombre = productoExistente.Any(x=> x.Nombre == txtNombre.Text);

            if (!existeNombre)
            {
                producto.Nombre = txtNombre.Text;
                producto.CategoriaId = ((Categoria)cBoxCategoria.SelectedItem).CategoriaId;
                producto.Habilitado = checkBoxHabilitado.Checked;


                _productoBusiness.AltaProducto(producto);
                DataGridViewForm1.DataSource = _productoBusiness.GetAll().Items;
                this.Close();
            }
            else 
            {
                MostrarErrorPor3Segundos("Ya existe un producto con el mismo nombre");
            }


          
        }

        public void CargarDatos(DataGridView dataGridViewForm1)
        {
            DataGridViewForm1 = dataGridViewForm1;

        }

        private async void MostrarErrorPor3Segundos(string mensaje)
        {
            // Establece el texto del Label
            lblMsjError.Text = mensaje;

            // Espera 3 segundos
            await Task.Delay(3000);

            // Limpia el texto del Label después de 3 segundos
            lblMsjError.Text = "";
        }
    }
}
