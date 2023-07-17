using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Profactura
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Inversionista : ContentPage
    {
        private const string Url = "http://169.254.31.55/ws_profactura/postInver.php";
        private readonly HttpClient client = new HttpClient();
        private ObservableCollection<Profactura.datosInversionista> _post;

        string usuario;
        public Inversionista(string usuario)
        {
            InitializeComponent();
            this.usuario = usuario;
        }

        private void ListaInversion_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var objetoDatos1 = (datosInversionista)e.SelectedItem;
            Navigation.PushAsync(new ActuElimInver(objetoDatos1, usuario));
        }

        private async void btnMostrar_Clicked(object sender, EventArgs e)
        {
            try
            {
                var content = await client.GetStringAsync(Url);
                List<Profactura.datosInversionista> post = JsonConvert.DeserializeObject<List<Profactura.datosInversionista>>(content);
                _post = new ObservableCollection<Profactura.datosInversionista>(post);

                ListaInversion.ItemsSource = _post;
            }
            catch (Exception ex)
            {
                // Manejar el error, ya sea mostrándolo en un mensaje o registrándolo.
            }
        }

        private void btnSalir_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Menu(usuario));
        }
    }
}