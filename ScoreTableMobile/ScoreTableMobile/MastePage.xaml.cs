using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ScoreTableMobile
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MastePage : MasterDetailPage
    {
        public MastePage(string username)
        {
            InitializeComponent();
            MasterPage.ListView.ItemSelected += ListView_ItemSelected;
            MasterPage.userName.Text = username;
        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as MastePageMenuItem;
            if (item == null)
                return;
            
            var page = getPage(item.Id);
            page.Title = item.Title;

            Detail = new NavigationPage(page);
            IsPresented = false;

            MasterPage.ListView.SelectedItem = null;
        }

        private Page getPage(String itemSelected) {

            switch(itemSelected) {
                case "Create":
                    return new MastePageDetail();
                case "Tables":
                    return new Tables.TableView();
                case "Teams":
                    return new Team.TeamView();
                case "Schedule":
                    return new Schedule.ScheduleView();
            }
            return new MastePageDetail();
        }
    }
}