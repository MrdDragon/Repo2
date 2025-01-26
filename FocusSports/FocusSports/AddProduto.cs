//-----------------------------------------------------------------
//    <copyright file="AddProduto.cs"    company="IPCA">
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
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace FocusSports
{
    public partial class AddProduto : Form
    {
        string conString = Connecao.GetConString();
        SqlConnection conn;
        SqlCommand cmd;
        SqlDataAdapter adapt;
        bool editar = false; //Variavel para saber se é para editar ou adicionar
        int proId = 0;

        public AddProduto()
        {
            conn = new SqlConnection(conString);
            InitializeComponent();
        }

        public void EditarProduto(int id)
        {
            proId = id;
            editar = true;
            conn.Open();
            cmd = new SqlCommand("select * from dbo.Produtos WHERE ProdutoID = @produtoId", conn);
            cmd.Parameters.AddWithValue("@produtoId", id);
            adapt = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapt.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];
                txtNome.Text = Convert.ToString(dr["NomeProduto"]);
                txtTamanho.Text = Convert.ToString(dr["Tamanho"]);
                txtQuantidade.Text = Convert.ToDouble(dr["Quantidade"]).ToString();
                comboBox1.SelectedItem = Convert.ToString(dr["TipoProduto"]);
                dateTimePicker1.Value = Convert.ToDateTime(dr["Validade"]);
                txtNota.Text = Convert.ToString(dr["Nota"]);
                txtCaminhoImagem.Text = Convert.ToString(dr["CaminhoImg"]);
                //O system.glob...CultureInfo... é para aparecer ponto em vez da virgula nos numeros que recebemos da tabela
                txtPrecoV.Text = Convert.ToDouble(dr["PrecoVenda"]).ToString("F2", System.Globalization.CultureInfo.InvariantCulture);
                txtPrecoC.Text = Convert.ToDouble(dr["PrecoCompra"]).ToString("F2", System.Globalization.CultureInfo.InvariantCulture);
                pictureBox1.ImageLocation = Convert.ToString(dr["CaminhoImg"]);
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            
            conn.Close();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e) //Botao de carregar imagem
        {
            //Abre a caixa de dialogo para escolher uma imagem para o produto
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Arquivos de Imagem|*.jpg;*.jpeg;*.png;*.bmp;*.gif";
                openFileDialog.Title = "Selecione uma Imagem";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Obtém o caminho do arquivo selecionado
                    string caminhoImagem = openFileDialog.FileName;

                    txtCaminhoImagem.Text = caminhoImagem;

                    //Mostra a imagem na pictureBox
                    pictureBox1.ImageLocation = caminhoImagem;
                    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                 
                }
            }
        }

        
        private void comboBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Quando uma tecla é primida dentro da comboBox dos Tipos, ignora e não faz nada
            e.Handled = true;
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verificar se o caractere pressionado não é um número ou teclas de controle
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                // Cancelar a entrada se não for um número ou uma tecla de controle
                e.Handled = true;

                //Mensagem de aviso
                MessageBox.Show("Por favor, insira apenas números.","Atenção!");
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verificar se o caractere pressionado não é um número, teclas de controle ou ponto
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != '.')
            {
                // Cancelar a entrada se não for um número, tecla de controle ou ponto
                e.Handled = true;

                //Mensagem de aviso
                MessageBox.Show("Por favor, insira apenas números.", "Atenção!");
            }
           
            // Permitir apenas um ponto decimal
            if (e.KeyChar == '.' && txtPrecoC.Text.Contains("."))
            {
                e.Handled = true;
            }

            // Adicionar zero antes do ponto, se o campo estiver vazio
            if (e.KeyChar == '.' && txtPrecoC.Text == "")
            {
                txtPrecoC.Text = "0";
                txtPrecoC.SelectionStart = txtPrecoC.Text.Length; // Colocar o cursor no final
            }
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verificar se o caractere pressionado não é um número, teclas de controle ou ponto
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != '.')
            {
                // Cancelar a entrada se não for um número, tecla de controle ou ponto
                e.Handled = true;

                //Mensagem de aviso
                MessageBox.Show("Por favor, insira apenas números.", "Atenção!");
            }

            // Permitir apenas um ponto decimal
            if (e.KeyChar == '.' && txtPrecoV.Text.Contains("."))
            {
                e.Handled = true;
            }

            // Adicionar zero antes do ponto, se o campo estiver vazio
            if (e.KeyChar == '.' && txtPrecoV.Text == "")
            {
                txtPrecoV.Text = "0";
                txtPrecoV.SelectionStart = txtPrecoV.Text.Length; // Colocar o cursor no final
            }

        }

        //Quando o valor do tipo de produto é alterado verifica se é suplemento para por a validade visivel
        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem.ToString() == "Suplemento")
            {
                dateTimePicker1.Value = DateTime.Now.Date;
                lblValidade.Visible = true;
                dateTimePicker1.Visible = true;
            }
            else
            {
                dateTimePicker1.Value = new DateTime(9998, 12, 31);
                lblValidade.Visible = false;
                dateTimePicker1.Visible = false;
            }
        }


        //Botão de adicionar produto
        private void button1_Click(object sender, EventArgs e)
        {
            //Verificar se estão preenchidos os campos
            if(txtNome.Text == "" || txtQuantidade.Text == "" || txtPrecoC.Text == "" || txtPrecoV.Text == "" || txtTamanho.Text == "" || comboBox1.SelectedItem == null)
            {
                MessageBox.Show("Por favor preencha todos os campos obrigatórios.", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                if (string.IsNullOrEmpty(txtNome.Text)) lblaviso1.Visible = true;
                if (string.IsNullOrEmpty(txtTamanho.Text)) lblaviso2.Visible = true;
                if (string.IsNullOrEmpty(txtQuantidade.Text)) lblaviso3.Visible = true;
                if (string.IsNullOrEmpty(comboBox1.Text)) lblaviso4.Visible = true;
                if (string.IsNullOrEmpty(txtPrecoC.Text)) lblaviso5.Visible = true;
                if (string.IsNullOrEmpty(txtPrecoV.Text)) lblaviso6.Visible = true;
            }
            else
            {
                //Verifica se é suplemento e está dentro da validade
                if (comboBox1.SelectedItem.ToString() == "Suplemento" && dateTimePicker1.Value < DateTime.Today.Date)
                {
                    MessageBox.Show("Produto fora da validade!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    dateTimePicker1.Focus();
                }
                else
                {
                    if(editar == true)
                    {
                        cmd = new SqlCommand("UPDATE dbo.Produtos set NomeProduto = @nomeProduto, Tamanho = @tamanho, PrecoVenda = @precoVenda, PrecoCompra = @precoCompra, Quantidade = @quantidade, TipoProduto = @tipoProduto, Validade = @validade, Nota = @nota, CaminhoImg = @caminhoImg Where ProdutoID = @produtoId", conn);
                        conn.Open();
                        cmd.Parameters.AddWithValue("@nomeProduto", txtNome.Text);
                        cmd.Parameters.AddWithValue("@tamanho", txtTamanho.Text);
                        cmd.Parameters.AddWithValue("@precoVenda", txtPrecoV.Text);
                        cmd.Parameters.AddWithValue("@precoCompra", txtPrecoC.Text);
                        cmd.Parameters.AddWithValue("@quantidade", txtQuantidade.Text);
                        cmd.Parameters.AddWithValue("@tipoProduto", comboBox1.SelectedItem.ToString());
                        cmd.Parameters.AddWithValue("@validade", dateTimePicker1.Value);
                        cmd.Parameters.AddWithValue("@nota", txtNota.Text);
                        cmd.Parameters.AddWithValue("@caminhoImg", txtCaminhoImagem.Text);
                        cmd.Parameters.AddWithValue("@produtoId", proId);
                        cmd.ExecuteNonQuery();
                        conn.Close();
                        MessageBox.Show("Produto atualizado com sucesso!", "Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    else
                    {
                        cmd = new SqlCommand("Insert Into dbo.Produtos(NomeProduto,Tamanho,PrecoVenda,PrecoCompra,Quantidade,TipoProduto,Validade,Nota,CaminhoImg,Aviso) VALUES(@nomeProduto,@tamanho,@precoVenda,@precoCompra,@quantidade,@tipoProduto,@validade,@nota,@caminhoImg,@aviso)", conn);
                        conn.Open();
                        cmd.Parameters.AddWithValue("@nomeProduto", txtNome.Text);
                        cmd.Parameters.AddWithValue("@tamanho", txtTamanho.Text);
                        cmd.Parameters.AddWithValue("@precoVenda", txtPrecoV.Text);
                        cmd.Parameters.AddWithValue("@precoCompra", txtPrecoC.Text);
                        cmd.Parameters.AddWithValue("@quantidade", txtQuantidade.Text);
                        cmd.Parameters.AddWithValue("@tipoProduto", comboBox1.SelectedItem.ToString());
                        cmd.Parameters.AddWithValue("@validade", dateTimePicker1.Value);
                        cmd.Parameters.AddWithValue("@nota", txtNota.Text);
                        cmd.Parameters.AddWithValue("@caminhoImg", txtCaminhoImagem.Text);
                        cmd.Parameters.AddWithValue("@aviso", "Sim");
                        cmd.ExecuteNonQuery();
                        conn.Close();
                        MessageBox.Show("Produto registado com sucesso!", "Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                }
            }

        }

        private void txtQuantidade_TextChanged(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
