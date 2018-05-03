using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ScoreTableMobile.Backend.Model;
using ScoreTableMobile.Backend.Data;
using System.Collections.ObjectModel;

namespace ScoreTableMobile.Tables
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TableView : ContentPage
    {
        public static ItemManager TodoManager { get; private set; }

        public TableView()
        {
            TodoManager = new ItemManager(new TeamRestService());
            InitializeComponent();
        }

        protected async override void OnAppearing()
        {
            List<TableModel> DynamicJsonCollection = await TodoManager.GetTasksTableAsync();
            dataGrid.ItemsSource = DynamicJsonCollection;
            await Navigation.PopAsync();
        }
        
    }
}