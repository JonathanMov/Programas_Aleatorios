using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Restaurante
{
    public partial class Inicio : Form
    {
        public Inicio()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e){
            Form menu = new Menu();
            menu.Show();
            this.Hide();
        }
        private void button1_Click(object sender, EventArgs e){
            Form login = new Inicio_Sesion();
            login.Show();
            this.Hide();
        }
        private void pictureBox2_Click(object sender, EventArgs e){
            Form orden = new Ordenar();
            orden.Show();
            this.Hide();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
