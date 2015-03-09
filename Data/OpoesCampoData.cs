using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Data
{
    public class OpoesCampoData
    {
        public List<OpcoesCampo> ObterPorCampoId(int campoId)
        {
            List<OpcoesCampo> opcoes = null;

            using (var context = new CategoriasContext())
            {
                var query = from c in context.OpcoesCampos
                            where c.CampoId == campoId
                            select c;

                opcoes = new List<OpcoesCampo>(query);
            }

            return opcoes;
        }
    }
}
