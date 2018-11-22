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
    public partial class Entrada : Form
    {
        public Entrada()
        {
            InitializeComponent();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void btnsairentrada_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja sair?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btnadmlogin_Click(object sender, EventArgs e)
        {
            this.Hide();
            Loginadm ladm = new Loginadm();
            ladm.Show();
        }

        private void btnuserlogin_Click(object sender, EventArgs e)
        {
            this.Hide();
            Loginuser luser = new Loginuser();
            luser.Show();
        }

        private void Entrada_Load(object sender, EventArgs e)
        {

        }
    }
}
