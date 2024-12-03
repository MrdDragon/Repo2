//-----------------------------------------------------------------
//    <copyright file="Registar.cs"    company="IPCA">
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
    public partial class Registar : Form
    {

        string conString = Connecao.GetConString();
        SqlConnection conn;
        SqlCommand cmd;
        SqlDataAdapter adapt;
        string typuser = "Cliente";
        

        public void Permissoes(string permissoes)
        {
            if (permissoes != "Administrador")
            {
                btnUti.Visible = false;
                btnAdmin.Visible = false;
                btnStocks.Visible = false;
                dataGridView1.Visible = false;
                btnCliente_Click(btnCliente, EventArgs.Empty);
            }
        }

        public Registar()
        {
            conn = new SqlConnection(conString);
            InitializeComponent();
            MostraClientes();
            
        }

        // Ver os Utilizadores na DataGridView
        private void MostraUtilizadores()
        {
            conn.Open();
            DataTable dt = new DataTable();
            adapt = new SqlDataAdapter("select * from dbo.Utilizadores", conn);
            adapt.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
        }

        // Ver os Clientes na DataGridView
        private void MostraClientes()
        {
            conn.Open();
            DataTable dt = new DataTable();
            adapt = new SqlDataAdapter("select * from dbo.Clientes", conn);
            adapt.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
        }


        private void NovoUtilizador(string tipoUser)
        {
            if(tipoUser == "Cliente")
            {

                //cmd = new SqlCommand("Insert Into tbl_Record(Name,State) values(@name,@state)", conn);
                //conn.Open();
                //cmd.Parameters.AddWithValue("@name", txt_Utilizador.Text);
                //cmd.Parameters.AddWithValue("@state", txt_Nome.Text);
                //cmd.Parameters.AddWithValue("@name", txt_Email.Text);
                //cmd.Parameters.AddWithValue("@state", txt_Pass.Text);
                //cmd.ExecuteNonQuery();
                //conn.Close();
                //MessageBox.Show("Utilizador registado com sucesso!");
                MostraClientes();
            }
            else
            {
                cmd = new SqlCommand("Insert Into dbo.Utilizadores(Utilizador,Nome,Email,Permissoes,Password) VALUES(@utilizador,@nome,@email,@permissoes,@password)", conn);
                conn.Open();
                cmd.Parameters.AddWithValue("@utilizador", txt_Utilizador.Text);
                cmd.Parameters.AddWithValue("@nome", txt_Nome.Text);
                cmd.Parameters.AddWithValue("@email", txt_Email.Text);
                cmd.Parameters.AddWithValue("@password", txt_Pass.Text);
                cmd.Parameters.AddWithValue("@permissoes", tipoUser);
                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Utilizador registado com sucesso!");
                MudarLabels();

            }

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(typuser != "Cliente")
            {
                if (txt_Utilizador.Text != "" && txt_Pass.Text != "" && txt_Email.Text != "" && txt_Nome.Text != "")
                {
                    NovoUtilizador(typuser);
                }
                else
                {
                    MessageBox.Show("Preencha todos os campos!");
                }
            }
            else
            {
                if (txt_Utilizador.Text != "" && txt_Pass.Text != "" && txt_Email.Text != "" && txt_Nome.Text != "" && txt_Dist.Text != "" && txt_Tele.Text != "" && txt_Pais.Text != "")
                {
                    NovoUtilizador(typuser);
                }
                else
                {
                    MessageBox.Show("Preencha todos os campos!");
                }
               
            }

        }

        //Muda as Labels para Utilizadores e limpa os campos
        private void MudarLabels()
        {
            label1.Text = "Utilizador";
            label3.Text = "Palavra-passe";
            txt_Pass.PasswordChar = '*';
            checkBox1.Visible = true;
            labeldesc.Visible = true;
            txt_Pass.Size = new Size(265, 27);
            txt_Pass.Text = "";
            txt_Utilizador.Text = "";
            txt_Nome.Text = "";
            txt_Email.Text = "";
            txt_Dist.Visible = false;
            txt_Dist.Text = "";
            txt_Nota.Visible = false;
            txt_Nota.Text = "";
            txt_Pais.Visible = false;
            txt_Pais.Text = "";
            txt_Tele.Visible = false;
            txt_Tele.Text = "";
            label6.Visible = false;
            label7.Visible = false;
            label8.Visible = false;
            label9.Visible = false;
            MostraUtilizadores();

        }

        private void btnStocks_Click(object sender, EventArgs e)
        {
            labeldesc.Text = "Pode adicionar à base de dados, mas não pode apagar registos, nem criar novos Utilizadores!";
            typuser = "Stocks";
            MudarLabels();
            labelregistar.Text = "Registar Utilizador: Stocks";
        }

        private void btnAdmin_Click(object sender, EventArgs e)
        {
            labeldesc.Text = "Acesso Total!";
            typuser = "Administrador";
            MudarLabels();
            labelregistar.Text = "Registar Utilizador: Administrador";
        }

        private void btnCliente_Click(object sender, EventArgs e)
        {
            label6.Visible = true;
            label7.Visible = true;
            label8.Visible = true;
            label9.Visible = true;
            txt_Pais.Visible = true;
            txt_Tele.Visible = true;
            txt_Nota.Visible = true;
            txt_Dist.Visible = true;
            labeldesc.Visible = false;
            txt_Pass.Size = new Size(125, 27);
            typuser = "Cliente";
            label1.Text = "Morada";
            label3.Text = "Código-Postal";
            txt_Pass.PasswordChar = '\0';
            labelregistar.Text = "Registar Cliente";
            checkBox1.Visible = false;
            MostraClientes();
        }

        private void btnUti_Click(object sender, EventArgs e)
        {
            labeldesc.Text = "Pode aceder à base de dados sem alterar, não pode criar novos Utilizadores!";
            typuser = "Vendas";
            MudarLabels();
            labelregistar.Text = "Registar Utilizador: Vendas";
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                txt_Pass.PasswordChar = '\0';
            }
            else
            {
                txt_Pass.PasswordChar = '*';
            }
        }
    }
}
