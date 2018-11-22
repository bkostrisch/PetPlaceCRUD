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
    public partial class Loginadm : Form
    {
        public Loginadm()
        {
            InitializeComponent();
        }

        private void btnfecharadm_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja sair?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btnbackmenu_Click(object sender, EventArgs e)
        {
            this.Hide();
            Entrada entra = new Entrada();
            entra.Show();
        }

        string petdb = @"Data Source=petplace.db;Version=3;";

        private void btnEntrarAdm_Click(object sender, EventArgs e)
        {
            SQLiteConnection sqlcon = new SQLiteConnection(petdb);

            if ((txtUserAdm.Text == "") && (txtPassAdm.Text == "") || (txtUserAdm.Text == "") || (txtPassAdm.Text == ""))
            {
                lblAvisoAdm.Visible = true;
                lblAvisoAdm.Text = "Usuário e/ou senha vazios!";
            }
            else
            {
                try
                {
                    sqlcon.Open();
                    string query = "SELECT * FROM loginadm WHERE account = '" + txtUserAdm.Text + "' AND password ='" + txtPassAdm.Text + "'";
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
                        AdMenu menudm = new AdMenu();
                        menudm.Show();                        
                    }

                    if (count < 1)
                    {
                        lblAvisoAdm.Visible = true;
                        lblAvisoAdm.Text = "Usuário e/ou senha inválidos!";
                        txtUserAdm.Clear();
                        txtPassAdm.Clear();
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao logar: " + ex);
                }
            }
        }

        private void Loginadm_Load(object sender, EventArgs e)
        {

        }
    }
}
