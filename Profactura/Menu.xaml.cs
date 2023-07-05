﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Profactura
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Menu : ContentPage
    {
        string usuario;
        public Menu(string usuario)
        {
                InitializeComponent();
                lblUsuario.Text = "usuario conectado" + " " + ": " + " " + usuario;
                this.usuario = usuario;
        }

        private void btnVerCliente_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Cliente(usuario));
        }

        private void btnInserCliente_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new RegistroCliente());
        }

        private void btnVerInver_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Inversionista());
        }

        private void btnInserInver_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new RegistroInversionista());
        }

        private void btnSalir_Clicked(object sender, EventArgs e)
        {

            Navigation.PushAsync(new Login());

        }
    }
}