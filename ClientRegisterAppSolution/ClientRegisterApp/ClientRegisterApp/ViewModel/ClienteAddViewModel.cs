using ClientRegisterApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientRegisterApp.ViewModel
{
    public class ClienteAddViewModel
    {
        public ClienteAddViewModel(Client client)
        {
            ID = client.ID;
            Name = client.Name;
            Phone = client.Phone;
            Address = client.Address;
            Image = client.Image;
        }

        public ClienteAddViewModel()
            : this(new Client())
        {

        }
        public int ID { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public byte[] Image { get; set; }
    }
}
