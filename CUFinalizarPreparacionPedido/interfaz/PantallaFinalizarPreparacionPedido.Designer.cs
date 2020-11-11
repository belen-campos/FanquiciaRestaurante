namespace CUFinalizarPreparacionPedido.interfaz
{
    partial class PantallaFinalizarPreparacionPedido
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PantallaFinalizarPreparacionPedido));
            this.opciones = new System.Windows.Forms.TabControl();
            this.tabTiempo = new System.Windows.Forms.TabPage();
            this.dvgDetallesTiempo = new System.Windows.Forms.DataGridView();
            this.Producto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.menu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mesa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label3 = new System.Windows.Forms.Label();
            this.tabSeccion = new System.Windows.Forms.TabPage();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.tabMesa = new System.Windows.Forms.TabPage();
            this.dgvMesa = new System.Windows.Forms.DataGridView();
            this.cmbMesa = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tabMozo = new System.Windows.Forms.TabPage();
            this.dataGridView4 = new System.Windows.Forms.DataGridView();
            this.Column12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column15 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnFinalizarPedido = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnVolver = new System.Windows.Forms.Button();
            this.IndiceOrig = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mesas = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.opciones.SuspendLayout();
            this.tabTiempo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dvgDetallesTiempo)).BeginInit();
            this.tabSeccion.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.tabMesa.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMesa)).BeginInit();
            this.tabMozo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView4)).BeginInit();
            this.SuspendLayout();
            // 
            // opciones
            // 
            this.opciones.Controls.Add(this.tabTiempo);
            this.opciones.Controls.Add(this.tabSeccion);
            this.opciones.Controls.Add(this.tabMesa);
            this.opciones.Controls.Add(this.tabMozo);
            this.opciones.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.opciones.Location = new System.Drawing.Point(28, 53);
            this.opciones.Name = "opciones";
            this.opciones.SelectedIndex = 0;
            this.opciones.Size = new System.Drawing.Size(729, 333);
            this.opciones.TabIndex = 0;
            this.opciones.SelectedIndexChanged += new System.EventHandler(this.opciones_SelectedIndexChanged);
            // 
            // tabTiempo
            // 
            this.tabTiempo.Controls.Add(this.dvgDetallesTiempo);
            this.tabTiempo.Controls.Add(this.label3);
            this.tabTiempo.Location = new System.Drawing.Point(4, 29);
            this.tabTiempo.Name = "tabTiempo";
            this.tabTiempo.Padding = new System.Windows.Forms.Padding(3);
            this.tabTiempo.Size = new System.Drawing.Size(721, 300);
            this.tabTiempo.TabIndex = 0;
            this.tabTiempo.Text = "Mayor tiempo de espera";
            this.tabTiempo.UseVisualStyleBackColor = true;
            // 
            // dvgDetallesTiempo
            // 
            this.dvgDetallesTiempo.AllowUserToAddRows = false;
            this.dvgDetallesTiempo.AllowUserToDeleteRows = false;
            this.dvgDetallesTiempo.AllowUserToResizeColumns = false;
            this.dvgDetallesTiempo.AllowUserToResizeRows = false;
            this.dvgDetallesTiempo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dvgDetallesTiempo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Producto,
            this.menu,
            this.cantidad,
            this.mesa});
            this.dvgDetallesTiempo.Location = new System.Drawing.Point(19, 41);
            this.dvgDetallesTiempo.Name = "dvgDetallesTiempo";
            this.dvgDetallesTiempo.ReadOnly = true;
            this.dvgDetallesTiempo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dvgDetallesTiempo.ShowCellErrors = false;
            this.dvgDetallesTiempo.ShowCellToolTips = false;
            this.dvgDetallesTiempo.ShowEditingIcon = false;
            this.dvgDetallesTiempo.Size = new System.Drawing.Size(687, 242);
            this.dvgDetallesTiempo.TabIndex = 1;
            this.dvgDetallesTiempo.TabStop = false;
            // 
            // Producto
            // 
            this.Producto.DataPropertyName = "producto";
            this.Producto.HeaderText = "Producto";
            this.Producto.Name = "Producto";
            this.Producto.ReadOnly = true;
            this.Producto.Width = 244;
            // 
            // menu
            // 
            this.menu.DataPropertyName = "menu";
            this.menu.HeaderText = "Menu";
            this.menu.Name = "menu";
            this.menu.ReadOnly = true;
            this.menu.Width = 200;
            // 
            // cantidad
            // 
            this.cantidad.DataPropertyName = "cantidad";
            this.cantidad.HeaderText = "Cantidad";
            this.cantidad.Name = "cantidad";
            this.cantidad.ReadOnly = true;
            this.cantidad.Width = 90;
            // 
            // mesa
            // 
            this.mesa.DataPropertyName = "mesa";
            this.mesa.HeaderText = "Mesa";
            this.mesa.Name = "mesa";
            this.mesa.ReadOnly = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 7);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(226, 20);
            this.label3.TabIndex = 0;
            this.label3.Text = "Seleccione el pedido a finalizar";
            // 
            // tabSeccion
            // 
            this.tabSeccion.Controls.Add(this.dataGridView2);
            this.tabSeccion.Controls.Add(this.label1);
            this.tabSeccion.Controls.Add(this.comboBox1);
            this.tabSeccion.Location = new System.Drawing.Point(4, 29);
            this.tabSeccion.Name = "tabSeccion";
            this.tabSeccion.Padding = new System.Windows.Forms.Padding(3);
            this.tabSeccion.Size = new System.Drawing.Size(721, 300);
            this.tabSeccion.TabIndex = 1;
            this.tabSeccion.Text = "Nombre de Seccion";
            this.tabSeccion.UseVisualStyleBackColor = true;
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column5,
            this.Column6,
            this.Column7,
            this.Column8});
            this.dataGridView2.Location = new System.Drawing.Point(19, 41);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.Size = new System.Drawing.Size(683, 244);
            this.dataGridView2.TabIndex = 2;
            // 
            // Column5
            // 
            this.Column5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column5.HeaderText = "Producto";
            this.Column5.Name = "Column5";
            // 
            // Column6
            // 
            this.Column6.HeaderText = "Menu";
            this.Column6.Name = "Column6";
            // 
            // Column7
            // 
            this.Column7.HeaderText = "Cantidad";
            this.Column7.Name = "Column7";
            // 
            // Column8
            // 
            this.Column8.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column8.HeaderText = "Mesa";
            this.Column8.Name = "Column8";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(179, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Seleccione una Seccion";
            // 
            // comboBox1
            // 
            this.comboBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.TitleBar;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(220, 7);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(292, 28);
            this.comboBox1.TabIndex = 0;
            // 
            // tabMesa
            // 
            this.tabMesa.Controls.Add(this.dgvMesa);
            this.tabMesa.Controls.Add(this.cmbMesa);
            this.tabMesa.Controls.Add(this.label4);
            this.tabMesa.Location = new System.Drawing.Point(4, 29);
            this.tabMesa.Name = "tabMesa";
            this.tabMesa.Size = new System.Drawing.Size(721, 300);
            this.tabMesa.TabIndex = 2;
            this.tabMesa.Text = "Numero de Mesa";
            this.tabMesa.UseVisualStyleBackColor = true;
            // 
            // dgvMesa
            // 
            this.dgvMesa.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.dgvMesa.AllowUserToAddRows = false;
            this.dgvMesa.AllowUserToDeleteRows = false;
            this.dgvMesa.AllowUserToResizeColumns = false;
            this.dgvMesa.AllowUserToResizeRows = false;
            this.dgvMesa.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMesa.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMesa.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IndiceOrig,
            this.mesas,
            this.Column9,
            this.Column10,
            this.Column11});
            this.dgvMesa.Location = new System.Drawing.Point(19, 41);
            this.dgvMesa.Name = "dgvMesa";
            this.dgvMesa.ReadOnly = true;
            this.dgvMesa.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMesa.ShowCellErrors = false;
            this.dgvMesa.ShowCellToolTips = false;
            this.dgvMesa.ShowEditingIcon = false;
            this.dgvMesa.Size = new System.Drawing.Size(683, 244);
            this.dgvMesa.TabIndex = 2;
            // 
            // cmbMesa
            // 
            this.cmbMesa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMesa.FormattingEnabled = true;
            this.cmbMesa.Location = new System.Drawing.Point(220, 7);
            this.cmbMesa.Name = "cmbMesa";
            this.cmbMesa.Size = new System.Drawing.Size(218, 28);
            this.cmbMesa.TabIndex = 1;
            this.cmbMesa.SelectedIndexChanged += new System.EventHandler(this.cmbMesa_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 7);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(161, 20);
            this.label4.TabIndex = 0;
            this.label4.Text = "Seleccione una Mesa";
            // 
            // tabMozo
            // 
            this.tabMozo.Controls.Add(this.dataGridView4);
            this.tabMozo.Controls.Add(this.comboBox3);
            this.tabMozo.Controls.Add(this.label5);
            this.tabMozo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabMozo.Location = new System.Drawing.Point(4, 29);
            this.tabMozo.Name = "tabMozo";
            this.tabMozo.Size = new System.Drawing.Size(721, 300);
            this.tabMozo.TabIndex = 3;
            this.tabMozo.Text = "Nombre de Mozo";
            this.tabMozo.UseVisualStyleBackColor = true;
            // 
            // dataGridView4
            // 
            this.dataGridView4.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView4.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView4.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column12,
            this.Column13,
            this.Column14,
            this.Column15});
            this.dataGridView4.Location = new System.Drawing.Point(19, 41);
            this.dataGridView4.Name = "dataGridView4";
            this.dataGridView4.Size = new System.Drawing.Size(683, 244);
            this.dataGridView4.TabIndex = 2;
            // 
            // Column12
            // 
            this.Column12.HeaderText = "Producto";
            this.Column12.Name = "Column12";
            // 
            // Column13
            // 
            this.Column13.HeaderText = "Menu";
            this.Column13.Name = "Column13";
            // 
            // Column14
            // 
            this.Column14.HeaderText = "Cantidad";
            this.Column14.Name = "Column14";
            // 
            // Column15
            // 
            this.Column15.HeaderText = "Mesa";
            this.Column15.Name = "Column15";
            // 
            // comboBox3
            // 
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Location = new System.Drawing.Point(220, 7);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(209, 28);
            this.comboBox3.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(17, 7);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(152, 20);
            this.label5.TabIndex = 0;
            this.label5.Text = "Seleccione un Mozo";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(24, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(310, 24);
            this.label2.TabIndex = 1;
            this.label2.Text = "Finalizar Preparacion de Pedido";
            // 
            // btnFinalizarPedido
            // 
            this.btnFinalizarPedido.Location = new System.Drawing.Point(605, 406);
            this.btnFinalizarPedido.Name = "btnFinalizarPedido";
            this.btnFinalizarPedido.Size = new System.Drawing.Size(148, 23);
            this.btnFinalizarPedido.TabIndex = 2;
            this.btnFinalizarPedido.Text = "Finalizar Preparacion";
            this.btnFinalizarPedido.UseVisualStyleBackColor = true;
            this.btnFinalizarPedido.Click += new System.EventHandler(this.btnFinalizarPedido_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(32, 405);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 3;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnVolver
            // 
            this.btnVolver.Location = new System.Drawing.Point(124, 405);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(75, 23);
            this.btnVolver.TabIndex = 4;
            this.btnVolver.Text = "Volver";
            this.btnVolver.UseVisualStyleBackColor = true;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // IndiceOrig
            // 
            this.IndiceOrig.HeaderText = "Indice";
            this.IndiceOrig.Name = "IndiceOrig";
            this.IndiceOrig.ReadOnly = true;
            this.IndiceOrig.Visible = false;
            // 
            // mesas
            // 
            this.mesas.HeaderText = "Mesa";
            this.mesas.Name = "mesas";
            this.mesas.ReadOnly = true;
            this.mesas.Visible = false;
            // 
            // Column9
            // 
            this.Column9.HeaderText = "Producto";
            this.Column9.Name = "Column9";
            this.Column9.ReadOnly = true;
            // 
            // Column10
            // 
            this.Column10.HeaderText = "Menu";
            this.Column10.Name = "Column10";
            this.Column10.ReadOnly = true;
            // 
            // Column11
            // 
            this.Column11.HeaderText = "Cantidad";
            this.Column11.Name = "Column11";
            this.Column11.ReadOnly = true;
            // 
            // PantallaFinalizarPreparacionPedido
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnFinalizarPedido);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.opciones);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PantallaFinalizarPreparacionPedido";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Restaurant DSI";
            this.Load += new System.EventHandler(this.PantallaFinalizarPreparacionPedido_Load);
            this.opciones.ResumeLayout(false);
            this.tabTiempo.ResumeLayout(false);
            this.tabTiempo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dvgDetallesTiempo)).EndInit();
            this.tabSeccion.ResumeLayout(false);
            this.tabSeccion.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.tabMesa.ResumeLayout(false);
            this.tabMesa.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMesa)).EndInit();
            this.tabMozo.ResumeLayout(false);
            this.tabMozo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView4)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl opciones;
        private System.Windows.Forms.TabPage tabTiempo;
        private System.Windows.Forms.TabPage tabSeccion;
        private System.Windows.Forms.DataGridView dvgDetallesTiempo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.TabPage tabMesa;
        private System.Windows.Forms.TabPage tabMozo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnFinalizarPedido;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnVolver;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvMesa;
        private System.Windows.Forms.ComboBox cmbMesa;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dataGridView4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column12;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column13;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column14;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column15;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Producto;
        private System.Windows.Forms.DataGridViewTextBoxColumn menu;
        private System.Windows.Forms.DataGridViewTextBoxColumn cantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn mesa;
        private System.Windows.Forms.DataGridViewTextBoxColumn IndiceOrig;
        private System.Windows.Forms.DataGridViewTextBoxColumn mesas;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column11;
    }
}

