using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;

namespace Restaurante
{
    public partial class Inicio_Sesion : Form
    {
        OleDbConnection conexion = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\\Restaurante.accdb");
        OleDbCommand command = new OleDbCommand();
        OleDbDataReader dtr;
        public Inicio_Sesion(){
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e){
            Form inicio = new Inicio();
            inicio.Show();
            this.Close();
        }

        private void btnLog_Click(object sender, EventArgs e)
        {
            command.Connection = conexion;
            command.CommandType = CommandType.Text;
            command.CommandText = "SELECT Contraseña FROM Usuarios WHERE Nombre_Usuario='"+txbUser.Text+"'";
            try{
                dtr = command.ExecuteReader();
                if (dtr.HasRows)
                {
                    while (dtr.Read())
                    {
                        if (dtr.GetValue(0).ToString() == txbPass.Text){
                            Form editar = new Menu_admin();
                            editar.Show();
                            this.Close();
                        }else{
                            MessageBox.Show("Usuario o contraseña Incorrectos","Error");
                        }
                    }
                }
                dtr.Close();
            }
            catch (Exception k)
            {
                MessageBox.Show("Error "+k,"Error");
            }
        }

        private void Inicio_Sesion_Load(object sender, EventArgs e)
        {
            try{
                conexion.Open();
                MessageBox.Show("Conexión Exitosa con el Servidor","Conectado");

            }
            catch(Exception){
                MessageBox.Show("Conexión con el Servidor Fallida","Error con el servidor");
                Form inicio = new Inicio();
                inicio.Show();
                this.Close();
            }
        }
    }
}
