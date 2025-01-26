//-----------------------------------------------------------------
//    <copyright file="Clientes.cs"    company="IPCA">
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace FocusSports
{
    public partial class Clientes : Form
    {
        string conString = Connecao.GetConString();
        SqlConnection conn;
        SqlCommand cmd;
        SqlDataAdapter adapt;
        int id = 0;

        public Clientes()
        {
            conn = new SqlConnection(conString);
            InitializeComponent();
            MostrarClientes();
        }

        public void Permissoes(string permissoes)
        {
            string permi = permissoes;
            if (permissoes != "Administrador")
            {
                pBApagar.Visible = false;
                btnApagar.Visible = false;
            }
        }

        private void MostrarClientes()
        {
            conn.Open();
            adapt = new SqlDataAdapter("SELECT * FROM dbo.Clientes", conn);
            DataTable dt = new DataTable();
            adapt.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
        }

        private bool VerificaNos(TreeNodeCollection nodes, string noTxt)
        {
            foreach (TreeNode node in nodes)
            {
                if (node.Text == noTxt)
                {
                    return true; // Nó encontrado
                }
            }
            return false; // Nó não encontrado
        }

        //Filtra os Distritos e Paises existentes na tabela clientes e cria Nós para cada um
        public void FiltrarClientes(string filtroC)
        {
            conn.Open();
            cmd = new SqlCommand("SELECT DISTINCT " + filtroC + " FROM dbo.Clientes ORDER BY " + filtroC + " ASC", conn);
            
            adapt = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapt.Fill(dt);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = dt.Rows[i];

                // Obtém o nó principal
                TreeNode noFiltrar = treeView1.Nodes[0];
                
                if (filtroC == "Distrito")
                {
                    // Obtém o filho "Distrito"
                    TreeNode fDistrito = noFiltrar.Nodes[0];

                    if (!VerificaNos(fDistrito.Nodes, dr[filtroC].ToString()))
                    {
                        // Adiciona novo distrito
                        fDistrito.Nodes.Add(dr[filtroC].ToString());
                    }
                }
                else
                {
                    // Obtém o filho "Pais"
                    TreeNode fPais = noFiltrar.Nodes[1];

                    if (!VerificaNos(fPais.Nodes, dr[filtroC].ToString()))
                    {
                        // Adiciona novo "País"
                        fPais.Nodes.Add(dr[filtroC].ToString());
                    }
                }
                
                treeView1.ExpandAll();
            }   

            conn.Close();
        }

        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            // Obtém o nó clicado
            TreeNode noClicado = e.Node;
            TreeNode noPai = noClicado.Parent; // O nó pai

            if (noPai != null)
            {
                if (noPai.Text == "Filtrar por:")
                {
                    if (noClicado.Text == "Distrito")
                    {
                        FiltrarClientes("Distrito");
                    }
                    else if (noClicado.Text == "Pais")
                    {
                        FiltrarClientes("Pais");
                    }
                }
                else
                {
                    conn.Open();
                    adapt = new SqlDataAdapter("SELECT * FROM dbo.Clientes WHERE " + noPai.Text + " = '" + noClicado.Text + "'", conn);
                    DataTable dt = new DataTable();
                    adapt.Fill(dt);
                    dataGridView1.DataSource = dt;
                    conn.Close();
                }


            }
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtNome.Text != "")
            {
                try
                {
                    conn.Open();
                    DataTable dt = new DataTable();
                    adapt = new SqlDataAdapter("select * from dbo.Clientes WHERE NomeCliente LIKE '%" + txtNome.Text + "%'", conn);
                    adapt.Fill(dt);
                    dataGridView1.DataSource = dt;
                    conn.Close();
                }
                catch (Exception)
                {
                    MessageBox.Show("Erro na pesquisa!", "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                conn.Open();
                DataTable dt = new DataTable();
                adapt = new SqlDataAdapter("select * from dbo.Clientes", conn);
                adapt.Fill(dt);
                dataGridView1.DataSource = dt;
                conn.Close();
            }
        }

        private void txtNome_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                button1.PerformClick();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnApagar_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Tem certeza que deseja apagar este registo?", "Confirmação de Exclusão", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                cmd = new SqlCommand("DELETE FROM dbo.Clientes WHERE ClienteID = @clienteid", conn);
                conn.Open();
                cmd.Parameters.AddWithValue("@clienteid", id);
                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Registo apagado com sucesso!");
                MostrarClientes();
            }
        }

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows[e.RowIndex].Cells[0].Value != null)
            {
                id = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                
                if (this.MdiParent is FMenu fmenu)
                {
                    //Mostra o nome e email do cliente na barra inferior do menu 
                    fmenu.Seleccao(dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString() + "     " + dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString());
                  
                }

            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (this.MdiParent is FMenu fMenu)
            {
                fMenu.AbrirRegistos(0);
                this.Close();
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (this.MdiParent is FMenu fMenu)
            {
                fMenu.AbrirRegistos(id);
                this.Close();
            }
        }
    }
}
