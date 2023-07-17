using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Collections.ObjectModel;
using Newtonsoft.Json;

namespace Profactura
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Cliente : ContentPage
    {
        private const string Url = "http://169.254.31.55/ws_profactura/post.php";
        private readonly HttpClient client = new HttpClient();
        private ObservableCollection<Profactura.datosCliente> _post;
        
        string usuario;
        public Cliente(string usuario)
        {
            InitializeComponent();
            this.usuario = usuario;
        }

        private void btnSalir_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Menu(usuario));
        }

        private void ListaCliente_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var objetoDatos = (datosCliente)e.SelectedItem;
        }

        private async void btnMostrar_Clicked(object sender, EventArgs e)
        {

            try
            {
                var content = await client.GetStringAsync(Url);
                List<Profactura.datosCliente> post = JsonConvert.DeserializeObject<List<Profactura.datosCliente>>(content);
                _post = new ObservableCollection<Profactura.datosCliente>(post);

                ListaCliente.ItemsSource = _post;
            }
            catch (Exception ex)
            {
                // Manejar el error, ya sea mostrándolo en un mensaje o registrándolo.
            }

        }
    }
}