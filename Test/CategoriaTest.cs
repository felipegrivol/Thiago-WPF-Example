using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model;
using Data;

namespace Test
{
    [TestClass]
    public class CategoriaTest
    {
        [TestMethod]
        public void AdicionarCategoriaTest()
        {
            var data = new CategoriaData();

            var categoria = new Categoria()
            {
                Descricao = "Carros"
            };

            data.Adicionar(categoria);
            var result = data.ObterPorId(categoria.Id);
            Assert.IsTrue(result != null && result.Id > 0, "Categoria não inserida");
        }
        [TestMethod]
        public void ExcluirCategoriaTest()
        {
            var data = new CategoriaData();

            var categoria = new Categoria()
            {
                Descricao = "Avião"
            };

            data.Adicionar(categoria);
            data.Excluir(categoria.Id);
            var result = data.ObterPorId(categoria.Id);

            Assert.IsTrue(result == null, "Categoria não excluida");
        }
    }
}
