using System;
using System.Windows.Forms;

namespace Mini_PuntoVenta {
    partial class Inventario {
        Producto prod_act;
        /// <summary>
        /// Evento encargado de añadir un nuevo producto en la base de datos especificada, ademas de comprobar que los textBox no estén vacios.
        /// </summary>
        void click_Reg(object sender,EventArgs e) {
            try {
                TxtisEmpty(this.Controls as ControlCollection);
                RegistroDB.productos.Add(new Producto(this.code.Text.Replace(" ", "_"), this.product.Text.Replace(" ", "_"), this.description.Text.Replace(" ", "_"), Convert.ToDouble(this.price.Text), Convert.ToInt32(this.cantidad.Text)));
                RegistroDB.Actualiza(false);
                MessageBox.Show("Registro exitoso");
                limpiar();
            }
            /*En caso que algun textBox se encuentre vacio se notica al usuario que debe ingresar datos válidos */
            catch (TextBoxisEmptyException) {
                MessageBox.Show(new TextBoxisEmptyException().Message);
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }
        /// <summary>
        /// Evento encargado de actualizar la base de datos al cambiar un elemento dentro de la misma, ademas de comprobar que los textBox no estén vacios.
        /// </summary>
        void click_Act(object sender, EventArgs e) {
            try {
                TxtisEmpty(this.Controls as ControlCollection);
                this.prod_act.code = this.code.Text;
                this.prod_act.product = this.product.Text;
                this.prod_act.price = Convert.ToDouble(this.price.Text);
                this.prod_act.cantidad = Convert.ToInt32(this.cantidad.Text);
                RegistroDB.Actualiza(false);
                MessageBox.Show("Producto actualizado de manera exitosa");
                limpiar();
            }
            catch (TextBoxisEmptyException) {
                MessageBox.Show(new TextBoxisEmptyException().Message);
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }
        /// <summary>
        /// Evento encargado (al presionar enter) de determinar si el codigo ingresado pertence a un articulo, de ser asi actualizar sus datos.
        /// En caso de que el elemento no exista lo añade a la base de datos.
        /// </summary>
        void reg_Act(object sender, KeyPressEventArgs e) {
            if (e.KeyChar == (char)Keys.Enter) {
                this.code.Text = this.code.Text.ToUpper();
                desactivar_Activar(true);

                this.prod_act=GetProducto(this.code.Text);
                /*
                 * En caso que coincida el codigo dado en el textbox con algun producto en la DB, despliega su info en las txtBox.
                 * Además desactiva el boton de registrar para que solo se pueda actualizar el producto. En caso que sea un nuevo
                 * producto tambien se activan todos los campos menos el boton de actualizar porque se registrará un nuevo elemento.
                 */
                if (this.prod_act != null) {
                    this.registrar.Enabled = false;
                    this.product.Text = this.prod_act.product.Replace("_", " ");
                    this.description.Text = this.prod_act.description.Replace("_", " ");
                    this.cantidad.Text = this.prod_act.cantidad.ToString().Replace("_", " ");
                    this.price.Text = this.prod_act.price.ToString().Replace("_", " ");
                    MessageBox.Show(this.prod_act.ToString());
                }
                else 
                    this.actualizar.Enabled = false;
            }
        }

    }
}
