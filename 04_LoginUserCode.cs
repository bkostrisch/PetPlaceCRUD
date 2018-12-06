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
    public partial class Loginuser : Form
    {
        public Loginuser()
        {
            InitializeComponent();
        }

        private void btnfecharuser_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja sair?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btnbackmenu1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Entrada entra = new Entrada();
            entra.Show();
        }

        string dbcon = @"Data Source=petplace.db;Version=3;";

        private void btnEntrarUser_Click(object sender, EventArgs e)
        {
            SQLiteConnection sqlcon = new SQLiteConnection(dbcon);

            if ((txtAccUser.Text == "") && (txtPassUser.Text == "") || (txtAccUser.Text == "") || (txtPassUser.Text == ""))
            {
                lblAvisoUser.Visible = true;
                lblAvisoUser.Text = "Usuário e/ou senha vazios!";
            }
            else
            {
                try
                {
                    sqlcon.Open();
                    string query = "SELECT * FROM loginuser WHERE usuario = '" + txtAccUser.Text + "' AND senha ='" + txtPassUser.Text + "'";
                    SQLiteCommand com = new SQLiteCommand(query, sqlcon);
                    com.ExecuteNonQuery();
                    SQLiteDataReader dr = com.ExecuteReader();

                    int count = 0;

                    while (dr.Read())
                    {
                        count++;
                    }

                    if (count == 1)
                    {
                        this.Hide();
                        UserMenu menuser = new UserMenu();
                        menuser.Show();                        
                    }

                    if (count < 1)
                    {
                        lblAvisoUser.Visible = true;
                        lblAvisoUser.Text = "Usuário e/ou senha inválidos!";
                        txtAccUser.Clear();
                        txtPassUser.Clear();
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao logar: " + ex);
                }
            }
        }

        private void Loginuser_Load(object sender, EventArgs e)
        {

        }
    }
}
