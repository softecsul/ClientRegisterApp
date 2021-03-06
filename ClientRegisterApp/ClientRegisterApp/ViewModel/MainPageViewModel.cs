﻿using ClientRegisterApp.Data.Models;
using ClientRegisterApp.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientRegisterApp.ViewModel
{
	public class MainPageViewModel : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;

		public ClientServiceApi clientServiceApi;

		public MainPageViewModel (Client client)
		{
			ID = client.ID;
			Name = client.Name;
			Phone = client.Phone;
			Address = client.Address;
			Image = client.Image;

			clientServiceApi = new ClientServiceApi ();
		}


		public async Task GetAllClients ()
		{
			Clients = new ObservableCollection<Client> (await clientServiceApi.GetAll ());
			//await Task.Run(()=>Clients = new ObservableCollection<Client>());
		}

		public MainPageViewModel ()
			: this (new Client ())
		{

		}

		public int ID { get; set; }

		public string Name { get; set; }

		public string Phone { get; set; }

		public string Address { get; set; }

		public byte[] Image { get; set; }


		// TODO: Metodos para formatar apresentação na View.

		public async Task<bool> ExcludeClient (Client client)
		{
			var result = await clientServiceApi.Delete (client.ID);
			if (result) {
				Clients.Remove (client);
				OnPropertyChanged (nameof (Clients));
				return true;
			}
			return false;
		}

		public static Client GetClient ()
		{
			return null;
		}

		public ObservableCollection<Client> Clients { get; set; }


		protected virtual void OnPropertyChanged (string propertyName)
		{
			if (PropertyChanged != null) {
				var handler = PropertyChanged;
				if (handler != null)
					handler (this, new PropertyChangedEventArgs (propertyName));
			}
		}
	}
}
