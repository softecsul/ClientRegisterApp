using ClientRegisterApp.iOS;
using Foundation;
using SystemConfiguration;
using System.Net.Http;
using System;
using System.Threading.Tasks;
using System.Diagnostics;



[assembly: Xamarin.Forms.Dependency (typeof(WifiManagerIOS))]
namespace ClientRegisterApp.iOS
{
	public class WifiManagerIOS:IWifiManager
	{
		
		#region IWifiManager implementation

		public static string HostName = "https://www.google.com.br";
		//		private Action success;
		//		private Action failure;

		//it tries to connect to google.com to check if internet exists or not.

		public bool IsConnectedInTargetSsid (out string ssid)
		{
			ssid = string.Empty;
			Foundation.NSDictionary dict;
			var status = CaptiveNetwork.TryCopyCurrentNetworkInfo ("en0", out dict);
			if (status == StatusCode.NoKey || dict == null) {
				return false;
			}

			var bssid = dict [CaptiveNetwork.NetworkInfoKeyBSSID];
			var ssidObj = dict [CaptiveNetwork.NetworkInfoKeySSID];
			var ssiddata = dict [CaptiveNetwork.NetworkInfoKeySSIDData];

			//TODO: Implementar acesso ao banco para não ficar hard code aqui.
			ssid = ssidObj.ToString ();
			return ssid == "App";
		}

		public NetworkStatus GetTypeOfConnection ()
		{
			return NetworkHelper.InternetConnectionStatus ();
		}

		public async Task<bool> HasNetworkDataTraffic (string host)
		{
			try {
				using (var client = new HttpClient ()) {
					var m = new HttpRequestMessage (HttpMethod.Head, "http://google.com");

					client.Timeout = TimeSpan.FromSeconds (1);
					var resp = await client.SendAsync (m);
					return resp != null;
				}
			} catch (Exception e) {
				Debug.WriteLine (e.ToString ());
				return false;
			}

		}


		#endregion

	}
}

