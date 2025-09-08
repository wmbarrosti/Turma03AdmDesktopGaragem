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
using DAO;
namespace AdmDesktop
{
    public partial class frmGerenciarMarcas : Form
    {
        public frmGerenciarMarcas()
        {
            InitializeComponent();
            Util.ConfigurarFormulario(form: this, titulo: Comum.Texto.TITULO_MARCA);
            Util.ConfigurarGrid(grdResultado);
            Util.ConfigurarBotoes(cadastrar: btnCadastrar,
                alterar: btnAlterar, excluir: btnExcluir, cancelar: btnCancelar);
        }

        #region Eventos
        private void frmGerenciarMarcas_Load(object sender, EventArgs e)
        {
            SetarEstadoNovo();
        
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            if (ValidarCampos())
            {
                try
                {
                    Cadastrar();
                    Util.ExibirMsg(Util.TipoMsg.Ok);
                    SetarEstadoNovo();
                   
                }
                catch
                {
                    Util.ExibirMsg(Util.TipoMsg.Erro);
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            SetarEstadoNovo();
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


        #region Métodos
        private void SetarEstadoNovo()
        {
            Util.ConfigurarEstadoTela(Util.EstadoTela.Novo,
                cadastrar: btnCadastrar, alterar: btnAlterar, excluir: btnExcluir);
            LimparCampos();
            Consultar();
        }
        private void SetarEstadoEdicao()
        {
            Util.ConfigurarEstadoTela(Util.EstadoTela.Editar,
               cadastrar: btnCadastrar, alterar: btnAlterar, excluir: btnExcluir);

        }
        private void LimparCampos()
        {
            txtNome.Clear();
            txtNome.Focus();
        }

        private bool ValidarCampos()
        {
            bool flag = true;
            string campos = Texto.TEXTO_MSG_CAMPO_OBG;

            if (string.IsNullOrWhiteSpace(txtNome.Text))
            {
                campos += "- " + lblNome.Text;
                flag = false;
            }

            if (!flag)
                Util.ExibirMsg(Util.TipoMsg.Aviso, campos);


            return flag;
        }


        private void Cadastrar()
        {
            //Cria o obj para pegar as informaçoes
            tb_marca objMarca = new tb_marca();
            //Cria o obj para chamar o METODO
            MarcaDAO objDAO = new MarcaDAO();

            objMarca.nome_marca = txtNome.Text;
            objMarca.garagem_id = Util.CodigoGaragem;


            objDAO.CadastrarMarca(objMarca);

        }
        private void Alterar()
        {

        }
        private void Consultar()
        {
            //Cria o obj para chamar o METODO
            MarcaDAO objDAO = new MarcaDAO();

            List<tb_marca> lstRetorno = objDAO.ConsultarMarca(Util.CodigoGaragem);


            grdResultado.DataSource = lstRetorno;

            grdResultado.Columns["id_marcar"].Visible = false;
            grdResultado.Columns["garagem_id"].Visible = false;
            grdResultado.Columns["tb_garagem"].Visible = false;
            grdResultado.Columns["tb_modelo"].Visible = false;

            grdResultado.Columns["nome_marca"].HeaderText = "Marca";


        }
        private void Cancelar()
        {
            SetarEstadoNovo();
        }
        private void Excluir()
        {

        }
        #endregion
    }
}
