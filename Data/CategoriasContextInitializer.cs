namespace Data
{
	#region References

	using System.Collections.Generic;
	using System.Data.Entity;

	using Model;

	#endregion

	public class CategoriasContextInitializer : DropCreateDatabaseIfModelChanges<CategoriasContext>
	{
        //public override void InitializeDatabase(CategoriasContext context)
        //{
        //    var categorias = new List<Categoria>()
        //                     {
        //                         new Categoria() { Descricao = "Livraria" },
        //                         new Categoria() { Descricao = "Papelaria" },
        //                         new Categoria() { Descricao = "Games" },
        //                     };

        //    context.Categorias.AddRange(categorias);
        //    context.SaveChanges();

        //    var subcategorias = new List<SubCategoria>()
        //                        {
        //                            new SubCategoria()
        //                            {
        //                                Descricao = "Juridico",
        //                                CategoriaId = 1,
        //                                Campos = new List<Campo>
        //                                         {
        //                                             new Campo() { Ordem = 1, Descricao = "Nome", Tipo = TipoCampo.Textbox },
        //                                             new Campo() { Ordem = 2, Descricao = "Valor", Tipo = TipoCampo.Textbox },
        //                                         }
        //                            },
        //                            new SubCategoria()
        //                            {
        //                                Descricao = "Papelaria",
        //                                CategoriaId = 1,
        //                                Campos = new List<Campo>
        //                                         {
        //                                             new Campo() { Ordem = 1, Descricao = "Nome", Tipo = TipoCampo.Textbox },
        //                                             new Campo() { Ordem = 2, Descricao = "Valor", Tipo = TipoCampo.Textbox },
        //                                             new Campo() { Ordem = 3, Descricao = "Fabricante", Tipo = TipoCampo.Textbox },
        //                                         }
        //                            },
        //                            new SubCategoria()
        //                            {
        //                                Descricao = "Acao",
        //                                CategoriaId = 3,
        //                                Campos = new List<Campo>
        //                                         {
        //                                             new Campo() { Ordem = 1, Descricao = "Nome", Tipo = TipoCampo.Textbox },
        //                                             new Campo() { Ordem = 2, Descricao = "Valor", Tipo = TipoCampo.Textbox },
        //                                             new Campo() { Ordem = 3, Descricao = "Tipo", Tipo = TipoCampo.Radio },
        //                                         }
        //                            },
        //                        };

        //    context.SubCategorias.AddRange(subcategorias);
        //    context.SaveChanges();
        //    base.InitializeDatabase(context);
        //}
	}
}