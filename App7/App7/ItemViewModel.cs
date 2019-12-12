using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace App7
{
	sealed class ItemViewModel : BaseViewModel
	{
		public string Name => obj.Name;

		public int Id => obj.Id;

		uint count;

		public uint Count
		{
			get => count;
			set => SetProperty(ref count, value);
		}

		public Command AddCommand { get; }
		public Command RemoveCommand { get; }

		Item obj;
		public ItemViewModel(Item item)
		{
			obj = item;
			AddCommand = new Command(AddCommandExecute);
			RemoveCommand = new Command(RemoveCommandExecute);
		}

		private void AddCommandExecute()
		{
			Count = ++obj.Count;
		}

		private void RemoveCommandExecute()
		{
			if (obj.Count == 0)
				return;
			Count = --obj.Count;
		}
	}
}
