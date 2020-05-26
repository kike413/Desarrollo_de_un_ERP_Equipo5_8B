namespace Presentacion
{
    partial class ProductosProveedorGUI
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle22 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle23 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle24 = new System.Windows.Forms.DataGridViewCellStyle();
            this.txtPrecioUCompra = new System.Windows.Forms.TextBox();
            this.PrecioUltimaCompra = new System.Windows.Forms.Label();
            this.txtCantMinima = new System.Windows.Forms.TextBox();
            this.CantMinima = new System.Windows.Forms.Label();
            this.txtPrecioEstandar = new System.Windows.Forms.TextBox();
            this.PrecioEstandar = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.DiasRetardo = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Regresar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.txtCantMaxima = new System.Windows.Forms.TextBox();
            this.CantMaxima = new System.Windows.Forms.Label();
            this.avanza = new System.Windows.Forms.Button();
            this.retroceder = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.error = new System.Windows.Forms.ErrorProvider(this.components);
            this.txtDiasRetardo = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.error)).BeginInit();
            this.SuspendLayout();
            // 
            // txtPrecioUCompra
            // 
            this.txtPrecioUCompra.Location = new System.Drawing.Point(651, 152);
            this.txtPrecioUCompra.Name = "txtPrecioUCompra";
            this.txtPrecioUCompra.Size = new System.Drawing.Size(138, 20);
            this.txtPrecioUCompra.TabIndex = 41;
            this.txtPrecioUCompra.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPrecioUCompra_KeyPress);
            // 
            // PrecioUltimaCompra
            // 
            this.PrecioUltimaCompra.AutoSize = true;
            this.PrecioUltimaCompra.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PrecioUltimaCompra.ForeColor = System.Drawing.Color.White;
            this.PrecioUltimaCompra.Location = new System.Drawing.Point(556, 153);
            this.PrecioUltimaCompra.Name = "PrecioUltimaCompra";
            this.PrecioUltimaCompra.Size = new System.Drawing.Size(100, 16);
            this.PrecioUltimaCompra.TabIndex = 40;
            this.PrecioUltimaCompra.Text = "Precio U.Compra:";
            // 
            // txtCantMinima
            // 
            this.txtCantMinima.Location = new System.Drawing.Point(652, 190);
            this.txtCantMinima.Name = "txtCantMinima";
            this.txtCantMinima.Size = new System.Drawing.Size(138, 20);
            this.txtCantMinima.TabIndex = 39;
            this.txtCantMinima.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCantMinima_KeyPress);
            // 
            // CantMinima
            // 
            this.CantMinima.AutoSize = true;
            this.CantMinima.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CantMinima.ForeColor = System.Drawing.Color.White;
            this.CantMinima.Location = new System.Drawing.Point(556, 191);
            this.CantMinima.Name = "CantMinima";
            this.CantMinima.Size = new System.Drawing.Size(80, 16);
            this.CantMinima.TabIndex = 38;
            this.CantMinima.Text = "Cant. Minima:";
            // 
            // txtPrecioEstandar
            // 
            this.txtPrecioEstandar.Location = new System.Drawing.Point(651, 117);
            this.txtPrecioEstandar.Name = "txtPrecioEstandar";
            this.txtPrecioEstandar.Size = new System.Drawing.Size(138, 20);
            this.txtPrecioEstandar.TabIndex = 37;
            this.txtPrecioEstandar.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPrecioEstandar_KeyPress);
            // 
            // PrecioEstandar
            // 
            this.PrecioEstandar.AutoSize = true;
            this.PrecioEstandar.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PrecioEstandar.ForeColor = System.Drawing.Color.White;
            this.PrecioEstandar.Location = new System.Drawing.Point(556, 118);
            this.PrecioEstandar.Name = "PrecioEstandar";
            this.PrecioEstandar.Size = new System.Drawing.Size(95, 16);
            this.PrecioEstandar.TabIndex = 35;
            this.PrecioEstandar.Text = "Precio Estandar:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(619, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(141, 16);
            this.label2.TabIndex = 31;
            this.label2.Text = "Productos Proveedor";
            // 
            // DiasRetardo
            // 
            this.DiasRetardo.AutoSize = true;
            this.DiasRetardo.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DiasRetardo.ForeColor = System.Drawing.Color.White;
            this.DiasRetardo.Location = new System.Drawing.Point(556, 73);
            this.DiasRetardo.Name = "DiasRetardo";
            this.DiasRetardo.Size = new System.Drawing.Size(96, 16);
            this.DiasRetardo.TabIndex = 29;
            this.DiasRetardo.Text = "Dias de Retardo:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(73, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(191, 16);
            this.label1.TabIndex = 33;
            this.label1.Text = "Listado Productos Proveedor";
            // 
            // Regresar
            // 
            this.Regresar.BackColor = System.Drawing.Color.Crimson;
            this.Regresar.FlatAppearance.BorderSize = 0;
            this.Regresar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.Regresar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Regresar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Regresar.Font = new System.Drawing.Font("Javanese Text", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Regresar.ForeColor = System.Drawing.Color.LightGray;
            this.Regresar.Location = new System.Drawing.Point(652, 335);
            this.Regresar.Name = "Regresar";
            this.Regresar.Size = new System.Drawing.Size(108, 31);
            this.Regresar.TabIndex = 34;
            this.Regresar.Text = "Regresar";
            this.Regresar.UseVisualStyleBackColor = false;
            this.Regresar.Click += new System.EventHandler(this.Regresar_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnGuardar.FlatAppearance.BorderSize = 0;
            this.btnGuardar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.SkyBlue;
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardar.ForeColor = System.Drawing.Color.White;
            this.btnGuardar.Location = new System.Drawing.Point(652, 282);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(118, 24);
            this.btnGuardar.TabIndex = 30;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(66)))), ((int)(((byte)(91)))));
            this.dataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle22.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle22.BackColor = System.Drawing.SystemColors.HotTrack;
            dataGridViewCellStyle22.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle22.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle22.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle22.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle22.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle22;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.EnableHeadersVisualStyles = false;
            this.dataGridView1.GridColor = System.Drawing.Color.SteelBlue;
            this.dataGridView1.Location = new System.Drawing.Point(12, 73);
            this.dataGridView1.Name = "dataGridView1";
            dataGridViewCellStyle23.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle23.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(66)))), ((int)(((byte)(91)))));
            dataGridViewCellStyle23.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle23.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle23.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle23.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle23.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle23;
            this.dataGridView1.RowHeadersVisible = false;
            dataGridViewCellStyle24.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(66)))), ((int)(((byte)(91)))));
            dataGridViewCellStyle24.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle24.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle24.SelectionBackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle24.SelectionForeColor = System.Drawing.Color.White;
            this.dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle24;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(517, 211);
            this.dataGridView1.TabIndex = 32;
            // 
            // txtCantMaxima
            // 
            this.txtCantMaxima.Location = new System.Drawing.Point(652, 227);
            this.txtCantMaxima.Name = "txtCantMaxima";
            this.txtCantMaxima.Size = new System.Drawing.Size(138, 20);
            this.txtCantMaxima.TabIndex = 43;
            this.txtCantMaxima.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCantMaxima_KeyPress);
            // 
            // CantMaxima
            // 
            this.CantMaxima.AutoSize = true;
            this.CantMaxima.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CantMaxima.ForeColor = System.Drawing.Color.White;
            this.CantMaxima.Location = new System.Drawing.Point(556, 228);
            this.CantMaxima.Name = "CantMaxima";
            this.CantMaxima.Size = new System.Drawing.Size(82, 16);
            this.CantMaxima.TabIndex = 42;
            this.CantMaxima.Text = "Cant. Maxima:";
            // 
            // avanza
            // 
            this.avanza.BackColor = System.Drawing.Color.RoyalBlue;
            this.avanza.FlatAppearance.BorderSize = 0;
            this.avanza.FlatAppearance.MouseDownBackColor = System.Drawing.Color.SkyBlue;
            this.avanza.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.avanza.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.avanza.ForeColor = System.Drawing.Color.White;
            this.avanza.Location = new System.Drawing.Point(487, 290);
            this.avanza.Name = "avanza";
            this.avanza.Size = new System.Drawing.Size(38, 23);
            this.avanza.TabIndex = 47;
            this.avanza.Text = ">";
            this.avanza.UseVisualStyleBackColor = false;
            this.avanza.Click += new System.EventHandler(this.avanza_Click);
            // 
            // retroceder
            // 
            this.retroceder.BackColor = System.Drawing.Color.RoyalBlue;
            this.retroceder.FlatAppearance.BorderSize = 0;
            this.retroceder.FlatAppearance.MouseDownBackColor = System.Drawing.Color.SkyBlue;
            this.retroceder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.retroceder.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.retroceder.ForeColor = System.Drawing.Color.White;
            this.retroceder.Location = new System.Drawing.Point(24, 290);
            this.retroceder.Name = "retroceder";
            this.retroceder.Size = new System.Drawing.Size(38, 23);
            this.retroceder.TabIndex = 46;
            this.retroceder.Text = "<";
            this.retroceder.UseVisualStyleBackColor = false;
            this.retroceder.Click += new System.EventHandler(this.retroceder_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.BackColor = System.Drawing.Color.Crimson;
            this.btnEliminar.FlatAppearance.BorderSize = 0;
            this.btnEliminar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.SkyBlue;
            this.btnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminar.ForeColor = System.Drawing.Color.White;
            this.btnEliminar.Location = new System.Drawing.Point(133, 356);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(75, 23);
            this.btnEliminar.TabIndex = 45;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnEditar.FlatAppearance.BorderSize = 0;
            this.btnEditar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.SkyBlue;
            this.btnEditar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditar.ForeColor = System.Drawing.Color.White;
            this.btnEditar.Location = new System.Drawing.Point(18, 356);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(75, 23);
            this.btnEditar.TabIndex = 44;
            this.btnEditar.Text = "Editar";
            this.btnEditar.UseVisualStyleBackColor = false;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // error
            // 
            this.error.ContainerControl = this;
            // 
            // txtDiasRetardo
            // 
            this.txtDiasRetardo.Location = new System.Drawing.Point(651, 73);
            this.txtDiasRetardo.Name = "txtDiasRetardo";
            this.txtDiasRetardo.Size = new System.Drawing.Size(138, 20);
            this.txtDiasRetardo.TabIndex = 48;
            this.txtDiasRetardo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDiasRetardo_KeyPress);
            // 
            // ProductosProveedorGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(66)))), ((int)(((byte)(92)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txtDiasRetardo);
            this.Controls.Add(this.avanza);
            this.Controls.Add(this.retroceder);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.txtCantMaxima);
            this.Controls.Add(this.CantMaxima);
            this.Controls.Add(this.txtPrecioUCompra);
            this.Controls.Add(this.PrecioUltimaCompra);
            this.Controls.Add(this.txtCantMinima);
            this.Controls.Add(this.CantMinima);
            this.Controls.Add(this.txtPrecioEstandar);
            this.Controls.Add(this.PrecioEstandar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.DiasRetardo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Regresar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.dataGridView1);
            this.Name = "ProductosProveedorGUI";
            this.Text = "ProductosProveedorGUI";
            this.Load += new System.EventHandler(this.ProductosProveedorGUI_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.error)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtPrecioUCompra;
        private System.Windows.Forms.Label PrecioUltimaCompra;
        private System.Windows.Forms.TextBox txtCantMinima;
        private System.Windows.Forms.Label CantMinima;
        private System.Windows.Forms.TextBox txtPrecioEstandar;
        private System.Windows.Forms.Label PrecioEstandar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label DiasRetardo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Regresar;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox txtCantMaxima;
        private System.Windows.Forms.Label CantMaxima;
        private System.Windows.Forms.Button avanza;
        private System.Windows.Forms.Button retroceder;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.ErrorProvider error;
        private System.Windows.Forms.TextBox txtDiasRetardo;
    }
}