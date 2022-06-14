namespace PSP04gui
{
    partial class UI
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }


        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UI));
            this.labelUser = new System.Windows.Forms.Label();
            this.campoUser = new System.Windows.Forms.TextBox();
            this.campoURL = new System.Windows.Forms.TextBox();
            this.labelUrl = new System.Windows.Forms.Label();
            this.campoPwd = new System.Windows.Forms.TextBox();
            this.labelPwd = new System.Windows.Forms.Label();
            this.botonConectar = new System.Windows.Forms.Button();
            this.grupoInfoServidor = new System.Windows.Forms.GroupBox();
            this.listadoFicheros = new System.Windows.Forms.TextBox();
            this.botonListarContenido = new System.Windows.Forms.Button();
            this.grupoSubirFichero = new System.Windows.Forms.GroupBox();
            this.textBoxEmailSubida = new System.Windows.Forms.TextBox();
            this.textBoxNombreFichero = new System.Windows.Forms.TextBox();
            this.checkBoxConfirmacionSubida = new System.Windows.Forms.CheckBox();
            this.checkBoxAsignarNombre = new System.Windows.Forms.CheckBox();
            this.botonEnviarFichero = new System.Windows.Forms.Button();
            this.botonSeleccionarFicheroSubida = new System.Windows.Forms.Button();
            this.ubicacionArchivoSubida = new System.Windows.Forms.TextBox();
            this.grupoDescargarFichero = new System.Windows.Forms.GroupBox();
            this.textBoxEmailDescarga = new System.Windows.Forms.TextBox();
            this.checkBoxConfirmacionDescarga = new System.Windows.Forms.CheckBox();
            this.ubicacionDescarga = new System.Windows.Forms.TextBox();
            this.botonUbicacionDescarga = new System.Windows.Forms.Button();
            this.botonDescargarFichero = new System.Windows.Forms.Button();
            this.labelEligeFichero = new System.Windows.Forms.Label();
            this.cajaDespegable = new System.Windows.Forms.ComboBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.grupoInfoServidor.SuspendLayout();
            this.grupoSubirFichero.SuspendLayout();
            this.grupoDescargarFichero.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // labelUser
            // 
            this.labelUser.AutoSize = true;
            this.labelUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelUser.Location = new System.Drawing.Point(82, 18);
            this.labelUser.Name = "labelUser";
            this.labelUser.Size = new System.Drawing.Size(62, 16);
            this.labelUser.TabIndex = 0;
            this.labelUser.Text = "Usuario";
            // 
            // campoUser
            // 
            this.campoUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.campoUser.Location = new System.Drawing.Point(149, 12);
            this.campoUser.Name = "campoUser";
            this.campoUser.Size = new System.Drawing.Size(221, 22);
            this.campoUser.TabIndex = 1;
            this.campoUser.TextChanged += new System.EventHandler(this.campoUser_TextChanged);
            // 
            // campoURL
            // 
            this.campoURL.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.campoURL.Location = new System.Drawing.Point(149, 68);
            this.campoURL.Name = "campoURL";
            this.campoURL.Size = new System.Drawing.Size(221, 22);
            this.campoURL.TabIndex = 3;
            this.campoURL.TextChanged += new System.EventHandler(this.campoURL_TextChanged);
            // 
            // labelUrl
            // 
            this.labelUrl.AutoSize = true;
            this.labelUrl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelUrl.Location = new System.Drawing.Point(12, 68);
            this.labelUrl.Name = "labelUrl";
            this.labelUrl.Size = new System.Drawing.Size(132, 16);
            this.labelUrl.TabIndex = 6;
            this.labelUrl.Text = "URL o IP Servidor";
            // 
            // campoPwd
            // 
            this.campoPwd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.campoPwd.Location = new System.Drawing.Point(149, 40);
            this.campoPwd.Name = "campoPwd";
            this.campoPwd.Size = new System.Drawing.Size(221, 22);
            this.campoPwd.TabIndex = 2;
            this.campoPwd.TextChanged += new System.EventHandler(this.campoPwd_TextChanged);
            // 
            // labelPwd
            // 
            this.labelPwd.AutoSize = true;
            this.labelPwd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPwd.Location = new System.Drawing.Point(57, 43);
            this.labelPwd.Name = "labelPwd";
            this.labelPwd.Size = new System.Drawing.Size(87, 16);
            this.labelPwd.TabIndex = 5;
            this.labelPwd.Text = "Contraseña";
            // 
            // botonConectar
            // 
            this.botonConectar.Location = new System.Drawing.Point(386, 24);
            this.botonConectar.Name = "botonConectar";
            this.botonConectar.Size = new System.Drawing.Size(159, 54);
            this.botonConectar.TabIndex = 4;
            this.botonConectar.Text = "Conectar";
            this.botonConectar.UseVisualStyleBackColor = true;
            this.botonConectar.Click += new System.EventHandler(this.botonConectar_Click);
            // 
            // grupoInfoServidor
            // 
            this.grupoInfoServidor.Controls.Add(this.listadoFicheros);
            this.grupoInfoServidor.Controls.Add(this.botonListarContenido);
            this.grupoInfoServidor.Location = new System.Drawing.Point(12, 122);
            this.grupoInfoServidor.Name = "grupoInfoServidor";
            this.grupoInfoServidor.Size = new System.Drawing.Size(635, 280);
            this.grupoInfoServidor.TabIndex = 7;
            this.grupoInfoServidor.TabStop = false;
            this.grupoInfoServidor.Text = "Información Servidor";
            // 
            // listadoFicheros
            // 
            this.listadoFicheros.AcceptsReturn = true;
            this.listadoFicheros.Location = new System.Drawing.Point(6, 89);
            this.listadoFicheros.Multiline = true;
            this.listadoFicheros.Name = "listadoFicheros";
            this.listadoFicheros.ReadOnly = true;
            this.listadoFicheros.Size = new System.Drawing.Size(623, 185);
            this.listadoFicheros.TabIndex = 1;
            // 
            // botonListarContenido
            // 
            this.botonListarContenido.Location = new System.Drawing.Point(6, 34);
            this.botonListarContenido.Name = "botonListarContenido";
            this.botonListarContenido.Size = new System.Drawing.Size(155, 49);
            this.botonListarContenido.TabIndex = 0;
            this.botonListarContenido.Text = "Listar Contenido Servidor Detallado";
            this.botonListarContenido.UseVisualStyleBackColor = true;
            this.botonListarContenido.Click += new System.EventHandler(this.botonListarContenido_Click);
            // 
            // grupoSubirFichero
            // 
            this.grupoSubirFichero.Controls.Add(this.textBoxEmailSubida);
            this.grupoSubirFichero.Controls.Add(this.textBoxNombreFichero);
            this.grupoSubirFichero.Controls.Add(this.checkBoxConfirmacionSubida);
            this.grupoSubirFichero.Controls.Add(this.checkBoxAsignarNombre);
            this.grupoSubirFichero.Controls.Add(this.botonEnviarFichero);
            this.grupoSubirFichero.Controls.Add(this.botonSeleccionarFicheroSubida);
            this.grupoSubirFichero.Controls.Add(this.ubicacionArchivoSubida);
            this.grupoSubirFichero.Location = new System.Drawing.Point(15, 408);
            this.grupoSubirFichero.Name = "grupoSubirFichero";
            this.grupoSubirFichero.Size = new System.Drawing.Size(632, 208);
            this.grupoSubirFichero.TabIndex = 8;
            this.grupoSubirFichero.TabStop = false;
            this.grupoSubirFichero.Text = "Subir Fichero FTP";
            // 
            // textBoxEmailSubida
            // 
            this.textBoxEmailSubida.Location = new System.Drawing.Point(203, 116);
            this.textBoxEmailSubida.Name = "textBoxEmailSubida";
            this.textBoxEmailSubida.Size = new System.Drawing.Size(152, 20);
            this.textBoxEmailSubida.TabIndex = 8;
            this.textBoxEmailSubida.Visible = false;
            // 
            // textBoxNombreFichero
            // 
            this.textBoxNombreFichero.Location = new System.Drawing.Point(203, 96);
            this.textBoxNombreFichero.Name = "textBoxNombreFichero";
            this.textBoxNombreFichero.Size = new System.Drawing.Size(152, 20);
            this.textBoxNombreFichero.TabIndex = 7;
            this.textBoxNombreFichero.Visible = false;
            this.textBoxNombreFichero.TextChanged += new System.EventHandler(this.textBoxNombreFichero_TextChanged);
            // 
            // checkBoxConfirmacionSubida
            // 
            this.checkBoxConfirmacionSubida.AutoSize = true;
            this.checkBoxConfirmacionSubida.Location = new System.Drawing.Point(371, 119);
            this.checkBoxConfirmacionSubida.Name = "checkBoxConfirmacionSubida";
            this.checkBoxConfirmacionSubida.Size = new System.Drawing.Size(186, 17);
            this.checkBoxConfirmacionSubida.TabIndex = 6;
            this.checkBoxConfirmacionSubida.Text = "Confirmación de Subida Vía Email";
            this.checkBoxConfirmacionSubida.UseVisualStyleBackColor = true;
            this.checkBoxConfirmacionSubida.CheckedChanged += new System.EventHandler(this.checkBoxConfirmarSubida_CheckedChanged);
            // 
            // checkBoxAsignarNombre
            // 
            this.checkBoxAsignarNombre.AutoSize = true;
            this.checkBoxAsignarNombre.Location = new System.Drawing.Point(371, 96);
            this.checkBoxAsignarNombre.Name = "checkBoxAsignarNombre";
            this.checkBoxAsignarNombre.Size = new System.Drawing.Size(148, 17);
            this.checkBoxAsignarNombre.TabIndex = 5;
            this.checkBoxAsignarNombre.Text = "Asignar Nombre a Fichero";
            this.checkBoxAsignarNombre.UseVisualStyleBackColor = true;
            this.checkBoxAsignarNombre.CheckedChanged += new System.EventHandler(this.checkBoxAsignarNombre_CheckedChanged);
            // 
            // botonEnviarFichero
            // 
            this.botonEnviarFichero.Enabled = false;
            this.botonEnviarFichero.Location = new System.Drawing.Point(445, 19);
            this.botonEnviarFichero.Name = "botonEnviarFichero";
            this.botonEnviarFichero.Size = new System.Drawing.Size(135, 43);
            this.botonEnviarFichero.TabIndex = 4;
            this.botonEnviarFichero.Text = "Enviar fichero al Servidor";
            this.botonEnviarFichero.UseVisualStyleBackColor = true;
            this.botonEnviarFichero.Click += new System.EventHandler(this.botonEnviarFichero_Click);
            // 
            // botonSeleccionarFicheroSubida
            // 
            this.botonSeleccionarFicheroSubida.Location = new System.Drawing.Point(45, 19);
            this.botonSeleccionarFicheroSubida.Name = "botonSeleccionarFicheroSubida";
            this.botonSeleccionarFicheroSubida.Size = new System.Drawing.Size(155, 43);
            this.botonSeleccionarFicheroSubida.TabIndex = 3;
            this.botonSeleccionarFicheroSubida.Text = "Seleccionar Fichero Subida";
            this.botonSeleccionarFicheroSubida.UseVisualStyleBackColor = true;
            this.botonSeleccionarFicheroSubida.Click += new System.EventHandler(this.botonSeleccionarFicheroSubida_Click);
            // 
            // ubicacionArchivoSubida
            // 
            this.ubicacionArchivoSubida.AcceptsReturn = true;
            this.ubicacionArchivoSubida.Location = new System.Drawing.Point(203, 19);
            this.ubicacionArchivoSubida.Multiline = true;
            this.ubicacionArchivoSubida.Name = "ubicacionArchivoSubida";
            this.ubicacionArchivoSubida.ReadOnly = true;
            this.ubicacionArchivoSubida.Size = new System.Drawing.Size(236, 43);
            this.ubicacionArchivoSubida.TabIndex = 2;
            this.ubicacionArchivoSubida.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ubicacionArchivoSubida.TextChanged += new System.EventHandler(this.ubicacionArchivoSubida_TextChanged);
            // 
            // grupoDescargarFichero
            // 
            this.grupoDescargarFichero.Controls.Add(this.textBoxEmailDescarga);
            this.grupoDescargarFichero.Controls.Add(this.checkBoxConfirmacionDescarga);
            this.grupoDescargarFichero.Controls.Add(this.ubicacionDescarga);
            this.grupoDescargarFichero.Controls.Add(this.botonUbicacionDescarga);
            this.grupoDescargarFichero.Controls.Add(this.botonDescargarFichero);
            this.grupoDescargarFichero.Controls.Add(this.labelEligeFichero);
            this.grupoDescargarFichero.Controls.Add(this.cajaDespegable);
            this.grupoDescargarFichero.Location = new System.Drawing.Point(15, 622);
            this.grupoDescargarFichero.Name = "grupoDescargarFichero";
            this.grupoDescargarFichero.Size = new System.Drawing.Size(632, 230);
            this.grupoDescargarFichero.TabIndex = 9;
            this.grupoDescargarFichero.TabStop = false;
            this.grupoDescargarFichero.Text = "Descargar Fichero FTP";
            // 
            // textBoxEmailDescarga
            // 
            this.textBoxEmailDescarga.Location = new System.Drawing.Point(203, 165);
            this.textBoxEmailDescarga.Name = "textBoxEmailDescarga";
            this.textBoxEmailDescarga.Size = new System.Drawing.Size(152, 20);
            this.textBoxEmailDescarga.TabIndex = 9;
            this.textBoxEmailDescarga.Visible = false;
            // 
            // checkBoxConfirmacionDescarga
            // 
            this.checkBoxConfirmacionDescarga.AutoSize = true;
            this.checkBoxConfirmacionDescarga.Location = new System.Drawing.Point(371, 165);
            this.checkBoxConfirmacionDescarga.Name = "checkBoxConfirmacionDescarga";
            this.checkBoxConfirmacionDescarga.Size = new System.Drawing.Size(199, 17);
            this.checkBoxConfirmacionDescarga.TabIndex = 7;
            this.checkBoxConfirmacionDescarga.Text = "Confirmación de Descarga Vía Email";
            this.checkBoxConfirmacionDescarga.UseVisualStyleBackColor = true;
            this.checkBoxConfirmacionDescarga.CheckedChanged += new System.EventHandler(this.checkBoxConfirmacionDescarga_CheckedChanged);
            // 
            // ubicacionDescarga
            // 
            this.ubicacionDescarga.AcceptsReturn = true;
            this.ubicacionDescarga.Location = new System.Drawing.Point(203, 91);
            this.ubicacionDescarga.Multiline = true;
            this.ubicacionDescarga.Name = "ubicacionDescarga";
            this.ubicacionDescarga.ReadOnly = true;
            this.ubicacionDescarga.Size = new System.Drawing.Size(236, 43);
            this.ubicacionDescarga.TabIndex = 2;
            this.ubicacionDescarga.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ubicacionDescarga.TextChanged += new System.EventHandler(this.ubicacionDescarga_TextChanged);
            // 
            // botonUbicacionDescarga
            // 
            this.botonUbicacionDescarga.Location = new System.Drawing.Point(45, 91);
            this.botonUbicacionDescarga.Name = "botonUbicacionDescarga";
            this.botonUbicacionDescarga.Size = new System.Drawing.Size(155, 43);
            this.botonUbicacionDescarga.TabIndex = 3;
            this.botonUbicacionDescarga.Text = "Ubicación donde quiero guardar";
            this.botonUbicacionDescarga.UseVisualStyleBackColor = true;
            this.botonUbicacionDescarga.Click += new System.EventHandler(this.botonUbicacionDescarga_Click);
            // 
            // botonDescargarFichero
            // 
            this.botonDescargarFichero.Enabled = false;
            this.botonDescargarFichero.Location = new System.Drawing.Point(445, 91);
            this.botonDescargarFichero.Name = "botonDescargarFichero";
            this.botonDescargarFichero.Size = new System.Drawing.Size(135, 43);
            this.botonDescargarFichero.TabIndex = 2;
            this.botonDescargarFichero.Text = "Descargar Fichero";
            this.botonDescargarFichero.UseVisualStyleBackColor = true;
            this.botonDescargarFichero.Click += new System.EventHandler(this.botonDescargarFichero_Click);
            // 
            // labelEligeFichero
            // 
            this.labelEligeFichero.AutoSize = true;
            this.labelEligeFichero.Location = new System.Drawing.Point(57, 28);
            this.labelEligeFichero.Name = "labelEligeFichero";
            this.labelEligeFichero.Size = new System.Drawing.Size(151, 13);
            this.labelEligeFichero.TabIndex = 1;
            this.labelEligeFichero.Text = "Elige un fichero para descarga";
            // 
            // cajaDespegable
            // 
            this.cajaDespegable.FormattingEnabled = true;
            this.cajaDespegable.Location = new System.Drawing.Point(45, 53);
            this.cajaDespegable.Name = "cajaDespegable";
            this.cajaDespegable.Size = new System.Drawing.Size(535, 21);
            this.cajaDespegable.TabIndex = 0;
            this.cajaDespegable.DropDown += new System.EventHandler(this.cajaDespegable_abrirDespegable);
            this.cajaDespegable.SelectedIndexChanged += new System.EventHandler(this.cajaDespegable_SelectedIndexChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(551, -5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(119, 89);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // UI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(658, 864);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.grupoDescargarFichero);
            this.Controls.Add(this.grupoSubirFichero);
            this.Controls.Add(this.grupoInfoServidor);
            this.Controls.Add(this.botonConectar);
            this.Controls.Add(this.campoPwd);
            this.Controls.Add(this.labelPwd);
            this.Controls.Add(this.campoURL);
            this.Controls.Add(this.labelUrl);
            this.Controls.Add(this.campoUser);
            this.Controls.Add(this.labelUser);
            this.Name = "UI";
            this.Text = "BirtLH FTP Client";
            this.grupoInfoServidor.ResumeLayout(false);
            this.grupoInfoServidor.PerformLayout();
            this.grupoSubirFichero.ResumeLayout(false);
            this.grupoSubirFichero.PerformLayout();
            this.grupoDescargarFichero.ResumeLayout(false);
            this.grupoDescargarFichero.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        private System.Windows.Forms.Label labelUser;
        private System.Windows.Forms.TextBox campoUser;
        private System.Windows.Forms.TextBox campoURL;
        private System.Windows.Forms.Label labelUrl;
        private System.Windows.Forms.TextBox campoPwd;
        private System.Windows.Forms.Label labelPwd;
        private System.Windows.Forms.Button botonConectar;
        private System.Windows.Forms.GroupBox grupoInfoServidor;
        private System.Windows.Forms.Button botonListarContenido;
        private System.Windows.Forms.GroupBox grupoSubirFichero;
        private System.Windows.Forms.GroupBox grupoDescargarFichero;
        private System.Windows.Forms.TextBox listadoFicheros;
        private System.Windows.Forms.Label labelEligeFichero;
        private System.Windows.Forms.ComboBox cajaDespegable;
        private System.Windows.Forms.Button botonDescargarFichero;
        private System.Windows.Forms.Button botonUbicacionDescarga;
        private System.Windows.Forms.TextBox ubicacionDescarga;
        private System.Windows.Forms.Button botonEnviarFichero;
        private System.Windows.Forms.Button botonSeleccionarFicheroSubida;
        private System.Windows.Forms.TextBox ubicacionArchivoSubida;
        private System.Windows.Forms.CheckBox checkBoxConfirmacionSubida;
        private System.Windows.Forms.CheckBox checkBoxAsignarNombre;
        private System.Windows.Forms.CheckBox checkBoxConfirmacionDescarga;
        private System.Windows.Forms.TextBox textBoxEmailSubida;
        private System.Windows.Forms.TextBox textBoxNombreFichero;
        private System.Windows.Forms.TextBox textBoxEmailDescarga;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

