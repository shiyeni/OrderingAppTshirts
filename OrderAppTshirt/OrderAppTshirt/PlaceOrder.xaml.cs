using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using T_ShirtApp;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace OrderAppTshirt
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PlaceOrder : ContentPage
    {
        public List<Orders> Orders { get; set; }
        public PlaceOrder()
        {
            InitializeComponent();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            Orders = await App.Database.GetItemsAsync();
            BindingContext = this;
        }


        private async void OrderedItems_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new T_ShirtOrdering
            {
                BindingContext = new Orders()
            });         
         }

        private async void OrderedItemsView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if(e.SelectedItem != null)
            {
                await Navigation.PushAsync(new T_ShirtOrdering
                {
                    BindingContext = e.SelectedItem as Orders
                });
            }
        }

        private void Map_Clicked(object sender, EventArgs e)
        {

        }

        private async void Submitsever_Clicked(object sender, EventArgs e)
        {
            //var databaseContent = App.Database;
            //Orders = await databaseContent.GetItemsAsync();
            //var MyServerOrders = Orders.Select(x => new Orders()
            //{
            //    Name = x.Name,           
            //    Size = x.Size,
            //    Gender = x.Gender,
            //    Color = x.Color,
            //    DateOfOrder = x.DateOfOrder,
            //    ShippingAddress = x.ShippingAddress
            //});
            //var json = JsonConvert.SerializeObject(MyServerOrders);
            //var client = new HttpClient();
            //var url = "http://10.0.2.2:5000/items";
            //var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
            //var response = await client.PostAsync(url, content);
            //await DisplayAlert("Response", response.ReasonPhrase, "ok");

            var databaseContent = App.Database;
            Orders = await databaseContent.GetItemsAsync();
            var MyServerOrders = Orders.Select(x => new Orders()
            {
                Name = x.Name,
                Size = x.Size,
                Gender = x.Gender,
                Color = x.Color,
                DateOfOrder = x.DateOfOrder,
                ShippingAddress = x.ShippingAddress
            });
            var json = JsonConvert.SerializeObject(MyServerOrders);
            var client = new HttpClient();
            var url = "http://10.0.2.2:5000/items";
            var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
            var response = await client.PostAsync(url, content);
            await DisplayAlert("Response", response.ReasonPhrase, "OK");
        }
    }
}