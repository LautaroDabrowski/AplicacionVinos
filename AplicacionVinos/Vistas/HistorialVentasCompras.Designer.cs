namespace AplicacionVinos.Vistas
{
    partial class HistorialVentasCompras
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgv_Rventas = new System.Windows.Forms.DataGridView();
            this.btn_BuscarVent = new System.Windows.Forms.Button();
            this.dt_hasta = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.dt_Desde = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgv_RepComp = new System.Windows.Forms.DataGridView();
            this.btn_BuscarCom = new System.Windows.Forms.Button();
            this.dt_FHasta = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.dt_FDesde = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Rventas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_RepComp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(239)))), ((int)(((byte)(225)))));
            this.groupBox2.Controls.Add(this.dgv_Rventas);
            this.groupBox2.Controls.Add(this.btn_BuscarVent);
            this.groupBox2.Controls.Add(this.dt_hasta);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.dt_Desde);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.pictureBox1);
            this.groupBox2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(0)))), ((int)(((byte)(31)))));
            this.groupBox2.Location = new System.Drawing.Point(12, 42);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(904, 299);
            this.groupBox2.TabIndex = 16;
            this.groupBox2.TabStop = false;
            // 
            // dgv_Rventas
            // 
            this.dgv_Rventas.BackgroundColor = System.Drawing.SystemColors.Menu;
            this.dgv_Rventas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Rventas.Location = new System.Drawing.Point(18, 117);
            this.dgv_Rventas.Name = "dgv_Rventas";
            this.dgv_Rventas.RowHeadersWidth = 51;
            this.dgv_Rventas.RowTemplate.Height = 24;
            this.dgv_Rventas.Size = new System.Drawing.Size(861, 165);
            this.dgv_Rventas.TabIndex = 36;
            // 
            // btn_BuscarVent
            // 
            this.btn_BuscarVent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(175)))), ((int)(((byte)(55)))));
            this.btn_BuscarVent.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_BuscarVent.ForeColor = System.Drawing.Color.White;
            this.btn_BuscarVent.Location = new System.Drawing.Point(630, 61);
            this.btn_BuscarVent.Name = "btn_BuscarVent";
            this.btn_BuscarVent.Size = new System.Drawing.Size(249, 46);
            this.btn_BuscarVent.TabIndex = 35;
            this.btn_BuscarVent.Text = "Buscar";
            this.btn_BuscarVent.UseVisualStyleBackColor = false;
            // 
            // dt_hasta
            // 
            this.dt_hasta.Location = new System.Drawing.Point(328, 67);
            this.dt_hasta.Name = "dt_hasta";
            this.dt_hasta.Size = new System.Drawing.Size(268, 34);
            this.dt_hasta.TabIndex = 20;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 4);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(116, 28);
            this.label3.TabIndex = 19;
            this.label3.Text = "Elegir Fecha";
            // 
            // dt_Desde
            // 
            this.dt_Desde.Location = new System.Drawing.Point(18, 67);
            this.dt_Desde.Name = "dt_Desde";
            this.dt_Desde.Size = new System.Drawing.Size(268, 34);
            this.dt_Desde.TabIndex = 18;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(323, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 28);
            this.label2.TabIndex = 2;
            this.label2.Text = "Hasta";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 28);
            this.label1.TabIndex = 0;
            this.label1.Text = "Desde  ";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::AplicacionVinos.Properties.Resources.Logotipo_Vino_Minimalista_Negro_y_Violeta__6_;
            this.pictureBox1.Location = new System.Drawing.Point(117, -74);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(569, 523);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 37;
            this.pictureBox1.TabStop = false;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Yu Gothic", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(212)))), ((int)(((byte)(200)))));
            this.label16.Location = new System.Drawing.Point(12, 7);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(209, 30);
            this.label16.TabIndex = 18;
            this.label16.Text = "Reporte de Ventas";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Yu Gothic", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(212)))), ((int)(((byte)(200)))));
            this.label4.Location = new System.Drawing.Point(12, 351);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(231, 30);
            this.label4.TabIndex = 19;
            this.label4.Text = "Reporte de Compras";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(239)))), ((int)(((byte)(225)))));
            this.groupBox1.Controls.Add(this.dgv_RepComp);
            this.groupBox1.Controls.Add(this.btn_BuscarCom);
            this.groupBox1.Controls.Add(this.dt_FHasta);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.dt_FDesde);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.pictureBox2);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(0)))), ((int)(((byte)(31)))));
            this.groupBox1.Location = new System.Drawing.Point(12, 384);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(904, 299);
            this.groupBox1.TabIndex = 20;
            this.groupBox1.TabStop = false;
            // 
            // dgv_RepComp
            // 
            this.dgv_RepComp.BackgroundColor = System.Drawing.SystemColors.Menu;
            this.dgv_RepComp.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_RepComp.Location = new System.Drawing.Point(18, 117);
            this.dgv_RepComp.Name = "dgv_RepComp";
            this.dgv_RepComp.RowHeadersWidth = 51;
            this.dgv_RepComp.RowTemplate.Height = 24;
            this.dgv_RepComp.Size = new System.Drawing.Size(861, 165);
            this.dgv_RepComp.TabIndex = 36;
            // 
            // btn_BuscarCom
            // 
            this.btn_BuscarCom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(175)))), ((int)(((byte)(55)))));
            this.btn_BuscarCom.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_BuscarCom.ForeColor = System.Drawing.Color.White;
            this.btn_BuscarCom.Location = new System.Drawing.Point(630, 61);
            this.btn_BuscarCom.Name = "btn_BuscarCom";
            this.btn_BuscarCom.Size = new System.Drawing.Size(249, 46);
            this.btn_BuscarCom.TabIndex = 35;
            this.btn_BuscarCom.Text = "Buscar";
            this.btn_BuscarCom.UseVisualStyleBackColor = false;
            // 
            // dt_FHasta
            // 
            this.dt_FHasta.Location = new System.Drawing.Point(328, 67);
            this.dt_FHasta.Name = "dt_FHasta";
            this.dt_FHasta.Size = new System.Drawing.Size(268, 34);
            this.dt_FHasta.TabIndex = 20;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 4);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(116, 28);
            this.label5.TabIndex = 19;
            this.label5.Text = "Elegir Fecha";
            // 
            // dt_FDesde
            // 
            this.dt_FDesde.Location = new System.Drawing.Point(18, 67);
            this.dt_FDesde.Name = "dt_FDesde";
            this.dt_FDesde.Size = new System.Drawing.Size(268, 34);
            this.dt_FDesde.TabIndex = 18;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(323, 36);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(61, 28);
            this.label6.TabIndex = 2;
            this.label6.Text = "Hasta";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(13, 36);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(76, 28);
            this.label7.TabIndex = 0;
            this.label7.Text = "Desde  ";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::AplicacionVinos.Properties.Resources.Logotipo_Vino_Minimalista_Negro_y_Violeta__6_;
            this.pictureBox2.Location = new System.Drawing.Point(117, -382);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(569, 523);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 38;
            this.pictureBox2.TabStop = false;
            // 
            // HistorialVentasCompras
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(0)))), ((int)(((byte)(31)))));
            this.ClientSize = new System.Drawing.Size(928, 695);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.groupBox2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "HistorialVentasCompras";
            this.Text = "HistorialVentasCompras";
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Rventas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_RepComp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DateTimePicker dt_hasta;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dt_Desde;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgv_Rventas;
        private System.Windows.Forms.Button btn_BuscarVent;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgv_RepComp;
        private System.Windows.Forms.Button btn_BuscarCom;
        private System.Windows.Forms.DateTimePicker dt_FHasta;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dt_FDesde;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}