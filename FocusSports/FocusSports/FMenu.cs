﻿//-----------------------------------------------------------------
//    <copyright file="FMenu.cs"    company="IPCA">
//     Copyright (c) IPCA-EST 2024. All rights reserved.
//    </copyright>
//    <date>2024-11-22</date>
//    <time>22:05</time>
//    <version>0.1</version>
//    <author>Daniel.O & Andreia.M</author>
//    <description>FocusSports</description>
//-----------------------------------------------------------------
using System;
using System.Data;
using System.Data.SqlClient;
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
        int idCliente = 0, utilizadorId = 0, idCli= 0;

        public void Permissoes(string permissoes, int utId)
        {
            permi = permissoes;
            utilizadorId = utId;

            if (permissoes != "Vendas")
            {
                VerificaVS();
                opçõesToolStripMenuItem.Visible = true;
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
            conn.Open();

            DataTable dt2 = new DataTable();
            adapt = new SqlDataAdapter("select * from dbo.Opcoes", conn);
            adapt.Fill(dt2);

            if (dt2.Rows.Count == 0)//Se não houver dados na tabela "opções" insere valores por defeito
            {
                cmd = new SqlCommand("Insert Into dbo.Opcoes(Opid,AvisoStock,AvisoValidade) values(@opid, @avisoStock, @avisoValidade)", conn);
                cmd.Parameters.AddWithValue("@avisoStock", 200);
                cmd.Parameters.AddWithValue("@avisoValidade", 2);
                cmd.Parameters.AddWithValue("@opid", 1);
                cmd.ExecuteNonQuery();
            }

            DataRow dr2 = dt2.Rows[0];
            int avisoSt = Convert.ToInt32(dr2["AvisoStock"].ToString());
            int avisoVal = Convert.ToInt32(dr2["AvisoValidade"].ToString());

            DateTime dateTime = DateTime.Now.Date.AddMonths(avisoVal);
            
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

                    if (Convert.ToInt32(dr["Quantidade"]) < avisoSt)
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

        public void AbrirRegistos(int idC)
        {
            idCliente = idC;
            registarClienteToolStripMenuItem_Click(null, EventArgs.Empty);
            
        }

        public void AbrirEncomendas(int idClie)
        {
            idCli = idClie;
            encomendaToolStripMenuItem_Click(null, EventArgs.Empty);
        }
        public void AbrirClientes()
        {
            clientesToolStripMenuItem_Click(null, EventArgs.Empty);
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
                janela_Registar.EditarClientes(idCliente);
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

        private void opçõesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (FormAberto("Opcoes") != true)
            {
                FecharForms();
                Opcoes janela_opcoes = new Opcoes();
                janela_opcoes.MdiParent = this;
                tableLayoutCentro.Visible = false;
                janela_opcoes.Show();
                janela_opcoes.WindowState = FormWindowState.Maximized;
                labelSelecao.Visible = false;
            }
        }

        private void encomendaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (FormAberto("Encomendas") != true)
            {
                FecharForms();
                Encomendas janela_encomenda = new Encomendas();
                janela_encomenda.MdiParent = this;
                tableLayoutCentro.Visible = false;
                janela_encomenda.ClienteID(idCli, utilizadorId);
                janela_encomenda.Permissoes(permi);
                janela_encomenda.Show();
                janela_encomenda.WindowState = FormWindowState.Maximized;
                labelSelecao.Visible = false;
            }
        }
    }
}
