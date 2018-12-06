using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MVPetPlace
{
    public partial class UserMenu : Form
    {
        public UserMenu()
        {
            InitializeComponent();
        }

        private void btnFecharUserMenu_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja sair?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btnUserClientes_Click(object sender, EventArgs e)
        {
            this.Hide();
            CadastroClientes cadd = new CadastroClientes();
            cadd.Show();
        }

        private void btnUserLogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            Entrada entra = new Entrada();
            entra.Show();
        }

        private void UserMenu_Load(object sender, EventArgs e)
        {

        }
    }
}
