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
    public partial class Cliente : ContentPage
    {
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
    }
}