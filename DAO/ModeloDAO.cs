using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{

    public class ModeloDAO
    {
        db_garagem objbanco = new db_garagem();


        public void CadastrarModelo(tb_modelo objModelo)
        {
            objbanco.tb_modelo.Add(objModelo);
            objbanco.SaveChanges();
        }

        public void AlterarModelo(tb_modelo objModelo)
        {
            tb_modelo objUpdate = objbanco.tb_modelo
                                    .Where(m => m.id_modelo == objModelo.id_modelo).FirstOrDefault();

            objUpdate.nome_modelo = objModelo.nome_modelo;
            objUpdate.marca_id = objModelo.marca_id;

            objbanco.SaveChanges();
        }
        
        public void ExcluirModelo(int idModelo)
        {
            tb_modelo objExcluir = objbanco.tb_modelo
                                  .Where(m => m.id_modelo == idModelo).FirstOrDefault();

            objbanco.tb_modelo.Remove(objExcluir);

            objbanco.SaveChanges();

        }

        public List<tb_modelo> Consultar(int codigoGaragem)
        {
            List<tb_modelo> lstConsulta = objbanco.tb_modelo.Where(m => m.garagem_id == codigoGaragem).ToList();

            return lstConsulta;
        }

        public List<tb_modelo> ConsultarModelos(int codigoGaragem) 
            => objbanco.tb_modelo.Where(m => m.garagem_id == codigoGaragem).ToList();


    }
}
