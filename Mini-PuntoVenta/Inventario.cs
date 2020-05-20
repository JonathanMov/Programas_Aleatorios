using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Mini_PuntoVenta {
    partial class Inventario : Form {
        /// <summary>
        /// Inicia la forma, dandole diseño,iniciando sus componentes y lee la DB
        /// </summary>
        public Inventario() {
            Funciones.Diseno(this, 400, 300, "Inventario", "logo_inv");
            RegistroDB.Leer(false);
            iniciaComponentes();
        }
        /// <summary>
        /// Limpia todas las texBoxBase que hay en la forma e implementa el método desactivar_Activar
        /// para desactivar los componentes
        /// </summary>
        void limpiar() {
            foreach (Control caja in Controls)
                if(caja is TextBox|| caja is RichTextBox)
                (caja as TextBoxBase).Clear();
            desactivar_Activar(false);
        }
        /// <summary>
        /// Desactiva o activa todos los controles excepto las etiquetas y el txtBox de Código
        /// </summary>
        /// <param name="oper">Activa o desactivar todo.</param>
        void desactivar_Activar(bool oper) {
            foreach (Control caja in Controls)
                if (caja == this.code||caja is Label)
                    caja.Enabled = true;
                else
                    caja.Enabled = oper;
        }
        /// <summary>
        /// Busca en la base de datos si el codigo proporcionado pertence a algun producto en ella.
        /// </summary>
        /// <param name="codig">Codigo del producto a buscar</param>
        /// <returns>En caso de encontrar coincidencia regresa el producto,en caso contrario regresa null.</returns>
        static public Producto GetProducto(string codig){
            foreach (Producto prod in RegistroDB.productos)
                if (codig == prod.code)
                    return prod;
            return null;
        }
        public override String ToString() {
            return String.Format("{0}|{1}|{2}|{3}|{4}", this.code.Text, this.product.Text, this.description.Text, this.price.Text, this.cantidad.Text).Replace(" ", "_");
        }
        /// <summary>
        /// Comprueba que todas las textBoxBase dentro de una lista de control no estén vacias, en caso de estarlo
        /// se arroja una excepcion tipo TextBoxisEmptyException
        /// </summary>
        /// <param name="cts"></param>
        public static void TxtisEmpty(ControlCollection cts) {
            foreach (Control caja in cts)
                if (caja is TextBoxBase && (caja as TextBoxBase).Text == String.Empty)
                    throw new TextBoxisEmptyException();
        }
    }
}
