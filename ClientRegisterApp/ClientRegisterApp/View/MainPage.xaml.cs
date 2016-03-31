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
			/*var wifiManger = DependencyService.Get<IWifiManager> ();
			var type = wifiManger.GetTypeOfConnection ();

			try {
				if (type != NetworkStatus.NotReachable)
					Task.Run ((Func<Task>)vm.GetAllClients).Wait ();
			} catch (Exception e) {
				Debug.WriteLine (e);
			}*/

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

		public void OnClickedShowSsid (object obj, EventArgs args)
		{
			var wifiManger = DependencyService.Get<IWifiManager> ();
			string ssid;
			var isConnected = wifiManger.IsConnectedInTargetSsid (out ssid);
			if (isConnected) {
				DisplayAlert ("Info", "Conectado a rede alvo: App.", "Ok");
			} else {
				DisplayAlert ("Info", "Não conectado a rede alvo, rede conectada: " + ssid, "Ok");
			}
		}

		public void OnClickedShowCurrentNetwork (object obj, EventArgs args)
		{
			var wifiManger = DependencyService.Get<IWifiManager> ();
			var type = wifiManger.GetTypeOfConnection ();
			switch (type) {
			case NetworkStatus.NotReachable:
				DisplayAlert ("Info", "Sem internet.", "Ok");
				break;
			case NetworkStatus.ReachableViaCarrierDataNetwork:
				DisplayAlert ("Info", "Conexão via 3G", "Ok");
				break;
			case NetworkStatus.ReachableViaWiFiNetwork:
				DisplayAlert ("Info", "Conexão via Wifi", "Ok");
				break;
			}
		}

		public async void OnClickedHasDataTraffic (object obj, EventArgs args)
		{
			int count = 0;
			string host = txtHost.Text ?? "https://www.google.com.br";
			x:
			var wifiManger = DependencyService.Get<IWifiManager> ();
			var result = await wifiManger.HasNetworkDataTraffic (host);

			if (result && count == 0) {
				count++;
				goto x;
			}
			if (result) {
				DisplayAlert ("Info", "Possui trafego de dados", "Ok");
			} else {
				DisplayAlert ("Info", "Não possui trafego de dados", "Ok");
			}
				
		}
	}
}