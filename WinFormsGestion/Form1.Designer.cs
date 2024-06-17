namespace WinFormsGestion
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dataGridView1 = new DataGridView();
            btnAgregar = new Button();
            btnModificar = new Button();
            btnEliminar = new Button();
            labelErrorForm1 = new Label();
            label1 = new Label();
            label2 = new Label();
            cBoxFiltrado = new ComboBox();
            lblFiltrarCategoria = new Label();
            btnBuscar = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(23, 233);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(365, 243);
            dataGridView1.TabIndex = 0;
            // 
            // btnAgregar
            // 
            btnAgregar.Location = new Point(441, 267);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(75, 23);
            btnAgregar.TabIndex = 1;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = true;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // btnModificar
            // 
            btnModificar.Location = new Point(441, 320);
            btnModificar.Name = "btnModificar";
            btnModificar.Size = new Size(75, 23);
            btnModificar.TabIndex = 2;
            btnModificar.Text = "Modificar";
            btnModificar.UseVisualStyleBackColor = true;
            btnModificar.Click += btnModificar_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(441, 373);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(75, 23);
            btnEliminar.TabIndex = 3;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // labelErrorForm1
            // 
            labelErrorForm1.AutoSize = true;
            labelErrorForm1.ForeColor = Color.Red;
            labelErrorForm1.Location = new Point(23, 519);
            labelErrorForm1.Name = "labelErrorForm1";
            labelErrorForm1.Size = new Size(105, 15);
            labelErrorForm1.TabIndex = 4;
            labelErrorForm1.Text = "Muestra de errores";
            labelErrorForm1.Visible = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Times New Roman", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(23, 121);
            label1.Name = "label1";
            label1.Size = new Size(204, 26);
            label1.TabIndex = 5;
            label1.Text = "Lista de Productos";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BorderStyle = BorderStyle.Fixed3D;
            label2.Font = new Font("Broadway", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(143, 30);
            label2.Name = "label2";
            label2.Size = new Size(312, 38);
            label2.TabIndex = 6;
            label2.Text = "MICHI MERCADO";
            label2.TextAlign = ContentAlignment.TopCenter;
            // 
            // cBoxFiltrado
            // 
            cBoxFiltrado.DropDownStyle = ComboBoxStyle.DropDownList;
            cBoxFiltrado.FormattingEnabled = true;
            cBoxFiltrado.Location = new Point(26, 189);
            cBoxFiltrado.Name = "cBoxFiltrado";
            cBoxFiltrado.Size = new Size(174, 23);
            cBoxFiltrado.TabIndex = 7;
            // 
            // lblFiltrarCategoria
            // 
            lblFiltrarCategoria.AutoSize = true;
            lblFiltrarCategoria.Location = new Point(26, 164);
            lblFiltrarCategoria.Name = "lblFiltrarCategoria";
            lblFiltrarCategoria.Size = new Size(110, 15);
            lblFiltrarCategoria.TabIndex = 8;
            lblFiltrarCategoria.Text = "Filtrar por categoría";
            // 
            // btnBuscar
            // 
            btnBuscar.Location = new Point(228, 189);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(75, 23);
            btnBuscar.TabIndex = 9;
            btnBuscar.Text = "Buscar";
            btnBuscar.UseVisualStyleBackColor = true;
            btnBuscar.Click += btnBuscar_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(598, 594);
            Controls.Add(btnBuscar);
            Controls.Add(lblFiltrarCategoria);
            Controls.Add(cBoxFiltrado);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(labelErrorForm1);
            Controls.Add(btnEliminar);
            Controls.Add(btnModificar);
            Controls.Add(btnAgregar);
            Controls.Add(dataGridView1);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private Button btnAgregar;
        private Button btnModificar;
        private Button btnEliminar;
        private Label labelErrorForm1;
        private Label label1;
        private Label label2;
        private ComboBox cBoxFiltrado;
        private Label lblFiltrarCategoria;
        private Button btnBuscar;
    }
}
