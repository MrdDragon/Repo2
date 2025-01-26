//-----------------------------------------------------------------
//    <copyright file="Registar.cs"    company="IPCA">
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
    public partial class Registar : Form
    {

        string conString = Connecao.GetConString();
        SqlConnection conn;
        SqlCommand cmd;
        SqlDataAdapter adapt;
        string typuser = "Cliente"; //Variavel para saber o tipo de registo
        bool editarCl = false; //Variavel para saber se é para editar ou adicionar Clientes
        bool editarUt = false; //Variavel para saber se é para editar ou adicionar Utilizadores
        int clienteId = 0, utilizadorId = 0;

        public void Permissoes(string permissoes)
        {
            if (permissoes != "Administrador")
            {
                btnUti.Visible = false;
                btnAdmin.Visible = false;
                btnStocks.Visible = false;
                btnCliente.Visible = false;
                pictureBox2.Visible = false;
                pictureBox3.Visible = false;
                btnEditar.Visible = false;
                btnApagar.Visible = false;
                splitter2.Visible = false;
            }
        }

        public Registar()
        {
            conn = new SqlConnection(conString);
            InitializeComponent();
            txt_Pass.Enabled = true;
        }

        public void EditarClientes(int id)
        {
            conn.Open();
            cmd = new SqlCommand("select * from dbo.Clientes WHERE ClienteID = @clienteId", conn);
            cmd.Parameters.AddWithValue("@clienteId", id);
            adapt = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapt.Fill(dt);

            if (this.MdiParent is FMenu fMenu)
            {
                fMenu.AbrirRegistos(0);
            }

            if (dt.Rows.Count > 0)
            {
                btnCancelar.Visible = true;
                clienteId = id;
                labelregistar.Text = "Editar Registo do Cliente";
                editarCl = true;
                DataRow dr = dt.Rows[0];
                txt_Nome.Text = Convert.ToString(dr["NomeCliente"]);
                txt_Tele.Text = Convert.ToString(dr["Telefone"]);
                txt_Utilizador.Text = Convert.ToString(dr["Morada"]);
                txt_Dist.Text = Convert.ToString(dr["Distrito"]);
                txt_Pais.Text = Convert.ToString(dr["Pais"]);
                txt_Email.Text = Convert.ToString(dr["EmailCliente"]);
                txt_Pass.Text = Convert.ToString(dr["CodigoPostal"]);
                txt_Nota.Text = Convert.ToString(dr["Nota"]);
            }

            conn.Close();
        }

        // Ver os Utilizadores na DataGridView
        private void MostraUtilizadores()
        {
            using (SqlConnection conn = new SqlConnection(conString))
            {
                conn.Open();
                DataTable dt = new DataTable();
                adapt = new SqlDataAdapter("select UtilizadorID, Utilizador, Nome, Email, Permissoes from dbo.Utilizadores", conn);
                adapt.Fill(dt);
                dataGridView1.DataSource = dt;
                conn.Close();
            }
        }

        // Verifica se ja existem o utilizador e email
        private void VerificaUtilizador(string utilizador, string email)
        {
            using (SqlConnection conn = new SqlConnection(conString))
            {
                conn.Open();
                DataTable dt = new DataTable();
                adapt = new SqlDataAdapter("select Utilizador from dbo.Utilizadores WHERE Utilizador = '" + utilizador + "'", conn);
                adapt.Fill(dt);

                if (dt.Rows.Count == 1)
                {
                    MessageBox.Show("Utilizador já existente!", "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txt_Utilizador.Focus();
                }
                else
                {
                    adapt = new SqlDataAdapter("select Email from dbo.Utilizadores WHERE EMAIL = '" + email + "'", conn);
                    DataTable dt2 = new DataTable();
                    adapt.Fill(dt2);

                    if (dt2.Rows.Count == 1)
                    {
                        MessageBox.Show("Email já existente!", "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txt_Email.Focus();
                    }
                    else
                    {
                        NovoUtilizador(typuser);

                    }
                }
                conn.Close();
            }
        }

        private void NovoUtilizador(string tipoUser)
        {
            if(tipoUser == "Cliente")
            {
                if (editarCl == true)
                {
                    cmd = new SqlCommand("UPDATE dbo.Clientes set NomeCliente = @nomecliente, Telefone = @telefone, Morada = @morada, Distrito = @distrito, Pais = @pais, EmailCliente = @emailcliente, CodigoPostal = @codigopostal, Nota = @nota Where ClienteID = @clienteId", conn);
                    conn.Open();
                    cmd.Parameters.AddWithValue("@nomecliente", txt_Nome.Text);
                    cmd.Parameters.AddWithValue("@telefone", txt_Tele.Text);
                    cmd.Parameters.AddWithValue("@morada", txt_Utilizador.Text);
                    cmd.Parameters.AddWithValue("@distrito", txt_Dist.Text);
                    cmd.Parameters.AddWithValue("@pais", txt_Pais.Text);
                    cmd.Parameters.AddWithValue("@emailcliente", txt_Email.Text);
                    cmd.Parameters.AddWithValue("@codigopostal", txt_Pass.Text);
                    cmd.Parameters.AddWithValue("@nota", txt_Nota.Text);
                    cmd.Parameters.AddWithValue("@clienteId", clienteId);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("Registo Alterado com sucesso!");
                    LimparCampos();
                }
                else
                {
                    cmd = new SqlCommand("Insert Into dbo.Clientes(NomeCliente,Telefone,Morada,Distrito,Pais,EmailCliente,CodigoPostal,Nota) values(@nomecliente, @telefone, @morada, @distrito, @pais, @emailcliente, @codigopostal, @nota)", conn);
                    conn.Open();
                    cmd.Parameters.AddWithValue("@nomecliente", txt_Nome.Text);
                    cmd.Parameters.AddWithValue("@telefone", txt_Tele.Text);
                    cmd.Parameters.AddWithValue("@morada", txt_Utilizador.Text);
                    cmd.Parameters.AddWithValue("@distrito", txt_Dist.Text);
                    cmd.Parameters.AddWithValue("@pais", txt_Pais.Text);
                    cmd.Parameters.AddWithValue("@emailcliente", txt_Email.Text);
                    cmd.Parameters.AddWithValue("@codigopostal", txt_Pass.Text);
                    cmd.Parameters.AddWithValue("@nota", txt_Nota.Text);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("Cliente registado com sucesso!");
                    LimparCampos();
                }
                    
            }
            else
            {
                if(editarUt == true)
                {
                    using (SqlConnection conn = new SqlConnection(conString))
                    {
                        cmd = new SqlCommand("UPDATE dbo.Utilizadores set Nome = @nome, Email = @email, Utilizador = @utilizador Where UtilizadorID = @utilizadorId", conn);
                        conn.Open();
                        cmd.Parameters.AddWithValue("@utilizador", txt_Utilizador.Text);
                        cmd.Parameters.AddWithValue("@nome", txt_Nome.Text);
                        cmd.Parameters.AddWithValue("@email", txt_Email.Text);
                        cmd.Parameters.AddWithValue("UtilizadorID", utilizadorId);
                        cmd.ExecuteNonQuery();
                        conn.Close();
                        MessageBox.Show("Utilizador editado com sucesso!");
                        MudarLabels();
                    }
                        
                }
                else
                {
                    using (SqlConnection conn = new SqlConnection(conString))
                    {
                        cmd = new SqlCommand("Insert Into dbo.Utilizadores(Utilizador, Nome, Email, Permissoes, Password) VALUES (@utilizador, @nome, @email, @permissoes, HASHBYTES('SHA2_256', @password))", conn);
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
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(typuser != "Cliente")
            {
                if (editarUt == true)
                {
                    if (txt_Utilizador.Text != "" && txt_Email.Text != "" && txt_Nome.Text != "")
                    {
                        NovoUtilizador(typuser);
                    }
                    else
                    {
                        MessageBox.Show("Preencha os campos! (Utilizador, Email, Nome)");
                    }
                }
                else
                {
                    if (txt_Utilizador.Text != "" && txt_Pass.Text != "" && txt_Email.Text != "" && txt_Nome.Text != "")
                    {
                        VerificaUtilizador(txt_Utilizador.Text, txt_Email.Text);
                    }
                    else
                    {
                        MessageBox.Show("Preencha todos os campos!");
                    }
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

        //Muda as Labels para registar Utilizadores em vez de Clientes e limpa os campos
        private void MudarLabels()
        {
            LimparCampos();
            label1.Text = "Utilizador";
            label3.Text = "Palavra-passe";
            txt_Pass.PasswordChar = '*';
            checkBox1.Visible = true;
            labeldesc.Visible = true;
            txt_Pass.Size = new Size(265, 27);
            txt_Dist.Visible = false;
            txt_Nota.Visible = false;
            txt_Pais.Visible = false;
            txt_Tele.Visible = false;
            label6.Visible = false;
            label7.Visible = false;
            label8.Visible = false;
            label9.Visible = false;
            dataGridView1.Visible = true;
            MostraUtilizadores();
            btnCancelar.Visible = false;
        }

        private void LimparCampos()
        {
            txt_Pass.Text = "";
            txt_Utilizador.Text = "";
            txt_Nome.Text = "";
            txt_Email.Text = "";
            txt_Dist.Text = "";
            txt_Nota.Text = "";
            txt_Pais.Text = "";
            txt_Tele.Text = "";
            editarCl = false;
            editarUt = false;
        }

        //Mudar as labels da janela para diferentes tipos de utilizadores
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
            dataGridView1.Visible = false;
            LimparCampos();
            pictureBox2.Visible = false;
            pictureBox3.Visible = false;
            btnEditar.Visible = false;
            btnApagar.Visible = false;
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

        private void txt_Email_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir apenas um astersco
            if (e.KeyChar == '@' && txt_Email.Text.Contains("@"))
            {
                e.Handled = true;
            }
        }

        private void txt_Tele_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verificar se o caractere pressionado é não é um número ou + ou teclas de controle
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != '+')
            {
                // Cancelar a entrada se não for um número, tecla de controle ou ponto
                e.Handled = true;

                //Mensagem de aviso
                MessageBox.Show("Por favor, insira apenas números.", "Atenção!");
            }

            // Permitir apenas um +
            if (e.KeyChar == '+' && txt_Tele.Text.Contains("+"))
            {
                e.Handled = true;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LimparCampos();
            clienteId = 0;
            btnCancelar.Visible = false;
            txt_Pass.Enabled = true;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            
            conn.Open();
            cmd = new SqlCommand("select * from dbo.Utilizadores WHERE UtilizadorID = @utilizadorId", conn);
            cmd.Parameters.AddWithValue("@utilizadorId", utilizadorId);
            adapt = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapt.Fill(dt);
            conn.Close();

            if (dt.Rows.Count > 0)
            {
                editarUt = true;
                DataRow dr = dt.Rows[0];
                txt_Nome.Text = dr["Nome"].ToString();
                txt_Email.Text = dr["Email"].ToString();
                txt_Utilizador.Text = dr["Utilizador"].ToString();
                btnCancelar.Visible = true;
                txt_Pass.Enabled = false;
            }
        }

        private void btnApagar_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Tem certeza que deseja apagar este utilizador?", "Confirmação de Exclusão", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                cmd = new SqlCommand("DELETE FROM dbo.Utilizadores WHERE UtilizadorID = @utilizadorid", conn);
                conn.Open();
                cmd.Parameters.AddWithValue("@utilizadorid", utilizadorId);
                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Registo apagado com sucesso!");
                MostraUtilizadores();
            }
        }

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows[e.RowIndex].Cells[0].Value != null)
            {
                utilizadorId = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                pictureBox2.Visible = true;
                pictureBox3.Visible = true;
                btnEditar.Visible = true;
                btnApagar.Visible = true;
                btnEditar.Enabled = true;
                btnApagar.Enabled = true;

                if (this.MdiParent is FMenu fmenu)
                {
                    fmenu.Seleccao(dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString());
                }

            }

        }
    }
}
