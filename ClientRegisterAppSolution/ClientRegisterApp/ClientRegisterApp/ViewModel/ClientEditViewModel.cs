using ClientRegisterApp.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientRegisterApp.ViewModel
{
    class ClientEditViewModel
    {

        public ClientEditViewModel(Client client)
        {
            ID = client.ID;
            Name = client.Name;
            Phone = client.Phone;
            Address = client.Address;
            Image = client.Image;
        }

        public ClientEditViewModel()
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
