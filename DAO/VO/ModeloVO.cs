using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.VO
{
    public class ModeloVO
    {
        //Propriedade para exibir na Grid
        public string Modelo { get; set; }
        //Propriedade para exibir na Grid
        public string Marca { get; set; }

        //Propriedade para edição
        public tb_modelo ObjModelo { get; set; }
    }
}
