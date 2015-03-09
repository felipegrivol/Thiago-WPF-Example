namespace UI.ViewModel
{
	#region References

    using System;
    using System.Reactive;
    using System.Reactive.Concurrency;
    using System.Reactive.Linq;
    using System.Threading.Tasks;
    using System.Windows;
    using ReactiveUI;

	#endregion

	public abstract class ViewModelBase : ReactiveObject, IViewModel
	{
		private bool _isBusy;
		public bool IsBusy
		{
			get
			{
				return this._isBusy;
			}
			protected set
			{
				this.RaiseAndSetIfChanged(ref _isBusy, value);
			}
		}

        public ViewModelBase()
        {
            RxApp.MainThreadScheduler = new DispatcherScheduler(Application.Current.Dispatcher);
        }

		protected ReactiveCommand<Unit> CreateCommand(Action execute)
		{
			var command = ReactiveCommand.CreateAsyncTask(async _ => await this.Work(execute), RxApp.MainThreadScheduler);
			command.ThrownExceptions.DistinctUntilChanged().Subscribe(e => MessageBox.Show(e.Message, "Error", MessageBoxButton.OK));
			command.IsExecuting.Subscribe(isExecuting => IsBusy = isExecuting);

			return command;
			
		}

		protected ReactiveCommand<Unit> CreateCommand(IObservable<bool> canExecute, Action execute)
		{
			var command = ReactiveCommand.CreateAsyncTask(canExecute, async _ => await this.Work(execute), RxApp.MainThreadScheduler);
			command.ThrownExceptions.DistinctUntilChanged().Subscribe(e => MessageBox.Show(e.Message, "Error", MessageBoxButton.OK));
			command.IsExecuting.Subscribe(isExecuting => IsBusy = isExecuting);

			return command;
		}

		private Task Work(Action action)
		{
			var work = Task.Run(() =>
			{
				if (action != null)
				{
					action();
				}
			});
			return work;
		}


	}
}