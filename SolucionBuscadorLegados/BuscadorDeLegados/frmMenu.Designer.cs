namespace BuscadorDeLegados
{
    partial class frmMenu
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
            this.btnBuscarUno = new System.Windows.Forms.Button();
            this.btnBuscarMasivo = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnBuscarUno
            // 
            this.btnBuscarUno.BackColor = System.Drawing.Color.Turquoise;
            this.btnBuscarUno.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscarUno.Location = new System.Drawing.Point(12, 12);
            this.btnBuscarUno.Name = "btnBuscarUno";
            this.btnBuscarUno.Size = new System.Drawing.Size(208, 51);
            this.btnBuscarUno.TabIndex = 0;
            this.btnBuscarUno.Text = "BUSCAR AD";
            this.btnBuscarUno.UseVisualStyleBackColor = false;
            this.btnBuscarUno.Click += new System.EventHandler(this.btnBuscarUno_Click);
            // 
            // btnBuscarMasivo
            // 
            this.btnBuscarMasivo.BackColor = System.Drawing.Color.Turquoise;
            this.btnBuscarMasivo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscarMasivo.Location = new System.Drawing.Point(12, 85);
            this.btnBuscarMasivo.Name = "btnBuscarMasivo";
            this.btnBuscarMasivo.Size = new System.Drawing.Size(208, 53);
            this.btnBuscarMasivo.TabIndex = 1;
            this.btnBuscarMasivo.Text = "BUSCAR APPS";
            this.btnBuscarMasivo.UseVisualStyleBackColor = false;
            this.btnBuscarMasivo.Click += new System.EventHandler(this.btnBuscarMasivo_Click);
            // 
            // frmMenu
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.ClientSize = new System.Drawing.Size(259, 164);
            this.Controls.Add(this.btnBuscarMasivo);
            this.Controls.Add(this.btnBuscarUno);
            this.Name = "frmMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MENU";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnBuscarUno;
        private System.Windows.Forms.Button btnBuscarMasivo;
    }
}