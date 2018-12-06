using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
using System.IO;

namespace MVPetPlace
{
    public partial class CadastroClientes : Form
    {
        public CadastroClientes()
        {
            InitializeComponent();
            LoadData();
        }

        private SQLiteConnection sql_con;
        private SQLiteCommand sql_cmd;
        private SQLiteDataAdapter DB;
        private DataSet DS = new DataSet();
        private DataTable DT = new DataTable();

        //Faz a Conexão
        private void SetConnection()
        {
            sql_con = new SQLiteConnection
                ("Data Source=petplace.db;Version=3;New=False;Compress=true;");
        }

        //Executa
        private void ExecuteQuery(string txtQuery)
        {
            SetConnection();
            sql_con.Open();
            sql_cmd = sql_con.CreateCommand();
            sql_cmd.CommandText = txtQuery;
            sql_cmd.ExecuteNonQuery();
            sql_con.Close();
        }
        
        private void LoadData()
        {
            SetConnection();
            sql_con.Open();
            sql_cmd = sql_con.CreateCommand();
            string CommandText = "select * from cadastro";
            DB = new SQLiteDataAdapter(CommandText, sql_con);
            DS.Reset();
            DB.Fill(DS);
            DT = DS.Tables[0];
            dataGridClientes.DataSource = DT;
            sql_con.Close();
        }

        private void CadastroClientes_Load(object sender, EventArgs e)
        {

        }

        private void btnCadastroClientes_Click(object sender, EventArgs e)
        {
            string txtQuery = "insert into cadastro (ID, Nome, Celular, Email, Endereco, RG, CPF, NomPet, Raca, Idade, Sexo, Servico, Valor)values('" + txtIdCliente.Text + "','" + txtNomeCliente.Text + "','" + txtCelularCliente.Text + "','" + txtEmailCliente.Text + "', '" + txtEndCliente.Text + "', '" + txtRgCliente.Text + "', '" + txtCpfCliente.Text + "','" + txtNomePet.Text + "','" + txtRacaPet.Text + "','" + txtIdadePet.Text + "','" + txtSexoPet.Text + "','" + txtServico.Text + "','" + txtValorTotal.Text + "')";


            ExecuteQuery(txtQuery);
            LoadData();

            txtIdCliente.Text = string.Empty;
            txtNomeCliente.Text = string.Empty;
            txtCelularCliente.Text = string.Empty;
            txtEmailCliente.Text = string.Empty;
            txtEndCliente.Text = string.Empty;
            txtRgCliente.Text = string.Empty;
            txtCpfCliente.Text = string.Empty;
            txtNomePet.Text = string.Empty;
            txtRacaPet.Text = string.Empty;
            txtIdadePet.Text = string.Empty;
            txtSexoPet.Text = string.Empty;
            txtServico.Text = string.Empty;
            txtValorTotal.Text = string.Empty;
        }

        private void btnEditarClientes_Click(object sender, EventArgs e)
        {
            string txtQuery = "update cadastro set (Nome, Celular, Email, Endereco, RG, CPF, NomPet, Raca, Idade, Sexo, Servico, Valor)=('" + txtNomeCliente.Text + "','" + txtCelularCliente.Text + "','" + txtEmailCliente.Text + "', '" + txtEndCliente.Text + "', '" + txtRgCliente.Text + "', '" + txtCpfCliente.Text + "','" + txtNomePet.Text + "','" + txtRacaPet.Text + "','" + txtIdadePet.Text + "','" + txtSexoPet.Text + "','" + txtServico.Text + "','" + txtValorTotal.Text + "') where ID = '" + txtIdCliente.Text + "'";

            ExecuteQuery(txtQuery);
            LoadData();
            txtIdCliente.Text = string.Empty;
            txtNomeCliente.Text = string.Empty;
            txtCelularCliente.Text = string.Empty;
            txtEmailCliente.Text = string.Empty;
            txtEndCliente.Text = string.Empty;
            txtRgCliente.Text = string.Empty;
            txtCpfCliente.Text = string.Empty;
            txtNomePet.Text = string.Empty;
            txtRacaPet.Text = string.Empty;
            txtIdadePet.Text = string.Empty;
            txtSexoPet.Text = string.Empty;
            txtServico.Text = string.Empty;
            txtValorTotal.Text = string.Empty;
        }

        private void btnDeletarClientes_Click(object sender, EventArgs e)
        {
            String txtQuery = "delete from cadastro where ID = '" + txtIdCliente.Text + "'";
            ExecuteQuery(txtQuery);
            LoadData();
            txtIdCliente.Text = string.Empty;
            txtNomeCliente.Text = string.Empty;
            txtCelularCliente.Text = string.Empty;
            txtEmailCliente.Text = string.Empty;
            txtEndCliente.Text = string.Empty;
            txtRgCliente.Text = string.Empty;
            txtCpfCliente.Text = string.Empty;
            txtNomePet.Text = string.Empty;
            txtRacaPet.Text = string.Empty;
            txtIdadePet.Text = string.Empty;
            txtSexoPet.Text = string.Empty;
            txtServico.Text = string.Empty;
            txtValorTotal.Text = string.Empty;
        }

        private void dataGridClientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void btnFecharClientes_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja sair?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void dataGridClientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            DataGridViewRow selectedRow = dataGridClientes.Rows[index];
            txtIdCliente.Text = dataGridClientes.SelectedRows[0].Cells[0].Value.ToString();
            txtNomeCliente.Text = dataGridClientes.SelectedRows[0].Cells[1].Value.ToString();
            txtCelularCliente.Text = dataGridClientes.SelectedRows[0].Cells[2].Value.ToString();
            txtEmailCliente.Text = dataGridClientes.SelectedRows[0].Cells[3].Value.ToString();
            txtEndCliente.Text = dataGridClientes.SelectedRows[0].Cells[4].Value.ToString();
            txtRgCliente.Text = dataGridClientes.SelectedRows[0].Cells[5].Value.ToString();
            txtCpfCliente.Text = dataGridClientes.SelectedRows[0].Cells[6].Value.ToString();
            txtNomePet.Text = dataGridClientes.SelectedRows[0].Cells[7].Value.ToString();
            txtRacaPet.Text = dataGridClientes.SelectedRows[0].Cells[8].Value.ToString();
            txtIdadePet.Text = dataGridClientes.SelectedRows[0].Cells[9].Value.ToString();
            txtSexoPet.Text = dataGridClientes.SelectedRows[0].Cells[10].Value.ToString();
            txtServico.Text = dataGridClientes.SelectedRows[0].Cells[11].Value.ToString();
            txtValorTotal.Text = dataGridClientes.SelectedRows[0].Cells[12].Value.ToString();
        }

        private void btnVoltarClientes_Click(object sender, EventArgs e)
        {
            this.Hide();
            Entrada enter = new Entrada();
            enter.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
