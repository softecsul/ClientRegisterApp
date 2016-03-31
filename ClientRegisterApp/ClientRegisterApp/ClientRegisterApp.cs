using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Diagnostics;

using System.Threading.Tasks;


using Xamarin.Forms;



namespace ClientRegisterApp
{
	public class ClientRegisterApp : Application
	{
		public ClientRegisterApp ()
		{
			// The root page of your application
			MainPage = new NavigationPage (new MainPage ());
		}

		protected override void OnStart ()
		{
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
