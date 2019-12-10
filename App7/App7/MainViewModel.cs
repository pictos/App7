using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace App7
{
	sealed class MainViewModel : BaseViewModel
	{
		public ObservableCollection<Item> Items { get; }

		public Command<Item> AddCommand { get; }
		public Command<Item> RemoveCommand { get; }

		public MainViewModel()
		{
			Items = new ObservableCollection<Item>();
			AddCommand = new Command<Item>(AddCommandExecute);
			RemoveCommand = new Command<Item>(RemoveCommandExecute);
		}

		private void AddCommandExecute(Item obj)
		{
			++obj.Count;
		}

		private void RemoveCommandExecute(Item obj)
		{
			if (obj.Count == 0)
				return;
			--obj.Count;
		}

		public async override Task InitAsync()
		{
			var items = await ClientAPI.GetItemsAsync();
			items.ForEach(Items.Add);
		}
	}

	abstract class BaseViewModel : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler? PropertyChanged;

		private IClientAPI? clientAPI;

		public IClientAPI ClientAPI => clientAPI ??= DependencyService.Get<IClientAPI>();


		protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}

		protected bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string? propertyName = null)
		{
			if (EqualityComparer<T>.Default.Equals(storage, value))
				return false;

			storage = value;
			OnPropertyChanged(propertyName);

			return true;
		}

		public virtual Task InitAsync() => Task.CompletedTask;
	}
}
