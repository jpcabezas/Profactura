using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Profactura.Droid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

[assembly: Xamarin.Forms.Dependency(typeof(mensajeAndroid))] // esta anotación hace que esta clase se lea el momento de ejecutarse el proyecto principal 
// se debe colocar simepre que la clase esté fuera del proyecto principal.

namespace Profactura.Droid
{
    public class mensajeAndroid : Mensaje // hacemos publica la clase e implementamos la interfaz mensaje
    {
        public void longAlert(string mensaje)
        {
            Toast.MakeText(Application.Context, mensaje, ToastLength.Long).Show(); // implementamos el mensaje largo
        }

        public void shortAlert(string mensaje)
        {
            Toast.MakeText(Application.Context, mensaje, ToastLength.Short).Show(); // implementamos el mensaje corto
        }
    }
}