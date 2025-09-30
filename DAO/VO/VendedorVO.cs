using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.VO
{
    public class VendedorVO
    {
        //As informações que serão exibidas na GRID
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }

        public string Comissao { get; set; }

        public string Status { get; set; }

        //Propiedade para poder alterar
        public tb_vendedor ObjVendedor { get; set; }
    }
}
