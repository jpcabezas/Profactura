using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Profactura
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login : ContentPage
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnIniciar_Clicked(object sender, EventArgs e)
        {
            String usuario = "Admin";
            String usuario2 = "comercial1";
            String contraseña = "2023";
            String contrasena2 = "2023";
            String usuario3 = "comercial2";
            String contrasena3 = "2023";
            if (txtUsuario.Text == usuario && txtContraseña.Text == contraseña)
            {
                Navigation.PushAsync(new Menu(usuario));
            }
            else if (txtUsuario.Text == usuario2 && txtContraseña.Text == contrasena2)
            {
                Navigation.PushAsync(new Menu(usuario));
            }
            else if (txtUsuario.Text == usuario3 && txtContraseña.Text == contrasena3)
            {
                Navigation.PushAsync(new Menu(usuario));
            }
            else
            {
                DisplayAlert("Error", "usuario/contaseña incorrectos", "cerrar");
            }
        }

        private void btnCancelar_Clicked(object sender, EventArgs e)
        {
            txtUsuario.Text = String.Empty;
            txtContraseña.Text = String.Empty;
        }
    }
}