using ClientRegisterApp.Data.Models;
using ClientRegisterApp.View;
using ClientRegisterApp.ViewModel;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using ZXing.Net;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace ClientRegisterApp
{
	public partial class MainPage : ContentPage
	{
		MainPageViewModel vm;

		public MainPage ()
		{
			vm = new MainPageViewModel (new Client ());
			try {
				Task.Run (() => vm.GetAllClients ()).Wait ();
			} catch (Exception e) {
				Debug.WriteLine (e);
			}

			BindingContext = vm;
			InitializeComponent ();
		}

		public void OnItemTapped (object obj, ItemTappedEventArgs e)
		{
			//var client = e.Item as Client;
		}

		public async void OnClickedReadCode (object obj, EventArgs args)
		{
			var scanner = new ZXing.Mobile.MobileBarcodeScanner ();
			var result = await scanner.Scan ();
			if (result != null)
				await DisplayAlert ("Info", "Resultado: " + result, "Ok");
		}

		public void OnClickedAdd (object obj, EventArgs args)
		{
			//TODO: Pesquisar sobre a navegação, Implementar tela.

			//Cria uma nova instancia em memoria para o ClientAddViewModel
			ClientAddViewModelSingleton.CreateNewInstance ();
			Navigation.PushAsync (new ClienteAddPage ()).ConfigureAwait (false);

		}

		public async void OnClickedEdit (object obj, EventArgs args)
		{
				
			var client = ClientsList.SelectedItem as Client;
			ClientEditViewModelSingleton.CreateNewInstance (client);
			if (vm.Clients.Count > 0 && client != null) {
				await Navigation.PushAsync (new ClientEditPage (client));
			} else
				await DisplayAlert ("Info", "Por favor, selecione um registro para editar.", "Ok");

		}

		public async void OnClickedExclude (object obj, EventArgs args)
		{
			var client = ClientsList.SelectedItem as Client;
			if (client != null) {
				var result = await DisplayAlert ("Question", string.Format ("Tem certeza que deseja deletar o registro : {0}?", client.Name), "Sim", "Não");
				if (result) {
					await vm.ExcludeClient (client);
					// Chamada da web api para remover um cliente.
					await DisplayAlert ("Info", "Removido com sucesso.", "Ok");
				}
			} else
				await DisplayAlert ("Info", "Por favor, selecione um registro para realizar a operação.", "Ok");
		}
	}
}
