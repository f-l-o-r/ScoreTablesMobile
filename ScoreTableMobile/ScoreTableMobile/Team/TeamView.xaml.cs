using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ScoreTableMobile.Backend.Model;
using ScoreTableMobile.Backend.Data;

namespace ScoreTableMobile.Team
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TeamView : ContentPage
    {
        public static ItemManager TodoManager { get; private set; }

        public TeamView()
        {
            TodoManager = new ItemManager(new TeamRestService());
            InitializeComponent();
        }

        protected async override void OnAppearing()
        {
            // var TeamList = e. as TeamModel
            var todoItem = (LeagueModel)BindingContext;
            //await TodoManager.GetTasksAsync();
            await Navigation.PopAsync(); ;
            var teamage = new TeamModel();
            try {
                LeagueModel listLeague = await TodoManager.GetTasksLeagueAsync();
                lstView.ItemsSource = listLeague.Teams;
            } catch (Exception e) {
                string exception = e.Message;
            }
            
        }

        /* public ObservableCollection<VeggieViewModel> veggies { get; set; }
         public MainViewXaml()
         {
             InitializeComponent();

             veggies = new ObservableCollection<VeggieViewModel>();
             veggies.Add(new VeggieViewModel { Name = "Tomato", Type = "Fruit", Image = "tomato.png" });
             veggies.Add(new VeggieViewModel { Name = "Romaine Lettuce", Type = "Vegetable", Image = "lettuce.png" });
             veggies.Add(new VeggieViewModel { Name = "Zucchini", Type = "Vegetable", Image = "zucchini.png" });
             lstView.ItemsSource = veggies;
         }*/
    }
}