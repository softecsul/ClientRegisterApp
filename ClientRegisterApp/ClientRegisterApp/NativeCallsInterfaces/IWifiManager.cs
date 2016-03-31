using System;
using System.Threading.Tasks;

namespace ClientRegisterApp
{
	/// <summary>
	/// Enum for network status (no internet, mobile internet or wifi)
	/// </summary>
	public enum NetworkStatus
	{
		NotReachable,
		ReachableViaCarrierDataNetwork,
		ReachableViaWiFiNetwork

	}

	public interface IWifiManager
	{
		/// <summary>
		/// Determines whether the App is connected in target ssid.
		/// </summary>
		/// <returns><c>true</c> if this instance is connected in target ssid; otherwise, <c>false</c>.</returns>
		bool IsConnectedInTargetSsid (out string ssid);

		/// <summary>
		/// Gets the type of network connection.
		/// </summary>
		/// <returns>The type of connection.</returns>
		NetworkStatus GetTypeOfConnection ();

		/// <summary>
		/// Determines if the network has data traffic.
		/// </summary>
		/// <returns><c>true</c> if this instance has network data traffic; otherwise, <c>false</c>.</returns>
		Task<bool> HasNetworkDataTraffic (string host);
	}
}