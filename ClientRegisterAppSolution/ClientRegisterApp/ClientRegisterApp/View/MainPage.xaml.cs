using ClientRegisterApp.Model;
using ClientRegisterApp.View;
using ClientRegisterApp.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace ClientRegisterApp
{
    public partial class MainPage : ContentPage
    {
        MainPageViewModel vm;
        public MainPage()
        {
            vm = new MainPageViewModel(new Client());
            BindingContext = vm;
            InitializeComponent();
        }

        public void OnItemTapped(object obj, ItemTappedEventArgs e)
        {
            //var client = e.Item as Client;
        }

        public async void OnClickedAdd(object obj, EventArgs args)
        {
            //TODO: Pesquisar sobre a navegação, Implementar tela.
            await Navigation.PushAsync(new ClienteAddPage());

        }
        public async void OnClickedEdit(object obj, EventArgs args)
        {
            var client = ClientsList.SelectedItem as Client;
            if (client != null)
            {
                await Navigation.PushAsync(new ClientEditPage(client));
            }
            else
                await DisplayAlert("Info", "Por favor, selecione um registro para editar.", "Ok");

        }
        public async void OnClickedExclude(object obj, EventArgs args)
        {
            var client = ClientsList.SelectedItem as Client;
            if (client != null)
            {
               var result = await DisplayAlert("Question", string.Format("Tem certeza que deseja deletar o registro : {0}?",client.Name), "Sim","Não");
                if (result)
                {
                    vm.ExcludeClient(client);
                    // Chamada da web api para remover um cliente.
                    await DisplayAlert("Info","Removido com sucesso.","Ok");
                }
            }
            else
                await DisplayAlert("Info", "Por favor, selecione um registro para realizar a operação.", "Ok");
        }
    }
}
