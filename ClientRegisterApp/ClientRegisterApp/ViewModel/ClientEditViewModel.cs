using ClientRegisterApp.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.ComponentModel;
using ClientRegisterApp.Service;
using System.Runtime.CompilerServices;

namespace ClientRegisterApp.ViewModel
{
	public class ClientEditViewModel:INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;


		private ClientServiceApi _clientServiceApi;

		#region Fields

		private int _id;
		private string _name;
		private string _phone;
		private string _address;
		private byte[] _image;
		private ImageSource _imagemSrc;

		#endregion

		public ClientEditViewModel (Client client)
		{
			_clientServiceApi = new ClientServiceApi ();

			LoadClient (client.ID);

		}

		public ClientEditViewModel ()
			: this (new Client ())
		{

		}

		public int ID { 
			get { return _id; }
			set {
				_id = value; 
				OnPropertyChanged ("ID");
			}
		}


		public string Name {
			get{ return _name; } 
			set {
				_name = value;
				OnPropertyChanged ("Name");
			} 
		}

		public string Phone {
			get{ return _phone; }
			set {
				_phone = value;
				OnPropertyChanged ();
			} 
		}


		public string Address {
			get {
				return _address;
			}
			set {
				_address = value;
				OnPropertyChanged ();
			}
		}

		public byte[] Image {
			get {
				return _image;
			}
			set {
				_image = value;
				OnPropertyChanged ();
			}
		}

		public ImageSource ImagemSrc {
			
			get{ return  _imagemSrc; } 
			set {
				_imagemSrc = value; 
				OnPropertyChanged ("ImagemSrc");
			}
		}

		private async Task LoadClient (int id)
		{
			var client = await _clientServiceApi.Get (id);
			ID = client.ID;
			Name = client.Name;
			Phone = client.Phone;
			Address = client.Address;
			Image = client.Image;

			// Tratamento de imagem.
			System.IO.Stream buffer = new System.IO.MemoryStream (client.Image);
			ImagemSrc = ImageSource.FromStream (() => buffer);
		}

		public void ChangeImage (string path, byte[] imagem)
		{
			ImagemSrc = path;
			Image = imagem;
		}

		public void TakePicture ()
		{
			var takePicture = DependencyService.Get<ITakePicture> ();
			takePicture.TakePicture (Constants.EditClientCameraAction);

		}

		public bool Save ()
		{
			var client = new Client {
				ID = this.ID,
				Name = this.Name,
				Phone = this.Phone,
				Address = this.Address,
				Image = Image
			};

			return _clientServiceApi.Update (client);
		}

		protected virtual void OnPropertyChanged ([CallerMemberName]string propertyName = null)
		{
			var handler = PropertyChanged;
			if (handler != null) {
				handler (this, new PropertyChangedEventArgs (propertyName));
			}
		}
	}
}
