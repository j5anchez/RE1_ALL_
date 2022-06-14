using System.Security.Cryptography;
namespace comparadorFicheros
{
partial class Form1
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
    /// <summary>
    /// Método necesario para admitir el Diseñador. No se puede modificar
    /// el contenido de este método con el editor de código.
    /// </summary>
    private void InitializeComponent()
    {
        this.label1 = new System.Windows.Forms.Label();
        this.tb_UsuarioRegistrado = new System.Windows.Forms.TextBox();
        this.boton_RegistrarUsuario = new System.Windows.Forms.Button();
        this.gb_RegistroUsuario = new System.Windows.Forms.GroupBox();
        this.label9 = new System.Windows.Forms.Label();
        this.tb_Email = new System.Windows.Forms.TextBox();
        this.boton_RegistroAceptar = new System.Windows.Forms.Button();
        this.radio_RegistrarNo = new System.Windows.Forms.RadioButton();
        this.radio_RegistrarYes = new System.Windows.Forms.RadioButton();
        this.label5 = new System.Windows.Forms.Label();
        this.boton_GuardaryCerrar = new System.Windows.Forms.Button();
        this.gb_Borrar = new System.Windows.Forms.GroupBox();
        this.cb_BorrarDescripcion = new System.Windows.Forms.ComboBox();
        this.boton_Borrar = new System.Windows.Forms.Button();
        this.label10 = new System.Windows.Forms.Label();
        this.gb_Registrar = new System.Windows.Forms.GroupBox();
        this.boton_Guardar = new System.Windows.Forms.Button();
        this.tb_RegistrarPassword = new System.Windows.Forms.TextBox();
        this.label8 = new System.Windows.Forms.Label();
        this.tb_RegistrarDescripcion = new System.Windows.Forms.TextBox();
        this.label7 = new System.Windows.Forms.Label();
        this.gb_Visualizar = new System.Windows.Forms.GroupBox();
        this.cb_VisualizarDescripcion = new System.Windows.Forms.ComboBox();
        this.label_UbicacionFichero = new System.Windows.Forms.Label();
        this.boton_Fichero = new System.Windows.Forms.Button();
        this.label6 = new System.Windows.Forms.Label();
        this.label11 = new System.Windows.Forms.Label();
        this.tb_VisualizarPassword = new System.Windows.Forms.TextBox();
        this.label12 = new System.Windows.Forms.Label();
        this.check_BorrarPass = new System.Windows.Forms.CheckBox();
        this.check_RegistrarPass = new System.Windows.Forms.CheckBox();
        this.check_VisualizarPass = new System.Windows.Forms.CheckBox();
        this.gb_RegistroUsuario.SuspendLayout();
        this.gb_Borrar.SuspendLayout();
        this.gb_Registrar.SuspendLayout();
        this.gb_Visualizar.SuspendLayout();
        this.SuspendLayout();
        //
        // label1
        //
        this.label1.AutoSize = true;
        this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold,
                                                   System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.label1.Location = new System.Drawing.Point(12, 9);
        this.label1.Name = "label1";
        this.label1.Size = new System.Drawing.Size(61, 16);
        this.label1.TabIndex = 9;
        this.label1.Text = "Usuario";
        //
        // tb_UsuarioRegistrado
        //
        this.tb_UsuarioRegistrado.Location = new System.Drawing.Point(79, 8);
        this.tb_UsuarioRegistrado.Name = "tb_UsuarioRegistrado";
        this.tb_UsuarioRegistrado.Size = new System.Drawing.Size(128, 20);
        this.tb_UsuarioRegistrado.TabIndex = 10;
        //
        // boton_RegistrarUsuario
        //
        this.boton_RegistrarUsuario.Location = new System.Drawing.Point(213, 8);
        this.boton_RegistrarUsuario.Name = "boton_RegistrarUsuario";
        this.boton_RegistrarUsuario.Size = new System.Drawing.Size(75, 23);
        this.boton_RegistrarUsuario.TabIndex = 11;
        this.boton_RegistrarUsuario.Text = "Registrar";
        this.boton_RegistrarUsuario.UseVisualStyleBackColor = true;
        this.boton_RegistrarUsuario.Click += new System.EventHandler(this.boton_RegistrarUsuario_Click);
        //
        // gb_RegistroUsuario
        //
        this.gb_RegistroUsuario.Controls.Add(this.label9);
        this.gb_RegistroUsuario.Controls.Add(this.tb_Email);
        this.gb_RegistroUsuario.Controls.Add(this.boton_RegistroAceptar);
        this.gb_RegistroUsuario.Controls.Add(this.radio_RegistrarNo);
        this.gb_RegistroUsuario.Controls.Add(this.radio_RegistrarYes);
        this.gb_RegistroUsuario.Controls.Add(this.label5);
        this.gb_RegistroUsuario.Enabled = false;
        this.gb_RegistroUsuario.Location = new System.Drawing.Point(357, 8);
        this.gb_RegistroUsuario.Name = "gb_RegistroUsuario";
        this.gb_RegistroUsuario.Size = new System.Drawing.Size(220, 127);
        this.gb_RegistroUsuario.TabIndex = 24;
        this.gb_RegistroUsuario.TabStop = false;
        this.gb_RegistroUsuario.Text = "Registro Usuario";
        //
        // label9
        //
        this.label9.AutoSize = true;
        this.label9.Location = new System.Drawing.Point(6, 76);
        this.label9.Name = "label9";
        this.label9.Size = new System.Drawing.Size(35, 13);
        this.label9.TabIndex = 16;
        this.label9.Text = "Email:";
        //
        // tb_Email
        //
        this.tb_Email.Location = new System.Drawing.Point(39, 75);
        this.tb_Email.Margin = new System.Windows.Forms.Padding(2);
        this.tb_Email.Name = "tb_Email";
        this.tb_Email.Size = new System.Drawing.Size(155, 20);
        this.tb_Email.TabIndex = 25;
        //
        // boton_RegistroAceptar
        //
        this.boton_RegistroAceptar.Location = new System.Drawing.Point(39, 101);
        this.boton_RegistroAceptar.Margin = new System.Windows.Forms.Padding(2);
        this.boton_RegistroAceptar.Name = "boton_RegistroAceptar";
        this.boton_RegistroAceptar.Size = new System.Drawing.Size(100, 21);
        this.boton_RegistroAceptar.TabIndex = 16;
        this.boton_RegistroAceptar.Text = "Aceptar";
        this.boton_RegistroAceptar.UseVisualStyleBackColor = true;
        this.boton_RegistroAceptar.Click += new System.EventHandler(this.boton_RegistroAceptar_Click);
        //
        // radio_RegistrarNo
        //
        this.radio_RegistrarNo.AutoSize = true;
        this.radio_RegistrarNo.Checked = true;
        this.radio_RegistrarNo.Location = new System.Drawing.Point(90, 53);
        this.radio_RegistrarNo.Name = "radio_RegistrarNo";
        this.radio_RegistrarNo.Size = new System.Drawing.Size(39, 17);
        this.radio_RegistrarNo.TabIndex = 25;
        this.radio_RegistrarNo.TabStop = true;
        this.radio_RegistrarNo.Text = "No";
        this.radio_RegistrarNo.UseVisualStyleBackColor = true;
        //
        // radio_RegistrarYes
        //
        this.radio_RegistrarYes.AutoSize = true;
        this.radio_RegistrarYes.Location = new System.Drawing.Point(50, 53);
        this.radio_RegistrarYes.Name = "radio_RegistrarYes";
        this.radio_RegistrarYes.Size = new System.Drawing.Size(34, 17);
        this.radio_RegistrarYes.TabIndex = 24;
        this.radio_RegistrarYes.Text = "Si";
        this.radio_RegistrarYes.UseVisualStyleBackColor = true;
        //
        // label5
        //
        this.label5.AutoSize = true;
        this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold,
                                                   System.Drawing.GraphicsUnit.Point, ((byte)(254)));
        this.label5.Location = new System.Drawing.Point(21, 17);
        this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
        this.label5.Name = "label5";
        this.label5.Size = new System.Drawing.Size(178, 26);
        this.label5.TabIndex = 6;
        this.label5.Text = "El usuario indicado no existe: \r\n¿desea registrarlo?";
        //
        // boton_GuardaryCerrar
        //
        this.boton_GuardaryCerrar.Location = new System.Drawing.Point(473, 510);
        this.boton_GuardaryCerrar.Name = "boton_GuardaryCerrar";
        this.boton_GuardaryCerrar.Size = new System.Drawing.Size(104, 23);
        this.boton_GuardaryCerrar.TabIndex = 28;
        this.boton_GuardaryCerrar.Text = "Guardar y Cerrar";
        this.boton_GuardaryCerrar.UseVisualStyleBackColor = true;
        this.boton_GuardaryCerrar.Click += new System.EventHandler(this.boton_GuardaryCerrar_Click);
        //
        // gb_Borrar
        //
        this.gb_Borrar.Controls.Add(this.cb_BorrarDescripcion);
        this.gb_Borrar.Controls.Add(this.boton_Borrar);
        this.gb_Borrar.Controls.Add(this.label10);
        this.gb_Borrar.Enabled = false;
        this.gb_Borrar.Location = new System.Drawing.Point(15, 415);
        this.gb_Borrar.Name = "gb_Borrar";
        this.gb_Borrar.Size = new System.Drawing.Size(562, 85);
        this.gb_Borrar.TabIndex = 26;
        this.gb_Borrar.TabStop = false;
        this.gb_Borrar.Text = "Borrar";
        //
        // cb_BorrarDescripcion
        //
        this.cb_BorrarDescripcion.FormattingEnabled = true;
        this.cb_BorrarDescripcion.Location = new System.Drawing.Point(178, 19);
        this.cb_BorrarDescripcion.Name = "cb_BorrarDescripcion";
        this.cb_BorrarDescripcion.Size = new System.Drawing.Size(363, 21);
        this.cb_BorrarDescripcion.TabIndex = 15;
        this.cb_BorrarDescripcion.Text = "No hay nada para mostrar";
        this.cb_BorrarDescripcion.DropDown += new System.EventHandler(this.cb_BorrarDescripcion_DropDown);
        //
        // boton_Borrar
        //
        this.boton_Borrar.Location = new System.Drawing.Point(178, 52);
        this.boton_Borrar.Margin = new System.Windows.Forms.Padding(2);
        this.boton_Borrar.Name = "boton_Borrar";
        this.boton_Borrar.Size = new System.Drawing.Size(100, 21);
        this.boton_Borrar.TabIndex = 13;
        this.boton_Borrar.Text = "Borrar";
        this.boton_Borrar.UseVisualStyleBackColor = true;
        this.boton_Borrar.Click += new System.EventHandler(this.boton_Borrar_Click);
        //
        // label10
        //
        this.label10.AutoSize = true;
        this.label10.Location = new System.Drawing.Point(75, 27);
        this.label10.Name = "label10";
        this.label10.Size = new System.Drawing.Size(97, 13);
        this.label10.TabIndex = 12;
        this.label10.Text = "Elija la descripción:";
        //
        // gb_Registrar
        //
        this.gb_Registrar.Controls.Add(this.boton_Guardar);
        this.gb_Registrar.Controls.Add(this.tb_RegistrarPassword);
        this.gb_Registrar.Controls.Add(this.label8);
        this.gb_Registrar.Controls.Add(this.tb_RegistrarDescripcion);
        this.gb_Registrar.Controls.Add(this.label7);
        this.gb_Registrar.Enabled = false;
        this.gb_Registrar.Location = new System.Drawing.Point(15, 279);
        this.gb_Registrar.Name = "gb_Registrar";
        this.gb_Registrar.Size = new System.Drawing.Size(562, 130);
        this.gb_Registrar.TabIndex = 27;
        this.gb_Registrar.TabStop = false;
        this.gb_Registrar.Text = "Registrar";
        //
        // boton_Guardar
        //
        this.boton_Guardar.Location = new System.Drawing.Point(178, 95);
        this.boton_Guardar.Margin = new System.Windows.Forms.Padding(2);
        this.boton_Guardar.Name = "boton_Guardar";
        this.boton_Guardar.Size = new System.Drawing.Size(100, 21);
        this.boton_Guardar.TabIndex = 23;
        this.boton_Guardar.Text = "Guardar";
        this.boton_Guardar.UseVisualStyleBackColor = true;
        this.boton_Guardar.Click += new System.EventHandler(this.boton_Guardar_Click);
        //
        // tb_RegistrarPassword
        //
        this.tb_RegistrarPassword.Location = new System.Drawing.Point(178, 62);
        this.tb_RegistrarPassword.Name = "tb_RegistrarPassword";
        this.tb_RegistrarPassword.PasswordChar = '*';
        this.tb_RegistrarPassword.Size = new System.Drawing.Size(363, 20);
        this.tb_RegistrarPassword.TabIndex = 20;
        this.tb_RegistrarPassword.UseSystemPasswordChar = true;
        //
        // label8
        //
        this.label8.AutoSize = true;
        this.label8.Location = new System.Drawing.Point(109, 65);
        this.label8.Name = "label8";
        this.label8.Size = new System.Drawing.Size(64, 13);
        this.label8.TabIndex = 19;
        this.label8.Text = "Contraseña:";
        //
        // tb_RegistrarDescripcion
        //
        this.tb_RegistrarDescripcion.Location = new System.Drawing.Point(178, 22);
        this.tb_RegistrarDescripcion.Name = "tb_RegistrarDescripcion";
        this.tb_RegistrarDescripcion.Size = new System.Drawing.Size(363, 20);
        this.tb_RegistrarDescripcion.TabIndex = 18;
        //
        // label7
        //
        this.label7.AutoSize = true;
        this.label7.Location = new System.Drawing.Point(109, 22);
        this.label7.Name = "label7";
        this.label7.Size = new System.Drawing.Size(63, 13);
        this.label7.TabIndex = 17;
        this.label7.Text = "Descipción:";
        //
        // gb_Visualizar
        //
        this.gb_Visualizar.BackColor = System.Drawing.SystemColors.ActiveCaption;
        this.gb_Visualizar.Controls.Add(this.cb_VisualizarDescripcion);
        this.gb_Visualizar.Controls.Add(this.label_UbicacionFichero);
        this.gb_Visualizar.Controls.Add(this.boton_Fichero);
        this.gb_Visualizar.Controls.Add(this.label6);
        this.gb_Visualizar.Controls.Add(this.label11);
        this.gb_Visualizar.Controls.Add(this.tb_VisualizarPassword);
        this.gb_Visualizar.Controls.Add(this.label12);
        this.gb_Visualizar.Enabled = false;
        this.gb_Visualizar.Location = new System.Drawing.Point(15, 155);
        this.gb_Visualizar.Name = "gb_Visualizar";
        this.gb_Visualizar.Size = new System.Drawing.Size(562, 118);
        this.gb_Visualizar.TabIndex = 25;
        this.gb_Visualizar.TabStop = false;
        this.gb_Visualizar.Text = "Visualizar";
        //
        // cb_VisualizarDescripcion
        //
        this.cb_VisualizarDescripcion.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
        this.cb_VisualizarDescripcion.FormattingEnabled = true;
        this.cb_VisualizarDescripcion.Location = new System.Drawing.Point(178, 18);
        this.cb_VisualizarDescripcion.Name = "cb_VisualizarDescripcion";
        this.cb_VisualizarDescripcion.Size = new System.Drawing.Size(363, 21);
        this.cb_VisualizarDescripcion.TabIndex = 15;
        this.cb_VisualizarDescripcion.Text = "No hay nada para mostrar";
        this.cb_VisualizarDescripcion.DropDown += new System.EventHandler(this.cb_VisualizarDescripcion_DropDown);
        //
        // label_UbicacionFichero
        //
        this.label_UbicacionFichero.AutoSize = true;
        this.label_UbicacionFichero.Location = new System.Drawing.Point(283, 55);
        this.label_UbicacionFichero.Margin = new System.Windows.Forms.Padding(3);
        this.label_UbicacionFichero.Name = "label_UbicacionFichero";
        this.label_UbicacionFichero.Size = new System.Drawing.Size(110, 13);
        this.label_UbicacionFichero.TabIndex = 14;
        this.label_UbicacionFichero.Text = "Ubicación del Fichero";
        //
        // boton_Fichero
        //
        this.boton_Fichero.Location = new System.Drawing.Point(178, 51);
        this.boton_Fichero.Margin = new System.Windows.Forms.Padding(2);
        this.boton_Fichero.Name = "boton_Fichero";
        this.boton_Fichero.Size = new System.Drawing.Size(100, 21);
        this.boton_Fichero.TabIndex = 13;
        this.boton_Fichero.Text = "Fichero";
        this.boton_Fichero.UseVisualStyleBackColor = true;
        this.boton_Fichero.Click += new System.EventHandler(this.boton_Fichero_Click);
        //
        // label6
        //
        this.label6.AutoSize = true;
        this.label6.Location = new System.Drawing.Point(75, 26);
        this.label6.Name = "label6";
        this.label6.Size = new System.Drawing.Size(97, 13);
        this.label6.TabIndex = 12;
        this.label6.Text = "Elija la descripción:";
        //
        // label11
        //
        this.label11.AutoSize = true;
        this.label11.Location = new System.Drawing.Point(33, 54);
        this.label11.Name = "label11";
        this.label11.Size = new System.Drawing.Size(139, 13);
        this.label11.TabIndex = 11;
        this.label11.Text = "Registre el fichero de clave:";
        //
        // tb_VisualizarPassword
        //
        this.tb_VisualizarPassword.Location = new System.Drawing.Point(178, 85);
        this.tb_VisualizarPassword.Name = "tb_VisualizarPassword";
        this.tb_VisualizarPassword.Size = new System.Drawing.Size(363, 20);
        this.tb_VisualizarPassword.TabIndex = 10;
        //
        // label12
        //
        this.label12.AutoSize = true;
        this.label12.Location = new System.Drawing.Point(57, 88);
        this.label12.Name = "label12";
        this.label12.Size = new System.Drawing.Size(115, 13);
        this.label12.TabIndex = 9;
        this.label12.Text = "Esta es su contraseña:";
        //
        // check_BorrarPass
        //
        this.check_BorrarPass.AutoSize = true;
        this.check_BorrarPass.Enabled = false;
        this.check_BorrarPass.Location = new System.Drawing.Point(15, 85);
        this.check_BorrarPass.Name = "check_BorrarPass";
        this.check_BorrarPass.Size = new System.Drawing.Size(111, 17);
        this.check_BorrarPass.TabIndex = 29;
        this.check_BorrarPass.Text = "Borrar Contraseña";
        this.check_BorrarPass.UseVisualStyleBackColor = true;
        this.check_BorrarPass.CheckedChanged += new System.EventHandler(this.check_BorrarPass_CheckedChanged);
        //
        // check_RegistrarPass
        //
        this.check_RegistrarPass.AutoSize = true;
        this.check_RegistrarPass.Enabled = false;
        this.check_RegistrarPass.Location = new System.Drawing.Point(15, 61);
        this.check_RegistrarPass.Name = "check_RegistrarPass";
        this.check_RegistrarPass.Size = new System.Drawing.Size(125, 17);
        this.check_RegistrarPass.TabIndex = 31;
        this.check_RegistrarPass.Text = "Registrar Contraseña";
        this.check_RegistrarPass.UseVisualStyleBackColor = true;
        this.check_RegistrarPass.CheckedChanged += new System.EventHandler(this.check_RegistrarPass_CheckedChanged);
        //
        // check_VisualizarPass
        //
        this.check_VisualizarPass.AutoSize = true;
        this.check_VisualizarPass.Enabled = false;
        this.check_VisualizarPass.Location = new System.Drawing.Point(15, 38);
        this.check_VisualizarPass.Name = "check_VisualizarPass";
        this.check_VisualizarPass.Size = new System.Drawing.Size(127, 17);
        this.check_VisualizarPass.TabIndex = 30;
        this.check_VisualizarPass.Text = "Visualizar Contraseña";
        this.check_VisualizarPass.UseVisualStyleBackColor = true;
        this.check_VisualizarPass.CheckedChanged += new System.EventHandler(this.check_VisualizarPass_CheckedChanged);
        //
        // Form1
        //
        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.BackColor = System.Drawing.SystemColors.ActiveCaption;
        this.ClientSize = new System.Drawing.Size(593, 545);
        this.Controls.Add(this.check_BorrarPass);
        this.Controls.Add(this.check_RegistrarPass);
        this.Controls.Add(this.check_VisualizarPass);
        this.Controls.Add(this.boton_GuardaryCerrar);
        this.Controls.Add(this.gb_Borrar);
        this.Controls.Add(this.gb_Registrar);
        this.Controls.Add(this.gb_Visualizar);
        this.Controls.Add(this.gb_RegistroUsuario);
        this.Controls.Add(this.boton_RegistrarUsuario);
        this.Controls.Add(this.tb_UsuarioRegistrado);
        this.Controls.Add(this.label1);
        this.Margin = new System.Windows.Forms.Padding(2);
        this.Name = "Form1";
        this.Text = "PSP05";
        this.gb_RegistroUsuario.ResumeLayout(false);
        this.gb_RegistroUsuario.PerformLayout();
        this.gb_Borrar.ResumeLayout(false);
        this.gb_Borrar.PerformLayout();
        this.gb_Registrar.ResumeLayout(false);
        this.gb_Registrar.PerformLayout();
        this.gb_Visualizar.ResumeLayout(false);
        this.gb_Visualizar.PerformLayout();
        this.ResumeLayout(false);
        this.PerformLayout();
    }
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.TextBox tb_UsuarioRegistrado;
    private System.Windows.Forms.Button boton_RegistrarUsuario;
    private System.Windows.Forms.GroupBox gb_RegistroUsuario;
    private System.Windows.Forms.Label label9;
    private System.Windows.Forms.TextBox tb_Email;
    private System.Windows.Forms.Button boton_RegistroAceptar;
    private System.Windows.Forms.RadioButton radio_RegistrarNo;
    private System.Windows.Forms.RadioButton radio_RegistrarYes;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.Button boton_GuardaryCerrar;
    private System.Windows.Forms.GroupBox gb_Borrar;
    private System.Windows.Forms.ComboBox cb_BorrarDescripcion;
    private System.Windows.Forms.Button boton_Borrar;
    private System.Windows.Forms.Label label10;
    private System.Windows.Forms.GroupBox gb_Registrar;
    private System.Windows.Forms.Button boton_Guardar;
    private System.Windows.Forms.TextBox tb_RegistrarPassword;
    private System.Windows.Forms.Label label8;
    private System.Windows.Forms.TextBox tb_RegistrarDescripcion;
    private System.Windows.Forms.Label label7;
    private System.Windows.Forms.GroupBox gb_Visualizar;
    private System.Windows.Forms.ComboBox cb_VisualizarDescripcion;
    private System.Windows.Forms.Label label_UbicacionFichero;
    private System.Windows.Forms.Button boton_Fichero;
    private System.Windows.Forms.Label label6;
    private System.Windows.Forms.Label label11;
    private System.Windows.Forms.TextBox tb_VisualizarPassword;
    private System.Windows.Forms.Label label12;
    private System.Windows.Forms.CheckBox check_BorrarPass;
    private System.Windows.Forms.CheckBox check_RegistrarPass;
    private System.Windows.Forms.CheckBox check_VisualizarPass;
}
}
