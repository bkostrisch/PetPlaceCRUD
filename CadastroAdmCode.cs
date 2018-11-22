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
    public partial class CadastroAdm : Form
    {
        public CadastroAdm()
        {
            InitializeComponent();
        }

        private void CadastroAdm_Load(object sender, EventArgs e)
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
            string CommandText = "select * from loginadm";
            DB = new SQLiteDataAdapter(CommandText, sql_con);
            DS.Reset();
            DB.Fill(DS);
            DT = DS.Tables[0];
            dataGridAdms.DataSource = DT;
            sql_con.Close();
        }

        private void btnCadastroAdm_Click(object sender, EventArgs e)
        {
            string txtQuery = "insert into loginadm (ID, NomeAdm, CelularAdm, DataAdm, EmailAdm, EndAdm, RgAdm, CpfAdm, account, password)values('"+ txtIdAdm.Text +"','" + txtNomeAdm.Text + "','" + txtCelularAdm.Text + "','" + txtDataAdm.Text + "','" + txtEmailAdm.Text + "', '" + txtEndAdm.Text + "', '" + txtRgAdm.Text + "', '" + txtCpfAdm.Text + "','" + txtNewAdm.Text + "','" + txtNewSenhaAdm.Text + "')";
            ExecuteQuery(txtQuery);
            LoadData();

            txtIdAdm.Text = string.Empty;
            txtNomeAdm.Text = string.Empty;
            txtCelularAdm.Text = string.Empty;
            txtDataAdm.Text = string.Empty;
            txtEmailAdm.Text = string.Empty;
            txtEndAdm.Text = string.Empty;
            txtRgAdm.Text = string.Empty;
            txtCpfAdm.Text = string.Empty;
            txtNewAdm.Text = string.Empty;
            txtNewSenhaAdm.Text = string.Empty;            
        }

        private void btnDeletarAdm_Click(object sender, EventArgs e)
        {
            String txtQuery = "delete from loginadm where ID = '" + txtIdAdm.Text + "'";
            ExecuteQuery(txtQuery);
            LoadData();

            txtIdAdm.Text = string.Empty;
            txtNomeAdm.Text = string.Empty;
            txtCelularAdm.Text = string.Empty;
            txtDataAdm.Text = string.Empty;
            txtEmailAdm.Text = string.Empty;
            txtEndAdm.Text = string.Empty;
            txtRgAdm.Text = string.Empty;
            txtCpfAdm.Text = string.Empty;
            txtNewAdm.Text = string.Empty;
            txtNewSenhaAdm.Text = string.Empty;
        }

        private void btnEditarAdm_Click(object sender, EventArgs e)
        {
            string txtQuery = "update loginadm set (NomeAdm, CelularAdm, DataAdm, EmailAdm, EndAdm, RgAdm, CpfAdm, account, password)values('" + txtNomeAdm.Text + "','" + txtCelularAdm.Text + "','" + txtDataAdm.Text + "','" + txtEmailAdm.Text + "', '" + txtEndAdm.Text + "', '" + txtRgAdm.Text + "', '" + txtCpfAdm.Text + "','" + txtNewAdm.Text + "','" + txtNewSenhaAdm.Text + "') where ID = '" + txtIdAdm.Text + "'";
            ExecuteQuery(txtQuery);
            LoadData();

            txtIdAdm.Text = string.Empty;
            txtNomeAdm.Text = string.Empty;
            txtCelularAdm.Text = string.Empty;
            txtDataAdm.Text = string.Empty;
            txtEmailAdm.Text = string.Empty;
            txtEndAdm.Text = string.Empty;
            txtRgAdm.Text = string.Empty;
            txtCpfAdm.Text = string.Empty;
            txtNewAdm.Text = string.Empty;
            txtNewSenhaAdm.Text = string.Empty;
        }

        private void btnFecharNewAdm_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja sair?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btnVoltarMenuAdm_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdMenu amn = new AdMenu();
            amn.Show();
        }
    }
}
