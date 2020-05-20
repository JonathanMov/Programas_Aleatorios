using System;
using System.IO;
using System.Text.Json;
using System.Windows.Forms;
using System.Collections.Generic;

namespace Mini_PuntoVenta {
    /// <summary>
    /// Conexion a la base de datos.
    /// </summary>
    class RegistroDB {
        ///<summary>
        ///Lista "interna" donde se almacenan los productos de la DB
        ///</summary>
        public static List<Producto> productos;
        public static List<VentaBase> ventas;
        /// <summary>
        /// Lee la DB y la almacena en la lista "interna".
        /// </summary>
        /// <param name="name">Nombre de la DB</param>
        public static void Leer(bool charge) {
            /*Se carga toda la DB a la lista interna productos*/
            try {
                productos = JsonSerializer.Deserialize<List<Producto>>(File.ReadAllText("./Inventario.json"));
                if(charge)
                    ventas = JsonSerializer.Deserialize<List<VentaBase>>(File.ReadAllText("./Ventas.json"));
                 MessageBox.Show("Base de datos cargada :)");
            } 
            /*En caso de alguna excepcion, esta se muestra en un messageBox para su correccion*/
            catch(Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }
        /// <summary>
        /// Actualiza la DB con los datos de la lista interna RegistroDB.productos
        /// </summary>
        /// <param name="name">Nombre de la DB a actualizar</param>
        /// <param name="DB">Nombre de la lista interna que se escribirá en la DB</param>
        public static void Actualiza(bool act) {
            try {
                /*Conexion a la DB e insercion del header y productos en la DB*/
                File.WriteAllText("./Inventario.json", JsonSerializer.Serialize(productos));
                if(act)
                    File.WriteAllText("./Ventas.json", JsonSerializer.Serialize(ventas));
            }
            /*En caso de alguna excepcion, esta se muestra en un messageBox para su correccion*/
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
