using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using T_ShirtApp;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace OrderAppTshirt
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class T_ShirtOrdering : ContentPage
    {
        public T_ShirtOrdering()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            var tShirtItems = new Orders();
            BindingContext = tShirtItems;

        }
        private async void Save_Clicked(object sender, EventArgs e)
        {
            var tShirtItems = (Orders)BindingContext;
            await App.Database.SaveItemAsync(tShirtItems);

            await Navigation.PushAsync(new PlaceOrder());
        }

        private async void Delete_Clicked(object sender, EventArgs e)
        {
            var tShirtItems = (Orders)BindingContext;
            await App.Database.DeleteItemAsync(tShirtItems);

            await Navigation.PushAsync(new PlaceOrder());
        }
    }
}