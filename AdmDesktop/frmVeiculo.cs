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


namespace AdmDesktopTurma005
{
    public partial class frmVeiculo : Form
    {
        public frmVeiculo()
        {
            InitializeComponent();
            Util.ConfigurarGrid(grdAdicionais, true);
            Util.ConfigurarCombo(cbMarca, "nome_marca", "id_marcar");
            Util.ConfigurarCombo(cbModelo, "nome_modelo", "id_modelo");
            Util.ConfigurarCombo(cbSituacao);
        }

        bool primeiraVez = true;


       private void CarregarAdicionais()
        {
            grdAdicionais.DataSource = new AdicionalDAO().ConsultarAdicionais(Util.CodigoGaragem);
            grdAdicionais.Columns["id_adicional"].Visible = false;
            grdAdicionais.Columns["garagem_id"].Visible = false;
            grdAdicionais.Columns["tb_garagem"].Visible = false;
            grdAdicionais.Columns["tb_veiculo"].Visible = false;
            grdAdicionais.Columns["nome_adicional"].HeaderText = "Adicional";
        }

        private void CarregarMarcas()
        {
            cbMarca.DataSource = new MarcaDAO().ConsultarMarca(Util.CodigoGaragem);
            cbMarca.SelectedIndex = -1;
        }

        private void CarregarModelos()
        {
            if (cbMarca.SelectedIndex != -1 && !primeiraVez)
            {

                int codMarca = (int)cbMarca.SelectedValue;
                cbModelo.DataSource = new ModeloDAO().ConsultarModelos(Util.CodigoGaragem, codMarca);
                cbModelo.SelectedIndex = -1;
            }
        }


        private void frmVeiculo_Load(object sender, EventArgs e)
        {
            CarregarAdicionais();
            CarregarMarcas();
            primeiraVez = false;
        }

        private void cbMarca_SelectedIndexChanged(object sender, EventArgs e)
        {
            CarregarModelos();
        }
    }
}
