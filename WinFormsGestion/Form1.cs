using Gestion.Core.Business;
using Gestion.Core.Entities;
using Microsoft.Extensions.DependencyInjection;
using System.Windows.Forms;

namespace WinFormsGestion
{
    public partial class Form1 : Form
    {
        private ProductoBusiness _productoBusiness { get; set; }
        private OperacionesBusiness _operacionesBusiness { get; set; }

        public Form1(ProductoBusiness productoBusiness, OperacionesBusiness operacionesBusiness)
        {
            _productoBusiness = productoBusiness;
            _operacionesBusiness = operacionesBusiness;
            InitializeComponent();
            InitControl();
            CambiarColorFilas();

        }

        public void InitControl()
        {
            dataGridView1.DataSource = _productoBusiness.GetAll().Items;
            dataGridView1.ReadOnly = true;
            dataGridView1.MultiSelect = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Columns["Categoria"].Visible = false;
            dataGridView1.Columns["CategoriaId"].Visible = false;
            dataGridView1.Columns["Habilitado"].Visible = false;
            dataGridView1.Columns["NombreCategoria"].HeaderText = "Categoria";


            cBoxFiltrado.DataSource = _productoBusiness.CategoriaCBox();
            cBoxFiltrado.DisplayMember = "Nombre";


        }



        private async void MostrarErrorPor3Segundos(string mensaje)
        {
            // Establece el texto del Label
            labelErrorForm1.Text = mensaje;
            labelErrorForm1.Visible = true;

            // Espera 3 segundos
            await Task.Delay(3000);

            // Limpia el texto del Label después de 3 segundos
            labelErrorForm1.Text = "";
            labelErrorForm1.Visible = false;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            var productos = _productoBusiness.GetAll().Items;

            var categoriaSeleccionada = ((Categoria)cBoxFiltrado.SelectedItem).CategoriaId;

            if (categoriaSeleccionada != 0)
            {
                dataGridView1.DataSource = productos.FindAll(p => p.CategoriaId == categoriaSeleccionada);
            }
            else
            {
                dataGridView1.DataSource = productos;
            }

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                //row va a ser nuestra fila seleccionada
                var row = dataGridView1.SelectedRows[0];

                var productoSeleccionado = (Producto)row.DataBoundItem;

                //Se llama a la funcion GetAllCompras. Obtenemos todas las compras y preguntamos si existe alguna
                //compra del producto seleccionado
                var comprasFiltradas = _operacionesBusiness.GetAllCompras().Items.Any(x => x.ProductoId == productoSeleccionado.ProductoId);
                var ventasFiltradas = _operacionesBusiness.GetAllVentas().Items.Any(x => x.ProductoId == productoSeleccionado.ProductoId);
                if (comprasFiltradas == false && ventasFiltradas == false)
                {
                    _productoBusiness.EliminarProducto(productoSeleccionado.ProductoId);

                    dataGridView1.DataSource = _productoBusiness.GetAll().Items;
                }
                else
                {
                    MostrarErrorPor3Segundos("El producto no puede ser eliminado porque tiene una compra o venta asociada");
                }


            }
            else
            {
                MostrarErrorPor3Segundos("Debe seleccionar un producto");
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            //VERIFICA SI EXISTE UN FORM2 ABIERTO Y LO CIERRA
            Form2 existingForm2 = Application.OpenForms.OfType<Form2>().FirstOrDefault();
            if (existingForm2 != null)
            {
                // Cerrar la instancia existente de Form3
                existingForm2.Close();
            }
            var form2 = Program.ServiceProvider.GetRequiredService<Form2>();
            form2.CargarDatos(dataGridView1);
            form2.Show();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                //row va a ser nuestra fila seleccionada
                var row = dataGridView1.SelectedRows[0];

                var productoSeleccionado = (Producto)row.DataBoundItem;



                //VERIFICA SI EXISTE UN FORM3 ABIERTO Y LO CIERRA
                Form3 existingForm3 = Application.OpenForms.OfType<Form3>().FirstOrDefault();
                if (existingForm3 != null)
                {
                    // Cerrar la instancia existente de Form3
                    existingForm3.Close();
                }
                var form3 = Program.ServiceProvider.GetRequiredService<Form3>();
                form3.CargarDatos(dataGridView1, productoSeleccionado);
                form3.Show();

            }


        }

        private void CambiarColorFilas()
        {
            dataGridView1.RowPrePaint += (sender, e) =>
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                Producto producto = row.DataBoundItem as Producto;

                if (producto != null)
                {
                    if (!producto.Habilitado)
                    {
                        row.DefaultCellStyle.BackColor = Color.IndianRed; // Cambia el color a rojo si no está habilitado
                    }
                    else
                    {
                        row.DefaultCellStyle.BackColor = Color.LightGreen; // Cambia el color a verde si está habilitado
                    }
                }
            };
        }
    }
}
