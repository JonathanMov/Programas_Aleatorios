using System;
using System.Windows.Forms;

namespace Mini_PuntoVenta {
    partial class Inventario {
        Producto prod_act;
        void click_Reg(object sender,EventArgs e) {
            try {
                foreach (Control caja in Controls)
                    if (caja is TextBox)
                        if ((caja as TextBox).Text == String.Empty)
                            throw new Exception();
                
                RegistroDB.Agregar(ToString(), "Inventario");
                MessageBox.Show("Registro exitoso");
            }
            catch (Exception) {
                MessageBox.Show("Rellena todos los campos");
            }
            finally {
                limpiar();
            }
        }
        void click_Act(object sender, EventArgs e) {
            try {
                foreach (Control caja in Controls)
                    if (caja is TextBox&& (caja as TextBox).Text == String.Empty)
                        throw new Exception();

                this.prod_act.code = this.code.Text;
                this.prod_act.product = this.product.Text;
                this.prod_act.price = Convert.ToDouble(this.price.Text);
                this.prod_act.cantidad = Convert.ToInt32(this.cantidad.Text);
                RegistroDB.Actualiza("Inventario");
                MessageBox.Show("Producto actualizado de manera exitosa");
            }
            catch (Exception) {
                MessageBox.Show("Rellena todos los campos");
            }
            finally {
                limpiar();
            }
        }
        void reg_Act(object sender, KeyPressEventArgs e) {
            if (e.KeyChar == (char)Keys.Enter) {
                desactivar_Activar(true);

                this.prod_act=getProducto(this.code.Text);
                if (prod_act != null) {
                    this.code.Enabled = true;
                    this.cantidad.Enabled = true;
                    this.price.Enabled = true;
                    this.product.Text = prod_act.product.Replace("_", " ");
                    this.description.Text = prod_act.description.Replace("_", " ");
                    this.cantidad.Text = prod_act.cantidad.ToString().Replace("_", " ");
                    this.price.Text = prod_act.price.ToString().Replace("_", " ");
                    this.registrar.Enabled = false;
                    MessageBox.Show(prod_act.ToString());
                }
                else 
                    this.actualizar.Enabled = false;
                
                    
            }
        }

    }
}
