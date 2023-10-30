namespace PE_2023_3MelanyRodriguez.Formularios
{
    partial class FrmProovedorGestion
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
            this.label1 = new System.Windows.Forms.Label();
            this.TxtBuscar = new System.Windows.Forms.TextBox();
            this.CboxVerActivos = new System.Windows.Forms.CheckBox();
            this.DgLista = new System.Windows.Forms.DataGridView();
            this.CProovedorID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CProovedorNombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CProovedorEmail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CProovedorDireccion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CProovedorCedula = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CProovedorTipoDescripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.TxtProovedorNotas = new System.Windows.Forms.TextBox();
            this.TxtProovedorDireccion = new System.Windows.Forms.TextBox();
            this.CbProovedorTipo = new System.Windows.Forms.ComboBox();
            this.TxtProovedorEmail = new System.Windows.Forms.TextBox();
            this.TxtProovedorCedula = new System.Windows.Forms.TextBox();
            this.TxtProovedorNombre = new System.Windows.Forms.TextBox();
            this.TxtProovedorID = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.BtnAgregar = new System.Windows.Forms.Button();
            this.BtnEditar = new System.Windows.Forms.Button();
            this.BtnEliminar = new System.Windows.Forms.Button();
            this.BtnLimpiar = new System.Windows.Forms.Button();
            this.BtnCancelar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DgLista)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(59, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Buscar";
            // 
            // TxtBuscar
            // 
            this.TxtBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtBuscar.Location = new System.Drawing.Point(158, 34);
            this.TxtBuscar.Name = "TxtBuscar";
            this.TxtBuscar.Size = new System.Drawing.Size(345, 26);
            this.TxtBuscar.TabIndex = 1;
            this.TxtBuscar.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TxtBuscar.TextChanged += new System.EventHandler(this.TxtBuscar_TextChanged);
            // 
            // CboxVerActivos
            // 
            this.CboxVerActivos.AutoSize = true;
            this.CboxVerActivos.Checked = true;
            this.CboxVerActivos.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CboxVerActivos.Location = new System.Drawing.Point(561, 36);
            this.CboxVerActivos.Name = "CboxVerActivos";
            this.CboxVerActivos.Size = new System.Drawing.Size(80, 17);
            this.CboxVerActivos.TabIndex = 2;
            this.CboxVerActivos.Text = "Ver Activos";
            this.CboxVerActivos.UseVisualStyleBackColor = true;
            this.CboxVerActivos.CheckedChanged += new System.EventHandler(this.CboxVerActivos_CheckedChanged);
            // 
            // DgLista
            // 
            this.DgLista.AllowUserToAddRows = false;
            this.DgLista.AllowUserToDeleteRows = false;
            this.DgLista.AllowUserToOrderColumns = true;
            this.DgLista.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgLista.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CProovedorID,
            this.CProovedorNombre,
            this.CProovedorEmail,
            this.CProovedorDireccion,
            this.CProovedorCedula,
            this.CProovedorTipoDescripcion});
            this.DgLista.Location = new System.Drawing.Point(46, 95);
            this.DgLista.MultiSelect = false;
            this.DgLista.Name = "DgLista";
            this.DgLista.ReadOnly = true;
            this.DgLista.RowHeadersVisible = false;
            this.DgLista.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgLista.Size = new System.Drawing.Size(687, 158);
            this.DgLista.TabIndex = 3;
            this.DgLista.VirtualMode = true;
            this.DgLista.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgLista_CellClick);
            this.DgLista.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.DgLista_DataBindingComplete);
            // 
            // CProovedorID
            // 
            this.CProovedorID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.CProovedorID.DataPropertyName = "ProovedorID";
            this.CProovedorID.HeaderText = "Cod.Proovedor";
            this.CProovedorID.Name = "CProovedorID";
            this.CProovedorID.ReadOnly = true;
            // 
            // CProovedorNombre
            // 
            this.CProovedorNombre.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.CProovedorNombre.DataPropertyName = "ProovedorNombre";
            this.CProovedorNombre.HeaderText = "Nombre";
            this.CProovedorNombre.Name = "CProovedorNombre";
            this.CProovedorNombre.ReadOnly = true;
            // 
            // CProovedorEmail
            // 
            this.CProovedorEmail.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.CProovedorEmail.DataPropertyName = "ProovedorEmail";
            this.CProovedorEmail.HeaderText = "Correo";
            this.CProovedorEmail.Name = "CProovedorEmail";
            this.CProovedorEmail.ReadOnly = true;
            // 
            // CProovedorDireccion
            // 
            this.CProovedorDireccion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.CProovedorDireccion.DataPropertyName = "ProovedorDireccion";
            this.CProovedorDireccion.HeaderText = "Direccion";
            this.CProovedorDireccion.Name = "CProovedorDireccion";
            this.CProovedorDireccion.ReadOnly = true;
            // 
            // CProovedorCedula
            // 
            this.CProovedorCedula.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.CProovedorCedula.DataPropertyName = "ProovedorCedula";
            this.CProovedorCedula.HeaderText = "Cedula";
            this.CProovedorCedula.Name = "CProovedorCedula";
            this.CProovedorCedula.ReadOnly = true;
            // 
            // CProovedorTipoDescripcion
            // 
            this.CProovedorTipoDescripcion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.CProovedorTipoDescripcion.DataPropertyName = "ProovedorTipoDescripcion";
            this.CProovedorTipoDescripcion.HeaderText = "Tipo de Proovedor";
            this.CProovedorTipoDescripcion.Name = "CProovedorTipoDescripcion";
            this.CProovedorTipoDescripcion.ReadOnly = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.TxtProovedorNotas);
            this.groupBox1.Controls.Add(this.TxtProovedorDireccion);
            this.groupBox1.Controls.Add(this.CbProovedorTipo);
            this.groupBox1.Controls.Add(this.TxtProovedorEmail);
            this.groupBox1.Controls.Add(this.TxtProovedorCedula);
            this.groupBox1.Controls.Add(this.TxtProovedorNombre);
            this.groupBox1.Controls.Add(this.TxtProovedorID);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(56, 305);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(677, 179);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Detalle de Proovedores";
            // 
            // TxtProovedorNotas
            // 
            this.TxtProovedorNotas.Location = new System.Drawing.Point(463, 74);
            this.TxtProovedorNotas.Multiline = true;
            this.TxtProovedorNotas.Name = "TxtProovedorNotas";
            this.TxtProovedorNotas.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.TxtProovedorNotas.Size = new System.Drawing.Size(208, 20);
            this.TxtProovedorNotas.TabIndex = 13;
            this.TxtProovedorNotas.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtProovedorNotas_KeyPress);
            // 
            // TxtProovedorDireccion
            // 
            this.TxtProovedorDireccion.Location = new System.Drawing.Point(486, 30);
            this.TxtProovedorDireccion.Multiline = true;
            this.TxtProovedorDireccion.Name = "TxtProovedorDireccion";
            this.TxtProovedorDireccion.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.TxtProovedorDireccion.Size = new System.Drawing.Size(185, 20);
            this.TxtProovedorDireccion.TabIndex = 12;
            this.TxtProovedorDireccion.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtProovedorDireccion_KeyPress);
            // 
            // CbProovedorTipo
            // 
            this.CbProovedorTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CbProovedorTipo.FormattingEnabled = true;
            this.CbProovedorTipo.Location = new System.Drawing.Point(519, 101);
            this.CbProovedorTipo.Name = "CbProovedorTipo";
            this.CbProovedorTipo.Size = new System.Drawing.Size(152, 26);
            this.CbProovedorTipo.TabIndex = 11;
            // 
            // TxtProovedorEmail
            // 
            this.TxtProovedorEmail.Location = new System.Drawing.Point(177, 138);
            this.TxtProovedorEmail.Name = "TxtProovedorEmail";
            this.TxtProovedorEmail.Size = new System.Drawing.Size(165, 24);
            this.TxtProovedorEmail.TabIndex = 10;
            this.TxtProovedorEmail.Enter += new System.EventHandler(this.TxtProovedorEmail_Enter);
            this.TxtProovedorEmail.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtProovedorEmail_KeyPress);
            this.TxtProovedorEmail.Leave += new System.EventHandler(this.TxtProovedorEmail_Leave);
            // 
            // TxtProovedorCedula
            // 
            this.TxtProovedorCedula.Location = new System.Drawing.Point(177, 101);
            this.TxtProovedorCedula.Name = "TxtProovedorCedula";
            this.TxtProovedorCedula.Size = new System.Drawing.Size(165, 24);
            this.TxtProovedorCedula.TabIndex = 9;
            this.TxtProovedorCedula.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtProovedorCedula_KeyPress);
            // 
            // TxtProovedorNombre
            // 
            this.TxtProovedorNombre.Location = new System.Drawing.Point(177, 71);
            this.TxtProovedorNombre.Name = "TxtProovedorNombre";
            this.TxtProovedorNombre.Size = new System.Drawing.Size(165, 24);
            this.TxtProovedorNombre.TabIndex = 8;
            this.TxtProovedorNombre.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtProovedorNombre_KeyPress);
            // 
            // TxtProovedorID
            // 
            this.TxtProovedorID.Location = new System.Drawing.Point(177, 33);
            this.TxtProovedorID.Name = "TxtProovedorID";
            this.TxtProovedorID.ReadOnly = true;
            this.TxtProovedorID.Size = new System.Drawing.Size(165, 24);
            this.TxtProovedorID.TabIndex = 7;
            this.TxtProovedorID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(382, 101);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(131, 18);
            this.label8.TabIndex = 6;
            this.label8.Text = "Tipo de Proovedor";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(409, 71);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(48, 18);
            this.label7.TabIndex = 5;
            this.label7.Text = "Notas";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(409, 33);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(71, 18);
            this.label6.TabIndex = 4;
            this.label6.Text = "Direccion";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(31, 144);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 18);
            this.label5.TabIndex = 3;
            this.label5.Text = "Correo";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(31, 107);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 18);
            this.label4.TabIndex = 2;
            this.label4.Text = "Cedula";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(31, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 18);
            this.label3.TabIndex = 1;
            this.label3.Text = "Nombre";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(153, 18);
            this.label2.TabIndex = 0;
            this.label2.Text = "Codigo del Proovedor";
            // 
            // BtnAgregar
            // 
            this.BtnAgregar.BackColor = System.Drawing.Color.Chartreuse;
            this.BtnAgregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnAgregar.ForeColor = System.Drawing.Color.Black;
            this.BtnAgregar.Location = new System.Drawing.Point(63, 504);
            this.BtnAgregar.Name = "BtnAgregar";
            this.BtnAgregar.Size = new System.Drawing.Size(127, 39);
            this.BtnAgregar.TabIndex = 5;
            this.BtnAgregar.Text = "AGREGAR";
            this.BtnAgregar.UseVisualStyleBackColor = false;
            this.BtnAgregar.Click += new System.EventHandler(this.BtnAgregar_Click);
            // 
            // BtnEditar
            // 
            this.BtnEditar.BackColor = System.Drawing.Color.LightSeaGreen;
            this.BtnEditar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnEditar.Location = new System.Drawing.Point(196, 504);
            this.BtnEditar.Name = "BtnEditar";
            this.BtnEditar.Size = new System.Drawing.Size(127, 39);
            this.BtnEditar.TabIndex = 6;
            this.BtnEditar.Text = "EDITAR";
            this.BtnEditar.UseVisualStyleBackColor = false;
            this.BtnEditar.Click += new System.EventHandler(this.BtnEditar_Click);
            // 
            // BtnEliminar
            // 
            this.BtnEliminar.BackColor = System.Drawing.Color.HotPink;
            this.BtnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnEliminar.Location = new System.Drawing.Point(330, 501);
            this.BtnEliminar.Name = "BtnEliminar";
            this.BtnEliminar.Size = new System.Drawing.Size(127, 42);
            this.BtnEliminar.TabIndex = 7;
            this.BtnEliminar.Text = "ELIMINAR";
            this.BtnEliminar.UseVisualStyleBackColor = false;
            this.BtnEliminar.Click += new System.EventHandler(this.BtnEliminar_Click);
            // 
            // BtnLimpiar
            // 
            this.BtnLimpiar.BackColor = System.Drawing.Color.DarkOrchid;
            this.BtnLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnLimpiar.Location = new System.Drawing.Point(467, 501);
            this.BtnLimpiar.Name = "BtnLimpiar";
            this.BtnLimpiar.Size = new System.Drawing.Size(127, 43);
            this.BtnLimpiar.TabIndex = 8;
            this.BtnLimpiar.Text = "LIMPIAR";
            this.BtnLimpiar.UseVisualStyleBackColor = false;
            this.BtnLimpiar.Click += new System.EventHandler(this.BtnLimpiar_Click);
            // 
            // BtnCancelar
            // 
            this.BtnCancelar.BackColor = System.Drawing.Color.LightCoral;
            this.BtnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnCancelar.Location = new System.Drawing.Point(600, 502);
            this.BtnCancelar.Name = "BtnCancelar";
            this.BtnCancelar.Size = new System.Drawing.Size(127, 42);
            this.BtnCancelar.TabIndex = 9;
            this.BtnCancelar.Text = "CANCELAR";
            this.BtnCancelar.UseVisualStyleBackColor = false;
            this.BtnCancelar.Click += new System.EventHandler(this.BtnCancelar_Click);
            // 
            // FrmProovedorGestion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PeachPuff;
            this.ClientSize = new System.Drawing.Size(777, 555);
            this.Controls.Add(this.BtnCancelar);
            this.Controls.Add(this.BtnLimpiar);
            this.Controls.Add(this.BtnEliminar);
            this.Controls.Add(this.BtnEditar);
            this.Controls.Add(this.BtnAgregar);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.DgLista);
            this.Controls.Add(this.CboxVerActivos);
            this.Controls.Add(this.TxtBuscar);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmProovedorGestion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.FrmProovedorGestion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DgLista)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TxtBuscar;
        private System.Windows.Forms.CheckBox CboxVerActivos;
        private System.Windows.Forms.DataGridView DgLista;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TxtProovedorID;
        private System.Windows.Forms.TextBox TxtProovedorNombre;
        private System.Windows.Forms.TextBox TxtProovedorCedula;
        private System.Windows.Forms.TextBox TxtProovedorEmail;
        private System.Windows.Forms.ComboBox CbProovedorTipo;
        private System.Windows.Forms.TextBox TxtProovedorNotas;
        private System.Windows.Forms.TextBox TxtProovedorDireccion;
        private System.Windows.Forms.Button BtnAgregar;
        private System.Windows.Forms.Button BtnEditar;
        private System.Windows.Forms.Button BtnEliminar;
        private System.Windows.Forms.Button BtnLimpiar;
        private System.Windows.Forms.Button BtnCancelar;
        private System.Windows.Forms.DataGridViewTextBoxColumn CProovedorID;
        private System.Windows.Forms.DataGridViewTextBoxColumn CProovedorNombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn CProovedorEmail;
        private System.Windows.Forms.DataGridViewTextBoxColumn CProovedorDireccion;
        private System.Windows.Forms.DataGridViewTextBoxColumn CProovedorCedula;
        private System.Windows.Forms.DataGridViewTextBoxColumn CProovedorTipoDescripcion;
    }
}