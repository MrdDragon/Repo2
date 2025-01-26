//-----------------------------------------------------------------
//    <copyright file="Encomendas.cs"    company="IPCA">
//     Copyright (c) IPCA-EST 2024. All rights reserved.
//    </copyright>
//    <date>2024-11-22</date>
//    <time>22:05</time>
//    <version>0.1</version>
//    <author>Daniel.O & Andreia.M</author>
//    <description>FocusSports</description>
//-----------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace FocusSports
{
    public partial class Encomendas : Form
    {

        string conString = Connecao.GetConString();
        SqlConnection conn;
        SqlCommand cmd;
        SqlDataAdapter adapt;
        int idProduto = 0, idCliente = 0, utilizadorId;
        string idVenda = "";

        public Encomendas()
        {
            conn = new SqlConnection(conString);
            InitializeComponent();
            MostraTodosProdutos();
        }

        public void Permissoes(string permissoes)
        {
            if (permissoes != "Administrador")
            {
                pictureBox3.Visible = false;
                pictureBox2.Visible = false;
                btnHist.Visible = false;
                btnVender.Visible = false;
            }
        }
        public void ClienteID(int id, int utId)
        {
            utilizadorId = utId;
            idCliente = id;
            btnCliente.Text = $"Cliente: {idCliente}";
        }

        private void MostraTipos(string tipoP)
        {
            conn.Open();
            cmd = new SqlCommand("select ProdutoID, NomeProduto, Tamanho, PrecoVenda, Quantidade from dbo.Produtos WHERE TipoProduto = @TipoProduto", conn);
            cmd.Parameters.AddWithValue("@TipoProduto", tipoP);
            adapt = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapt.Fill(dt);
            dataGridProdutos.DataSource = dt;
            conn.Close();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dataGridProdutos.Rows[i].Cells[3].Style.Format = "C2";
            }
        }

        private void AtualizarTotal()
        {
            decimal total = 0;
            int count = 0;

            foreach (DataGridViewRow row in dataGridVenda.Rows)
            {
                if (row.Cells["Subtotal"].Value != null)
                {
                    count++;
                    total += Convert.ToDecimal(row.Cells["Subtotal"].Value);
                }
            }
            if (count == 0)
            {
                btnVFinal.Enabled = false;
            }
            txtTotal.Text = $"{total:F2}";
        }

        public void MostraTodosProdutos()
        {
            conn.Open();

            DataTable dt = new DataTable();
            adapt = new SqlDataAdapter("select ProdutoID, NomeProduto, Tamanho, PrecoVenda as [Preço], Quantidade from dbo.Produtos", conn);
            adapt.Fill(dt);
            dataGridProdutos.DataSource = dt;
            dataGridProdutos.Columns["Preço"].DefaultCellStyle.Format = "C2";
            conn.Close();
        }
        private void btnTodos_Click(object sender, EventArgs e)
        {
            MostraTodosProdutos();
        }

        private void btnVest_Click(object sender, EventArgs e)
        {
            MostraTipos("Vestuário");
        }

        private void btnCal_Click(object sender, EventArgs e)
        {
            MostraTipos("Calçado");
        }

        private void btnEqui_Click(object sender, EventArgs e)
        {
            MostraTipos("Equipamento");
        }

        private void btnSup_Click(object sender, EventArgs e)
        {
            MostraTipos("Suplemento");
        }

        private void btnId_Click(object sender, EventArgs e)
        {
            txtNome.Text = "";
            if (txtId.Text != "")
            {
                try
                {
                    conn.Open();
                    DataTable dt = new DataTable();
                    adapt = new SqlDataAdapter("select ProdutoID, NomeProduto, Tamanho, PrecoVenda, Quantidade from dbo.Produtos WHERE ProdutoID LIKE '%" + txtId.Text + "%'", conn);
                    adapt.Fill(dt);
                    dataGridProdutos.DataSource = dt;
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        dataGridProdutos.Rows[i].Cells[3].Style.Format = "C2";
                    }
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
                    adapt = new SqlDataAdapter("select ProdutoID, NomeProduto, Tamanho, PrecoVenda, Quantidade from dbo.Produtos WHERE NomeProduto LIKE '%" + txtNome.Text + "%'", conn);
                    adapt.Fill(dt);
                    dataGridProdutos.DataSource = dt;
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        dataGridProdutos.Rows[i].Cells[3].Style.Format = "C2";
                    }
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

        private void btnHist_Click(object sender, EventArgs e)
        {
            lblQuantidade.Visible = false;
            txtQuantidade.Visible = false;
            btnCliente.Visible = false;
            btnId.Visible = false;
            btnNome.Visible = false;
            txtId.Visible = false;
            txtNome.Visible = false;
            btnTodos.Enabled = false;
            btnVest.Enabled = false;
            btnCal.Enabled = false;
            btnEqui.Enabled = false;
            btnSup.Enabled = false;
            dataGridVenda.Visible = false;
            lblPesq.Visible = true;
            cbPesquisa.Visible = true;
            tableLayoutPanel2.ColumnStyles[1].Width = 0;
            btnAdd.Visible = false;

            conn.Open();

            DataTable dt = new DataTable();
            adapt = new SqlDataAdapter("SELECT Vendas.VendaID, Clientes.NomeCliente, Clientes.Pais, Vendas.DataVenda, Vendas.TotalVenda," +
                " Utilizadores.Utilizador FROM Clientes INNER JOIN Vendas ON Clientes.ClienteID = Vendas.ClienteID INNER JOIN Utilizadores ON" +
                " Vendas.UtilizadorID = Utilizadores.UtilizadorID", conn);
            adapt.Fill(dt);
            dataGridProdutos.DataSource = dt;

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dataGridProdutos.Rows[i].Cells[4].Style.Format = "C2";
            }
            conn.Close();
        }

        private void cbPesquisa_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Quando uma tecla é primida dentro da comboBox dos Tipos, ignora e não faz nada
            e.Handled = true;
        }

        private void cbPesquisa_SelectedValueChanged(object sender, EventArgs e)
        {
            DateTime dateTimeP = DateTime.Now;
            decimal totalV = 1000;

            string query = "";
            bool totalFiltro = false;
            bool dataFiltro = false;

            // Determinar o filtro com base na seleção
            if (cbPesquisa.SelectedItem.ToString() == "Última semana")
            {
                dateTimeP = DateTime.Now.AddDays(-7);
                dataFiltro = true;
            }
            else if (cbPesquisa.SelectedItem.ToString() == "Último mês")
            {
                dateTimeP = DateTime.Now.AddMonths(-1);
                dataFiltro = true;
            }
            else if (cbPesquisa.SelectedItem.ToString() == "Último ano")
            {
                dateTimeP = DateTime.Now.AddYears(-1);
                dataFiltro = true;
            }
            else if (cbPesquisa.SelectedItem.ToString() == "Total < 1000")
            {
                query = "SELECT Vendas.VendaID, Clientes.NomeCliente, Clientes.Pais, Vendas.DataVenda, Vendas.TotalVenda, Utilizadores.Utilizador " +
                        "FROM Clientes " +
                        "INNER JOIN Vendas ON Clientes.ClienteID = Vendas.ClienteID " +
                        "INNER JOIN Utilizadores ON Vendas.UtilizadorID = Utilizadores.UtilizadorID " +
                        "WHERE TotalVenda < @totalVenda";
                totalFiltro = true;
            }
            else if (cbPesquisa.SelectedItem.ToString() == "Total > 1000")
            {
                query = "SELECT Vendas.VendaID, Clientes.NomeCliente, Clientes.Pais, Vendas.DataVenda, Vendas.TotalVenda, Utilizadores.Utilizador " +
                        "FROM Clientes " +
                        "INNER JOIN Vendas ON Clientes.ClienteID = Vendas.ClienteID " +
                        "INNER JOIN Utilizadores ON Vendas.UtilizadorID = Utilizadores.UtilizadorID " +
                        "WHERE TotalVenda > @totalVenda";
                totalFiltro = true;
            }

            try
            {
                conn.Open();
                DataTable dt = new DataTable();

                // Configurar o adaptador com base nos filtros
                if (totalFiltro)
                {
                    adapt = new SqlDataAdapter(query, conn);
                    adapt.SelectCommand.Parameters.AddWithValue("@totalVenda", totalV);
                }
                else if (dataFiltro)
                {
                    adapt = new SqlDataAdapter(
                        "SELECT Vendas.VendaID, Clientes.NomeCliente, Clientes.Pais, Vendas.DataVenda, Vendas.TotalVenda, Utilizadores.Utilizador " +
                        "FROM Clientes " +
                        "INNER JOIN Vendas ON Clientes.ClienteID = Vendas.ClienteID " +
                        "INNER JOIN Utilizadores ON Vendas.UtilizadorID = Utilizadores.UtilizadorID " +
                        "WHERE DataVenda >= @dataVenda", conn);
                    adapt.SelectCommand.Parameters.AddWithValue("@dataVenda", dateTimeP);
                }

                if (adapt != null)
                {
                    adapt.Fill(dt);
                    dataGridProdutos.DataSource = dt;
                    dataGridProdutos.Columns["TotalVenda"].DefaultCellStyle.Format = "C2";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro na pesquisa! {ex.Message}", "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
            }
    }

        private void btnVender_Click(object sender, EventArgs e)
        {
            lblQuantidade.Visible = true;
            txtQuantidade.Visible = true;
            btnCliente.Visible = true;
            btnId.Visible = true;
            btnNome.Visible = true;
            txtId.Visible = true;
            txtNome.Visible = true;
            btnTodos.Enabled = true;
            btnVest.Enabled = true;
            btnCal.Enabled = true;
            btnEqui.Enabled = true;
            btnSup.Enabled = true;
            dataGridVenda.Visible = true;
            lblPesq.Visible = false;
            cbPesquisa.Visible = false;
            tableLayoutPanel2.ColumnStyles[1].Width = 450;
            btnAdd.Visible = true;
            MostraTodosProdutos();
        }

        private void dataGridProdutos_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridProdutos.Rows[e.RowIndex].Cells[0].Value != null)
            {
                idProduto = Convert.ToInt32(dataGridProdutos.Rows[e.RowIndex].Cells[0].Value.ToString());
                btnAdd.Enabled = true;
                btnRemover.Enabled = false;
            }
        }
       
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (btnCliente.Text != "Cliente: 0")
            {
                if (idProduto != 0)
                {
                    for (int i = 0; i < dataGridProdutos.Rows.Count; i++)
                    {
                        if (Convert.ToInt32(dataGridProdutos.Rows[i].Cells[0].Value) == idProduto)
                        {
                            string nome = dataGridProdutos.Rows[i].Cells[1].Value.ToString();
                            string tamanho = dataGridProdutos.Rows[i].Cells[2].Value.ToString();
                            decimal preco = Convert.ToDecimal(dataGridProdutos.Rows[i].Cells[3].Value.ToString());
                            int quantidade = Convert.ToInt32(txtQuantidade.Text);
                            decimal subtotal = quantidade * preco;
                            dataGridVenda.Rows.Add(subtotal.ToString("F2"), preco.ToString("F2"), quantidade, tamanho, nome, idProduto);
                            btnVFinal.Enabled = true;
                            AtualizarTotal();
                            break;
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Selecione Cliente!", "Cliente", MessageBoxButtons.OK);
            }

        }

        private void dataGridVenda_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridVenda.Rows[e.RowIndex].Cells[4].Value != null)
            {
                idVenda = dataGridVenda.Rows[e.RowIndex].Cells[4].Value.ToString();
                btnRemover.Enabled = true;
                btnAdd.Enabled = false;
            }
        }

        private void btnRemover_Click(object sender, EventArgs e)
        {
            if (idVenda != "")
            {
                for (int i = 0; i < dataGridVenda.Rows.Count; i++)
                {
                    if (dataGridVenda.Rows[i].Cells[4].Value.ToString() == idVenda)
                    {
                        int rowIndex = dataGridVenda.Rows[i].Index;
                        if (rowIndex >= 0 && rowIndex < dataGridVenda.Rows.Count)
                        {
                            dataGridVenda.Rows.RemoveAt(rowIndex);
                            AtualizarTotal();
                        }
                        else
                        {
                            MessageBox.Show("Índice inválido!");
                        }
                        break;
                    }
                }

            }
        }

        private void btnVFinal_Click(object sender, EventArgs e)
        {
            if (btnCliente.Text != "Cliente: 0")
            {
                DialogResult dialogResult = MessageBox.Show("Tem a certeza que deseja finalizar encomenda?", "Confirmação de Venda", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    conn.Open();
                    SqlTransaction transaction = conn.BeginTransaction();

                    try
                    {
                        DateTime dateTime = DateTime.Now.Date;

                        SqlCommand cmdVenda = new SqlCommand("Insert Into dbo.Vendas(DataVenda,ClienteID,UtilizadorID,TotalVenda) OUTPUT INSERTED.VendaID values(@dataVenda, @clienteId, @utilizadorId, @totalVenda)", conn, transaction);

                        cmdVenda.Parameters.AddWithValue("@dataVenda", dateTime);
                        cmdVenda.Parameters.AddWithValue("@clienteId", idCliente);
                        cmdVenda.Parameters.AddWithValue("@utilizadorId", utilizadorId);
                        cmdVenda.Parameters.AddWithValue("@totalVenda", Convert.ToDouble(txtTotal.Text));
                        int vendaId = (int)cmdVenda.ExecuteScalar();

                        Dictionary<int, int> somaQuantidades = new Dictionary<int, int>();

                        for (int i = 0; i < dataGridVenda.Rows.Count; i++)
                        {
                            int produtoId = Convert.ToInt32(dataGridVenda.Rows[i].Cells["ProdutoID"].Value);
                            int quantidade = Convert.ToInt32(dataGridVenda.Rows[i].Cells["Quantidade"].Value);

                            if (somaQuantidades.ContainsKey(produtoId))
                            {
                                somaQuantidades[produtoId] += quantidade;
                            }
                            else
                            {
                                somaQuantidades[produtoId] = quantidade;
                            }
                        }
                        foreach (var item in somaQuantidades)
                        {
                            cmd = new SqlCommand("Insert Into dbo.ProdutoVenda(VendaID,ProdutoID,Quantidade) values(@vendaId, @produtoId, @quantidade)", conn, transaction);
                            cmd.Parameters.AddWithValue("@vendaId", vendaId);
                            cmd.Parameters.AddWithValue("@produtoId", item.Key);
                            cmd.Parameters.AddWithValue("@quantidade", item.Value);
                            cmd.ExecuteNonQuery();

                            SqlCommand cmdAtualizarProduto = new SqlCommand("Update dbo.Produtos Set Quantidade = Quantidade - @quantidade Where ProdutoID = @produtoId", conn, transaction);
                            cmdAtualizarProduto.Parameters.AddWithValue("@quantidade", item.Value);
                            cmdAtualizarProduto.Parameters.AddWithValue("@produtoId", item.Key);
                            cmdAtualizarProduto.ExecuteNonQuery();
                        }
                        transaction.Commit();
                        MessageBox.Show("Compra registada com sucesso!");
                        dataGridVenda.Rows.Clear();
                        btnVFinal.Enabled = false;
                    }
                    catch (Exception ex)
                    {
                        // Reverter a transação em caso de erro
                        transaction.Rollback();
                        MessageBox.Show($"Erro ao realizar a venda: {ex.Message}");
                    }
                        conn.Close();
                }
            }
            else
            {
                MessageBox.Show("Selecione Cliente!", "Cliente", MessageBoxButtons.OK);
            }
            
        }

        private void btnCliente_Click(object sender, EventArgs e)
        {
            if (this.MdiParent is FMenu fMenu)
            {
                fMenu.AbrirClientes();
            }
        }

        private void txtQuantidade_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verificar se o caractere pressionado não é um número ou teclas de controle
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Por favor, insira apenas números.", "Atenção!");
            }
        }
    }
}
