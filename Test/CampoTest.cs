using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Model;
using Data;
using System.Collections.Generic;

namespace Test
{
    [TestClass]
    public class CampoTest
    {
        [TestMethod]
        public void AdicionarCampoTest()
        {
            var data = new CampoData();

            var subCategorias = new SubCategoriaData().Obter();
            if (subCategorias == null || subCategorias.Count == 0)
                Assert.Fail("Não existem subcategorias cadastradas");

            var campo = new Campo()
            {
                Descricao = "Combustível",
                SubCategoriaId = subCategorias[0].Id,
                Ordem = 1,
                Tipo = TipoCampo.Combobox
            };

            data.Adicionar(campo);
            var result = data.ObterPorId(campo.Id);
            Assert.IsTrue(result != null && result.Id > 0, "Campo não inserida");
        }
        [TestMethod]
        public void ExcluirCampoTest()
        {
            var data = new CampoData();

            var subCategorias = new SubCategoriaData().Obter();
            if (subCategorias == null || subCategorias.Count == 0)
                Assert.Fail("Não existem subcategorias cadastradas");

            var campo = new Campo()
            {
                Descricao = "Combustível",
                SubCategoriaId = subCategorias[0].Id,
                Ordem = 1,
                Tipo = TipoCampo.Combobox
            };

            data.Adicionar(campo);
            data.Excluir(campo.Id);
            var result = data.ObterPorId(campo.Id);

            Assert.IsTrue(result == null, "Campo não excluida");
        }
    }
}
