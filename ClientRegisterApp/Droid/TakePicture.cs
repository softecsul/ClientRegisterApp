using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using ClientRegisterApp.Droid;
using Java.IO;
using Android.Graphics;
using Android.Provider;
using Android.Content.PM;
using Xamarin.Forms;

[assembly: Xamarin.Forms.Dependency (typeof(TakePicture))]
namespace ClientRegisterApp.Droid
{
	
	public class TakePicture : ITakePicture
	{
		public static readonly File File = new File (Android.OS.Environment.GetExternalStoragePublicDirectory (
			                                   Android.OS.Environment.DirectoryPictures), string.Format ("temp.jpg", new Guid ().ToString ()));

		void ITakePicture.TakePicture (int constantAction)
		{
			var intent = new Intent (MediaStore.ActionImageCapture);
			intent.PutExtra (MediaStore.ExtraOutput, Android.Net.Uri.FromFile (File));
			((Activity)Forms.Context).StartActivityForResult (intent, constantAction);
		}
	}
}