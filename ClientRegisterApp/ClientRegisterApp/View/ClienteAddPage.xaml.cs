using System;
using ClientRegisterApp.ViewModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClientRegisterApp.Data.Models;
using Xamarin.Forms;



namespace ClientRegisterApp.View
{
	public partial class ClienteAddPage : ContentPage
	{
		private ClienteAddViewModel vm;

		public ClienteAddPage ()
		{
			vm = ClientAddViewModelSingleton.GetInstance ();
			BindingContext = vm;
			InitializeComponent ();
		}


		public void OnTakePictureClicked (object obj, EventArgs evt)
		{
			vm.TakePicture ();
		}

		public async void BtnSaveCicked (object obj, EventArgs evt)
		{
			var result = await vm.Save ();
			if (result) {
				await DisplayAlert ("Info", "Inserido com sucesso!", "Ok");
				await Navigation.PushAsync (new MainPage ());
			} else
				await DisplayAlert ("Erro", "Erro ao incluir registro.", "Ok");

		}
	}
}
