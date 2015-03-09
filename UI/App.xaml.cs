using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace UI
{
	using System.Windows.Threading;

	using UI.View;
	using UI.ViewModel;

	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public partial class App : Application
	{
		protected override void OnStartup(StartupEventArgs e)
		{
			base.OnStartup(e);
			this.DispatcherUnhandledException += this.OnDispatcherUnhandledException;
			this.Start();
		}

		private void OnDispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
		{
			// Process unhandled exception
			if (e.Exception == null)
			{
				Application.Current.Shutdown();
				return;
			}
			string errorMessage = string.Format("Ocorreu um erro!\r\n {0}", e.Exception.Message);
			//insert code to log exception here
			MessageBox.Show(errorMessage, "Erro", MessageBoxButton.OK, MessageBoxImage.Error);

			// Prevent default unhandled exception processing
			e.Handled = true;
		}

		private void Start()
		{
			this.MainWindow = new MainWindow(new MainViewModel(Environment.UserName));

			this.MainWindow.Show();
		}
	}
}
