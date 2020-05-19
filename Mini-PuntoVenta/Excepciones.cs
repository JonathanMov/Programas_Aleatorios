using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mini_PuntoVenta {
    /// <summary>
    /// Excepcion que se produce cuando un textBox se encuentra vacio
    /// </summary>
    class TextBoxisEmptyException : Exception {
        public TextBoxisEmptyException() : base("Ingresa datos válidos en los textBox") {}
    }
    /// <summary>
    /// Excepcion que se produce cuando se agota un producto.
    /// </summary>
    class ProductoAgotadoException : Exception {
        public ProductoAgotadoException() : base("El producto que solicitas está agotado.") { }
    }
}
