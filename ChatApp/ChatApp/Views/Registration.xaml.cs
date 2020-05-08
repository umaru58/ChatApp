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
    public partial class Registration : ContentPage
    {
        public Registration()
        {
            InitializeComponent();
        }
        private void Login(object sender, EventArgs e)
        {
            Application.Current.MainPage = new Login();
        }
        public void ShowHidePass(object sender, EventArgs e)
        {
            Password.IsPassword = Password.IsPassword ? false : true;
            ShowPass.Text = ShowPass.Text == "Show" ? "Hide" : "Show";
        }

        public void ShowHideConf(object sender, EventArgs e)
        {
            ConfirmPassword.IsPassword = ConfirmPassword.IsPassword ? false : true;            
            ShowConf.Text = ShowConf.Text == "Show" ? "Hide" : "Show";
        }

        public void Dummy(object sender, EventArgs e)
        {
            DisplayAlert("Success", "Sign up successful. Verification email sent.", "OKAY");

            Application.Current.MainPage = new Login();
        }

        public void Register(object sender, EventArgs e)
        {
            var usernameEntry = username.Text;
            var emailEntry = email.Text;
            var passwordEntry = Password.Text;
            var confpassEntry = ConfirmPassword.Text;
            bool missing = false;

            if (string.IsNullOrWhiteSpace(usernameEntry))
            {
                usernameBorder.BorderColor = Xamarin.Forms.Color.Red;
                missing = true;
            }
            else
            {
                usernameBorder.BorderColor = Xamarin.Forms.Color.Black;
            }
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
            if (string.IsNullOrWhiteSpace(confpassEntry))
            {
                confpassBorder.BorderColor = Xamarin.Forms.Color.Red;
                missing = true;
            }
            else
            {
                confpassBorder.BorderColor = Xamarin.Forms.Color.Black;
            }

            if (missing)
            {
                DisplayAlert("Error", "Missing fields.", "OKAY");
            }
            else
            {
                if (string.Compare(passwordEntry, confpassEntry) == 0)
                {
                    Application.Current.Properties["name"] = usernameEntry;
                    Application.Current.Properties["email"] = emailEntry;
                    Application.Current.Properties["pass"] = passwordEntry;
                    Application.Current.SavePropertiesAsync();

                    DisplayAlert("Success", "Sign up successful. Verification email sent.", "OKAY");

                    Application.Current.MainPage = new Login();
                }
                else
                {
                    DisplayAlert("Error", "Passwords don't match.", "OKAY");
                }
            }

        }
    }
}