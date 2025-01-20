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
    public partial class Clientes : Form
    {
        string conString = Connecao.GetConString();
        SqlConnection conn;
        SqlCommand cmd;
        SqlDataAdapter adapt;

        public Clientes()
        {
            conn = new SqlConnection(conString);
            InitializeComponent();
            MostrarClientes();
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
                    // Obtém o filho Distrito
                    TreeNode fDistrito = noFiltrar.Nodes[0];

                    if (!VerificaNos(fDistrito.Nodes, dr[filtroC].ToString()))
                    {
                        // Adiciona novo distrito
                        fDistrito.Nodes.Add(dr[filtroC].ToString());
                    }
                }
                else
                {
                    // Obtém o filho Pais
                    TreeNode fPais = noFiltrar.Nodes[1];

                    if (!VerificaNos(fPais.Nodes, dr[filtroC].ToString()))
                    {
                        // Adiciona novo País
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
    }
}
