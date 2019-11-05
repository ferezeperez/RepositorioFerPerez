namespace BuscadorDeLegados
{
    partial class frmMasivo
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
            this.txtMasivo = new System.Windows.Forms.TextBox();
            this.btnMasivo = new System.Windows.Forms.Button();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.cboBusqueda = new System.Windows.Forms.ComboBox();
            this.dgvUsuarios = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuarios)).BeginInit();
            this.SuspendLayout();
            // 
            // txtMasivo
            // 
            this.txtMasivo.AllowDrop = true;
            this.txtMasivo.Location = new System.Drawing.Point(461, 12);
            this.txtMasivo.MaxLength = 99999;
            this.txtMasivo.Multiline = true;
            this.txtMasivo.Name = "txtMasivo";
            this.txtMasivo.Size = new System.Drawing.Size(258, 56);
            this.txtMasivo.TabIndex = 2000;
            this.txtMasivo.TabStop = false;
            this.txtMasivo.Visible = false;
            // 
            // btnMasivo
            // 
            this.btnMasivo.BackColor = System.Drawing.Color.Turquoise;
            this.btnMasivo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMasivo.Location = new System.Drawing.Point(233, 12);
            this.btnMasivo.Name = "btnMasivo";
            this.btnMasivo.Size = new System.Drawing.Size(189, 41);
            this.btnMasivo.TabIndex = 16;
            this.btnMasivo.Text = "Masivo";
            this.btnMasivo.UseVisualStyleBackColor = false;
            this.btnMasivo.Click += new System.EventHandler(this.btnMasivo_Click);
            // 
            // btnBuscar
            // 
            this.btnBuscar.BackColor = System.Drawing.Color.Turquoise;
            this.btnBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscar.Location = new System.Drawing.Point(108, 528);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(234, 48);
            this.btnBuscar.TabIndex = 17;
            this.btnBuscar.Text = "BUSCAR";
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // btnCerrar
            // 
            this.btnCerrar.BackColor = System.Drawing.Color.Turquoise;
            this.btnCerrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCerrar.Location = new System.Drawing.Point(483, 528);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(236, 48);
            this.btnCerrar.TabIndex = 18;
            this.btnCerrar.Text = "CERRAR";
            this.btnCerrar.UseVisualStyleBackColor = false;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // cboBusqueda
            // 
            this.cboBusqueda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboBusqueda.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboBusqueda.FormattingEnabled = true;
            this.cboBusqueda.Items.AddRange(new object[] {
            "Legados",
            "SAP",
            "Inactividad"});
            this.cboBusqueda.Location = new System.Drawing.Point(41, 18);
            this.cboBusqueda.Name = "cboBusqueda";
            this.cboBusqueda.Size = new System.Drawing.Size(158, 28);
            this.cboBusqueda.TabIndex = 19;
            // 
            // dgvUsuarios
            // 
            this.dgvUsuarios.AllowUserToOrderColumns = true;
            this.dgvUsuarios.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvUsuarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUsuarios.Location = new System.Drawing.Point(12, 74);
            this.dgvUsuarios.Name = "dgvUsuarios";
            this.dgvUsuarios.Size = new System.Drawing.Size(825, 448);
            this.dgvUsuarios.TabIndex = 24;
            // 
            // frmMasivo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.ClientSize = new System.Drawing.Size(849, 588);
            this.Controls.Add(this.dgvUsuarios);
            this.Controls.Add(this.cboBusqueda);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.btnMasivo);
            this.Controls.Add(this.txtMasivo);
            this.Name = "frmMasivo";
            this.Text = "BUSCADOR DE LEGADOS";
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuarios)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtMasivo;
        private System.Windows.Forms.Button btnMasivo;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.ComboBox cboBusqueda;
        public System.Windows.Forms.DataGridView dgvUsuarios;
    }
}