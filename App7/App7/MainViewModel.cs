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
		public ObservableCollection<ItemViewModel> Items { get; }

		public MainViewModel()
		{
			Items = new ObservableCollection<ItemViewModel>();
		}

		public async override Task InitAsync()
		{
			var items = await ClientAPI.GetItemsAsync();
			items.ForEach(item => Items.Add(new ItemViewModel(item)));
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
