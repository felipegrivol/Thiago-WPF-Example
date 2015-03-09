namespace UI.ViewModel
{
	#region References

	using System.Reactive;

	using ReactiveUI;

	#endregion

	public class MainViewModel : ViewModelBase
	{
		private bool _administrativo;
		private bool _publico;
		private string _userName;
		private AdministrativoViewModel _administrativoViewModel;
		private PublicoViewModel _publicoViewModel;

		public MainViewModel(string username)
		{
			this.UserName = username;
			this.AbrirTelaAdministrativoCommand = this.CreateCommand(this.AbrirTelaAdministrativo);
			this.AbrirTelaPublicoCommand = this.CreateCommand(this.AbrirTelaPublico);
		}

		public string UserName
		{
			get
			{
				return this._userName;
			}
			set
			{
				this.RaiseAndSetIfChanged(ref this._userName, value);
			}
		}

		public bool Administrativo
		{
			get
			{
				return this._administrativo;
			}
			set
			{
				this.RaiseAndSetIfChanged(ref this._administrativo, value);
			}
		}

		public bool Publico
		{
			get
			{
				return this._publico;
			}
			set
			{
				this.RaiseAndSetIfChanged(ref this._publico, value);
			}
		}

		public AdministrativoViewModel AdministrativoViewModel
		{
			get
			{
				return this._administrativoViewModel;
			}
			set
			{
				this.RaiseAndSetIfChanged(ref this._administrativoViewModel, value);
			}
		}

		public PublicoViewModel PublicoViewModel
		{
			get
			{
				return this._publicoViewModel;
			}
			set
			{
				this.RaiseAndSetIfChanged(ref this._publicoViewModel, value);
			}
		}

		public IReactiveCommand<Unit> AbrirTelaAdministrativoCommand { get; private set; }
		public IReactiveCommand<Unit> AbrirTelaPublicoCommand { get; private set; }

		private void AbrirTelaAdministrativo()
		{
			this.Publico = false;
			this.Administrativo = true;
			this.AdministrativoViewModel = new AdministrativoViewModel();
		}

		private void AbrirTelaPublico()
		{
			this.Publico = true;
			this.Administrativo = false;
			this.PublicoViewModel = new PublicoViewModel();
		}
	}
}