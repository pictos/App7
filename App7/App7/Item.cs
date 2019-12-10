using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace App7
{
	public class Item : BindableObject
	{
		public int Id { get; set; }

		public string Name { get; set; } = string.Empty;

		private uint count;

		public uint Count
		{
			get { return count; }
			set { count = value; OnPropertyChanged(); }
		}

	}
}
