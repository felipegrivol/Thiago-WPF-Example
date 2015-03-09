using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Data
{
    public class CampoData
    {
        public List<Campo> Obter()
        {
            List<Campo> campos = null;

            using (var context = new CategoriasContext())
            {
                var query = from c in context.Campos
                            orderby c.Ordem
                            select c;
                campos = new List<Campo>(query);
            }

            return campos;
        }

        public Campo ObterPorId(int campoId)
        {
            Campo campo = null;

            using (var context = new CategoriasContext())
            {
                var query = from c in context.Campos
                            where c.Id == campoId
                            orderby c.Ordem
                            select c;

                campo = query.FirstOrDefault();
            }

            return campo;
        }

        public List<Campo> ObterPorSubCategoriaId(int subCategoriaId)
        {
            List<Campo> campos = null;

            using (var context = new CategoriasContext())
            {
                var query = (context.Campos.Include("Opcoes")).Where(x => x.SubCategoriaId == subCategoriaId).OrderBy(y => y.Ordem);
                campos = new List<Campo>(query);
            }

            return campos;
        }

        public void Excluir(int campoId)
        {
            using (var context = new CategoriasContext())
            {
                var campo = context.Campos.Find(campoId);
                context.Campos.Remove(campo);
                context.SaveChanges();
            }
        }

        public void Adicionar(Campo campo)
        {
            using (var context = new CategoriasContext())
            {
                context.Campos.Add(campo);
                context.SaveChanges();
            }
        }

    }
}
