using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Mini_PuntoVenta {
    partial class Inventario : Form {
        public Inventario() {
            Funciones.Diseno(this, 400, 300, "Inventario", "logo_inv");
            RegistroDB.Leer("Inventario");
            iniciaComponentes();
        }
        void limpiar() {
            foreach (Control caja in Controls)
                if(caja is TextBox|| caja is RichTextBox)
                (caja as TextBoxBase).Clear();
            desactivar_Activar(false);
        }
        void desactivar_Activar(bool oper) {
            foreach (Control caja in Controls)
                if (caja == this.code||caja is Label)
                    caja.Enabled = true;
                else
                    caja.Enabled = oper;
        }
        Producto getProducto(string codig){
            foreach (Producto prod in RegistroDB.productos)
                if (codig == prod.code)
                    return prod;
            return null;
        }
        public override String ToString() {
            return String.Format("{0}|{1}|{2}|{3}|{4}", this.code.Text, this.product.Text, this.description.Text, this.price.Text, this.cantidad.Text).Replace(" ", "_");
        }
    }
}
