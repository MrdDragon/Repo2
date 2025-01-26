//-----------------------------------------------------------------
//    <copyright file="Produtos.cs"    company="IPCA">
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
using System.Drawing;
using System.Windows.Forms;

namespace FocusSports
{
    public partial class Produtos : Form
    {
        string conString = Connecao.GetConString();
        SqlConnection conn;
        SqlCommand cmd;
        SqlDataAdapter adapt;
        int id;

        public void Permissoes(string permissoes)
        {
            if(permissoes == "Vendas")
            {
                pBAdd.Visible = false;
                btnAdd.Visible = false;
                pBApagar.Visible = false;
                btnApagar.Visible = false;
                pBEditar.Visible = false;
                btnEditar.Visible = false;
                btnRemover.Visible = false;
            }
            else if (permissoes == "Stocks")
            {
                pBApagar.Visible = false;
                btnApagar.Visible = false;
            }
        }

        public Produtos()
        {
            conn = new SqlConnection(conString);
            InitializeComponent();
            MostraTodosProdutos();
        }

        public void MostraTodosProdutos()
        {
            conn.Open();

            DataTable dt2 = new DataTable();
            adapt = new SqlDataAdapter("select * from dbo.Opcoes", conn);
            adapt.Fill(dt2);
            DataRow dr2 = dt2.Rows[0];
            int avisoSt = Convert.ToInt32(dr2["AvisoStock"].ToString());
            int avisoVal = Convert.ToInt32(dr2["AvisoValidade"].ToString());

            //Adicionamos os meses (dentro dos parenteses) à data actual para comparar se as validades ja la chegaram!
            DateTime dateTime = DateTime.Now.AddMonths(avisoVal);

            DataTable dt = new DataTable();
            adapt = new SqlDataAdapter("select * from dbo.Produtos", conn);
            adapt.Fill(dt);
            dataGridProdutos.DataSource = dt;
            
            DateTime validade;

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = dt.Rows[i];

                dataGridProdutos.Rows[i].Cells[3].Style.Format = "C2";
                dataGridProdutos.Rows[i].Cells[4].Style.Format = "C2";

                if (dr["Aviso"].ToString() == "Sim")
                {
                    validade = Convert.ToDateTime(dr["Validade"]);

                    if (validade <= dateTime)
                    {
                        dataGridProdutos.Rows[i].DefaultCellStyle.BackColor = Color.DarkRed; // Cor de fundo
                        dataGridProdutos.Rows[i].DefaultCellStyle.ForeColor = Color.White; // Cor do texto
                    }

                    if (Convert.ToInt32(dr["Quantidade"]) < avisoSt) //A quantidade que queremos o aviso de stocks
                    {
                        dataGridProdutos.Rows[i].DefaultCellStyle.BackColor = Color.DarkRed; // Cor de fundo
                        dataGridProdutos.Rows[i].DefaultCellStyle.ForeColor = Color.White; // Cor do texto
                    }
                }
            }
            conn.Close();
        }

        private void MostraTipos(string tipoP)
        {
            conn.Open();
            cmd = new SqlCommand("select * from dbo.Produtos WHERE TipoProduto = @TipoProduto", conn);
            cmd.Parameters.AddWithValue("@TipoProduto", tipoP);
            adapt = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapt.Fill(dt);
            dataGridProdutos.DataSource = dt;
            conn.Close();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dataGridProdutos.Rows[i].Cells[3].Style.Format = "C2";
                dataGridProdutos.Rows[i].Cells[4].Style.Format = "C2";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MostraTipos("Vestuário");
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void btnCal_Click(object sender, EventArgs e)
        {
            MostraTipos("Calçado");
        }

        private void btn_Equ_Click(object sender, EventArgs e)
        {
            MostraTipos("Equipamento");
        }

        private void btnSup_Click(object sender, EventArgs e)
        {
            MostraTipos("Suplemento");
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnTodos_Click(object sender, EventArgs e)
        {
            MostraTodosProdutos();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddProduto addProduto = new AddProduto(); 
            addProduto.Text = "Registar Produto";
            addProduto.ShowDialog();
        }

        private void dataGridProdutos_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridProdutos.Rows[e.RowIndex].Cells[0].Value != null)
            {
                id = Convert.ToInt32(dataGridProdutos.Rows[e.RowIndex].Cells[0].Value.ToString());
                pictureBoxPreview.ImageLocation = dataGridProdutos.Rows[e.RowIndex].Cells[9].Value.ToString();
                txtDesc.Text = dataGridProdutos.Rows[e.RowIndex].Cells[8].Value.ToString();

                
                if (this.MdiParent is FMenu fmenu)
                {
                    fmenu.Seleccao(dataGridProdutos.Rows[e.RowIndex].Cells[1].Value.ToString());
                }
                
            }
        }

        private void dataGridProdutos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnApagar_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Tem certeza que deseja apagar este registo?", "Confirmação de Exclusão", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                cmd = new SqlCommand("DELETE FROM dbo.Produtos WHERE ProdutoID = @produtoid", conn);
                conn.Open();
                cmd.Parameters.AddWithValue("@produtoid", id);
                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Registo apagado com sucesso!");
                MostraTodosProdutos();
            }
        }

        //Pesquisar por Id
        private void btnId_Click(object sender, EventArgs e)
        {
            txtNome.Text = "";
            if (txtId.Text != "")
            {
                try
                {
                    conn.Open();
                    DataTable dt = new DataTable();
                    adapt = new SqlDataAdapter("select * from dbo.Produtos WHERE ProdutoID LIKE '%" + txtId.Text + "%'", conn);
                    adapt.Fill(dt);
                    dataGridProdutos.DataSource = dt;
                    dataGridProdutos.Columns["PrecoVenda"].DefaultCellStyle.Format = "C2";
                    dataGridProdutos.Columns["PrecoCompra"].DefaultCellStyle.Format = "C2";
                    conn.Close();
                }
                catch (Exception)
                {
                    MessageBox.Show("Erro na pesquisa!", "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MostraTodosProdutos();
            }
        }

        private void btnNome_Click(object sender, EventArgs e)
        {
            txtId.Text = "";
            if (txtNome.Text != "")
            {
                try
                {
                    conn.Open();
                    DataTable dt = new DataTable();
                    adapt = new SqlDataAdapter("select * from dbo.Produtos WHERE NomeProduto LIKE '%" + txtNome.Text + "%'", conn);
                    adapt.Fill(dt);
                    dataGridProdutos.DataSource = dt;
                    dataGridProdutos.Columns["PrecoVenda"].DefaultCellStyle.Format = "C2";
                    dataGridProdutos.Columns["PrecoCompra"].DefaultCellStyle.Format = "C2";
                    conn.Close();
                }
                catch (Exception)
                {
                    MessageBox.Show("Erro na pesquisa!", "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MostraTodosProdutos();
            }
        }

        private void txtId_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnId.PerformClick();
            }
        }

        private void txtNome_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnNome.PerformClick();
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            AddProduto addProduto = new AddProduto();
            addProduto.Text = "Editar Produto";
            addProduto.EditarProduto(id);
            addProduto.ShowDialog();
        }

        private void btnRemover_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Tem a certeza que deseja remover aviso deste produto?", "Confirmação de Exclusão", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                cmd = new SqlCommand("UPDATE dbo.Produtos set Aviso = @aviso Where ProdutoID = @produtoId", conn);
                conn.Open();
                cmd.Parameters.AddWithValue("@aviso", "Não");
                cmd.Parameters.AddWithValue("@produtoId", id);
                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Aviso removido com sucesso!", "Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MostraTodosProdutos();
                if (this.MdiParent is FMenu fMenu) fMenu.VerificaVS(); //Verifica se o formulário pai é o FMenu e chama o método VerificaVS
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Tem a certeza que deseja incluir produto nos avisos?", "Confirmação de Exclusão", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                cmd = new SqlCommand("UPDATE dbo.Produtos set Aviso = @aviso Where ProdutoID = @produtoId", conn);
                conn.Open();
                cmd.Parameters.AddWithValue("@aviso", "Sim");
                cmd.Parameters.AddWithValue("@produtoId", id);
                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Aviso removido com sucesso!", "Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MostraTodosProdutos();
                if (this.MdiParent is FMenu fMenu) fMenu.VerificaVS(); //Verifica se o formulário pai é o FMenu e chama o método VerificaVS
            }
        }
    }
}
