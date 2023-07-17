using Plugin.Media;
using System;
using System.Net;
using Plugin.Media.Abstractions;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Profactura
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegistroCliente : ContentPage
    {
        String usuario;
        public RegistroCliente(string usuario)
        {
            InitializeComponent();
            this.usuario = usuario;

        }

        private void btnRegistro_Clicked(object sender, EventArgs e)
        {
            try
            {
                WebClient cliente = new WebClient();
                string Url = "http://169.254.31.55/ws_profactura/post.php";

                var parametros = new System.Collections.Specialized.NameValueCollection();
                parametros.Add("codigo", txtCodigo.Text);
                parametros.Add("nombre", txtNombre.Text);
                parametros.Add("apellido", txtApellido.Text);
                parametros.Add("ruc", txtRuc.Text);
                parametros.Add("empresa", txtEmpresa.Text);
                parametros.Add("direccion", txtDireccion.Text);
                parametros.Add("telefono", txtTelefono.Text);
                cliente.UploadValues(Url, "POST", parametros);

                //mensaje TOAST en lugar del display alert
                var mensaje = "Datos ingresados";
                DependencyService.Get<Mensaje>().longAlert(mensaje);

                //DisplayAlert("Alerta", "Ingreso correcto", "Cerrar");
                Navigation.PushAsync(new Menu(usuario));
            }

            catch (Exception ex)
            {
                DisplayAlert("Alerta", ex.Message, "Cerrar");
            }
        }

        private async void btnFoto_Clicked(object sender, EventArgs e)
        {
            await CrossMedia.Current.Initialize();

            if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
            {
                await DisplayAlert("No Camera", ":( No hay una Camara", "OK");
                return;
            }
            var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
            {
                Directory = "Sample",
                Name = "test.jpg",
                SaveToAlbum = true,
                CompressionQuality = 75,
                CustomPhotoSize = 50,
                PhotoSize = Plugin.Media.Abstractions.PhotoSize.MaxWidthHeight,
                MaxWidthHeight = 2000,
                DefaultCamera = Plugin.Media.Abstractions.CameraDevice.Rear
            });

            if (file == null)
                return;

            await DisplayAlert("File Location", file.Path, "OK");

            Imagen.Source = ImageSource.FromStream(()=>
            {
                var stream = file.GetStream();
                
                return stream;
            });
        }
    }
}