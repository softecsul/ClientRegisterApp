using System;
using ClientRegisterApp.ViewModel;

namespace ClientRegisterApp
{
	public class ClientEditViewModelSingleton
	{
		private static ClientEditViewModel instance;

		public static void CreateNewInstance (global::ClientRegisterApp.Data.Models.Client client)
		{
			instance = new ClientEditViewModel (client);
		}

		public static ClientEditViewModel GetInstance ()
		{
			if (instance == null) {
				instance = new ClientEditViewModel ();
			}
			return instance;
		}
	}
}

