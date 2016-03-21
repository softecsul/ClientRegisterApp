using ClientRegisterApp.Data.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ClientRegisterApp.Service
{
	public class ClientServiceApi : IWebApi<Client>
	{
		HttpClient client;

		public ClientServiceApi ()
		{
			client = new HttpClient {
				MaxResponseContentBufferSize = 1000000 * 10 //10mb
			};
			client.DefaultRequestHeaders.Accept.Clear ();
			client.DefaultRequestHeaders.Accept.Add (new MediaTypeWithQualityHeaderValue ("application/json"));
		}

		public async Task<bool> Delete (int id)
		{
			try {
				var uri = new Uri (string.Format (Constants.RestURL, "Clientes/" + id));
				await client.DeleteAsync (uri);
				return true;	
			} catch (Exception ex) {
				System.Diagnostics.Debug.WriteLine (ex);
				return false;
			}

		}

		public async Task<Client> Get (int id)
		{
			Client c = null;

			var uri = new Uri (string.Format (Constants.RestURL, "Clientes/" + id));

			var response = await client.GetAsync (uri);
			if (response.IsSuccessStatusCode) {
				var content = await response.Content.ReadAsStringAsync ();
				c = JsonConvert.DeserializeObject<Client> (content);
			}

			return c;
		}

		public async Task<IEnumerable<Client>> GetAll ()
		{
			List<Client> clients = null;

			var uri = new Uri (string.Format (Constants.RestURL, "Clientes"));


			var response = await client.GetAsync (uri);
			if (response.IsSuccessStatusCode) {
				var content = await response.Content.ReadAsStringAsync ();
				clients = JsonConvert.DeserializeObject<List<Client>> (content);
			}

			return clients;
		}

		public async Task<bool> Insert (Client c)
		{
			var json = JsonConvert.SerializeObject (c, Formatting.None);
			using (var content = new StringContent (json, Encoding.UTF8, "application/json")) {
				await client.PostAsync (string.Format (Constants.RestURL, "Clientes"), content);
				return true;
			}
		}

		public bool Update (Client c)
		{
			var json = JsonConvert.SerializeObject (c, Formatting.None);
			using (var content = new StringContent (json, Encoding.UTF8, "application/json")) {
				client.PutAsync (string.Format (Constants.RestURL, "Clientes/" + c.ID), content).ConfigureAwait (false);
				return true;
			}
		}
	}
}
