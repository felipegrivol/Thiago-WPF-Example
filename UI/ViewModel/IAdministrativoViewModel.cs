namespace UI.ViewModel
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Reactive;
    using Model;
    using ReactiveUI;

	public interface IAdministrativoViewModel : IViewModel
	{
		string DescricaoCategoria { get; set; }
        ObservableCollection<Categoria> Categorias { get; set; }
		Categoria CategoriaSelecionada { get; set; }
		IReactiveCommand<Unit> AdicionarCategoriaCommand { get; }
		IReactiveCommand<Unit> EditarCategoriaCommand { get; }
		IReactiveCommand<Unit> RemoverCategoriaCommand { get; }
		bool EditandoCategoria { get; set; }

		string DescricaoSubCategorias { get; set; }
		IEnumerable<SubCategoria> SubCategorias { get; set; }
		SubCategoria SubCategoriaSelecionada { get; set; }
		IReactiveCommand<Unit> AdicionarSubCategoriaCommand { get; }
		IReactiveCommand<Unit> EditarSubCategoriaCommand { get; }
		IReactiveCommand<Unit> RemoverSubCategoriaCommand { get; }
		bool EditandoSubCategoria { get; set; }

		string DescricaoCampo { get; set; }
		string OrdemCampo { get; set; }
		IDictionary<string, TipoCampo> TiposCampo { get; set; }
		TipoCampo TipoCampo { get; set; }
		IEnumerable<Campo> Campos { get; set; }
		Campo CampoSelecionado { get; set; }
		IReactiveCommand<Unit> AdicionarCampoCommand { get; }
		IReactiveCommand<Unit> EditarCampoCommand { get; }
		IReactiveCommand<Unit> RemoverCampoCommand { get; }
		bool EditandoCampo { get; set; }

	}
}