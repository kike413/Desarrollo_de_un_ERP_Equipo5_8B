namespace Presentacion
{
    partial class PrincipalGUI
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.EstadoCivil = new System.Windows.Forms.Label();
            this.Nombre = new System.Windows.Forms.Label();
            this.Cargo = new System.Windows.Forms.Label();
            this.Colores = new System.Windows.Forms.Button();
            this.Productos = new System.Windows.Forms.Button();
            this.Estilos = new System.Windows.Forms.Button();
            this.Marcas = new System.Windows.Forms.Button();
            this.Categorias = new System.Windows.Forms.Button();
            this.Pedidos = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            this.brnCerrarSesion = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.Colores);
            this.panel1.Controls.Add(this.Productos);
            this.panel1.Controls.Add(this.Estilos);
            this.panel1.Controls.Add(this.Marcas);
            this.panel1.Controls.Add(this.Categorias);
            this.panel1.Controls.Add(this.Pedidos);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 450);
            this.panel1.TabIndex = 15;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Gray;
            this.panel3.Controls.Add(this.EstadoCivil);
            this.panel3.Controls.Add(this.Nombre);
            this.panel3.Controls.Add(this.Cargo);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(600, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(200, 450);
            this.panel3.TabIndex = 16;
            // 
            // EstadoCivil
            // 
            this.EstadoCivil.AutoSize = true;
            this.EstadoCivil.Location = new System.Drawing.Point(3, 77);
            this.EstadoCivil.Name = "EstadoCivil";
            this.EstadoCivil.Size = new System.Drawing.Size(59, 13);
            this.EstadoCivil.TabIndex = 2;
            this.EstadoCivil.Text = "EstadoCivil";
            // 
            // Nombre
            // 
            this.Nombre.AutoSize = true;
            this.Nombre.Location = new System.Drawing.Point(3, 50);
            this.Nombre.Name = "Nombre";
            this.Nombre.Size = new System.Drawing.Size(44, 13);
            this.Nombre.TabIndex = 1;
            this.Nombre.Text = "Nombre";
            // 
            // Cargo
            // 
            this.Cargo.AutoSize = true;
            this.Cargo.Location = new System.Drawing.Point(3, 26);
            this.Cargo.Name = "Cargo";
            this.Cargo.Size = new System.Drawing.Size(35, 13);
            this.Cargo.TabIndex = 0;
            this.Cargo.Text = "Cargo";
            // 
            // Colores
            // 
            this.Colores.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.Colores.FlatAppearance.BorderSize = 0;
            this.Colores.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.Colores.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Colores.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Colores.ForeColor = System.Drawing.Color.LightGray;
            this.Colores.Location = new System.Drawing.Point(419, 12);
            this.Colores.Name = "Colores";
            this.Colores.Size = new System.Drawing.Size(77, 40);
            this.Colores.TabIndex = 15;
            this.Colores.Text = "Colores";
            this.Colores.UseVisualStyleBackColor = false;
            this.Colores.Click += new System.EventHandler(this.Colores_Click_1);
            // 
            // Productos
            // 
            this.Productos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.Productos.FlatAppearance.BorderSize = 0;
            this.Productos.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.Productos.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Productos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Productos.ForeColor = System.Drawing.Color.LightGray;
            this.Productos.Location = new System.Drawing.Point(3, 12);
            this.Productos.Name = "Productos";
            this.Productos.Size = new System.Drawing.Size(77, 40);
            this.Productos.TabIndex = 15;
            this.Productos.Text = "Productos";
            this.Productos.UseVisualStyleBackColor = false;
            // 
            // Estilos
            // 
            this.Estilos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.Estilos.FlatAppearance.BorderSize = 0;
            this.Estilos.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.Estilos.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Estilos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Estilos.ForeColor = System.Drawing.Color.LightGray;
            this.Estilos.Location = new System.Drawing.Point(253, 12);
            this.Estilos.Name = "Estilos";
            this.Estilos.Size = new System.Drawing.Size(77, 40);
            this.Estilos.TabIndex = 15;
            this.Estilos.Text = "Estilos";
            this.Estilos.UseVisualStyleBackColor = false;
            this.Estilos.Click += new System.EventHandler(this.Estilos_Click_1);
            // 
            // Marcas
            // 
            this.Marcas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.Marcas.FlatAppearance.BorderSize = 0;
            this.Marcas.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.Marcas.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Marcas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Marcas.ForeColor = System.Drawing.Color.LightGray;
            this.Marcas.Location = new System.Drawing.Point(170, 12);
            this.Marcas.Name = "Marcas";
            this.Marcas.Size = new System.Drawing.Size(77, 40);
            this.Marcas.TabIndex = 15;
            this.Marcas.Text = "Marcas";
            this.Marcas.UseVisualStyleBackColor = false;
            this.Marcas.Click += new System.EventHandler(this.Marcas_Click_1);
            // 
            // Categorias
            // 
            this.Categorias.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.Categorias.FlatAppearance.BorderSize = 0;
            this.Categorias.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.Categorias.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Categorias.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Categorias.ForeColor = System.Drawing.Color.LightGray;
            this.Categorias.Location = new System.Drawing.Point(336, 12);
            this.Categorias.Name = "Categorias";
            this.Categorias.Size = new System.Drawing.Size(77, 40);
            this.Categorias.TabIndex = 15;
            this.Categorias.Text = "Categorias";
            this.Categorias.UseVisualStyleBackColor = false;
            this.Categorias.Click += new System.EventHandler(this.Categorias_Click_1);
            // 
            // Pedidos
            // 
            this.Pedidos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.Pedidos.FlatAppearance.BorderSize = 0;
            this.Pedidos.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.Pedidos.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Pedidos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Pedidos.ForeColor = System.Drawing.Color.LightGray;
            this.Pedidos.Location = new System.Drawing.Point(87, 12);
            this.Pedidos.Name = "Pedidos";
            this.Pedidos.Size = new System.Drawing.Size(77, 40);
            this.Pedidos.TabIndex = 15;
            this.Pedidos.Text = "Pedidos";
            this.Pedidos.UseVisualStyleBackColor = false;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(66)))), ((int)(((byte)(92)))));
            this.panel2.Controls.Add(this.brnCerrarSesion);
            this.panel2.Location = new System.Drawing.Point(1, 403);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(799, 48);
            this.panel2.TabIndex = 17;
            // 
            // brnCerrarSesion
            // 
            this.brnCerrarSesion.BackColor = System.Drawing.Color.Crimson;
            this.brnCerrarSesion.FlatAppearance.BorderSize = 0;
            this.brnCerrarSesion.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.brnCerrarSesion.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.brnCerrarSesion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.brnCerrarSesion.Font = new System.Drawing.Font("Javanese Text", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.brnCerrarSesion.ForeColor = System.Drawing.Color.LightGray;
            this.brnCerrarSesion.Location = new System.Drawing.Point(3, 5);
            this.brnCerrarSesion.Name = "brnCerrarSesion";
            this.brnCerrarSesion.Size = new System.Drawing.Size(110, 40);
            this.brnCerrarSesion.TabIndex = 17;
            this.brnCerrarSesion.Text = "Cerrar Sesion";
            this.brnCerrarSesion.UseVisualStyleBackColor = false;
            this.brnCerrarSesion.Click += new System.EventHandler(this.brnCerrarSesion_Click);
            // 
            // PrincipalGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "PrincipalGUI";
            this.Opacity = 0.9D;
            this.Text = "Principal";
            this.TransparencyKey = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.Load += new System.EventHandler(this.Principal_Load);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button Colores;
        private System.Windows.Forms.Button Productos;
        private System.Windows.Forms.Button Estilos;
        private System.Windows.Forms.Button Marcas;
        private System.Windows.Forms.Button Categorias;
        private System.Windows.Forms.Button Pedidos;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button brnCerrarSesion;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label Cargo;
        private System.Windows.Forms.Label EstadoCivil;
        private System.Windows.Forms.Label Nombre;
    }
}