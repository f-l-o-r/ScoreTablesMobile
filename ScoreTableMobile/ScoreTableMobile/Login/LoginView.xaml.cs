using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ScoreTableMobile.Login
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginView : ContentPage
    {
        public LoginView()
        {
            InitializeComponent();
        }
        
        private async void onClickSignIn(object sender, EventArgs args) {
            try
            {
                await Navigation.PushAsync(new MastePage());

            }
            catch (Exception e) {
                String exception = e.ToString();
            }
            
        }
    }
}
