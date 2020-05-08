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
    public partial class TabbedPage1 : TabbedPage
    {
        public TabbedPage1(String name, String email)
        {            
            InitializeComponent();

            nameEntry.Text = name;
            emailEntry.Text = email;
        }

        public void SignOut(object sender, EventArgs e)
        {
            Application.Current.Properties.Remove("name");
            Application.Current.Properties.Remove("email");
            Application.Current.Properties.Remove("pass");
            Application.Current.SavePropertiesAsync();

            Application.Current.MainPage = new NavigationPage(new Login());
        }
    }
}