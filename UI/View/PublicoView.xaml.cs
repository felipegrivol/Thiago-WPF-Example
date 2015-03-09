namespace UI.View
{
	#region References

	using System.Windows.Controls;

	using ReactiveUI;

	using UI.ViewModel;
    using Model;

	#endregion

	/// <summary>
	///     Interaction logic for PublicoView.xaml
	/// </summary>
	public partial class PublicoView : UserControl, IViewFor<PublicoViewModel>
	{
		public PublicoView()
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
				this.ViewModel = (PublicoViewModel)value;
			}
		}

		public PublicoViewModel ViewModel { get; set; }

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            this.MainForm.Children.Clear();

            foreach (var campo in ((PublicoViewModel)this.DataContext).Campos)
            {
                System.Windows.Controls.TextBlock newDesc = new TextBlock();
                newDesc.Text = campo.Descricao;
                this.MainForm.Children.Add(newDesc);

                switch (campo.Tipo)
                {
                    case TipoCampo.Textbox:
                        System.Windows.Controls.TextBox newCampo = new System.Windows.Controls.TextBox();
                        this.MainForm.Children.Add(newCampo);
                        break;
                    case TipoCampo.Combobox:
                        System.Windows.Controls.ComboBox newCbo = new ComboBox();
                        newCbo.ItemsSource = campo.Opcoes;
                        newCbo.DisplayMemberPath = "Descricao";
                        this.MainForm.Children.Add(newCbo);
                        break;
                }
            }
        }
	}
}