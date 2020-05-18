using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace Mini_PuntoVenta {
    class RegistroDB {
        public static List<Producto> productos;
        public static void Leer(string name) {
            StreamReader textIn=null;
            productos = new List<Producto>();
            try {
                textIn = new StreamReader(new FileStream("./"+name+".txt",FileMode.Open,FileAccess.Read));
                textIn.ReadLine();
                
                while (textIn.Peek() != -1){
                    string row = textIn.ReadLine();
                    string[] columns = row.Split('|');
                    foreach (var item in productos)
                        if (columns[0].Contains(item.code)) {
                            row = textIn.ReadLine();
                            columns = row.Split('|');
                        }
                    Producto prod = new Producto(columns[0],columns[1],Convert.ToDouble(columns[3]),Convert.ToInt32(columns[4]));
                    prod.description = columns[2];
                    productos.Add(prod);
                }
            }
            catch(Exception ex) {
                MessageBox.Show(ex.Message);
            }
            finally {
                if (textIn != null)
                    textIn.Close();
            }
        }
        public static void Agregar(string anade,string name) {
            StreamWriter textOut=null;
            try {
                textOut = new StreamWriter(new FileStream("./" + name + ".txt", FileMode.Append, FileAccess.Write));
                textOut.WriteLine(anade);
            }
            catch(Exception ex) {
                MessageBox.Show(ex.Message);
            }
            finally {
                if (textOut != null)
                    textOut.Close();
            }
        }
        public static void Actualiza(string name) {
            StreamWriter textOut=null;
            try {
                textOut = new StreamWriter(new FileStream("./" + name + ".txt", FileMode.Create, FileAccess.Write));
                textOut.WriteLine("Code | Product | Description | Price | Cantidad");
                foreach (Producto cat in productos)
                    textOut.WriteLine(cat.ToString());
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
            finally {
                if (textOut != null)
                    textOut.Close();
            }
        }
    }
}
