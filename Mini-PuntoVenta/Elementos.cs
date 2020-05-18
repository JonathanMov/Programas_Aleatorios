using System;
using System.Drawing;
using System.Windows.Forms;

namespace Mini_PuntoVenta {
    partial class Inventario {
        TextBox code,product,price,cantidad;
        RichTextBox description;
        Label _code,_product,_description,_price,_cantidad;
        Button registrar,actualizar;
        void iniciaComponentes() {
            //Boton de registo
            this.registrar = new Button();
            this.registrar.Text = "Registrar\nProducto";
            this.registrar.Size = new Size(60, 60);
            this.registrar.Location = new Point(285, 50);
            this.registrar.Click += new EventHandler(click_Reg);
            Controls.Add(this.registrar);

            //Boton de actualizar
            this.actualizar = new Button();
            this.actualizar.Text = "Actualiza\nProducto";
            this.actualizar.Size = new Size(60, 60);
            this.actualizar.Location = new Point(this.registrar.Location.X, this.registrar.Location.Y+this.registrar.Size.Height+20);
            this.actualizar.Click += new EventHandler(click_Act);
            Controls.Add(this.actualizar);

            //Ingresar Codigo
            this._code = new Label();
            this._code.Text = "Codigo";
            this._code.AutoSize = true;
            this._code.Location = new Point(20, 40);
            Controls.Add(this._code);

            this.code = new TextBox();
            this.code.Size = new Size(50, this.code.Size.Height);
            this.code.Location = new Point(this._code.Location.X, this._code.Location.Y+this._code.Size.Height+10);
            this.code.KeyPress += new KeyPressEventHandler(reg_Act);
            Controls.Add(this.code);

            //Ingresar nombre de producto
            this._product = new Label();
            this._product.Text = "Nombre del producto";
            this._product.AutoSize = true;
            this._product.Location = new Point(this.code.Location.X+this.code.Size.Width+10, this._code.Location.Y);
            Controls.Add(this._product);

            this.product = new TextBox();
            this.product.Location = new Point(this._product.Location.X, this._product.Location.Y+ this._product.Size.Height+10);
            this.product.Size = new Size(175, this.product.Size.Height);
            Controls.Add(this.product);

            //Ingresar descripcion de producto
            this._description = new Label();
            this._description.Text = "Descripcion del producto";
            this._description.AutoSize = true;
            this._description.Location = new Point(this.code.Location.X, this.code.Location.Y + this.code.Size.Height + 10);
            Controls.Add(this._description);

            this.description = new RichTextBox();
            this.description.Location = new Point(this._description.Location.X, this._description.Location.Y + this._description.Size.Height + 10);
            this.description.Size = new Size(235, this.description.Size.Height/2);
            Controls.Add(this.description);

            //Ingresar precio
            this._price = new Label();
            this._price.Text = "Precio del producto";
            this._price.AutoSize = true;
            this._price.Location = new Point(this.code.Location.X, this.description.Location.Y + this.description.Size.Height + 10);
            Controls.Add(this._price);

            this.price = new TextBox();
            this.price.Location = new Point(this._price.Location.X, this._price.Location.Y + this._price.Size.Height + 10);
            Controls.Add(this.price);

            //Ingresar cantidad
            this._cantidad = new Label();
            this._cantidad.Text = "Cantidad del producto";
            this._cantidad.AutoSize = true;
            this._cantidad.Location = new Point(this.price.Location.X + this.price.Size.Width + 30, this._price.Location.Y);
            Controls.Add(this._cantidad);

            this.cantidad = new TextBox();
            this.cantidad.Location = new Point(this._cantidad.Location.X, this._cantidad.Location.Y + this._cantidad.Size.Height + 10);
            this.cantidad.Size = new Size(105, this.cantidad.Size.Height);
            Controls.Add(this.cantidad);

            foreach (Control caja in Controls)
                if (caja is TextBox || caja is RichTextBox || caja is Button)
                    if (caja != this.code)
                        caja.Enabled = false;
                    else if (caja is Button)
                        caja.Enabled = false;
        }
    }
}
