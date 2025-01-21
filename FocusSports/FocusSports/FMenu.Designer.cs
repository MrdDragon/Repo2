namespace FocusSports
{
    partial class FMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FMenu));
            this.tableLayoutBaixo = new System.Windows.Forms.TableLayoutPanel();
            this.labelSelecao = new System.Windows.Forms.Label();
            this.lblAviso = new System.Windows.Forms.Label();
            this.flowLayoutCima = new System.Windows.Forms.FlowLayoutPanel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logoutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sairToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip3 = new System.Windows.Forms.MenuStrip();
            this.produtosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip5 = new System.Windows.Forms.MenuStrip();
            this.clientesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip4 = new System.Windows.Forms.MenuStrip();
            this.registarClienteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip2 = new System.Windows.Forms.MenuStrip();
            this.opçõesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tableLayoutCentro = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutBaixo.SuspendLayout();
            this.flowLayoutCima.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.menuStrip3.SuspendLayout();
            this.menuStrip5.SuspendLayout();
            this.menuStrip4.SuspendLayout();
            this.menuStrip2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tableLayoutCentro.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutBaixo
            // 
            this.tableLayoutBaixo.AutoSize = true;
            this.tableLayoutBaixo.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutBaixo.BackColor = System.Drawing.Color.White;
            this.tableLayoutBaixo.ColumnCount = 2;
            this.tableLayoutBaixo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 62.7758F));
            this.tableLayoutBaixo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 37.2242F));
            this.tableLayoutBaixo.Controls.Add(this.labelSelecao, 1, 0);
            this.tableLayoutBaixo.Controls.Add(this.lblAviso, 0, 0);
            this.tableLayoutBaixo.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutBaixo.Location = new System.Drawing.Point(0, 817);
            this.tableLayoutBaixo.Name = "tableLayoutBaixo";
            this.tableLayoutBaixo.RowCount = 1;
            this.tableLayoutBaixo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutBaixo.Size = new System.Drawing.Size(1405, 35);
            this.tableLayoutBaixo.TabIndex = 0;
            // 
            // labelSelecao
            // 
            this.labelSelecao.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelSelecao.AutoSize = true;
            this.labelSelecao.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSelecao.Location = new System.Drawing.Point(885, 7);
            this.labelSelecao.Name = "labelSelecao";
            this.labelSelecao.Size = new System.Drawing.Size(100, 20);
            this.labelSelecao.TabIndex = 1;
            this.labelSelecao.Text = "Selecionado";
            this.labelSelecao.Visible = false;
            // 
            // lblAviso
            // 
            this.lblAviso.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblAviso.AutoSize = true;
            this.lblAviso.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAviso.ForeColor = System.Drawing.Color.Red;
            this.lblAviso.Location = new System.Drawing.Point(3, 5);
            this.lblAviso.Name = "lblAviso";
            this.lblAviso.Size = new System.Drawing.Size(67, 25);
            this.lblAviso.TabIndex = 2;
            this.lblAviso.Text = "Aviso!";
            this.lblAviso.Visible = false;
            // 
            // flowLayoutCima
            // 
            this.flowLayoutCima.AccessibleRole = System.Windows.Forms.AccessibleRole.MenuBar;
            this.flowLayoutCima.AutoSize = true;
            this.flowLayoutCima.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutCima.BackColor = System.Drawing.Color.White;
            this.flowLayoutCima.Controls.Add(this.menuStrip1);
            this.flowLayoutCima.Controls.Add(this.menuStrip3);
            this.flowLayoutCima.Controls.Add(this.menuStrip5);
            this.flowLayoutCima.Controls.Add(this.menuStrip4);
            this.flowLayoutCima.Controls.Add(this.menuStrip2);
            this.flowLayoutCima.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutCima.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutCima.Name = "flowLayoutCima";
            this.flowLayoutCima.Size = new System.Drawing.Size(1405, 31);
            this.flowLayoutCima.TabIndex = 1;
            this.flowLayoutCima.Paint += new System.Windows.Forms.PaintEventHandler(this.flowLayoutPanel1_Paint);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.White;
            this.menuStrip1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(76, 31);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuToolStripMenuItem
            // 
            this.menuToolStripMenuItem.BackColor = System.Drawing.Color.White;
            this.menuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.logoutToolStripMenuItem,
            this.sairToolStripMenuItem});
            this.menuToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuToolStripMenuItem.Name = "menuToolStripMenuItem";
            this.menuToolStripMenuItem.Size = new System.Drawing.Size(68, 27);
            this.menuToolStripMenuItem.Text = "Menu";
            // 
            // logoutToolStripMenuItem
            // 
            this.logoutToolStripMenuItem.Name = "logoutToolStripMenuItem";
            this.logoutToolStripMenuItem.Size = new System.Drawing.Size(148, 28);
            this.logoutToolStripMenuItem.Text = "Logout";
            this.logoutToolStripMenuItem.Click += new System.EventHandler(this.logoutToolStripMenuItem_Click);
            // 
            // sairToolStripMenuItem
            // 
            this.sairToolStripMenuItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F);
            this.sairToolStripMenuItem.Name = "sairToolStripMenuItem";
            this.sairToolStripMenuItem.Size = new System.Drawing.Size(148, 28);
            this.sairToolStripMenuItem.Text = "Sair";
            this.sairToolStripMenuItem.Click += new System.EventHandler(this.sairToolStripMenuItem_Click);
            // 
            // menuStrip3
            // 
            this.menuStrip3.BackColor = System.Drawing.Color.White;
            this.menuStrip3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F);
            this.menuStrip3.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.produtosToolStripMenuItem});
            this.menuStrip3.Location = new System.Drawing.Point(76, 0);
            this.menuStrip3.Name = "menuStrip3";
            this.menuStrip3.Size = new System.Drawing.Size(101, 31);
            this.menuStrip3.TabIndex = 5;
            this.menuStrip3.Text = "menuStrip3";
            // 
            // produtosToolStripMenuItem
            // 
            this.produtosToolStripMenuItem.BackColor = System.Drawing.Color.White;
            this.produtosToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.produtosToolStripMenuItem.Name = "produtosToolStripMenuItem";
            this.produtosToolStripMenuItem.Size = new System.Drawing.Size(93, 27);
            this.produtosToolStripMenuItem.Text = "Produtos";
            this.produtosToolStripMenuItem.Click += new System.EventHandler(this.produtosToolStripMenuItem_Click);
            // 
            // menuStrip5
            // 
            this.menuStrip5.BackColor = System.Drawing.Color.White;
            this.menuStrip5.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip5.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clientesToolStripMenuItem});
            this.menuStrip5.Location = new System.Drawing.Point(177, 0);
            this.menuStrip5.Name = "menuStrip5";
            this.menuStrip5.Size = new System.Drawing.Size(92, 28);
            this.menuStrip5.TabIndex = 7;
            this.menuStrip5.Text = "menuStrip5";
            // 
            // clientesToolStripMenuItem
            // 
            this.clientesToolStripMenuItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F);
            this.clientesToolStripMenuItem.Name = "clientesToolStripMenuItem";
            this.clientesToolStripMenuItem.Size = new System.Drawing.Size(84, 24);
            this.clientesToolStripMenuItem.Text = "Clientes";
            this.clientesToolStripMenuItem.Click += new System.EventHandler(this.clientesToolStripMenuItem_Click);
            // 
            // menuStrip4
            // 
            this.menuStrip4.BackColor = System.Drawing.Color.White;
            this.menuStrip4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F);
            this.menuStrip4.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip4.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.registarClienteToolStripMenuItem});
            this.menuStrip4.Location = new System.Drawing.Point(269, 0);
            this.menuStrip4.Name = "menuStrip4";
            this.menuStrip4.Size = new System.Drawing.Size(94, 28);
            this.menuStrip4.TabIndex = 6;
            this.menuStrip4.Text = "menuStrip4";
            // 
            // registarClienteToolStripMenuItem
            // 
            this.registarClienteToolStripMenuItem.Name = "registarClienteToolStripMenuItem";
            this.registarClienteToolStripMenuItem.Size = new System.Drawing.Size(86, 24);
            this.registarClienteToolStripMenuItem.Text = "Registar";
            this.registarClienteToolStripMenuItem.Click += new System.EventHandler(this.registarClienteToolStripMenuItem_Click);
            // 
            // menuStrip2
            // 
            this.menuStrip2.BackColor = System.Drawing.Color.White;
            this.menuStrip2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F);
            this.menuStrip2.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.opçõesToolStripMenuItem});
            this.menuStrip2.Location = new System.Drawing.Point(363, 0);
            this.menuStrip2.Name = "menuStrip2";
            this.menuStrip2.Size = new System.Drawing.Size(89, 31);
            this.menuStrip2.TabIndex = 4;
            this.menuStrip2.Text = "menuStrip2";
            // 
            // opçõesToolStripMenuItem
            // 
            this.opçõesToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.opçõesToolStripMenuItem.Name = "opçõesToolStripMenuItem";
            this.opçõesToolStripMenuItem.Size = new System.Drawing.Size(81, 27);
            this.opçõesToolStripMenuItem.Text = "Opções";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = global::FocusSports.Properties.Resources.Focus_Sports_logo_with_a_figure_running_or_practicing_sports__2_;
            this.pictureBox1.Location = new System.Drawing.Point(284, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(837, 780);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // tableLayoutCentro
            // 
            this.tableLayoutCentro.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutCentro.BackColor = System.Drawing.Color.White;
            this.tableLayoutCentro.ColumnCount = 3;
            this.tableLayoutCentro.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutCentro.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutCentro.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutCentro.Controls.Add(this.pictureBox1, 1, 0);
            this.tableLayoutCentro.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutCentro.Location = new System.Drawing.Point(0, 31);
            this.tableLayoutCentro.Name = "tableLayoutCentro";
            this.tableLayoutCentro.RowCount = 1;
            this.tableLayoutCentro.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutCentro.Size = new System.Drawing.Size(1405, 786);
            this.tableLayoutCentro.TabIndex = 0;
            // 
            // FMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(1405, 852);
            this.Controls.Add(this.tableLayoutCentro);
            this.Controls.Add(this.tableLayoutBaixo);
            this.Controls.Add(this.flowLayoutCima);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Focus Sports";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FMenu_FormClosing);
            this.tableLayoutBaixo.ResumeLayout(false);
            this.tableLayoutBaixo.PerformLayout();
            this.flowLayoutCima.ResumeLayout(false);
            this.flowLayoutCima.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.menuStrip3.ResumeLayout(false);
            this.menuStrip3.PerformLayout();
            this.menuStrip5.ResumeLayout(false);
            this.menuStrip5.PerformLayout();
            this.menuStrip4.ResumeLayout(false);
            this.menuStrip4.PerformLayout();
            this.menuStrip2.ResumeLayout(false);
            this.menuStrip2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tableLayoutCentro.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutBaixo;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutCima;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sairToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip2;
        private System.Windows.Forms.ToolStripMenuItem opçõesToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip3;
        private System.Windows.Forms.ToolStripMenuItem produtosToolStripMenuItem;
        private System.Windows.Forms.Label labelSelecao;
        private System.Windows.Forms.MenuStrip menuStrip4;
        private System.Windows.Forms.ToolStripMenuItem registarClienteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logoutToolStripMenuItem;
        private System.Windows.Forms.Label lblAviso;
        private System.Windows.Forms.MenuStrip menuStrip5;
        private System.Windows.Forms.ToolStripMenuItem clientesToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutCentro;
    }
}