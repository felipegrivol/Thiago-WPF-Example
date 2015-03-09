using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Data
{
    public class SubCategoriaData
    {
        public List<SubCategoria> Obter()
        {
            List<SubCategoria> subCategorias = null;

            using (var context = new CategoriasContext())
            {
                var query = from c in context.SubCategorias
                            select c;
                subCategorias = new List<SubCategoria>(query);
            }

            return subCategorias;
        }

        public SubCategoria ObterPorId(int subCategoriaId)
        {
            SubCategoria subCategoria = null;

            using (var context = new CategoriasContext())
            {
                var query = from c in context.SubCategorias
                            where c.Id == subCategoriaId
                            select c;

                subCategoria = query.FirstOrDefault();
            }

            return subCategoria;
        }

        public List<SubCategoria> ObterPorCategoriaId(int categoriaId)
        {
            List<SubCategoria> subCategorias = null;

            using (var context = new CategoriasContext())
            {
                var query = from c in context.SubCategorias
                            where c.CategoriaId == categoriaId
                            select c;

                subCategorias = new List<SubCategoria>(query);
            }

            return subCategorias;
        }

        public void Excluir(int subCategoriaId)
        {
            using (var context = new CategoriasContext())
            {
                var subCategoria = context.SubCategorias.Find(subCategoriaId);
                context.SubCategorias.Remove(subCategoria);
                context.SaveChanges();
            }
        }

        public void Adicionar(SubCategoria subCategoria)
        {
            using (var context = new CategoriasContext())
            {
                context.SubCategorias.Add(subCategoria);
                context.SaveChanges();
            }
        }


    }
}
