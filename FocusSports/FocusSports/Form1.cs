//-----------------------------------------------------------------
//    <copyright file="Form1.cs"    company="IPCA">
//     Copyright (c) IPCA-EST 2024. All rights reserved.
//    </copyright>
//    <date>2024-11-22</date>
//    <time>22:01</time>
//    <version>0.1</version>
//    <author>D.Oliveira</author>
//    <description>FocusSports-Login</description>
//-----------------------------------------------------------------
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace FocusSports
{
    
    public partial class Form_Login : Form
    {
        
        string conString = Connecao.GetConString();
        SqlConnection conn;
        SqlCommand cmd;
        SqlDataAdapter adapt;
    
        public Form_Login()
        {
            conn = new SqlConnection(conString);
            InitializeComponent();
            txt_Nome.Focus();
        }


        private void txt_Nome_TextChanged(object sender, EventArgs e)
        {
            VerificaTexto();
        }
        private void txt_Pass_TextChanged(object sender, EventArgs e)
        { 
            VerificaTexto();
        }

        //Metodo para ativar ou desativar o botão se não tiver dados introduzidos
        private void VerificaTexto()
        {
            if (string.IsNullOrEmpty(txt_Nome.Text) || string.IsNullOrEmpty(txt_Pass.Text))
            {
                button_Sub.Enabled = false;
            }
            else 
            {
                button_Sub.Enabled = true;
            }
        }

        private void button_Sub_Click(object sender, EventArgs e)
        {
            conn.Open();
            cmd = new SqlCommand("Select * From Utilizadores WHERE Utilizador = @Utilizador and Password = @Password", conn);
            cmd.Parameters.AddWithValue("@Utilizador", txt_Nome.Text);
            cmd.Parameters.AddWithValue("@Password", txt_Pass.Text);

            adapt = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapt.Fill(dt);
            
            if(dt.Rows.Count == 1)
            {
                FMenu fMenu = new FMenu();

                string permissoes = dt.Rows[0]["Permissoes"].ToString();
                fMenu.Permissoes(permissoes);

                this.Hide();
                fMenu.ShowDialog();
                this.Close();
            }
            else
            {
                cmd = new SqlCommand("Select * From Utilizadores WHERE Utilizador = @Utilizador", conn);
                cmd.Parameters.AddWithValue("@Utilizador", txt_Nome.Text);

                adapt = new SqlDataAdapter(cmd);
                DataTable dt2 = new DataTable();
                adapt.Fill(dt2);

                if (dt2.Rows.Count == 1)
                {
                    MessageBox.Show("Palavra-passe Inválida!", "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txt_Pass.Focus();
                }
                else
                {
                    MessageBox.Show("Utilizador inválido!", "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txt_Nome.Focus();
                }
                
            }

            conn.Close();
        }

        

        private void label2_Click(object sender, EventArgs e)
        {

        }


        //Para esconder ou ver a palavra-pass
        private void cb_pass_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_pass.Checked)
            {
                txt_Pass.PasswordChar = '\0';
            }
            else
            {
                txt_Pass.PasswordChar = '*';
            }
        }

        //Muda a cor do funda dac caixa de texto
        private void txt_Nome_Enter(object sender, EventArgs e)
        {
            txt_Nome.BackColor = Color.AliceBlue;
        }

        private void txt_Nome_Leave(object sender, EventArgs e)
        {
            txt_Nome.BackColor = Color.White;
        }

        private void txt_Pass_Enter(object sender, EventArgs e)
        {
            txt_Pass.BackColor = Color.AliceBlue;
        }

        private void txt_Pass_Leave(object sender, EventArgs e)
        {
            txt_Pass.BackColor = Color.White;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            FMenu fMenu = new FMenu();
            fMenu.Permissoes("Administrador");
            fMenu.ShowDialog();
            this.Close();
        }
    }
}
