using System;
using System.Collections.Generic;
using ClientRegisterApp.Droid;
using Xamarin.Forms;
using Android.Views;
using Android.Content;
using Android.Net;
using Android.App;
using Android.Net.Wifi;
using System.Threading.Tasks;

[assembly: Xamarin.Forms.Dependency (typeof(WifiMangerDroid))]
namespace ClientRegisterApp.Droid
{
	public class WifiMangerDroid : IWifiManager
	{
		#region IWifiManager implementation

		public bool IsConnectedInTargetSsid (out string ssid)
		{
			throw new NotImplementedException ();
		}

		public NetworkStatus GetTypeOfConnection ()
		{
			throw new NotImplementedException ();
		}

		public Task<bool> HasNetworkDataTraffic (string host)
		{
			throw new NotImplementedException ();
		}

		#endregion

		#region OLD

		//		public bool IsConnected ()
		//		{
		//			ConnectivityManager connectivityManager =
		//				(ConnectivityManager)((Activity)Forms.Context).GetSystemService (Android.Content.Context.ConnectivityService);
		//			NetworkInfo activeConnection = connectivityManager.ActiveNetworkInfo;
		//			bool isOnline = (activeConnection != null) && activeConnection.IsConnected;
		//
		//			return isOnline;
		//		}
		//
		//		public bool RemoveSsid (string ssid)
		//		{
		//			bool result = false;
		//			WifiManager wifiManager = (WifiManager)((Activity)Forms.Context).GetSystemService (Context.WifiService);
		//			var list = new List<WifiConfiguration> (wifiManager.ConfiguredNetworks);
		//			var network = list.Find (x => x.Ssid == ssid);
		//			if (network != null)
		//				result = wifiManager.RemoveNetwork (network.NetworkId);
		//			return result;
		//		}
		//
		//		public bool ConnectToTarger ()
		//		{
		//			//RemoveSsid ("App");
		//			String networkSSID = "App";
		//			String networkPass = "7891021006125";
		//
		//			WifiConfiguration wifiConfig = new WifiConfiguration ();
		//			wifiConfig.Ssid = String.Format ("\"{0}\"", networkSSID);
		//			wifiConfig.PreSharedKey = string.Format ("\"{0}\"", networkPass);
		//
		//			WifiManager wifiManager = (WifiManager)((Activity)Forms.Context).GetSystemService (Context.WifiService);
		//
		//			if (!wifiManager.IsWifiEnabled) {
		//				wifiManager.SetWifiEnabled (true);
		//			}
		//
		//			var list = new List<WifiConfiguration> (wifiManager.ConfiguredNetworks);
		//			var netid = list.Find (x => x.Ssid.Equals ("\"App\""));
		//
		//			if (netid == null) {
		//
		//				list = new List<WifiConfiguration> (wifiManager.ConfiguredNetworks);
		//				netid = list.Find (x => x.Ssid.Equals ("\"App\""));
		//			} else {
		//				wifiManager.RemoveNetwork (netid.NetworkId);
		//			}
		//
		//			wifiManager.Disconnect ();
		//			wifiManager.EnableNetwork (32, true);
		//			wifiManager.Reconnect ();
		//			return IsConnected ();
		//		}

		#endregion
	}
}

