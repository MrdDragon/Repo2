namespace WindowsFormTest
{
    partial class Form1
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.txt_Nome = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_Cidade = new System.Windows.Forms.TextBox();
            this.txt_label1 = new System.Windows.Forms.Label();
            this.txt_label = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.bt_Inserir = new System.Windows.Forms.Button();
            this.bt_Atualizar = new System.Windows.Forms.Button();
            this.bt_Apagar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // txt_Nome
            // 
            this.txt_Nome.Location = new System.Drawing.Point(12, 59);
            this.txt_Nome.Name = "txt_Nome";
            this.txt_Nome.Size = new System.Drawing.Size(194, 22);
            this.txt_Nome.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Registos";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // txt_Cidade
            // 
            this.txt_Cidade.Location = new System.Drawing.Point(12, 113);
            this.txt_Cidade.Name = "txt_Cidade";
            this.txt_Cidade.Size = new System.Drawing.Size(194, 22);
            this.txt_Cidade.TabIndex = 2;
            // 
            // txt_label1
            // 
            this.txt_label1.AutoSize = true;
            this.txt_label1.Location = new System.Drawing.Point(9, 94);
            this.txt_label1.Name = "txt_label1";
            this.txt_label1.Size = new System.Drawing.Size(51, 16);
            this.txt_label1.TabIndex = 3;
            this.txt_label1.Text = "Cidade";
            this.txt_label1.Click += new System.EventHandler(this.label2_Click);
            // 
            // txt_label
            // 
            this.txt_label.AutoSize = true;
            this.txt_label.Location = new System.Drawing.Point(9, 40);
            this.txt_label.Name = "txt_label";
            this.txt_label.Size = new System.Drawing.Size(44, 16);
            this.txt_label.TabIndex = 4;
            this.txt_label.Text = "Nome";
            this.txt_label.Click += new System.EventHandler(this.label3_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 165);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(712, 386);
            this.dataGridView1.TabIndex = 5;
            // 
            // bt_Inserir
            // 
            this.bt_Inserir.Location = new System.Drawing.Point(259, 94);
            this.bt_Inserir.Name = "bt_Inserir";
            this.bt_Inserir.Size = new System.Drawing.Size(88, 41);
            this.bt_Inserir.TabIndex = 6;
            this.bt_Inserir.Text = "Inserir";
            this.bt_Inserir.UseVisualStyleBackColor = true;
            this.bt_Inserir.Click += new System.EventHandler(this.bt_Inserir_Click);
            // 
            // bt_Atualizar
            // 
            this.bt_Atualizar.Location = new System.Drawing.Point(353, 94);
            this.bt_Atualizar.Name = "bt_Atualizar";
            this.bt_Atualizar.Size = new System.Drawing.Size(88, 41);
            this.bt_Atualizar.TabIndex = 7;
            this.bt_Atualizar.Text = "Atualizar";
            this.bt_Atualizar.UseVisualStyleBackColor = true;
            this.bt_Atualizar.Click += new System.EventHandler(this.bt_Atualizar_Click);
            // 
            // bt_Apagar
            // 
            this.bt_Apagar.Location = new System.Drawing.Point(447, 94);
            this.bt_Apagar.Name = "bt_Apagar";
            this.bt_Apagar.Size = new System.Drawing.Size(88, 41);
            this.bt_Apagar.TabIndex = 8;
            this.bt_Apagar.Text = "Apagar";
            this.bt_Apagar.UseVisualStyleBackColor = true;
            this.bt_Apagar.Click += new System.EventHandler(this.bt_Apagar_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(736, 563);
            this.Controls.Add(this.bt_Apagar);
            this.Controls.Add(this.bt_Atualizar);
            this.Controls.Add(this.bt_Inserir);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.txt_label);
            this.Controls.Add(this.txt_label1);
            this.Controls.Add(this.txt_Cidade);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_Nome);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_Nome;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_Cidade;
        private System.Windows.Forms.Label txt_label1;
        private System.Windows.Forms.Label txt_label;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button bt_Inserir;
        private System.Windows.Forms.Button bt_Atualizar;
        private System.Windows.Forms.Button bt_Apagar;
    }
}

