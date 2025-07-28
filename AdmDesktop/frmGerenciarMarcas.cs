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
    public partial class frmGerenciarMarcas : Form
    {
        public frmGerenciarMarcas()
        {
            InitializeComponent();
            Util.ConfigurarFormulario(form: this, titulo: Comum.Texto.TITULO_MARCA);
            Util.ConfigurarGrid(grdResultado);
            Util.ConfigurarBotoesCRUD(btnCadastrar, btnAlterar, btnExcluir, btnCancelar);
        }

        private void frmGerenciarMarcas_Load(object sender, EventArgs e)
        {

        }
    }
}
