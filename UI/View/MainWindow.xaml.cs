namespace UI.View
{
	#region References

	using System.Windows;

	using ReactiveUI;

	using UI.ViewModel;

	#endregion

	/// <summary>
	///     Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window, IViewFor<MainViewModel>
	{
		public MainWindow()
		{
			this.InitializeComponent();
		}

		public MainWindow(MainViewModel viewModel)
			: this()
		{
			this.DataContext = viewModel;
			this.ViewModel = viewModel;
		}

		object IViewFor.ViewModel
		{
			get
			{
				return this.ViewModel;
			}
			set
			{
				this.ViewModel = (MainViewModel)value;
			}
		}

		public MainViewModel ViewModel { get; set; }
	}
}