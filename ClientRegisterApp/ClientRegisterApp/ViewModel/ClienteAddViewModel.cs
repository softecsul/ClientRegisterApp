using ClientRegisterApp.Data.Models;
using ClientRegisterApp.Service;
using Xamarin.Forms;
using System.ComponentModel;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClientRegisterApp.View;
using System.Diagnostics;


namespace ClientRegisterApp.ViewModel
{
	public class ClienteAddViewModel:INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;

		private string _imagemSrc;
		public ClientServiceApi clientServiceApi;

		public ClienteAddViewModel (Client client)
		{

			ID = client.ID;
			Name = client.Name;
			Phone = client.Phone;
			Address = client.Address;
			Image = client.Image;
			ImagemSrc = "http://xamarin.com/content/images/pages/forms/example-app.png";
			clientServiceApi = new ClientServiceApi ();

		}

		public ClienteAddViewModel ()
			: this (new Client ())
		{

		}

		public string Address { get; set; }

		public int ID { get; set; }

		public byte[] Image { get; set; }

		public string Name { get; set; }

		public string Phone { get; set; }

		public string ImagemSrc {   
			get{ return  _imagemSrc; } 
			set {
				_imagemSrc = value; 
				OnPropertyChanged ("ImagemSrc");
			}
		}

		public void ChangeImage (string path, byte[] imagem)
		{
			ImagemSrc = path;
			Image = imagem;
		}

		public void TakePicture ()
		{
			var takePicture = DependencyService.Get<ITakePicture> ();
			takePicture.TakePicture (Constants.AddClientCameraAction);
		}

		public Task<bool> Save ()
		{
			var client = new Client {
				ID = this.ID,
				Name = this.Name,
				Phone = this.Phone,
				Address = this.Address,
				Image = Image
			};

			return clientServiceApi.Insert (client);
		}

		protected virtual void OnPropertyChanged (string propertyName)
		{
			if (PropertyChanged != null) {
				var handler = PropertyChanged;
				if (handler != null)
					handler (this, new PropertyChangedEventArgs (propertyName));
			}
		}
	}
}
