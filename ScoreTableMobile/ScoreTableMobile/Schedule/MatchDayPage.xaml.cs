using ScoreTableMobile.Backend.Model;
using ScoreTableMobile.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ScoreTableMobile.Schedule
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MatchDayPage : ContentPage
    {
        public MatchDayPage ()
		{
            InitializeComponent();
		}

        public MatchDayPage(ScheduleModel matchday)
        {
            BindingContext = new MatchDayPageViewModel(matchday);

            InitializeComponent();
            
            MessagingCenter.Subscribe<MatchDayPageViewModel, bool>(this, "putComplete", (sender, arg) => {
                // do something whenever the "Hi" message is sent
                bool result = arg;
                if (result)
                {
                    DisplayAlert("Success", "Matchday has been updated", "OK");
                }
                else
                {
                    DisplayAlert("Error", "An error occured", "OK");
                }
            });
        }
    }
}