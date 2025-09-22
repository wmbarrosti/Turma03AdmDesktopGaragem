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
    public partial class frmGerenciarVendedores : Form
    {
        public frmGerenciarVendedores()
        {
            InitializeComponent();
            Util.ConfigurarFormulario(form: this, titulo: Comum.Texto.TITULO_VENDEDOR);
            Util.ConfigurarGrid(grdResultado);
            Util.ConfigurarBotoes(cadastrar: btnCadastrar,
                alterar: btnAlterar, excluir: btnExcluir, cancelar: btnCancelar);
        }
        int codigoRegistro = 0;
        string nomeEdicao = string.Empty;

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            Cadastrar();
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

        private void frmGerenciarVendedores_Load(object sender, EventArgs e)
        {

        }

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
            codigoRegistro = 0;
            nomeEdicao = string.Empty;
            txtNome.Clear();
            txtNome.Focus();
        }

        private bool ValidarCampos()
        {
            bool flag = true;
            string campos = Texto.TEXTO_MSG_CAMPO_OBG;

            if (string.IsNullOrWhiteSpace(txtNome.Text))
            {
               // campos += "- " + lblNome.Text;
                flag = false;
            }

            if (!flag)
                Util.ExibirMsg(Util.TipoMsg.Aviso, campos);


            return flag;
        }


        private void Cadastrar()
        {
            //Cria o obj para pegar as informaçoes
            tb_vendedor objVendedor = new tb_vendedor();
            //Cria o obj para chamar o METODO
            VendedorDAO objDAO = new VendedorDAO();

            objVendedor.nome_vendedor = txtNome.Text;
            objVendedor.telefone_vendedor = txtTelefone.Text;
            objVendedor.cpf_vendedor = txtCPF.Text;
            objVendedor.email_vendedor = txtEmail.Text;
            objVendedor.obs_vendedor = txtObs.Text;
            objVendedor.comissao_vendedor = Convert.ToDecimal( txtComissao.Text);
            objVendedor.garagem_id = Util.CodigoGaragem;

            objDAO.CadastrarVendedor(objVendedor);

        }
        private void Alterar()
        {
            //Cria o obj para pegar as informaçoes
            tb_vendedor objVendedor = new tb_vendedor();
            tb_acesso objAcesso = new tb_acesso();
            //Cria o obj para chamar o METODO
            VendedorDAO objDAO = new VendedorDAO();


            objVendedor.nome_vendedor = txtNome.Text;
            objVendedor.telefone_vendedor = txtTelefone.Text;
            objVendedor.cpf_vendedor = txtCPF.Text;
            objVendedor.email_vendedor = txtEmail.Text;
            objVendedor.obs_vendedor = txtObs.Text;
            objVendedor.comissao_vendedor = Convert.ToDecimal(txtComissao.Text);
            objVendedor.id_vendedor = codigoRegistro;

            objAcesso.status_acesso = Convert.ToByte( chkStatus.Checked ? 1 : 0);


            objDAO.AlterarVendedor(objVendedor, objAcesso);
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
            MarcaDAO objDAO = new MarcaDAO();
            objDAO.ExcluirMarca(codigoRegistro);

        }
        #endregion

     

        private void txtCPF_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtCPF.Text))
            {
                if (!Util.ValidarCPF(txtCPF.Text))
                {
                    Util.ExibirMsg(Util.TipoMsg.CpfInvalido);
                    txtCPF.Clear();
                    txtCPF.Focus();
                }
            }

        }
    }
}
