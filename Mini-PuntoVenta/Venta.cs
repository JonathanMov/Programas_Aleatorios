using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mini_PuntoVenta {
    abstract class VentaBase {
        protected Producto prod_ven;
        protected readonly string date=DateTime.Now.ToString("yyyy-MM-dd:hh:mm:ss");
        protected int c_compra;
        public virtual double total {
            get =>this.c_compra * this.prod_ven.price;
        }
        public VentaBase(string code) {
            this.prod_ven = Inventario.GetProducto(code);
        }
    }
    class VentaMin : VentaBase {
        public VentaMin(string code) : base(code) { }
    }
    class VentaMay : VentaBase {
        public override double total {
            get => this.c_compra * this.prod_ven.price*0.85;
        }
        public VentaMay(string code) : base(code) { }
    }
}
