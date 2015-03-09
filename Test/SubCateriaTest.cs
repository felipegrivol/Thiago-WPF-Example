using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Model;
using Data;

namespace Test
{
    [TestClass]
    public class SubCateriaTest
    {
        [TestMethod]
        public void AdicionarSubCategoriaTest()
        {
            var data = new SubCategoriaData();

            var categorias = new CategoriaData().Obter();
            if(categorias == null || categorias.Count == 0)
                Assert.Fail("Não existem categorias cadastradas");

            var subCategoria = new SubCategoria()
            {
                Descricao = "Sedan",
                CategoriaId = categorias[0].Id,
            };

            data.Adicionar(subCategoria);
            var result = data.ObterPorId(subCategoria.Id);
            Assert.IsTrue(result != null && result.Id > 0, "SubCategoria não inserida");
        }
        [TestMethod]
        public void ExcluirSubCategoriaTest()
        {
            var data = new SubCategoriaData();

            var categorias = new CategoriaData().Obter();
            if (categorias == null || categorias.Count == 0)
                Assert.Fail("Não existem categorias cadastradas");

            var subCategoria = new SubCategoria()
            {
                Descricao = "Sedan",
                CategoriaId = categorias[0].Id,
            };

            data.Adicionar(subCategoria);
            data.Excluir(subCategoria.Id);
            var result = data.ObterPorId(subCategoria.Id);

            Assert.IsTrue(result == null, "SubCategoria não excluida");
        }
    }
}
