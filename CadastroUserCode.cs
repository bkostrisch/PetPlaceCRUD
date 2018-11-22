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
    public partial class CadastroUsuario : Form
    {
        public CadastroUsuario()
        {
            InitializeComponent();
        }

        private void CadastroUsuario_Load(object sender, EventArgs e)
        {

        }

        private SQLiteConnection sql_con;
        private SQLiteCommand sql_cmd;
        private SQLiteDataAdapter DB;
        private DataSet DS = new DataSet();
        private DataTable DT = new DataTable();

        private void SetConnection()
        {
            sql_con = new SQLiteConnection
                ("Data Source=petplace.db;Version=3;New=False;Compress=true;");
        }

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
            string CommandText = "select * from loginuser";
            DB = new SQLiteDataAdapter(CommandText, sql_con);
            DS.Reset();
            DB.Fill(DS);
            DT = DS.Tables[0];
            dataGridUsuarios.DataSource = DT;
            sql_con.Close();
        }

        private void btnCadastroUser_Click(object sender, EventArgs e)
        {
            string txtQuery = "insert into loginuser (ID, NomeUser, CelularUser, DataUser, EmailUser, EndUser, RgUser, CpfUser, usuario, senha)values('" + txtIdUser.Text + "','" + txtNomeUser.Text + "','" + txtCelularUser.Text + "','" + txtDataUser.Text + "','" + txtEmailUser.Text + "', '" + txtEndUser.Text + "', '" + txtRgUser.Text + "', '" + txtCpfUser.Text + "','" + txtNewUser.Text + "','" + txtSenhaUser.Text + "')";
            ExecuteQuery(txtQuery);
            LoadData();

            txtIdUser.Text = string.Empty;
            txtNomeUser.Text = string.Empty;
            txtCelularUser.Text = string.Empty;
            txtDataUser.Text = string.Empty;
            txtEmailUser.Text = string.Empty;
            txtEndUser.Text = string.Empty;
            txtRgUser.Text = string.Empty;
            txtCpfUser.Text = string.Empty;
            txtNewUser.Text = string.Empty;
            txtSenhaUser.Text = string.Empty;
        }

        private void btnDeletarUser_Click(object sender, EventArgs e)
        {
            String txtQuery = "delete from loginuser where ID = '" + txtIdUser.Text + "'";
            ExecuteQuery(txtQuery);
            LoadData();

            txtIdUser.Text = string.Empty;
            txtNomeUser.Text = string.Empty;
            txtCelularUser.Text = string.Empty;
            txtDataUser.Text = string.Empty;
            txtEmailUser.Text = string.Empty;
            txtEndUser.Text = string.Empty;
            txtRgUser.Text = string.Empty;
            txtCpfUser.Text = string.Empty;
            txtNewUser.Text = string.Empty;
            txtSenhaUser.Text = string.Empty;
        }

        private void btnEditarUser_Click(object sender, EventArgs e)
        {
            string txtQuery = "update loginadm set (NomeUser, CelularUser, DataUser, EmailUser, EndUser, RgUser, CpfUser, usuario, senha)values('" + txtNomeUser.Text + "','" + txtCelularUser.Text + "','" + txtDataUser.Text + "','" + txtEmailUser.Text + "', '" + txtEndUser.Text + "', '" + txtRgUser.Text + "', '" + txtCpfUser.Text + "','" + txtNewUser.Text + "','" + txtSenhaUser.Text + "') where ID = '" + txtIdUser.Text + "'";
            ExecuteQuery(txtQuery);
            LoadData();

            txtIdUser.Text = string.Empty;
            txtNomeUser.Text = string.Empty;
            txtCelularUser.Text = string.Empty;
            txtDataUser.Text = string.Empty;
            txtEmailUser.Text = string.Empty;
            txtEndUser.Text = string.Empty;
            txtRgUser.Text = string.Empty;
            txtCpfUser.Text = string.Empty;
            txtNewUser.Text = string.Empty;
            txtSenhaUser.Text = string.Empty;
        }

        private void btnVoltarMenuAdm1_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdMenu amd = new AdMenu();
            amd.Show();

        }

        private void btnFecharNewUser_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja sair?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
