using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using DAO.VO;

namespace DAO
{
    public class VendedorDAO
    {

        db_garagem objbanco = new db_garagem();

        public bool VerificarTemClientes(int codVendedor)
        {
            bool ret = objbanco.tb_cliente.AsNoTracking().Any(c => c.vendedor_id == codVendedor);
            return ret;
        }
        public bool VerificarTemVendas(int codVendedor)
         => objbanco.tb_venda.AsNoTracking().Any(v => v.vendedor_id == codVendedor);



        public List<VendedorVO> FiltrarVendedor(string nomeFiltro, int codGaragem)
        {
            List<VendedorVO> lstRetorno = new List<VendedorVO>();

            List<tb_vendedor> lstConsultar = objbanco.tb_vendedor.Include("tb_acesso")
                                .AsNoTracking()
                                .Where(v => v.garagem_id == codGaragem
                                && v.nome_vendedor.Contains(nomeFiltro)).ToList();

            foreach (var item in lstConsultar)
            {
                VendedorVO vo = new VendedorVO();

                vo.Nome = item.nome_vendedor;
                vo.Email = item.email_vendedor;
                vo.Telefone = item.telefone_vendedor;
                vo.Comissao = item.comissao_vendedor.ToString();
                vo.Status = item.tb_acesso.FirstOrDefault().status_acesso == 1 ? "Ativo" : "Inativo";
                vo.ObjVendedor = item;


                lstRetorno.Add(vo);

            }


            return lstRetorno;
        }


        public void CadastrarVendedor(tb_vendedor objVendedor)
        {

            using (TransactionScope tran = new TransactionScope())
            {
                objbanco.tb_vendedor.Add(objVendedor);
                objbanco.SaveChanges();

                //Procedimento que grava o acesso
                tb_acesso objAcesso = new tb_acesso();

                objAcesso.login_acesso = objVendedor.email_vendedor;
                objAcesso.senha_acesso = objVendedor.cpf_vendedor;
                objAcesso.status_acesso = 1;
                objAcesso.vendedor_id = objVendedor.id_vendedor;
                objAcesso.tipo_acesso = 2; //Tipo vendedor

                objbanco.tb_acesso.Add(objAcesso);
                objbanco.SaveChanges();

                tran.Complete();

            }


        }

        public void AlterarVendedor(tb_vendedor objVendedor, tb_acesso objAcesso)
        {

            using (TransactionScope tran = new TransactionScope())
            {


                tb_vendedor objUpdateVendedor = objbanco.tb_vendedor
                                                .Where(v => v.id_vendedor == objVendedor.id_vendedor).FirstOrDefault();

                tb_acesso objUpdateAcesso = objbanco.tb_acesso
                                                .FirstOrDefault(a => a.vendedor_id == objVendedor.id_vendedor);

                objUpdateVendedor.nome_vendedor = objVendedor.nome_vendedor;
                objUpdateVendedor.cpf_vendedor = objVendedor.cpf_vendedor;
                objUpdateVendedor.telefone_vendedor = objVendedor.telefone_vendedor;
                objUpdateVendedor.email_vendedor = objVendedor.email_vendedor;
                objUpdateVendedor.comissao_vendedor = objVendedor.comissao_vendedor;
                objUpdateVendedor.obs_vendedor = objVendedor.obs_vendedor;

                //Atualzia o vendedor
                objbanco.SaveChanges();

                objUpdateAcesso.status_acesso = objAcesso.status_acesso;
                //Atualiza o acesso
                objbanco.SaveChanges();

                tran.Complete();

            }


        }


        public void ExcluirVendedor(int codVendedor)
        {

            tb_vendedor objExcluirVendedor = objbanco.tb_vendedor
                                            .Where(v => v.id_vendedor == codVendedor).FirstOrDefault();
            objbanco.tb_vendedor.Remove(objExcluirVendedor);
            objbanco.SaveChanges();


        }
    }
}
