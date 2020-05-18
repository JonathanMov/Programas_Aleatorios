namespace Restaurante
{
    partial class Ordenar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Ordenar));
            this.btnInicio = new System.Windows.Forms.Button();
            this.btnOrden = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnMen = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnInicio
            // 
            this.btnInicio.Location = new System.Drawing.Point(623, 348);
            this.btnInicio.Name = "btnInicio";
            this.btnInicio.Size = new System.Drawing.Size(75, 40);
            this.btnInicio.TabIndex = 0;
            this.btnInicio.Text = "Regresar Inicio";
            this.btnInicio.UseVisualStyleBackColor = true;
            this.btnInicio.Click += new System.EventHandler(this.btnInicio_Click);
            // 
            // btnOrden
            // 
            this.btnOrden.Location = new System.Drawing.Point(623, 290);
            this.btnOrden.Name = "btnOrden";
            this.btnOrden.Size = new System.Drawing.Size(75, 23);
            this.btnOrden.TabIndex = 1;
            this.btnOrden.Text = "Ordenar";
            this.btnOrden.UseVisualStyleBackColor = true;
            this.btnOrden.Click += new System.EventHandler(this.btnOrden_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(623, 394);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 2;
            this.btnExit.Text = "Salir";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnMen
            // 
            this.btnMen.Location = new System.Drawing.Point(623, 319);
            this.btnMen.Name = "btnMen";
            this.btnMen.Size = new System.Drawing.Size(75, 23);
            this.btnMen.TabIndex = 3;
            this.btnMen.Text = "Ver Menu";
            this.btnMen.UseVisualStyleBackColor = true;
            this.btnMen.Click += new System.EventHandler(this.btnMen_Click);
            // 
            // Ordenar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnMen);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnOrden);
            this.Controls.Add(this.btnInicio);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Ordenar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ordenar";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnInicio;
        private System.Windows.Forms.Button btnOrden;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnMen;
    }
}