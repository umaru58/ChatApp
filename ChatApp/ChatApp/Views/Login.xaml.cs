using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ChatApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login : ContentPage
    {
        public Login()
        {
            InitializeComponent();
        }
        private void NavigateButton_OnClicked(object sender, EventArgs e)
        {
            Application.Current.MainPage = new Registration();
        }
        public void ShowHidePass(object sender, EventArgs e)
        {
            password.IsPassword = password.IsPassword ? false : true;
            ShowPass.Text = ShowPass.Text == "Show" ? "Hide" : "Show";
        }
       
        public void facebookSignIn(object sender, EventArgs e)
        {
            Application.Current.MainPage = new TabbedPage1(
                "Facebook User", "facebookuser@gmail.com"
            );
        }

        public void googleSignIn(object sender, EventArgs e)
        {
            Application.Current.MainPage = new TabbedPage1(
                "Google User", "googleuser@gmail.com"
            );
        }

        private void Login_OnClicked(object sender, EventArgs e)
        {                       
            var emailEntry = email.Text;
            var passwordEntry = password.Text;
            bool missing = false;

            if (string.IsNullOrWhiteSpace(emailEntry))
            {
                emailBorder.BorderColor = Xamarin.Forms.Color.Red;
                missing = true;
            }
            else
            {
                emailBorder.BorderColor = Xamarin.Forms.Color.Black;
            }
            if (string.IsNullOrWhiteSpace(passwordEntry))
            {
                passBorder.BorderColor = Xamarin.Forms.Color.Red;
                missing = true;
            }
            else
            {
                passBorder.BorderColor = Xamarin.Forms.Color.Black;
            }

            if (missing)
            {
                DisplayAlert("Error", "Missing fields.", "OKAY");
            }
            else
            {
                if ((Application.Current.Properties.ContainsKey("email") && Application.Current.Properties.ContainsKey("name")) &&
                    (string.Compare(emailEntry, Application.Current.Properties["email"].ToString()) == 0 &&
                    string.Compare(passwordEntry, Application.Current.Properties["pass"].ToString()) == 0))
                {                                        
                    Application.Current.MainPage = new TabbedPage1(
                        Application.Current.Properties["name"].ToString(), Application.Current.Properties["email"].ToString()
                    );
                }
                else
                {
                    DisplayAlert("Error", "Incorrect email or password.", "OKAY");
                }
            }
           
        }
    }
}