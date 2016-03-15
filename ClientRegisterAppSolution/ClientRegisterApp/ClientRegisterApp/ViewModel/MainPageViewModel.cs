﻿using ClientRegisterApp.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientRegisterApp.ViewModel
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public MainPageViewModel(Client client)
        {
            ID = client.ID;
            Name = client.Name;
            Phone = client.Phone;
            Address = client.Address;
            Image = client.Image;

            Clients = new ObservableCollection<Client>
                {
                    new Client {ID = 93, Name = "Luís Fernando",Address="Rua Alberto dos Santos, 289, St. Helena", Phone="9937-5963" },
                    new Client { Name = "John Whatever" },
                    new Client { Name = "José da Silva" }

                };
        }

        public MainPageViewModel()
            : this(new Client())
        {
           
        }
        public int ID { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public byte[] Image { get; set; }


        //TODO: Metodos para formatar apresentação na View.

        public bool ExcludeClient(Client client)
        {
            Clients.Remove(client);
            OnPropertyChanged(nameof(Clients));
            return true;
        }

        public static Client GetClient()
        {
            return null;
        }

        public ObservableCollection<Client> Clients { get; set; }
        

        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                var handler = PropertyChanged;
                if (handler != null)
                    handler(this,new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}