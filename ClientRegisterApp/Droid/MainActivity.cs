using System;
using Java.IO;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using ClientRegisterApp.ViewModel;


namespace ClientRegisterApp.Droid
{
	[Activity (Label = "ClientRegisterApp.Droid", Icon = "@drawable/icon", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
	public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsApplicationActivity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			global::Xamarin.Forms.Forms.Init (this, bundle);

			ZXing.Mobile.MobileBarcodeScanner.Initialize (Application);

			//Xamarin Forms
			LoadApplication (new ClientRegisterApp ());
		}

		protected override void OnActivityResult (int requestCode, Result resultCode, Intent data)
		{
			if (requestCode == Constants.AddClientCameraAction && resultCode == Result.Ok) {

				File file = new File (TakePicture.File.Path);
				byte[] imagemBuffer = Read (file);
				ClientAddViewModelSingleton.GetInstance ().ChangeImage (TakePicture.File.Path, imagemBuffer);	
			} else if (requestCode == Constants.EditClientCameraAction && resultCode == Android.App.Result.Ok) {

				File file = new File (TakePicture.File.Path);
				byte[] imagemBuffer = Read (file);
				ClientEditViewModelSingleton.GetInstance ().ChangeImage (TakePicture.File.Path, imagemBuffer);	
			}

		}

		public byte[] Read (File file)
		{
			ByteArrayOutputStream ous = null;
			InputStream ios = null;
			try {
				byte[] buffer = new byte[4096];
				ous = new ByteArrayOutputStream ();
				ios = new FileInputStream (file);
				int read = 0;
				while ((read = ios.Read (buffer)) != -1) {
					ous.Write (buffer, 0, read);
				}
			} finally {
				try {
					if (ous != null)
						ous.Close ();
				} catch (IOException e) {
					Android.Util.Log.Debug ("DEBUG", e.ToString ());
				}

				try {
					if (ios != null)
						ios.Close ();
				} catch (IOException e) {
					Android.Util.Log.Debug ("DEBUG", e.ToString ());
				}
			}
			return ous.ToByteArray ();
		}
	}
}

