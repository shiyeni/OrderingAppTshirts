using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace OrderAppTshirt
{
    public partial class App : Application
    {
        static DatabaseTshirts database;
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new T_ShirtOrdering());
        }
        public static DatabaseTshirts Database
        {
            get
            {
                if (database == null)
                {
                    database = new DatabaseTshirts(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "TShirtSQLite.db3"));
                }
                return database;
            }
        }
        public int ResumeAtoDoId { get; set; }
        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
