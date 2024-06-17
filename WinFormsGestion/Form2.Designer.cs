namespace WinFormsGestion
{
    partial class Form2
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
            txtNombre = new TextBox();
            label2 = new Label();
            cBoxCategoria = new ComboBox();
            label3 = new Label();
            checkBoxHabilitado = new CheckBox();
            btnGuardar = new Button();
            btnCerrar = new Button();
            lblMsjError = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Times New Roman", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(65, 39);
            label1.Name = "label1";
            label1.Size = new Size(177, 26);
            label1.TabIndex = 0;
            label1.Text = "Nuevo Producto";
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(81, 117);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(100, 23);
            txtNombre.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(81, 99);
            label2.Name = "label2";
            label2.Size = new Size(51, 15);
            label2.TabIndex = 2;
            label2.Text = "Nombre";
            // 
            // cBoxCategoria
            // 
            cBoxCategoria.DropDownStyle = ComboBoxStyle.DropDownList;
            cBoxCategoria.FormattingEnabled = true;
            cBoxCategoria.Location = new Point(81, 183);
            cBoxCategoria.Name = "cBoxCategoria";
            cBoxCategoria.Size = new Size(121, 23);
            cBoxCategoria.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(82, 165);
            label3.Name = "label3";
            label3.Size = new Size(58, 15);
            label3.TabIndex = 4;
            label3.Text = "Categoria";
            // 
            // checkBoxHabilitado
            // 
            checkBoxHabilitado.AutoSize = true;
            checkBoxHabilitado.Location = new Point(82, 248);
            checkBoxHabilitado.Name = "checkBoxHabilitado";
            checkBoxHabilitado.Size = new Size(81, 19);
            checkBoxHabilitado.TabIndex = 5;
            checkBoxHabilitado.Text = "Habilitado";
            checkBoxHabilitado.UseVisualStyleBackColor = true;
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(38, 307);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(75, 23);
            btnGuardar.TabIndex = 6;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // btnCerrar
            // 
            btnCerrar.Location = new Point(148, 307);
            btnCerrar.Name = "btnCerrar";
            btnCerrar.Size = new Size(75, 23);
            btnCerrar.TabIndex = 7;
            btnCerrar.Text = "Cerrar";
            btnCerrar.UseVisualStyleBackColor = true;
            btnCerrar.Click += btnCerrar_Click_1;
            // 
            // lblMsjError
            // 
            lblMsjError.AutoSize = true;
            lblMsjError.ForeColor = Color.Red;
            lblMsjError.Location = new Point(28, 355);
            lblMsjError.Name = "lblMsjError";
            lblMsjError.Size = new Size(79, 15);
            lblMsjError.TabIndex = 8;
            lblMsjError.Text = "Mensaje Error";
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(298, 394);
            Controls.Add(lblMsjError);
            Controls.Add(btnCerrar);
            Controls.Add(btnGuardar);
            Controls.Add(checkBoxHabilitado);
            Controls.Add(label3);
            Controls.Add(cBoxCategoria);
            Controls.Add(label2);
            Controls.Add(txtNombre);
            Controls.Add(label1);
            Name = "Form2";
            Text = "Form2";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtNombre;
        private Label label2;
        private ComboBox cBoxCategoria;
        private Label label3;
        private CheckBox checkBoxHabilitado;
        private Button btnGuardar;
        private Button btnCerrar;
        private Label lblMsjError;
    }
}