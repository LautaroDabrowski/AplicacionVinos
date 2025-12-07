namespace AplicacionVinos.Vistas
{
    partial class AltaCliente
    {
        private System.ComponentModel.IContainer components = null;

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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btn_Editar = new System.Windows.Forms.Button();
            this.txt_DNI = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cb_Estado = new System.Windows.Forms.ComboBox();
            this.txt_Telefono = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_Correo = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_RS = new System.Windows.Forms.TextBox();
            this.txt_Nombres = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_Apellido = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_Direccion = new System.Windows.Forms.TextBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.btn_Cancelar = new System.Windows.Forms.Button();
            this.btn_Agregar = new System.Windows.Forms.Button();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();

            // groupBox2
            this.groupBox2.BackColor = System.Drawing.Color.FromArgb(245, 239, 225);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.btn_Editar);
            this.groupBox2.Controls.Add(this.txt_DNI);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.cb_Estado);
            this.groupBox2.Controls.Add(this.txt_Telefono);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.txt_Correo);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.txt_RS);
            this.groupBox2.Controls.Add(this.txt_Nombres);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.txt_Apellido);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.txt_Direccion);
            this.groupBox2.Controls.Add(this.pictureBox2);
            this.groupBox2.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.groupBox2.ForeColor = System.Drawing.Color.FromArgb(61, 0, 31);
            this.groupBox2.Location = new System.Drawing.Point(12, 11);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(480, 671);
            this.groupBox2.TabIndex = 15;
            this.groupBox2.TabStop = false;

            // label8
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(13, 8);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(160, 28);
            this.label8.TabIndex = 40;
            this.label8.Text = "Datos del Cliente";

            // btn_Editar
            this.btn_Editar.BackColor = System.Drawing.Color.FromArgb(70, 70, 70);
            this.btn_Editar.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btn_Editar.ForeColor = System.Drawing.Color.White;
            this.btn_Editar.Location = new System.Drawing.Point(285, 21);
            this.btn_Editar.Name = "btn_Editar";
            this.btn_Editar.Size = new System.Drawing.Size(174, 37);
            this.btn_Editar.TabIndex = 37;
            this.btn_Editar.Text = "Editar Cliente";
            this.btn_Editar.UseVisualStyleBackColor = false;

            // txt_DNI
            this.txt_DNI.Location = new System.Drawing.Point(18, 233);
            this.txt_DNI.Name = "txt_DNI";
            this.txt_DNI.Size = new System.Drawing.Size(441, 34);
            this.txt_DNI.TabIndex = 19;

            // label7
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(13, 202);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(126, 28);
            this.label7.TabIndex = 18;
            this.label7.Text = "CUIL / CUIT";

            // cb_Estado
            this.cb_Estado.FormattingEnabled = true;
            this.cb_Estado.Location = new System.Drawing.Point(18, 616);
            this.cb_Estado.Name = "cb_Estado";
            this.cb_Estado.Size = new System.Drawing.Size(441, 36);
            this.cb_Estado.TabIndex = 17;

            // txt_Telefono
            this.txt_Telefono.Location = new System.Drawing.Point(18, 386);
            this.txt_Telefono.Name = "txt_Telefono";
            this.txt_Telefono.Size = new System.Drawing.Size(441, 34);
            this.txt_Telefono.TabIndex = 16;

            // label6
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 355);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(86, 28);
            this.label6.TabIndex = 15;
            this.label6.Text = "Teléfono";

            // label5
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 585);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 28);
            this.label5.TabIndex = 14;
            this.label5.Text = "Estado";

            // label4
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 512);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(123, 28);
            this.label4.TabIndex = 12;
            this.label4.Text = "Razón Social";

            // txt_Correo
            this.txt_Correo.Location = new System.Drawing.Point(18, 309);
            this.txt_Correo.Name = "txt_Correo";
            this.txt_Correo.Size = new System.Drawing.Size(441, 34);
            this.txt_Correo.TabIndex = 10;

            // label12
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(13, 278);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(174, 28);
            this.label12.TabIndex = 9;
            this.label12.Text = "Correo Electrónico";

            // label3
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 434);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 28);
            this.label3.TabIndex = 5;
            this.label3.Text = "Dirección";

            // txt_RS
            this.txt_RS.Location = new System.Drawing.Point(18, 543);
            this.txt_RS.Name = "txt_RS";
            this.txt_RS.Size = new System.Drawing.Size(441, 34);
            this.txt_RS.TabIndex = 4;

            // txt_Nombres
            this.txt_Nombres.Location = new System.Drawing.Point(17, 156);
            this.txt_Nombres.Name = "txt_Nombres";
            this.txt_Nombres.Size = new System.Drawing.Size(440, 34);
            this.txt_Nombres.TabIndex = 3;

            // label2
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 125);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 28);
            this.label2.TabIndex = 2;
            this.label2.Text = "Nombres";

            // txt_Apellido
            this.txt_Apellido.Location = new System.Drawing.Point(17, 80);
            this.txt_Apellido.Name = "txt_Apellido";
            this.txt_Apellido.Size = new System.Drawing.Size(440, 34);
            this.txt_Apellido.TabIndex = 1;

            // label1
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 28);
            this.label1.TabIndex = 0;
            this.label1.Text = "Apellido";

            // txt_Direccion
            this.txt_Direccion.Location = new System.Drawing.Point(18, 465);
            this.txt_Direccion.Name = "txt_Direccion";
            this.txt_Direccion.Size = new System.Drawing.Size(441, 34);
            this.txt_Direccion.TabIndex = 11;

            // pictureBox2
            this.pictureBox2.Image = global::AplicacionVinos.Properties.Resources.Logotipo_Vino_Minimalista_Negro_y_Violeta__8_;
            this.pictureBox2.Location = new System.Drawing.Point(0, 1);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(480, 671);
            this.pictureBox2.TabIndex = 41;
            this.pictureBox2.TabStop = false;

            // btn_Cancelar
            this.btn_Cancelar.BackColor = System.Drawing.Color.FromArgb(70, 70, 70);
            this.btn_Cancelar.Font = new System.Drawing.Font("Segoe UI", 10.8F);
            this.btn_Cancelar.ForeColor = System.Drawing.Color.White;
            this.btn_Cancelar.Location = new System.Drawing.Point(534, 617);
            this.btn_Cancelar.Name = "btn_Cancelar";
            this.btn_Cancelar.Size = new System.Drawing.Size(360, 46);
            this.btn_Cancelar.TabIndex = 35;
            this.btn_Cancelar.Text = "Cancelar";
            this.btn_Cancelar.UseVisualStyleBackColor = false;

            // btn_Agregar
            this.btn_Agregar.BackColor = System.Drawing.Color.FromArgb(212, 175, 55);
            this.btn_Agregar.Font = new System.Drawing.Font("Segoe UI", 10.8F);
            this.btn_Agregar.ForeColor = System.Drawing.Color.White;
            this.btn_Agregar.Location = new System.Drawing.Point(534, 542);
            this.btn_Agregar.Name = "btn_Agregar";
            this.btn_Agregar.Size = new System.Drawing.Size(360, 46);
            this.btn_Agregar.TabIndex = 34;
            this.btn_Agregar.Text = "Agregar Cliente";
            this.btn_Agregar.UseVisualStyleBackColor = false;

            // pictureBox3
            this.pictureBox3.Image = global::AplicacionVinos.Properties.Resources.Logotipo_Vino_Minimalista_Negro_y_Violeta__7_;
            this.pictureBox3.Location = new System.Drawing.Point(463, -56);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(354, 349);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 44;
            this.pictureBox3.TabStop = false;

            // pictureBox1
            this.pictureBox1.Image = global::AplicacionVinos.Properties.Resources.Logotipo_Vino_Minimalista_Negro_y_Violeta__34_;
            this.pictureBox1.Location = new System.Drawing.Point(575, 366);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(354, 351);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 45;
            this.pictureBox1.TabStop = false;

            // AltaCliente
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(61, 0, 31);
            this.ClientSize = new System.Drawing.Size(928, 695);
            this.Controls.Add(this.btn_Cancelar);
            this.Controls.Add(this.btn_Agregar);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.pictureBox3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AltaCliente";
            this.Text = "AltaCliente";
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
        }


        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txt_DNI;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cb_Estado;
        private System.Windows.Forms.TextBox txt_Telefono;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_Direccion;
        private System.Windows.Forms.TextBox txt_Correo;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_RS;
        private System.Windows.Forms.TextBox txt_Nombres;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_Apellido;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_Cancelar;
        private System.Windows.Forms.Button btn_Agregar;
        private System.Windows.Forms.Button btn_Editar;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}
