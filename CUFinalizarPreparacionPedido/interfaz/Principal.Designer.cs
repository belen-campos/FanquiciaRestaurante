namespace CUFinalizarPreparacionPedido.interfaz
{
    partial class Principal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Principal));
            this.btnFinalizarPreparacionPedido = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnFinalizarPreparacionPedido
            // 
            this.btnFinalizarPreparacionPedido.Location = new System.Drawing.Point(87, 68);
            this.btnFinalizarPreparacionPedido.Name = "btnFinalizarPreparacionPedido";
            this.btnFinalizarPreparacionPedido.Size = new System.Drawing.Size(203, 50);
            this.btnFinalizarPreparacionPedido.TabIndex = 0;
            this.btnFinalizarPreparacionPedido.Text = "Finalizar preparación de pedido";
            this.btnFinalizarPreparacionPedido.UseVisualStyleBackColor = true;
            this.btnFinalizarPreparacionPedido.Click += new System.EventHandler(this.btnFinalizarPreparacionPedido_Click);
            // 
            // Principal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(389, 206);
            this.Controls.Add(this.btnFinalizarPreparacionPedido);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Principal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Restaurant DSI";
            this.Load += new System.EventHandler(this.Principal_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnFinalizarPreparacionPedido;
    }
}