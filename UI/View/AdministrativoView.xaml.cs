namespace UI.View
{
	#region References

	using System.Windows.Controls;

	using ReactiveUI;

	using UI.ViewModel;

	#endregion

	/// <summary>
	///     Interaction logic for AdministrativoView.xaml
	/// </summary>
	public partial class AdministrativoView : UserControl, IViewFor<AdministrativoViewModel>
	{
		public AdministrativoView()
		{
			this.InitializeComponent();
		}

		object IViewFor.ViewModel
		{
			get
			{
				return this.ViewModel;
			}
			set
			{
				this.ViewModel = (AdministrativoViewModel)value;
			}
		}

		public AdministrativoViewModel ViewModel { get; set; }
	}
}