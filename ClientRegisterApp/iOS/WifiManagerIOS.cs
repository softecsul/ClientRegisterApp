using System;
using ClientRegisterApp.iOS;

[assembly: Xamarin.Forms.Dependency (typeof(WifiManagerIOS))]
namespace ClientRegisterApp.iOS
{
	public class WifiManagerIOS:IWifiManager
	{
		public WifiManagerIOS ()
		{
		}

		#region IWifiManager implementation

		public bool IsConnected ()
		{
			//throw new NotImplementedException ();
			return true;
		}

		public bool ConnectToTarger ()
		{
			//throw new NotImplementedException ();
			return true;
		}

		#endregion
	}
}

