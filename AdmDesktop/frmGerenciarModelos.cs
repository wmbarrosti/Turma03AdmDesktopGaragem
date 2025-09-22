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
    public partial class frmGerenciarModelos : Form
    {

        int codigoRegistro = 0;
        string nomeEdicao = "";
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
            Util.ConfigurarCombo(cbMarca, "nome_marca", "id_marcar");
            CarregarMarcas();
            Consultar();
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
                try
                {
                    Excluir();
                    Util.ExibirMsg(Util.TipoMsg.Ok);
                    SetarEstadoNovo();

                }
                catch
                {
                    Util.ExibirMsg(Util.TipoMsg.Erro);
                }
            }
        }

        private void grdResultado_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(grdResultado.RowCount > 0)
            {
                ModeloVO objLinha = (ModeloVO)grdResultado.CurrentRow.DataBoundItem;


                txtNome.Text = objLinha.ObjModelo.nome_modelo;
                cbMarca.SelectedValue = objLinha.ObjModelo.marca_id;

                codigoRegistro = objLinha.ObjModelo.id_modelo;
                nomeEdicao = objLinha.ObjModelo.nome_modelo;

                SetarEstadoEdicao();


            }
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
        private void CarregarMarcas()
        {
            MarcaDAO objDAO = new MarcaDAO();
            List<tb_marca> lstMarcas = objDAO.ConsultarMarca(Util.CodigoGaragem);
            cbMarca.DataSource = lstMarcas;
            cbMarca.SelectedIndex = -1;

        }
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
        private void Cadastrar()
        {
            ModeloDAO objDAO = new ModeloDAO();
            tb_modelo objModelo = new tb_modelo();

            objModelo.marca_id = (int)cbMarca.SelectedValue;
            objModelo.nome_modelo = txtNome.Text;
            objModelo.garagem_id = Util.CodigoGaragem;


            objDAO.CadastrarModelo(objModelo);
        }
        private void Alterar()
        {
            ModeloDAO objDAO = new ModeloDAO();
            tb_modelo objModelo = new tb_modelo();

            objModelo.marca_id = (int)cbMarca.SelectedValue;
            objModelo.nome_modelo = txtNome.Text;
            objModelo.id_modelo = codigoRegistro;


            objDAO.AlterarModelo(objModelo);
        }
        private void Consultar()
        {
            grdResultado.DataSource = new ModeloDAO().Consultar(Util.CodigoGaragem);
            grdResultado.Columns["ObjModelo"].Visible = false;
        }
        private void Cancelar()
        {
            SetarEstadoNovo();
        }
        private void Excluir()
        {
            new ModeloDAO().ExcluirModelo(codigoRegistro);
        }
        private void LimparCampos()
        {
            txtNome.Clear();
            cbMarca.SelectedIndex = -1;
            codigoRegistro = 0;
            nomeEdicao = string.Empty;
        }
        #endregion
    }
}
