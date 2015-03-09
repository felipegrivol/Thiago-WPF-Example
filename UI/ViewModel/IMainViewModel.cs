namespace UI.ViewModel
{
	using System.Reactive;

	using ReactiveUI;

	public interface IMainViewModel 
	{
		string UserName { get; set; }
		bool Administrativo { get; set; }
		bool Publico { get; set; }

		//IAdministrativoViewModel AdministrativoViewModel { get; set; }
		//IPublicoViewModel PublicoViewModel { get; set; }

		IReactiveCommand<Unit> AbrirTelaAdministrativoCommand { get; }
		IReactiveCommand<Unit> AbrirTelaPublicoCommand { get; }
	}
}