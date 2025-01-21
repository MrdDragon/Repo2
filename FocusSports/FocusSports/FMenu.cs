//-----------------------------------------------------------------
//    <copyright file="FMenu.cs"    company="IPCA">
//     Copyright (c) IPCA-EST 2024. All rights reserved.
//    </copyright>
//    <date>2024-11-22</date>
//    <time>22:01</time>
//    <version>0.1</version>
//    <author>D.Oliveira</author>
//    <description>FocusSports</description>
//-----------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FocusSports
{
    public partial class FMenu : Form
    {
        string permi;
        string conString = Connecao.GetConString();
        SqlConnection conn;
        SqlCommand cmd;
        SqlDataAdapter adapt;
        

        public void Permissoes(string permissoes)
        {
            permi = permissoes;

            if(permissoes != "Vendas")
            {
                VerificaVS();
            }
          
        }
        public FMenu()
        {
            conn = new SqlConnection(conString);
            InitializeComponent();
            
        }

        //Metodo para ver as validades e stocks
        public void VerificaVS()
        {
            DateTime dateTime = DateTime.Now.Date.AddMonths(2);
            
            conn.Open();
            DataTable dt = new DataTable();
            adapt = new SqlDataAdapter("select * from dbo.Produtos", conn);
            adapt.Fill(dt);
            DateTime validade;
            int contaValidade = 0, contaStock = 0;

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = dt.Rows[i];

                if (dr["Aviso"].ToString() == "Sim")
                {
                    validade = Convert.ToDateTime(dr["Validade"]);

                    if (validade <= dateTime)
                    {
                        contaValidade++;
                    }

                    if (Convert.ToInt32(dr["Quantidade"]) < 200)
                    {
                        contaStock++;
                    }
                }
                
            } 
            conn.Close();

            if (contaStock > 0 && contaValidade == 0)
            {
                lblAviso.Text = "Atenção existe " + contaStock + " Produto(s) com Stock baixo!";
                lblAviso.Visible = true;
            }
            else if (contaValidade > 0 && contaStock == 0)
            {
                lblAviso.Text = "Atenção existe " + contaValidade + " Produto(s) com Validade baixa!";
                lblAviso.Visible = true;
            }
            else if (contaValidade > 0 && contaStock > 0)
            {
                lblAviso.Text = "Atenção existem " + contaValidade + " Produto(s) com Validade baixa e " + contaStock + " Produto(s) com Stock baixo!";
                lblAviso.Visible = true;
            }
        }

        public void AbrirRegistos()
        {
            registarClienteToolStripMenuItem_Click(null, EventArgs.Empty);
        }

        //Muda a label em baixo para o seletionado
        public void Seleccao(string selecionado)
        {
                labelSelecao.Visible = true;
                labelSelecao.Text = selecionado;
            
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult resposta = MessageBox.Show("Tem a certeza que quer sair?", "Encerrar aplicação!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            
            if(resposta == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        // Verifica se algum formulário filho com o título especificado está aberto
        private bool FormAberto(string tituloForm)
        {
            
            foreach (Form f in this.MdiChildren)
            {
                if(f.Text == tituloForm)    //Compara pelo titulo
                {
                    return true;
                }
            }
            return false;
        }

        //Verifica se existe algum form aberto dentro da janela principal e fecha se houver
        private void FecharForms()
        {
            if (this.MdiChildren.Length > 0) 
            {
                foreach (Form f in this.MdiChildren)
                { 
                    f.Close();
                }
            }

        }
       
        //Clicar no botao para abrir a janela Produtos
        private void produtosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (FormAberto("Produtos") != true)
            {
                FecharForms();
                Produtos janela_Produtos = new Produtos();
                janela_Produtos.MdiParent = this;
                tableLayoutCentro.Visible = false;
                janela_Produtos.Permissoes(permi);
                janela_Produtos.Show();
                janela_Produtos.WindowState = FormWindowState.Maximized;
                janela_Produtos.MostraTodosProdutos();

            }
            
        }

        
        //Mostrar caixa de dialogo ao clicar na cruz vermelha para fechar a janela
        private void FMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult resposta = MessageBox.Show("Tem a certeza que quer sair?", "Encerrar aplicação!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resposta == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
            
                

        private void registarClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (FormAberto("Registar") != true)
            {
                FecharForms();
                Registar janela_Registar = new Registar();
                janela_Registar.MdiParent = this;
                tableLayoutCentro.Visible = false;
                janela_Registar.Permissoes(permi);
                janela_Registar.Show();
                janela_Registar.WindowState = FormWindowState.Maximized;
                labelSelecao.Visible = false;
            }
        }

        private void menuToolStripMenuItem_MouseHover(object sender, EventArgs e)
        {
      
        }

        private void menuToolStripMenuItem_MouseDown(object sender, MouseEventArgs e)
        {
           
        }

        private void menuToolStripMenuItem_MouseLeave(object sender, EventArgs e)
        {
          
        }

        //Botao Logout
        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form_Login form = new Form_Login();
            form.ShowDialog();
            this.Close();
        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (FormAberto("Clientes") != true)
            {
                FecharForms();
                Clientes janela_clientes = new Clientes();
                janela_clientes.MdiParent = this;
                tableLayoutCentro.Visible = false;
                janela_clientes.Permissoes(permi);
                janela_clientes.Show();
                janela_clientes.WindowState = FormWindowState.Maximized;
                labelSelecao.Visible = false;
            }
        }
    }
}
