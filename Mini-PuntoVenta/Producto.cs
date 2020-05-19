using System;
using System.Windows.Forms;

namespace Mini_PuntoVenta {
    /// <summary>
    /// Definicion de un producto.
    /// </summary>
    class Producto {
        /// <summary>
        /// Obtiene o establece el codigo del producto.
        /// </summary>
        public string code { get; set; }
        /// <summary>
        /// Obtiene o establece el nombre del producto.
        /// </summary>
        public string product { get; set; }
        /// <summary>
        /// Obtiene o establece la descripción del producto.
        /// </summary>
        public string description { get; set; } ="Descripcion No Disponible";
        /// <summary>
        /// Obtiene o establece el precio del producto.
        /// </summary>
        public double price { get; set; }
        private int _cantidad=0;
        /// <summary>
        /// Obtiene o establece la cantidad actual del producto.
        /// </summary>
        /// <exception cref="ProductoAgotadoException">Devuelta cuando la cantidad actual es menor a 1.</exception>
        public int cantidad {
            get {
                if (this._cantidad < 1)
                    throw new ProductoAgotadoException();
                else
                    return this._cantidad;
            }
            set {
                this._cantidad = value;
            }
        }/// <summary>
        /// Crea un producto inicializando todos los atributos menos el de la descripcion.
        /// </summary>
        /// <param name="code">Establece el codigo del producto</param>
        /// <param name="product">Establece el nombre del producto</param>
        /// <param name="price">Establece el precio del producto</param>
        /// <param name="cantidad">Establece la cantidad actual del producto</param>
        public Producto(string code,string product,double price,int cantidad) {
            this.code = code;
            this.product = product;
            this.price = price;
            this.cantidad = cantidad;
        }
        public override String ToString() {
            return String.Format("{0}|{1}|{2}|{3}|{4}",this.code,this.product,this.description,this.price,this.cantidad);
        }
    }
}
