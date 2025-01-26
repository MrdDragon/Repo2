//-----------------------------------------------------------------
//    <copyright file="Opcoes.cs"    company="IPCA">
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
    public partial class Opcoes : Form
    {
        string conString = Connecao.GetConString();
        SqlConnection conn;
        SqlCommand cmd;
        SqlDataAdapter adapt;

        public Opcoes()
        {
            conn = new SqlConnection(conString);
            InitializeComponent();
            CarregarOpcoes();
        }

        public void CarregarOpcoes()
        {
            conn.Open();
            cmd = new SqlCommand("select * from dbo.Opcoes", conn);
            adapt = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapt.Fill(dt);

            DataRow dr = dt.Rows[0];
            txtStock.Text = Convert.ToString(dr["AvisoStock"]);
            txtVal.Text = Convert.ToString(dr["AvisoValidade"]);
            conn.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtStock.Text != "" && txtVal.Text !="")
            {
                cmd = new SqlCommand("UPDATE dbo.Opcoes set AvisoStock = @avisoStock, AvisoValidade = @avisoValidade Where Opid = @opid", conn);
                conn.Open();
                cmd.Parameters.AddWithValue("@avisoStock", txtStock.Text);
                cmd.Parameters.AddWithValue("@avisoValidade", txtVal.Text);
                cmd.Parameters.AddWithValue("@opid", 1);

                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Guardado com sucesso!");
            }
            else if(txtStock.Text == "" && txtVal.Text != "")
            {
                cmd = new SqlCommand("UPDATE dbo.Opcoes set AvisoValidade = @avisoValidade Where Opid = @opid", conn);
                conn.Open();
                cmd.Parameters.AddWithValue("@avisoValidade", txtVal.Text);
                cmd.Parameters.AddWithValue("@opid", 1);

                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Guardado com sucesso!");
            }
            else if(txtStock.Text != "" && txtVal.Text == "")
            {
                cmd = new SqlCommand("UPDATE dbo.Opcoes set AvisoStock = @avisoStock Where Opid = @opid", conn);
                conn.Open();
                cmd.Parameters.AddWithValue("@avisoStock", txtStock.Text);
                cmd.Parameters.AddWithValue("@opid", 1);

                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Guardado com sucesso!");
            }

            if (this.MdiParent is FMenu fMenu) fMenu.VerificaVS(); //Verifica se o formulário pai é o FMenu e chama o método VerificaVS

        }

        private void txtStock_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verificar se o caractere pressionado não é um número ou teclas de controle
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                // Cancelar a entrada se não for um número ou tecla de controle
                e.Handled = true;

                MessageBox.Show("Por favor, insira apenas números.", "Atenção!");
            }
        }

        private void txtVal_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verificar se o caractere pressionado não é um número ou teclas de controle
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                // Cancelar a entrada se não for um número ou tecla de controle
                e.Handled = true;

                MessageBox.Show("Por favor, insira apenas números.", "Atenção!");
            }
        }
    }
}
