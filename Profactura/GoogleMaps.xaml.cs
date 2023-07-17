using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.GoogleMaps;
using Xamarin.Forms.Xaml;

namespace Profactura
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GoogleMaps : ContentPage
    {
        string usuario;
        public GoogleMaps(string usuario)
        {
            InitializeComponent();
            this.usuario = usuario;

            Pin MiUbi = new Pin()
            {
                Type = PinType.Place,
                Label = "Mi Ubicacion",
                Address = "Av. Orellana",
                Position = new Position(-0.19052181780158547, -78.48518985622043),
                Tag = "id_miubi",
            };

            map.Pins.Add(MiUbi);
            map.MoveToRegion(MapSpan.FromCenterAndRadius(MiUbi.Position, Distance.FromMeters(500)));
            this.usuario = usuario;
        }

        private void btnSalir_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Menu(usuario));
        }
    }
}