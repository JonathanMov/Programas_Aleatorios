using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace Mini_PuntoVenta {
    /// <summary>
    /// Conexion a la base de datos.
    /// </summary>
    class RegistroDB {
        ///<summary>
        ///Lista "interna" donde se almacenan los productos de la DB
        ///</summary>
        public static List<Producto> productos;
        /// <summary>
        /// Lee la DB y la almacena en la lista "interna".
        /// </summary>
        /// <param name="name">Nombre de la DB</param>
        public static void Leer(string name) {
            StreamReader textIn=null;
            productos = new List<Producto>();
            /*Se crea la conexion a la DB y se lee la primer línea que son los encabezados, esta no se guarda porque no es un producto*/
            try {
                textIn = new StreamReader(new FileStream("./"+name+".txt",FileMode.Open,FileAccess.Read));
                textIn.ReadLine();
                
                while (textIn.Peek() != -1){
                    string[] columns = textIn.ReadLine().Split('|');
                    Producto prod = new Producto(columns[0],columns[1],Convert.ToDouble(columns[3]),Convert.ToInt32(columns[4]));
                    prod.description = columns[2];
                    productos.Add(prod);
                }
            }
            /*En caso de alguna excepcion, esta se muestra en un messageBox para su correccion*/
            catch(Exception ex) {
                MessageBox.Show(ex.Message);
            }
            /*En caso que se haya abierto la conexion esta se cierra*/
            finally {
                if (textIn != null)
                    textIn.Close();
            }
        }
        /// <summary>
        /// Inserta una línea con los datos proporcionados a la DB deseada
        /// </summary>
        /// <param name="anade">Línea de texto que se añadira a la DB</param>
        /// <param name="name">Nombre de la DB a modificar</param>
        public static void Agregar(string anade,string name) {
            StreamWriter textOut=null;
            try {
                /*Conexion a la DB e insercion de la linea proporcionada*/
                textOut = new StreamWriter(new FileStream("./" + name + ".txt", FileMode.Append, FileAccess.Write));
                textOut.WriteLine(anade);
            }
            /*En caso de alguna excepcion, esta se muestra en un messageBox para su correccion*/
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
            /*En caso que se haya abierto la conexion esta se cierra*/
            finally {
                if (textOut != null)
                    textOut.Close();
            }
        }
        /// <summary>
        /// Actualiza la DB con los datos de la lista interna RegistroDB.productos
        /// </summary>
        /// <param name="name">Nombre de la DB a actualizar</param>
        public static void Actualiza(string name) {
            StreamWriter textOut=null;
            try {
                /*Conexion a la DB e insercion del header y productos en la DB*/
                textOut = new StreamWriter(new FileStream("./" + name + ".txt", FileMode.Create, FileAccess.Write));
                textOut.WriteLine("Code | Product | Description | Price | Cantidad");
                foreach (Producto cat in productos)
                    textOut.WriteLine(cat.ToString());
            }
            /*En caso de alguna excepcion, esta se muestra en un messageBox para su correccion*/
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
            /*En caso que se haya abierto la conexion esta se cierra*/
            finally {
                if (textOut != null)
                    textOut.Close();
            }
        }
    }
}
