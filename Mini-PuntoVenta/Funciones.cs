﻿using System;
using System.ComponentModel;
using System.Windows.Forms;
using System.Drawing;
using Mini_PuntoVenta;

/// <summary>
/// Configuraciones genericas.
/// </summary>
public class Funciones {
    /// <summary>
        /// <para> Establece el tamaño de la ventana, y su icono
        /// Ademas de dejar la ventana estática para evitar su redimension. </para>
        /// </summary>
        /// <param name="Lienzo"> Pasa la form actual, se recomienda usar this </param>
        /// <param name="x">Ingresa la dimension X deseada de la ventana </param>
        /// <param name="y">Ingresa la dimension Y deseada de la ventana </param>
        /// <param name="Titulo">Ingresa el nombre deseado de la ventana</param>
        /// <param name="nombre">Ingresa el nombre del icono de la ventana, nota: agregar en archivo recursos</param>
    public static void Diseno(Form Lienzo,int x,int y,String Titulo,String nombre) {
        Lienzo.Size = new Size(x, y);
        ComponentResourceManager imgs = new ComponentResourceManager(typeof(Mini_PuntoVenta.recursos));
        Lienzo.Icon = imgs.GetObject(nombre) as Icon;
        Lienzo.Text = Titulo;

        Lienzo.FormBorderStyle = FormBorderStyle.Fixed3D;
        Lienzo.MaximizeBox = false;
        Lienzo.MinimizeBox = false;

        Lienzo.StartPosition = FormStartPosition.CenterScreen;
        Lienzo.FormClosed += new FormClosedEventHandler(Cerrar);
    }
    public static void Cerrar(object sender, EventArgs e) {
        RegistroDB.productos = null;
        RegistroDB.ventas = null;
        Application.Exit();
    }
}