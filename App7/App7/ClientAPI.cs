using App7;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

[assembly: Xamarin.Forms.Dependency(typeof(ClientAPI))]
namespace App7
{
	public class ClientAPI : IClientAPI
	{
		public async Task<IEnumerable<Item>> GetItemsAsync()
		{
			await Task.Delay(200).ConfigureAwait(false);

			return await Task.Run<IEnumerable<Item>>(() =>
			{
				var list = new List<Item>
				{
					new Item { Name = "HeadPhone", Id = 1},
					new Item { Name = "CellPhone", Id = 2},
					new Item { Name = "Notebook", Id = 3},
					new Item { Name = "Pen Drive", Id = 4},
				};

				return list;
			});
		}

		public Task SendItemAsync()
		{
			return Task.Run(() => Debug.WriteLine("Send data"));
		}
	}

	interface IClientAPI
	{
		Task<IEnumerable<Item>> GetItemsAsync();

		Task SendItemAsync();
	}
}
