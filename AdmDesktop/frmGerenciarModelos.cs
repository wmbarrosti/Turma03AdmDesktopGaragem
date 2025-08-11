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
    public partial class frmGerenciarModelos : Form
    {
        public frmGerenciarModelos()
        {
            InitializeComponent();
            Util.ConfigurarFormulario(form: this, titulo: Comum.Texto.TITULO_MARCA);
            Util.ConfigurarGrid(grdResultado);
            Util.ConfigurarBotoes(cadastrar: btnCadastrar,
                alterar: btnAlterar, excluir: btnExcluir, cancelar: btnCancelar);
        }

        #region Eventos
        private void frmGerenciarModelos_Load(object sender, EventArgs e)
        {

        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            if (ValidarCampos())
            {

            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {

        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {

        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {

        }

        private void grdResultado_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        #endregion
        #region Método
        private bool ValidarCampos()
        {
            bool flag = true;
            string campos = Texto.TEXTO_MSG_CAMPO_OBG;


            if(cbMarca.SelectedIndex == -1)
            {
                flag = false;
                campos += $"- {lblMarca.Text}\n";
            }
            
            if (string.IsNullOrWhiteSpace(txtNome.Text))
            {
                flag = false;
                campos += $"- {lblModelo.Text}";
            }


            if (!flag)
                Util.ExibirMsg(Util.TipoMsg.Aviso, campos);

            return flag;

        }

        private void SetarEstadoNovo()
        {
         
            Util.ConfigurarEstadoTela(Util.EstadoTela.Novo,
                cadastrar: btnCadastrar, alterar: btnAlterar, excluir: btnExcluir);
            LimparCampos();
        }
        private void SetarEstadoEdicao()
        {
            Util.ConfigurarEstadoTela(Util.EstadoTela.Editar,
               cadastrar: btnCadastrar, alterar: btnAlterar, excluir: btnExcluir);

        }
        private void Cadastrar()
        {

        }
        private void Alterar()
        {

        }
        private void Consultar()
        {

        }
        private void Cancelar()
        {
            SetarEstadoNovo();
        }
        private void Excluir()
        {

        }
        private void LimparCampos()
        {

        }
        #endregion
    }
}
