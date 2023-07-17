using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Profactura
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ActuElimCliente : ContentPage
    {
        string usuario;
        public ActuElimCliente(datosCliente datos, string usuario)
        {
            InitializeComponent();
            this.usuario = usuario;
            txtCodigo.Text = datos.codigo.ToString();
            txtNombre.Text = datos.nombre.ToString();
            txtApellido.Text = datos.apellido.ToString();
            txtRuc.Text = datos.ruc.ToString();
            txtEmpresa.Text = datos.empresa.ToString();
            txtDireccion.Text = datos.direccion.ToString();
            txtTelefono.Text = datos.telefono.ToString();

        }

        private void btnActualizar_Clicked(object sender, EventArgs e)
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

                cliente.UploadValues(Url, "PUT", cliente.QueryString = parametros);
                // Implementamos el mensaje TOAST
                var mensaje = "Datos Actualizados";
                DependencyService.Get<Mensaje>().longAlert(mensaje);
                
                Navigation.PushAsync(new Cliente(usuario));
            }

            catch (Exception ex)
            {
                DisplayAlert("Alerta", ex.Message, "Cerrar");
            }
        }

        private void btnEliminar_Clicked(object sender, EventArgs e)
        {
            try
            {
                WebClient cliente = new WebClient();
                string Url = "http://169.254.31.55/ws_profactura/post.php";

                var parametros = new System.Collections.Specialized.NameValueCollection();
                parametros.Add("codigo", txtCodigo.Text);

                cliente.UploadValues(Url, "DELETE", cliente.QueryString = parametros);
                // Implementamos el mensaje TOAST
                var mensaje = "Datos Eliminados";
                DependencyService.Get<Mensaje>().longAlert(mensaje);
                // DisplayAlert("Alerta", "Eliminación correcta", "Cerrar");
                Navigation.PushAsync(new Cliente(usuario));
            }
            catch (Exception ex)
            {
                DisplayAlert("Alerta", ex.Message, "Cerrar");
            }
        }
    }
}