using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AdmDesktopTurma005;

namespace AdmDesktop
{
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void vendasToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void dasdadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new frmGerenciarMarcas().ShowDialog();
        }

        private void modeloToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new frmGerenciarModelos().ShowDialog();
        }

        private void gerenciarVeículoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new frmVeiculo().ShowDialog();
        }

        private void gerenciarVendedorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new frmGerenciarVendedores().ShowDialog();
        }

        private void acompanharPorVendedorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new frmConsultarVendasVendedor().ShowDialog();
        }

        private void acompanharPorVeículoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new frmConsultarVendasModelo().ShowDialog();
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
