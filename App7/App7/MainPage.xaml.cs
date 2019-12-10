using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App7
{
	// Learn more about making custom code visible in the Xamarin.Forms previewer
	// by visiting https://aka.ms/xamarinforms-previewer
	[DesignTimeVisible(false)]
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
		}

		protected override void OnAppearing()
		{
			(BindingContext as BaseViewModel)!.InitAsync();
		}

		private void Button_Clicked(object sender, EventArgs e)
		{
			(BindingContext as MainViewModel)!.RemoveCommand.Execute((sender as Button)?.BindingContext);
		}
	}
}
