namespace AdmDesktop
{
    partial class frmPrincipal
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.asddsdToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dasdadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modeloToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.veiculoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gerenciarVeículoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.vendasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gerenciarVendedorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.vendasToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.acompanharPorVendedorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.acompanharPorVeículoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sairToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 15F);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.asddsdToolStripMenuItem,
            this.veiculoToolStripMenuItem,
            this.vendasToolStripMenuItem,
            this.vendasToolStripMenuItem1,
            this.sairToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 36);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // asddsdToolStripMenuItem
            // 
            this.asddsdToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dasdadToolStripMenuItem,
            this.modeloToolStripMenuItem});
            this.asddsdToolStripMenuItem.Name = "asddsdToolStripMenuItem";
            this.asddsdToolStripMenuItem.Size = new System.Drawing.Size(110, 32);
            this.asddsdToolStripMenuItem.Text = "Cadastros";
            // 
            // dasdadToolStripMenuItem
            // 
            this.dasdadToolStripMenuItem.Name = "dasdadToolStripMenuItem";
            this.dasdadToolStripMenuItem.Size = new System.Drawing.Size(180, 32);
            this.dasdadToolStripMenuItem.Text = "Marca";
            this.dasdadToolStripMenuItem.Click += new System.EventHandler(this.dasdadToolStripMenuItem_Click);
            // 
            // modeloToolStripMenuItem
            // 
            this.modeloToolStripMenuItem.Name = "modeloToolStripMenuItem";
            this.modeloToolStripMenuItem.Size = new System.Drawing.Size(180, 32);
            this.modeloToolStripMenuItem.Text = "Modelo";
            this.modeloToolStripMenuItem.Click += new System.EventHandler(this.modeloToolStripMenuItem_Click);
            // 
            // veiculoToolStripMenuItem
            // 
            this.veiculoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gerenciarVeículoToolStripMenuItem});
            this.veiculoToolStripMenuItem.Name = "veiculoToolStripMenuItem";
            this.veiculoToolStripMenuItem.Size = new System.Drawing.Size(87, 32);
            this.veiculoToolStripMenuItem.Text = "Veiculo";
            // 
            // gerenciarVeículoToolStripMenuItem
            // 
            this.gerenciarVeículoToolStripMenuItem.Name = "gerenciarVeículoToolStripMenuItem";
            this.gerenciarVeículoToolStripMenuItem.Size = new System.Drawing.Size(234, 32);
            this.gerenciarVeículoToolStripMenuItem.Text = "Gerenciar veículo";
            this.gerenciarVeículoToolStripMenuItem.Click += new System.EventHandler(this.gerenciarVeículoToolStripMenuItem_Click);
            // 
            // vendasToolStripMenuItem
            // 
            this.vendasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gerenciarVendedorToolStripMenuItem});
            this.vendasToolStripMenuItem.Name = "vendasToolStripMenuItem";
            this.vendasToolStripMenuItem.Size = new System.Drawing.Size(109, 32);
            this.vendasToolStripMenuItem.Text = "Vendedor";
            this.vendasToolStripMenuItem.Click += new System.EventHandler(this.vendasToolStripMenuItem_Click);
            // 
            // gerenciarVendedorToolStripMenuItem
            // 
            this.gerenciarVendedorToolStripMenuItem.Name = "gerenciarVendedorToolStripMenuItem";
            this.gerenciarVendedorToolStripMenuItem.Size = new System.Drawing.Size(256, 32);
            this.gerenciarVendedorToolStripMenuItem.Text = "Gerenciar vendedor";
            this.gerenciarVendedorToolStripMenuItem.Click += new System.EventHandler(this.gerenciarVendedorToolStripMenuItem_Click);
            // 
            // vendasToolStripMenuItem1
            // 
            this.vendasToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.acompanharPorVendedorToolStripMenuItem,
            this.acompanharPorVeículoToolStripMenuItem});
            this.vendasToolStripMenuItem1.Name = "vendasToolStripMenuItem1";
            this.vendasToolStripMenuItem1.Size = new System.Drawing.Size(86, 32);
            this.vendasToolStripMenuItem1.Text = "Vendas";
            // 
            // acompanharPorVendedorToolStripMenuItem
            // 
            this.acompanharPorVendedorToolStripMenuItem.Name = "acompanharPorVendedorToolStripMenuItem";
            this.acompanharPorVendedorToolStripMenuItem.Size = new System.Drawing.Size(321, 32);
            this.acompanharPorVendedorToolStripMenuItem.Text = "Acompanhar por vendedor";
            this.acompanharPorVendedorToolStripMenuItem.Click += new System.EventHandler(this.acompanharPorVendedorToolStripMenuItem_Click);
            // 
            // acompanharPorVeículoToolStripMenuItem
            // 
            this.acompanharPorVeículoToolStripMenuItem.Name = "acompanharPorVeículoToolStripMenuItem";
            this.acompanharPorVeículoToolStripMenuItem.Size = new System.Drawing.Size(321, 32);
            this.acompanharPorVeículoToolStripMenuItem.Text = "Acompanhar por veículo";
            this.acompanharPorVeículoToolStripMenuItem.Click += new System.EventHandler(this.acompanharPorVeículoToolStripMenuItem_Click);
            // 
            // sairToolStripMenuItem
            // 
            this.sairToolStripMenuItem.Name = "sairToolStripMenuItem";
            this.sairToolStripMenuItem.Size = new System.Drawing.Size(57, 32);
            this.sairToolStripMenuItem.Text = "Sair";
            this.sairToolStripMenuItem.Click += new System.EventHandler(this.sairToolStripMenuItem_Click);
            // 
            // frmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmPrincipal";
            this.Text = "frmPrincipal";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem asddsdToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dasdadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modeloToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem veiculoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gerenciarVeículoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem vendasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gerenciarVendedorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem vendasToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem acompanharPorVendedorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem acompanharPorVeículoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sairToolStripMenuItem;
    }
}