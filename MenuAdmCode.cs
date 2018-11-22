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
    public partial class AdMenu : Form
    {
        public AdMenu()
        {
            InitializeComponent();
        }

        private void btnFecharAdMenu_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja sair?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btnCadastroAdm_Click(object sender, EventArgs e)
        {
            this.Hide();
            CadastroAdm cad = new CadastroAdm();
            cad.Show();
        }

        private void btnCadastroUser_Click(object sender, EventArgs e)
        {
            this.Hide();
            CadastroUsuario cadu = new CadastroUsuario();
            cadu.Show();
        }

        private void btnAdmClientes_Click(object sender, EventArgs e)
        {
            this.Hide();
            CadastroClientes cadd = new CadastroClientes();
            cadd.Show();
        }

        private void btnAdmLogOut_Click(object sender, EventArgs e)
        {
            this.Hide();
            Entrada entra = new Entrada();
            entra.Show();
        }

        private void AdMenu_Load(object sender, EventArgs e)
        {

        }
    }
}
