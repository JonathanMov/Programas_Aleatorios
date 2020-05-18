using System;
using System.Windows.Forms;

namespace Mini_PuntoVenta {
    class ProductoAgotadoExcepcion : Exception {
        public ProductoAgotadoExcepcion() : base("El producto que solicitas está agotado.") { }
    }
    class Producto {
        public string code { get; set; }
        public string product { get; set; }
        public string description { get; set; } ="Descripcion No Disponible";
        public double price { get; set; }
        private int _cantidad=0;
        public int cantidad {
            get {
                if (this._cantidad < 1)
                    throw new ProductoAgotadoExcepcion();
                else
                    return this._cantidad;
            }
            set {
                this._cantidad = value;
            }
        }
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
