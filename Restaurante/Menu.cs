using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Restaurante
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void btnReg_Click(object sender, EventArgs e){
            Form inicio = new Inicio();
            inicio.Show();
            this.Close();
        }

        private void btnExit_Click(object sender, EventArgs e){
            Application.Exit();
        }

        private void btnOrde_Click(object sender, EventArgs e){
            Form orden = new Ordenar();
            orden.Show();
            this.Close();
        }
    }
}
