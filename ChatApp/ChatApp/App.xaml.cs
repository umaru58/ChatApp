using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ChatApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            if (Application.Current.Properties.ContainsKey("email") && Application.Current.Properties.ContainsKey("name"))
            {
                Application.Current.MainPage = new TabbedPage1(
                        Application.Current.Properties["name"].ToString(), Application.Current.Properties["email"].ToString()
                    );
            }
            else
            {
                MainPage = new Login();
            }            
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
