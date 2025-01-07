//-----------------------------------------------------------------
//    <copyright file="Produtos.cs"    company="IPCA">
//     Copyright (c) IPCA-EST 2024. All rights reserved.
//    </copyright>
//    <date>2024-11-22</date>
//    <time>22:05</time>
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace FocusSports
{
    public partial class Produtos : Form
    {
        string conString = Connecao.GetConString();
        SqlConnection conn;
        SqlCommand cmd;
        SqlDataAdapter adapt;

        int id = 0;

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
            DataTable dt = new DataTable();
            adapt = new SqlDataAdapter("select * from dbo.Produtos", conn);
            adapt.Fill(dt);
            dataGridProdutos.DataSource = dt;
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
            addProduto.ShowDialog();
        }

        private void dataGridProdutos_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridProdutos.Rows[e.RowIndex].Cells[0].Value != null)
            {
                id = Convert.ToInt32(dataGridProdutos.Rows[e.RowIndex].Cells[0].Value.ToString());
                pictureBoxPreview.ImageLocation = dataGridProdutos.Rows[e.RowIndex].Cells[9].Value.ToString();
                btnEditar.Enabled = true;
                btnApagar.Enabled = true;
            }

        }
    }
}
