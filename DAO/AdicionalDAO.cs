using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class AdicionalDAO
    {
        db_garagem objbanco = new db_garagem();

        public List<tb_adicional> ConsultarAdicionais(int codGaragem)
        {

            List<tb_adicional> lst = objbanco.tb_adicional.AsNoTracking()
            .Where(a => a.garagem_id == codGaragem || a.garagem_id == null).ToList();
            return lst;

        }
    }
}
