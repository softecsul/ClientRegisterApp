using ClientRegisterApp.Data.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ClientRegisterApp.Service
{
    public class ClientServiceApi : IWebApi<Client>
    {
        HttpClient client;
        public ClientServiceApi()
        {
            client = new HttpClient
            {
                MaxResponseContentBufferSize = 256000
            };
        }
        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Client Get(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Client>> GetAll()
        {
            List<Client> clients = null;
            // RestUrl = http://developer.xamarin.com:8081/api/todoitems{0}
            var uri = new Uri(string.Format(Constants.RestURL, string.Empty));

            var response = await client.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                clients = JsonConvert.DeserializeObject<List<Client>>(content);
            }

            return clients;
        }

        public bool Insert(Client t)
        {
            throw new NotImplementedException();
        }

        public bool Update(Client t)
        {
            throw new NotImplementedException();
        }
    }
}
