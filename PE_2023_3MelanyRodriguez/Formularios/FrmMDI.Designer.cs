namespace PE_2023_3MelanyRodriguez.Formularios
{
    partial class FrmMDI
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
            this.MnuPrincipal = new System.Windows.Forms.MenuStrip();
            this.MnuGestiones = new System.Windows.Forms.ToolStripMenuItem();
            this.gESTIONDEUSUARIOSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gESTIONDEPROOVEDORESToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gESTIONDEPRODUCTOSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.rOLUSUARIOToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tipoDeProovedorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tipoDeVentaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuProcesos = new System.Windows.Forms.ToolStripMenuItem();
            this.rEToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuReportes = new System.Windows.Forms.ToolStripMenuItem();
            this.ventasPorFecToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ventasPorProovedoresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ventasPorProductosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listadoDeInventarioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.reimpresionDeVentasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuSalir = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.LblUsuario = new System.Windows.Forms.ToolStripStatusLabel();
            this.MnuPrincipal.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // MnuPrincipal
            // 
            this.MnuPrincipal.BackColor = System.Drawing.Color.Pink;
            this.MnuPrincipal.Font = new System.Drawing.Font("Segoe UI Emoji", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MnuPrincipal.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.MnuPrincipal.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MnuGestiones,
            this.MnuProcesos,
            this.MnuReportes,
            this.MnuSalir});
            this.MnuPrincipal.Location = new System.Drawing.Point(0, 0);
            this.MnuPrincipal.Name = "MnuPrincipal";
            this.MnuPrincipal.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.MnuPrincipal.Size = new System.Drawing.Size(800, 29);
            this.MnuPrincipal.TabIndex = 1;
            this.MnuPrincipal.Text = "menuStrip1";
            // 
            // MnuGestiones
            // 
            this.MnuGestiones.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gESTIONDEUSUARIOSToolStripMenuItem,
            this.gESTIONDEPROOVEDORESToolStripMenuItem,
            this.gESTIONDEPRODUCTOSToolStripMenuItem,
            this.toolStripSeparator1,
            this.rOLUSUARIOToolStripMenuItem,
            this.tipoDeProovedorToolStripMenuItem,
            this.tipoDeVentaToolStripMenuItem,
            this.cateToolStripMenuItem});
            this.MnuGestiones.ForeColor = System.Drawing.Color.Blue;
            this.MnuGestiones.Name = "MnuGestiones";
            this.MnuGestiones.Size = new System.Drawing.Size(103, 25);
            this.MnuGestiones.Text = "GESTIONES";
            // 
            // gESTIONDEUSUARIOSToolStripMenuItem
            // 
            this.gESTIONDEUSUARIOSToolStripMenuItem.Name = "gESTIONDEUSUARIOSToolStripMenuItem";
            this.gESTIONDEUSUARIOSToolStripMenuItem.Size = new System.Drawing.Size(282, 26);
            this.gESTIONDEUSUARIOSToolStripMenuItem.Text = "GESTION DE USUARIOS";
            this.gESTIONDEUSUARIOSToolStripMenuItem.Click += new System.EventHandler(this.gESTIONDEUSUARIOSToolStripMenuItem_Click);
            // 
            // gESTIONDEPROOVEDORESToolStripMenuItem
            // 
            this.gESTIONDEPROOVEDORESToolStripMenuItem.Name = "gESTIONDEPROOVEDORESToolStripMenuItem";
            this.gESTIONDEPROOVEDORESToolStripMenuItem.Size = new System.Drawing.Size(282, 26);
            this.gESTIONDEPROOVEDORESToolStripMenuItem.Text = "GESTION DE PROOVEDORES";
            this.gESTIONDEPROOVEDORESToolStripMenuItem.Click += new System.EventHandler(this.gESTIONDEPROOVEDORESToolStripMenuItem_Click);
            // 
            // gESTIONDEPRODUCTOSToolStripMenuItem
            // 
            this.gESTIONDEPRODUCTOSToolStripMenuItem.Name = "gESTIONDEPRODUCTOSToolStripMenuItem";
            this.gESTIONDEPRODUCTOSToolStripMenuItem.Size = new System.Drawing.Size(282, 26);
            this.gESTIONDEPRODUCTOSToolStripMenuItem.Text = "GESTION DE PRODUCTOS";
            this.gESTIONDEPRODUCTOSToolStripMenuItem.Click += new System.EventHandler(this.gESTIONDEPRODUCTOSToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(279, 6);
            // 
            // rOLUSUARIOToolStripMenuItem
            // 
            this.rOLUSUARIOToolStripMenuItem.Name = "rOLUSUARIOToolStripMenuItem";
            this.rOLUSUARIOToolStripMenuItem.Size = new System.Drawing.Size(282, 26);
            this.rOLUSUARIOToolStripMenuItem.Text = "Rol de Usuario";
            // 
            // tipoDeProovedorToolStripMenuItem
            // 
            this.tipoDeProovedorToolStripMenuItem.Name = "tipoDeProovedorToolStripMenuItem";
            this.tipoDeProovedorToolStripMenuItem.Size = new System.Drawing.Size(282, 26);
            this.tipoDeProovedorToolStripMenuItem.Text = "Tipo de proovedor";
            // 
            // tipoDeVentaToolStripMenuItem
            // 
            this.tipoDeVentaToolStripMenuItem.Name = "tipoDeVentaToolStripMenuItem";
            this.tipoDeVentaToolStripMenuItem.Size = new System.Drawing.Size(282, 26);
            this.tipoDeVentaToolStripMenuItem.Text = "Tipo de Venta";
            // 
            // cateToolStripMenuItem
            // 
            this.cateToolStripMenuItem.Name = "cateToolStripMenuItem";
            this.cateToolStripMenuItem.Size = new System.Drawing.Size(282, 26);
            this.cateToolStripMenuItem.Text = "Categoria de Productos";
            // 
            // MnuProcesos
            // 
            this.MnuProcesos.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rEToolStripMenuItem});
            this.MnuProcesos.ForeColor = System.Drawing.Color.Blue;
            this.MnuProcesos.Name = "MnuProcesos";
            this.MnuProcesos.Size = new System.Drawing.Size(101, 25);
            this.MnuProcesos.Text = "PROCESOS";
            // 
            // rEToolStripMenuItem
            // 
            this.rEToolStripMenuItem.Name = "rEToolStripMenuItem";
            this.rEToolStripMenuItem.Size = new System.Drawing.Size(236, 26);
            this.rEToolStripMenuItem.Text = "REGISTRO DE VENTAS";
            this.rEToolStripMenuItem.Click += new System.EventHandler(this.rEToolStripMenuItem_Click);
            // 
            // MnuReportes
            // 
            this.MnuReportes.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ventasPorFecToolStripMenuItem,
            this.ventasPorProovedoresToolStripMenuItem,
            this.ventasPorProductosToolStripMenuItem,
            this.listadoDeInventarioToolStripMenuItem,
            this.toolStripSeparator2,
            this.reimpresionDeVentasToolStripMenuItem});
            this.MnuReportes.ForeColor = System.Drawing.Color.Blue;
            this.MnuReportes.Name = "MnuReportes";
            this.MnuReportes.Size = new System.Drawing.Size(96, 25);
            this.MnuReportes.Text = "REPORTES";
            // 
            // ventasPorFecToolStripMenuItem
            // 
            this.ventasPorFecToolStripMenuItem.Name = "ventasPorFecToolStripMenuItem";
            this.ventasPorFecToolStripMenuItem.Size = new System.Drawing.Size(247, 26);
            this.ventasPorFecToolStripMenuItem.Text = "Ventas por Fecha";
            // 
            // ventasPorProovedoresToolStripMenuItem
            // 
            this.ventasPorProovedoresToolStripMenuItem.Name = "ventasPorProovedoresToolStripMenuItem";
            this.ventasPorProovedoresToolStripMenuItem.Size = new System.Drawing.Size(247, 26);
            this.ventasPorProovedoresToolStripMenuItem.Text = "Ventas por Proovedores";
            // 
            // ventasPorProductosToolStripMenuItem
            // 
            this.ventasPorProductosToolStripMenuItem.Name = "ventasPorProductosToolStripMenuItem";
            this.ventasPorProductosToolStripMenuItem.Size = new System.Drawing.Size(247, 26);
            this.ventasPorProductosToolStripMenuItem.Text = "Ventas por Productos";
            // 
            // listadoDeInventarioToolStripMenuItem
            // 
            this.listadoDeInventarioToolStripMenuItem.Name = "listadoDeInventarioToolStripMenuItem";
            this.listadoDeInventarioToolStripMenuItem.Size = new System.Drawing.Size(247, 26);
            this.listadoDeInventarioToolStripMenuItem.Text = "Listado de Inventario";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(244, 6);
            // 
            // reimpresionDeVentasToolStripMenuItem
            // 
            this.reimpresionDeVentasToolStripMenuItem.Name = "reimpresionDeVentasToolStripMenuItem";
            this.reimpresionDeVentasToolStripMenuItem.Size = new System.Drawing.Size(247, 26);
            this.reimpresionDeVentasToolStripMenuItem.Text = "Reimpresion de Ventas";
            // 
            // MnuSalir
            // 
            this.MnuSalir.ForeColor = System.Drawing.Color.Blue;
            this.MnuSalir.Name = "MnuSalir";
            this.MnuSalir.Size = new System.Drawing.Size(63, 25);
            this.MnuSalir.Text = "SALIR";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.LblUsuario});
            this.statusStrip1.Location = new System.Drawing.Point(0, 428);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(800, 22);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(59, 17);
            this.toolStripStatusLabel1.Text = "USUARIO:";
            // 
            // LblUsuario
            // 
            this.LblUsuario.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblUsuario.Name = "LblUsuario";
            this.LblUsuario.Size = new System.Drawing.Size(47, 17);
            this.LblUsuario.Text = "usuario";
            // 
            // FrmMDI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Fuchsia;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.MnuPrincipal);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.MnuPrincipal;
            this.Name = "FrmMDI";
            this.Text = "SISTEMA DE VENTAS DE PRODUCTOS PARA LA DISTRIBUIDORA DE DON BOSCO";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmMDI_FormClosed);
            this.Load += new System.EventHandler(this.FrmMDI_Load);
            this.MnuPrincipal.ResumeLayout(false);
            this.MnuPrincipal.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip MnuPrincipal;
        private System.Windows.Forms.ToolStripMenuItem MnuGestiones;
        private System.Windows.Forms.ToolStripMenuItem MnuProcesos;
        private System.Windows.Forms.ToolStripMenuItem MnuReportes;
        private System.Windows.Forms.ToolStripMenuItem MnuSalir;
        private System.Windows.Forms.ToolStripMenuItem gESTIONDEUSUARIOSToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gESTIONDEPROOVEDORESToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gESTIONDEPRODUCTOSToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem rOLUSUARIOToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tipoDeProovedorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tipoDeVentaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rEToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ventasPorFecToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ventasPorProovedoresToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ventasPorProductosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem listadoDeInventarioToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem reimpresionDeVentasToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel LblUsuario;
    }
}