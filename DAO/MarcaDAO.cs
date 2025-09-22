using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public  class MarcaDAO
    {

        public void CadastrarMarca(tb_marca objMarca)
        {
            //1 PASSO - Cria o obj do BANCO DE DADOS
            db_garagem objbanco = new db_garagem();

            //2 PSSO - ADD o obj de entrada na table correspondente
            objbanco.tb_marca.Add(objMarca);

            //Salva no BD
            objbanco.SaveChanges();

        }

        public List<tb_marca> ConsultarMarca(int codigoGaragem)
        {

            //1 PASSO - Cria o obj do BANCO DE DADOS
            db_garagem objbanco = new db_garagem();

            //2 PASSO - Crie uma variável que RECEBA a consulta
            List<tb_marca> lstConsulta = objbanco.tb_marca.AsNoTracking()
                                        .Where(m => m.garagem_id == codigoGaragem).ToList();

            return lstConsulta;
        }


        public void AlterarMarca(tb_marca objMarca)
        {
            //1 PASSO - Cria o obj do BANCO DE DADOS
            db_garagem objbanco = new db_garagem();

            //2 PASSO - PARA ALTERAÇÃO, TENHO QUE RESGATAR O REGISTRO A SER ALTERADO
            tb_marca objAlterarMarca = objbanco.tb_marca
                            .Where(marca => marca.id_marcar == objMarca.id_marcar).FirstOrDefault();

            //Atualizar as propriedades (colunas)
            objAlterarMarca.nome_marca = objMarca.nome_marca;

            objbanco.SaveChanges();
        }


        public void ExcluirMarca(int idMarca)
        {
            //1 PASSO - Cria o obj do BANCO DE DADOS
            db_garagem objbanco = new db_garagem();

            //2 PASSO - PARA EXCLUIR, TENHO QUE RESGATAR O REGISTRO A SER ALTERADO
            tb_marca objExcluirMarca = objbanco.tb_marca
                            .Where(marca => marca.id_marcar == idMarca).FirstOrDefault();

            //DELETA
            objbanco.tb_marca.Remove(objExcluirMarca);

            objbanco.SaveChanges();
        }



    }
}
