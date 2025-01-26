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
    public partial class Encomendas : Form
    {

        string conString = Connecao.GetConString();
        SqlConnection conn;
        SqlCommand cmd;
        SqlDataAdapter adapt;
        int id;

        public Encomendas()
        {
            conn = new SqlConnection(conString);
            InitializeComponent();
        }

        private void MostraTipos(string tipoP)
        {
            conn.Open();
            cmd = new SqlCommand("select * from dbo.Produtos WHERE TipoProduto = @TipoProduto", conn);
            cmd.Parameters.AddWithValue("@TipoProduto", tipoP);
            adapt = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapt.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
        }

        public void MostraTodosProdutos()
        {
            conn.Open();

            DataTable dt = new DataTable();
            adapt = new SqlDataAdapter("select * from dbo.Produtos", conn);
            adapt.Fill(dt);
            dataGridView1.DataSource = dt;

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = dt.Rows[i];

                dataGridView1.Rows[i].Cells[3].Style.Format = "C2";
                dataGridView1.Rows[i].Cells[4].Style.Format = "C2";
            }
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
    }
}
