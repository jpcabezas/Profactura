using Profactura.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace Profactura.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}