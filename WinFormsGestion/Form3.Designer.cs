namespace WinFormsGestion
{
    partial class Form3
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            txtEditarNombre = new TextBox();
            cBoxEditarCategoria = new ComboBox();
            label2 = new Label();
            label3 = new Label();
            checkBoxHabilitado = new CheckBox();
            lblMsjError = new Label();
            btnCerrar = new Button();
            btnGuardar = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Times New Roman", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(78, 46);
            label1.Name = "label1";
            label1.Size = new Size(180, 26);
            label1.TabIndex = 0;
            label1.Text = "Editar Producto";
            label1.TextAlign = ContentAlignment.TopCenter;
            // 
            // txtEditarNombre
            // 
            txtEditarNombre.Location = new Point(99, 139);
            txtEditarNombre.Name = "txtEditarNombre";
            txtEditarNombre.Size = new Size(121, 23);
            txtEditarNombre.TabIndex = 1;
            // 
            // cBoxEditarCategoria
            // 
            cBoxEditarCategoria.FormattingEnabled = true;
            cBoxEditarCategoria.Location = new Point(99, 208);
            cBoxEditarCategoria.Name = "cBoxEditarCategoria";
            cBoxEditarCategoria.Size = new Size(121, 23);
            cBoxEditarCategoria.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(100, 115);
            label2.Name = "label2";
            label2.Size = new Size(51, 15);
            label2.TabIndex = 3;
            label2.Text = "Nombre";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(99, 187);
            label3.Name = "label3";
            label3.Size = new Size(58, 15);
            label3.TabIndex = 4;
            label3.Text = "Categoría";
            // 
            // checkBoxHabilitado
            // 
            checkBoxHabilitado.AutoSize = true;
            checkBoxHabilitado.Location = new Point(99, 266);
            checkBoxHabilitado.Name = "checkBoxHabilitado";
            checkBoxHabilitado.Size = new Size(81, 19);
            checkBoxHabilitado.TabIndex = 5;
            checkBoxHabilitado.Text = "Habilitado";
            checkBoxHabilitado.UseVisualStyleBackColor = true;
            // 
            // lblMsjError
            // 
            lblMsjError.AutoSize = true;
            lblMsjError.ForeColor = Color.Red;
            lblMsjError.Location = new Point(53, 387);
            lblMsjError.Name = "lblMsjError";
            lblMsjError.Size = new Size(79, 15);
            lblMsjError.TabIndex = 11;
            lblMsjError.Text = "Mensaje Error";
            lblMsjError.Visible = false;
            // 
            // btnCerrar
            // 
            btnCerrar.Location = new Point(173, 339);
            btnCerrar.Name = "btnCerrar";
            btnCerrar.Size = new Size(75, 23);
            btnCerrar.TabIndex = 10;
            btnCerrar.Text = "Cerrar";
            btnCerrar.UseVisualStyleBackColor = true;
            btnCerrar.Click += btnCerrar_Click;
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(63, 339);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(75, 23);
            btnGuardar.TabIndex = 9;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // Form3
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(330, 429);
            Controls.Add(lblMsjError);
            Controls.Add(btnCerrar);
            Controls.Add(btnGuardar);
            Controls.Add(checkBoxHabilitado);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(cBoxEditarCategoria);
            Controls.Add(txtEditarNombre);
            Controls.Add(label1);
            Name = "Form3";
            Text = "Form3";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtEditarNombre;
        private ComboBox cBoxEditarCategoria;
        private Label label2;
        private Label label3;
        private CheckBox checkBoxHabilitado;
        private Label lblMsjError;
        private Button btnCerrar;
        private Button btnGuardar;
    }
}