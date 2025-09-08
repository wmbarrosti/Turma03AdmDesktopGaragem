using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Comum
{
    public static class Util
    {


        public static int CodigoGaragem = 1; //Fixo por eqto


        public enum TipoMsg
        {
            Ok,
            Erro,
            Aviso,
            ConfirmacaoExcluir
        }

        public enum EstadoTela
        {
            Novo,
            Editar
        }

      
        /// <summary>
        /// Gerencia estado dos buttons CRUD
        /// </summary>
        /// <param name="tipo">Estado da tela</param>
        /// <param name="cadastrar">Botão Cadastrar</param>
        /// <param name="alterar">Botão Alterar</param>
        /// <param name="excluir">Botão Excluir</param>
        public static void ConfigurarEstadoTela(EstadoTela tipo, Button cadastrar, Button alterar, Button excluir)
        {
            switch (tipo)
            {
                case EstadoTela.Novo:
                    cadastrar.Enabled = true;
                    excluir.Enabled = false;
                    alterar.Enabled = false;

                    ConfigurarEsteticaBotao(btn: alterar,  corTexto: Color.White,
                        corFundo: Color.Gray, texto: Texto.TITULO_BOTAO_ALTERAR);
                    ConfigurarEsteticaBotao(btn: excluir, corTexto: Color.White,
                       corFundo: Color.Gray, texto: Texto.TITULO_BOTAO_EXCLUIR);
                    break;
                case EstadoTela.Editar:
                    cadastrar.Enabled = false;
                    excluir.Enabled = true;
                    alterar.Enabled = true;
                    break;
               
            }
        }

        public static bool ExibirMsg(TipoMsg tipo, string mensagem = "")
        {
            bool flag = true;

            switch (tipo)
            {
                case TipoMsg.Ok:
                    MessageBox.Show(Texto.TEXTO_MSG_OK, Texto.TITULO_MSG_OK, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
                case TipoMsg.Erro:
                    MessageBox.Show(Texto.TEXTO_MSG_ERRO, Texto.TITULO_MSG_ERRO, MessageBoxButtons.OK, MessageBoxIcon.Error);

                    break;
                case TipoMsg.Aviso:
                    MessageBox.Show(mensagem, Texto.TITULO_MSG_AVISO, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
                case TipoMsg.ConfirmacaoExcluir:

                    if(MessageBox.Show(mensagem, Texto.TITULO_MSG_CONFIRMAR_EXCLUSAO,
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                    {
                        flag = false;
                    }

                    break;
            }


            return flag;
        }

        private static void ConfigurarEsteticaBotao(Button btn, 
            string texto = "", Color? corTexto = null, Color? corFundo = null, int height = 171, int width= 62)
        {
            btn.Text = texto;
            btn.ForeColor = (Color)corTexto;
            btn.BackColor = (Color)corFundo;
            btn.Width = height;
            btn.Height = width;

        }
        public static void ConfigurarBotoes(Button cadastrar = null, Button alterar = null,
           Button excluir = null, Button cancelar = null, Button pesquisar = null)
        {


            if(cadastrar != null)
                ConfigurarEsteticaBotao(cadastrar, Texto.TITULO_BOTAO_CADASTRAR, Color.White, Color.Green, 171, 62);
            
            
            if(alterar != null)
                ConfigurarEsteticaBotao(alterar, Texto.TITULO_BOTAO_ALTERAR, Color.White, Color.Orange, 171, 62);


            if (excluir != null)
                ConfigurarEsteticaBotao(excluir, Texto.TITULO_BOTAO_EXCLUIR, Color.White, Color.Red, 171, 62);


            if (cancelar != null)
                ConfigurarEsteticaBotao(cancelar, Texto.TITULO_BOTAO_CANCELAR, Color.White, Color.DimGray, 171, 62);


            if (pesquisar != null)
                ConfigurarEsteticaBotao(pesquisar, Texto.TITULO_BOTAO_PESQUISAR, Color.White, Color.Blue, 171, 62);

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
