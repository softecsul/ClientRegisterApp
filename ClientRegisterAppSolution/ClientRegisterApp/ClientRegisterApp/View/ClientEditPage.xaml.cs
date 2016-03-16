using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using ClientRegisterApp.ViewModel;
using ClientRegisterApp.Data.Models;

namespace ClientRegisterApp.View
{
    public partial class ClientEditPage : ContentPage
    {
        private ClientEditViewModel vm;


        public ClientEditPage(Client client)
        {
            
            vm = new ClientEditViewModel(client);
            BindingContext = vm;
            InitializeComponent();
        }

        public int ID { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public byte[] Image { get; set; }
    }
}
