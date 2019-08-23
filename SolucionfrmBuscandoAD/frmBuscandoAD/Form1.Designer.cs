namespace frmBuscandoAD
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

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnTraerAD = new System.Windows.Forms.Button();
            this.dgvUsuarios = new System.Windows.Forms.DataGridView();
            this.lblUsuarios = new System.Windows.Forms.Label();
            this.txtUsuarios = new System.Windows.Forms.TextBox();
            this.btnExportar = new System.Windows.Forms.Button();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.cboBusqueda = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnADconMembrecias = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuarios)).BeginInit();
            this.SuspendLayout();
            // 
            // btnTraerAD
            // 
            this.btnTraerAD.Location = new System.Drawing.Point(12, 470);
            this.btnTraerAD.Name = "btnTraerAD";
            this.btnTraerAD.Size = new System.Drawing.Size(114, 29);
            this.btnTraerAD.TabIndex = 0;
            this.btnTraerAD.Text = "Traer AD";
            this.btnTraerAD.UseVisualStyleBackColor = true;
            this.btnTraerAD.Click += new System.EventHandler(this.btnTraerAD_Click);
            // 
            // dgvUsuarios
            // 
            this.dgvUsuarios.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvUsuarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUsuarios.Location = new System.Drawing.Point(12, 90);
            this.dgvUsuarios.Name = "dgvUsuarios";
            this.dgvUsuarios.Size = new System.Drawing.Size(770, 364);
            this.dgvUsuarios.TabIndex = 1;
            // 
            // lblUsuarios
            // 
            this.lblUsuarios.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsuarios.Location = new System.Drawing.Point(243, 27);
            this.lblUsuarios.Name = "lblUsuarios";
            this.lblUsuarios.Size = new System.Drawing.Size(105, 31);
            this.lblUsuarios.TabIndex = 2;
            this.lblUsuarios.Text = "Usuarios:\r\n";
            // 
            // txtUsuarios
            // 
            this.txtUsuarios.Location = new System.Drawing.Point(354, 12);
            this.txtUsuarios.Multiline = true;
            this.txtUsuarios.Name = "txtUsuarios";
            this.txtUsuarios.Size = new System.Drawing.Size(379, 56);
            this.txtUsuarios.TabIndex = 3;
            // 
            // btnExportar
            // 
            this.btnExportar.BackColor = System.Drawing.Color.Aqua;
            this.btnExportar.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportar.Location = new System.Drawing.Point(594, 462);
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Size = new System.Drawing.Size(167, 62);
            this.btnExportar.TabIndex = 5;
            this.btnExportar.Text = "EXPORTAR";
            this.btnExportar.UseVisualStyleBackColor = false;
            this.btnExportar.Click += new System.EventHandler(this.btnExportar_Click);
            // 
            // btnBuscar
            // 
            this.btnBuscar.BackColor = System.Drawing.Color.Aqua;
            this.btnBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscar.Location = new System.Drawing.Point(418, 460);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(154, 64);
            this.btnBuscar.TabIndex = 7;
            this.btnBuscar.Text = "BUSCAR";
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // cboBusqueda
            // 
            this.cboBusqueda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboBusqueda.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboBusqueda.Items.AddRange(new object[] {
            "ConsultaAD",
            "BusquedaPorUPN",
            "ControlC",
            "ControlSemanal",
            "Log"});
            this.cboBusqueda.Location = new System.Drawing.Point(25, 23);
            this.cboBusqueda.Name = "cboBusqueda";
            this.cboBusqueda.Size = new System.Drawing.Size(212, 28);
            this.cboBusqueda.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(247, 462);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(165, 62);
            this.label1.TabIndex = 4;
            this.label1.Text = "label1";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(132, 470);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 41);
            this.label2.TabIndex = 9;
            this.label2.Text = "Cantidad:";
            // 
            // btnADconMembrecias
            // 
            this.btnADconMembrecias.Location = new System.Drawing.Point(12, 505);
            this.btnADconMembrecias.Name = "btnADconMembrecias";
            this.btnADconMembrecias.Size = new System.Drawing.Size(114, 25);
            this.btnADconMembrecias.TabIndex = 10;
            this.btnADconMembrecias.Text = "AD Membrecias";
            this.btnADconMembrecias.UseVisualStyleBackColor = true;
            this.btnADconMembrecias.Click += new System.EventHandler(this.btnADconMembrecias_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.ClientSize = new System.Drawing.Size(794, 536);
            this.Controls.Add(this.btnADconMembrecias);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cboBusqueda);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.btnExportar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtUsuarios);
            this.Controls.Add(this.lblUsuarios);
            this.Controls.Add(this.dgvUsuarios);
            this.Controls.Add(this.btnTraerAD);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuarios)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnTraerAD;
        private System.Windows.Forms.DataGridView dgvUsuarios;
        private System.Windows.Forms.Label lblUsuarios;
        private System.Windows.Forms.TextBox txtUsuarios;
        private System.Windows.Forms.Button btnExportar;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.ComboBox cboBusqueda;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnADconMembrecias;
    }
}

