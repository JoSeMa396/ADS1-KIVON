namespace WFASistemaHeladeriaKivon
{
    partial class IUOpcionesUsuario
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IUOpcionesUsuario));
            this.btnCerrarSesion = new System.Windows.Forms.Button();
            this.lblCabecera = new System.Windows.Forms.Label();
            this.mnsMenuPrincipal = new System.Windows.Forms.MenuStrip();
            this.usuariosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nuevoUsuarioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.administrarUsuarioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clientesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.administrarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.productosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pedidosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.mnsMenuPrincipal.SuspendLayout();
            this.SuspendLayout();
            //
            // btnCerrarSesion
            //
            this.btnCerrarSesion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCerrarSesion.Location = new System.Drawing.Point(891, 44);
            this.btnCerrarSesion.Name = "btnCerrarSesion";
            this.btnCerrarSesion.Size = new System.Drawing.Size(172, 23);
            this.btnCerrarSesion.TabIndex = 7;
            this.btnCerrarSesion.Text = "Cerrar Sesion";
            this.btnCerrarSesion.UseVisualStyleBackColor = true;
            this.btnCerrarSesion.Click += new System.EventHandler(this.btnCerrarSesion_Click);
            //
            // lblCabecera
            //
            this.lblCabecera.AutoSize = true;
            this.lblCabecera.BackColor = System.Drawing.Color.Transparent;
            this.lblCabecera.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCabecera.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblCabecera.Location = new System.Drawing.Point(12, 36);
            this.lblCabecera.Name = "lblCabecera";
            this.lblCabecera.Size = new System.Drawing.Size(86, 31);
            this.lblCabecera.TabIndex = 0;
            this.lblCabecera.Text = "label1";
            //
            // mnsMenuPrincipal
            //
            this.mnsMenuPrincipal.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.usuariosToolStripMenuItem,
            this.clientesToolStripMenuItem,
            this.productosToolStripMenuItem,
            this.pedidosToolStripMenuItem});
            this.mnsMenuPrincipal.Location = new System.Drawing.Point(0, 0);
            this.mnsMenuPrincipal.Name = "mnsMenuPrincipal";
            this.mnsMenuPrincipal.Size = new System.Drawing.Size(1084, 24);
            this.mnsMenuPrincipal.TabIndex = 8;
            this.mnsMenuPrincipal.Text = "menuStrip1";
            //
            // usuariosToolStripMenuItem
            //
            this.usuariosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuevoUsuarioToolStripMenuItem,
            this.administrarUsuarioToolStripMenuItem});
            this.usuariosToolStripMenuItem.Name = "usuariosToolStripMenuItem";
            this.usuariosToolStripMenuItem.Size = new System.Drawing.Size(64, 20);
            this.usuariosToolStripMenuItem.Text = "Usuarios";
            //
            // nuevoUsuarioToolStripMenuItem
            //
            this.nuevoUsuarioToolStripMenuItem.Name = "nuevoUsuarioToolStripMenuItem";
            this.nuevoUsuarioToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.nuevoUsuarioToolStripMenuItem.Text = "Nuevo usuario";
            this.nuevoUsuarioToolStripMenuItem.Click += new System.EventHandler(this.nuevoUsuarioToolStripMenuItem_Click);
            //
            // administrarUsuarioToolStripMenuItem
            //
            this.administrarUsuarioToolStripMenuItem.Name = "administrarUsuarioToolStripMenuItem";
            this.administrarUsuarioToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.administrarUsuarioToolStripMenuItem.Text = "Administrar usuario";
            this.administrarUsuarioToolStripMenuItem.Click += new System.EventHandler(this.administrarUsuarioToolStripMenuItem_Click);
            //
            // clientesToolStripMenuItem
            //
            this.clientesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.administrarToolStripMenuItem});
            this.clientesToolStripMenuItem.Name = "clientesToolStripMenuItem";
            this.clientesToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.clientesToolStripMenuItem.Text = "Clientes";
            //
            // administrarToolStripMenuItem
            //
            this.administrarToolStripMenuItem.Name = "administrarToolStripMenuItem";
            this.administrarToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.administrarToolStripMenuItem.Text = "Administrar cliente";
            this.administrarToolStripMenuItem.Click += new System.EventHandler(this.administrarToolStripMenuItem_Click);
            //
            // productosToolStripMenuItem
            //
            this.productosToolStripMenuItem.Name = "productosToolStripMenuItem";
            this.productosToolStripMenuItem.Size = new System.Drawing.Size(73, 20);
            this.productosToolStripMenuItem.Text = "Productos";
            //
            // pedidosToolStripMenuItem
            //
            this.pedidosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
            this.pedidosToolStripMenuItem.Name = "pedidosToolStripMenuItem";
            this.pedidosToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.pedidosToolStripMenuItem.Text = "Pedidos";
            //
            // toolStripMenuItem1
            //
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.toolStripMenuItem1.Text = "Nuevo pedido";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            //
            // IUOpcionesUsuario
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1084, 504);
            this.Controls.Add(this.lblCabecera);
            this.Controls.Add(this.btnCerrarSesion);
            this.Controls.Add(this.mnsMenuPrincipal);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MainMenuStrip = this.mnsMenuPrincipal;
            this.Name = "IUOpcionesUsuario";
            this.Text = "Menú Principal";
            this.Load += new System.EventHandler(this.IUOpcionesUsuario_Load);
            this.mnsMenuPrincipal.ResumeLayout(false);
            this.mnsMenuPrincipal.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblCabecera;
        private System.Windows.Forms.Button btnCerrarSesion;
        private System.Windows.Forms.MenuStrip mnsMenuPrincipal;
        private System.Windows.Forms.ToolStripMenuItem usuariosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nuevoUsuarioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem administrarUsuarioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clientesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem administrarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem productosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pedidosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
    }
}
