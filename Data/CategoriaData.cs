using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Data
{
    public class CategoriaData
    {
        public List<Categoria> Obter()
        {
            List<Categoria> categorias = null;

            using(var context = new CategoriasContext())
            {
                var query = from c in context.Categorias
                            select c;
                categorias = new List<Categoria>(query);
            }

            return categorias;
        }

        public Categoria ObterPorId(int categoriaId)
        {
            Categoria categoria = null;

            using(var context = new CategoriasContext())
            {
                var query = from c in context.Categorias
                            where c.Id == categoriaId
                            select c;

                categoria = query.FirstOrDefault();
            }

            return categoria;
        }

        public void Excluir(int categoriaId)
        {
            using(var context = new CategoriasContext())
            {
                var categoria = context.Categorias.Find(categoriaId);
                context.Categorias.Remove(categoria);
                context.SaveChanges();
            }
        }

        public void Adicionar(Categoria categoria)
        {
            using(var context = new CategoriasContext())
            {
                context.Categorias.Add(categoria);
                context.SaveChanges();
            }
        }
    }
}
