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
            ConfirmacaoExcluir,
            CpfInvalido
        }

        public enum EstadoTela
        {
            Novo,
            Editar
        }

        public static void ConfigurarCombo(ComboBox cmb, string display="", string value="")
        {
            cmb.DropDownStyle = ComboBoxStyle.DropDownList;

            if (!string.IsNullOrWhiteSpace(display) && !string.IsNullOrWhiteSpace(value))
            {
                cmb.DisplayMember = display;
                cmb.ValueMember = value;
            }


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
                case TipoMsg.CpfInvalido:
                    MessageBox.Show(Texto.TEXTO_MSG_CPF, Texto.TITULO_MSG_AVISO, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
                case TipoMsg.ConfirmacaoExcluir:

                    if(MessageBox.Show(Texto.TEXTO_MSG_EXCLUIR + mensagem, Texto.TITULO_MSG_CONFIRMAR_EXCLUSAO,
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

        public static bool ValidarCPF(string cpf)
        {
            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string tempCpf;
            string digito;
            int soma;
            int resto;

            cpf = cpf.Trim();
            cpf = cpf.Replace(".", "").Replace("-", "");

            if (cpf.Length != 11)
                return false;

            tempCpf = cpf.Substring(0, 9);
            soma = 0;

            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];

            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            digito = resto.ToString();

            tempCpf = tempCpf + digito;

            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];

            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            digito = digito + resto.ToString();

            return cpf.EndsWith(digito);
        }
    }
}
