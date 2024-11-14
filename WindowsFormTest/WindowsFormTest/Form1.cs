using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WindowsFormTest
{
    public partial class Form1 : Form
    {
        SqlConnection con = new SqlConnection("Data Source=MSI\\SQLEXPRESS;Initial Catalog=demodb;Integrated Security=true;");
        SqlCommand cmd;
        SqlDataAdapter adapt;

        int ID = 0; //Variavel para guardar registo selecionado
        public Form1()
        {
            InitializeComponent();
            DisplayData();
            this.dataGridView1.RowHeaderMouseClick += new DataGridViewCellMouseEventHandler(this.dataGridView1_RowHeaderMouseClick);

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void bt_Apagar_Click(object sender, EventArgs e)
        {
            if (ID != 0)
            {
                DialogResult dialogResult = MessageBox.Show("Tem certeza que deseja apagar este registo?", "Confirmação de Exclusão", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    cmd = new SqlCommand("DELETE FROM tbl_NCidade WHERE ID=@ID", con);
                    con.Open();
                    cmd.Parameters.AddWithValue("@ID", ID);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Registo apagado com sucesso!");
                    DisplayData();
                    ClearData();
                }
            }
            else
            {
                MessageBox.Show("Por favor selecione registo para apagar!");
            }
        }

        private void bt_Inserir_Click(object sender, EventArgs e)
        {
            if(txt_Nome.Text != "" && txt_Cidade.Text != "")
            {
                DialogResult dialogResult = MessageBox.Show("Tem certeza que deseja adicionar este registo?", "Confirmação de Registo", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    cmd = new SqlCommand("INSERT INTO tbl_NCidade(Nome, Cidade) VALUES (@Nome,@Cidade)", con);
                    con.Open();
                    cmd.Parameters.AddWithValue("@Nome", txt_Nome.Text);
                    cmd.Parameters.AddWithValue("@Cidade", txt_Cidade.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Dados Inseridos com Sucesso");
                    con.Close();
                    DisplayData();
                    ClearData();
                }
            }
            else
            {
                MessageBox.Show("Preencha todos os campos!");
            }
        }

        //Mostrar dados no DataGridView
        private void DisplayData()
        {
            con.Open();
            DataTable dt = new DataTable();
            adapt = new SqlDataAdapter("select * from tbl_NCidade", con);
            adapt.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        //Limpar Dados
        private void ClearData()
        {
            txt_Nome.Text = "";
            txt_Cidade.Text = "";
            ID = 0;
        }

        //dataGridView1 RowHeaderMouseClick Event
        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            ID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            txt_Nome.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            txt_Cidade.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
        }
        

        private void bt_Atualizar_Click(object sender, EventArgs e)
        {
            if (txt_Nome.Text != "" && txt_Cidade.Text != "" && ID != 0)
            {
                DialogResult dialogResult = MessageBox.Show("Tem certeza que deseja atualizar este registo?", "Confirmação de Alteração", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    cmd = new SqlCommand("Update tbl_NCidade set Nome=@nome,Cidade=@cidade Where ID=@Id", con);
                    con.Open();
                    cmd.Parameters.AddWithValue("@Id", ID);
                    cmd.Parameters.AddWithValue("@Nome", txt_Nome.Text);
                    cmd.Parameters.AddWithValue("@Cidade", txt_Cidade.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Dados Atualizados com Sucesso!");
                    con.Close();
                    DisplayData();
                    ClearData();
                }
            }
            else
            {
                MessageBox.Show("Por favor Selectiona Registo para Atualizar!");
            }
        }
    }
}
