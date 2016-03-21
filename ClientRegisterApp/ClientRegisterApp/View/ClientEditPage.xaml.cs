using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using ClientRegisterApp.ViewModel;
using ClientRegisterApp.Data.Models;

namespace ClientRegisterApp.View
{
	public partial class ClientEditPage : ContentPage
	{
		private ClientEditViewModel vm;


		public ClientEditPage (Client client)
		{

			vm = ClientEditViewModelSingleton.GetInstance ();
			BindingContext = vm;
			InitializeComponent ();
		}

		public void OnTakePictureClicked (object obj, EventArgs evt)
		{
			vm.TakePicture ();
		}

		public void BtnSaveCicked (object obj, EventArgs evt)
		{
			var result = vm.Save ();
			if (result) {
				DisplayAlert ("Info", "Alterado com sucesso!", "Ok");
				Navigation.PushAsync (new MainPage ()).ConfigureAwait (false);
			} else
				DisplayAlert ("Erro", "Erro ao alterar registro.", "Ok");
		}
	}
}
