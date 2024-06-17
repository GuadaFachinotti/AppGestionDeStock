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
    public partial class Form3 : Form
    {
        private ProductoBusiness _productoBusiness { get; set; }
        private OperacionesBusiness _operacionesBusiness { get; set; }

        public DataGridView DataGridViewForm1 { get; set; }

        public Producto ProductoForm1 { get; set; }

        public Form3(ProductoBusiness productoBusiness, OperacionesBusiness operacionesBusiness)
        {
            _productoBusiness = productoBusiness;
            _operacionesBusiness = operacionesBusiness;
            InitializeComponent();
            CargarDatos(DataGridViewForm1, ProductoForm1);
        }

        //Es lo que en un principio va a aparecer en el form3
        public void CargarDatos(DataGridView dataGridViewForm1, Producto productoForm1)
        {
            ProductoForm1 = productoForm1;
            DataGridViewForm1 = dataGridViewForm1;
            cBoxEditarCategoria.DataSource = _productoBusiness.GetAllCategoria();
            cBoxEditarCategoria.DisplayMember = "Nombre";
            //Para que aparezca la categoria del producto hay que especificar el valueMember
            cBoxEditarCategoria.ValueMember = "CategoriaId";

            if (ProductoForm1 != null)
            {
                //Lista de categorias
                var categorias = _productoBusiness.GetAllCategoria();
                //Cargo los datos del Producto a editar
                txtEditarNombre.Text = ProductoForm1.Nombre;

                cBoxEditarCategoria.SelectedValue = ProductoForm1.CategoriaId;
                checkBoxHabilitado.Checked = productoForm1.Habilitado;

            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            var producto = new Producto();
            var productoExistente = _productoBusiness.GetAll().Items;

          
             
            //Existe un producto con el mismo nombre y diferente ID
            bool existeNombre = productoExistente.Any(x => x.Nombre == txtEditarNombre.Text 
                                                        && x.ProductoId != ProductoForm1.ProductoId);


            //Lista de Productos Con Mismo Nombre y Distinto ID
            //En este caso deberiamos dejar modificar si la cantidad de elementos encontrados es 0
            //List<Producto> ProductosConMismoNombreYDistintoID = productoExistente.FindAll(x => x.Nombre == txtEditarNombre.Text
            //                                            && x.ProductoId != ProductoForm1.ProductoId);

            //Cuando no existe un producto con mismo nombre y diferente ID se permite modificar
            if (existeNombre== false)
            {
                producto.Nombre = txtEditarNombre.Text;
                producto.CategoriaId = ((Categoria)cBoxEditarCategoria.SelectedItem).CategoriaId;
                producto.Habilitado = checkBoxHabilitado.Checked;
                //Se carga el Id con el Id del producto "original" para poder modificarlo con el metodo
                //que utiliza productoID ya que debe verificar si ese producto existe
                //
                producto.ProductoId = ProductoForm1.ProductoId;


                _productoBusiness.ModificarProducto(producto);
                DataGridViewForm1.DataSource = _productoBusiness.GetAll().Items;
                this.Close();
            }
            else
            {
                //Se muestra error cuando existe un producto con el mismo nombre y diferente ID
                MostrarErrorPor3Segundos("Ya existe un producto con el mismo nombre");
            }
        }

        private async void MostrarErrorPor3Segundos(string mensaje)
        {
            // Establece el texto del Label
            lblMsjError.Text = mensaje;
            lblMsjError.Visible = true;

            // Espera 3 segundos
            await Task.Delay(3000);

            // Limpia el texto del Label después de 3 segundos
            lblMsjError.Text = "";
            lblMsjError.Visible = false;
        }
    }
}
