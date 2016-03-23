using System;

namespace ClientRegisterApp
{
	public interface IWifiManager
	{
		bool IsConnected ();

		bool ConnectToTarger ();
	}
}