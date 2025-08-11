using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Comum;


namespace AdmDesktop
{
    public partial class frmConsultarVendasVendedor : Form
    {
        public frmConsultarVendasVendedor()
        {
            InitializeComponent();
            Util.ConfigurarBotoes(pesquisar: btnPesquisar);
            Util.ConfigurarFormulario(this, Texto.TITULO_CONSULTAR_VENDAS_VENDEDOR);
        }

        private void frmConsultarVendasVendedor_Load(object sender, EventArgs e)
        {

        }
    }
}
