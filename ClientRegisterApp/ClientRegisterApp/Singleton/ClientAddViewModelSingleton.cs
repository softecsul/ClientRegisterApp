using System;
using ClientRegisterApp.ViewModel;

namespace ClientRegisterApp
{
	public class ClientAddViewModelSingleton
	{
		private static ClienteAddViewModel instance;

		public static void CreateNewInstance ()
		{
			instance = new ClienteAddViewModel (new global::ClientRegisterApp.Data.Models.Client ());
		}

		public static ClienteAddViewModel GetInstance ()
		{
			if (instance == null) {
				instance = new ClienteAddViewModel ();
			}
			return instance;
		}
	}

}


