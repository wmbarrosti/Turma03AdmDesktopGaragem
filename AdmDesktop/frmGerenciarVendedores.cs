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
using DAO.VO;

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
            if (ValidarCampos())
            {
                try
                {
                    Alterar();
                    Util.ExibirMsg(Util.TipoMsg.Ok);
                    SetarEstadoNovo();
                    FiltrarVendedor();
                }
                catch
                {
                    Util.ExibirMsg(Util.TipoMsg.Erro);
                }
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (Util.ExibirMsg(Util.TipoMsg.ConfirmacaoExcluir, nomeEdicao))
            {
                var objDAO = new VendedorDAO();

                if(objDAO.VerificarTemClientes(codigoRegistro))
                {
                    Util.ExibirMsg(Util.TipoMsg.TemCliente);
                    return;
                }

                if (objDAO.VerificarTemVendas(codigoRegistro))
                {
                    Util.ExibirMsg(Util.TipoMsg.TemVenda);
                    return;
                }

                try
                {
                    Excluir();
                    Util.ExibirMsg(Util.TipoMsg.Ok);
                    SetarEstadoNovo();
                    FiltrarVendedor();
                }
                catch
                {
                    Util.ExibirMsg(Util.TipoMsg.Erro);
                }
            }
        }

        private void frmGerenciarVendedores_Load(object sender, EventArgs e)
        {
            SetarEstadoNovo();
        }

        #region Métodos
        private void SetarEstadoNovo()
        {
            Util.ConfigurarEstadoTela(Util.EstadoTela.Novo,
                cadastrar: btnCadastrar, alterar: btnAlterar, excluir: btnExcluir);
            LimparCampos();
            FiltrarVendedor();
            chkStatus.Visible = false;
        }
        private void SetarEstadoEdicao()
        {
            Util.ConfigurarEstadoTela(Util.EstadoTela.Editar,
               cadastrar: btnCadastrar, alterar: btnAlterar, excluir: btnExcluir);
            chkStatus.Visible = true;
        }
        private void LimparCampos()
        {
            codigoRegistro = 0;
            nomeEdicao = string.Empty;
            txtNome.Clear();
            txtComissao.Clear();
            txtCPF.Clear();
            txtEmail.Clear();
            txtObs.Clear();
            txtTelefone.Clear();
            chkStatus.Checked = true;
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

        private void FiltrarVendedor()
        {
            string nomeFiltro = txtNomePesquisa.Text;

            grdResultado.DataSource = new VendedorDAO().FiltrarVendedor(nomeFiltro, Util.CodigoGaragem);

            grdResultado.Columns["ObjVendedor"].Visible = false;
            grdResultado.Columns["Email"].HeaderText = "E-mail";
            grdResultado.Columns["Comissao"].HeaderText = "Comissão";
     

        }

      
        private void Cancelar()
        {
            SetarEstadoNovo();
        }
        private void Excluir()
        {
            VendedorDAO objDAO = new VendedorDAO();
            objDAO.ExcluirVendedor(codigoRegistro);

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

        private void txtNomePesquisa_TextChanged(object sender, EventArgs e)
        {
            FiltrarVendedor();
        }

        private void grdResultado_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(grdResultado.RowCount > 0)
            {
                //Recupera
                VendedorVO objLinha= (VendedorVO)grdResultado.CurrentRow.DataBoundItem;

                codigoRegistro = objLinha.ObjVendedor.id_vendedor;
                txtNome.Text = objLinha.ObjVendedor.nome_vendedor;
                txtTelefone.Text = objLinha.ObjVendedor.telefone_vendedor;
                txtCPF.Text = objLinha.ObjVendedor.cpf_vendedor;
                txtEmail.Text = objLinha.ObjVendedor.email_vendedor;
                txtObs.Text = objLinha.ObjVendedor.obs_vendedor;
                txtComissao.Text = objLinha.ObjVendedor.comissao_vendedor.ToString();

                chkStatus.Checked = objLinha.Status == "Ativo" ? true : false;

                SetarEstadoEdicao();

            }
        }
    }
}
