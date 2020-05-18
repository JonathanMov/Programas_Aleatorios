using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Restaurante
{
    public partial class Ordenar : Form
    {
        public Ordenar()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e){
            Application.Exit();
        }

        private void btnOrden_Click(object sender, EventArgs e)
        {

        }

        private void btnInicio_Click(object sender, EventArgs e)
        {
            Form inicio = new Inicio();
            inicio.Show();
            this.Close();
        }

        private void btnMen_Click(object sender, EventArgs e){
            Form men = new Menu();
            men.Show();
            this.Close();
        }
    }
}
