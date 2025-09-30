using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comum
{
    public static class Texto
    {
        #region TÍTULO DOS FORMULÁRIOS
        public static string TITULO_MARCA = "Gerenciar marca"; 
        public static string TITULO_VENDEDOR = "Gerenciar vendedor";
        public static string TITULO_CONSULTAR_VENDAS_VENDEDOR = "Consultar vendas por vendedor";
        #endregion

        #region TEXTO DOS BOTÕES
        public static string TITULO_BOTAO_CADASTRAR = "Cadastrar";
        public static string TITULO_BOTAO_ALTERAR = "Alterar";
        public static string TITULO_BOTAO_CANCELAR = "Cancelar";
        public static string TITULO_BOTAO_EXCLUIR = "Excluir";
        public static string TITULO_BOTAO_PESQUISAR = "Pesquisar";
        #endregion


        #region TEXTO TITULO MSG
        public static string TITULO_MSG_OK = "Informação";
        public static string TITULO_MSG_ERRO = "Erro";
        public static string TITULO_MSG_AVISO = "Atenção";
        public static string TITULO_MSG_CONFIRMAR_EXCLUSAO = "Confirmação de exclusão";
        #endregion

        #region TEXTO  MSG
        public static string TEXTO_MSG_OK = "Ação realizada com sucesso";
        public static string TEXTO_MSG_ERRO = "Ocorreu um erro na operação! Tente mais tarde!";
        public static string TEXTO_MSG_EXCLUIR = "Deseja excluir o registro: ";
        public static string TEXTO_MSG_CPF = "CPF inválido!";
        public static string TEXTO_MSG_TEM_CLIENTES = "O vendedor não pode ser excluído pois o mesmo já tem clientes cadastrados";
        public static string TEXTO_MSG_TEM_VENDAS = "O vendedor não pode ser excluído pois o mesmo já tem vendas";
        /// <summary>
        /// Corrigir o(s) campo(s) abaixo
        /// </summary>
        public static string TEXTO_MSG_CAMPO_OBG = "Corrigir o(s) campo(s) abaixo:\n";

        #endregion

    }
}
