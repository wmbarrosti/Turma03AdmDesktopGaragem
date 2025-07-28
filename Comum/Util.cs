using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Comum
{
    public static class Util
    {

        public static void ConfigurarBotoesCRUD(Button btnCadastrar, Button btnAlterar, 
            Button btnExcluir, Button btnCancelar )
        {
            btnCadastrar.Text = Texto.TITULO_BOTAO_CADASTRAR;
            btnAlterar.Text = Texto.TITULO_BOTAO_ALTERAR;
            btnExcluir.Text = Texto.TITULO_BOTAO_EXCLUIR;
            btnCancelar.Text = Texto.TITULO_BOTAO_CANCELAR;

            btnCadastrar.ForeColor = Color.White;
            btnCadastrar.BackColor = Color.Green;

            btnAlterar.ForeColor = Color.White;
            btnAlterar.BackColor = Color.Orange;

            btnExcluir.ForeColor = Color.White;
            btnExcluir.BackColor = Color.Red;

            btnCancelar.ForeColor = Color.White;
            btnCancelar.BackColor = Color.DimGray;

            btnCadastrar.Width = 171;
            btnCadastrar.Height = 62;

            btnAlterar.Width = 171;
            btnAlterar.Height = 62;

            btnExcluir.Width = 171;
            btnExcluir.Height = 62;

            btnCancelar.Width = 171;
            btnCancelar.Height = 62;
        }


        public static void ConfigurarFormulario(Form form, string titulo)
        {
            form.Text = titulo;
            form.MaximizeBox = false;
            form.MinimizeBox = false;
            form.StartPosition = FormStartPosition.CenterScreen;
        }

        public static void ConfigurarGrid(DataGridView grid)
        {
            grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            grid.ReadOnly = true;
            grid.MultiSelect = false;
        }
    }
}
