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
            var TableItem = (TableModel)BindingContext;
            await Navigation.PopAsync(); 
            ViewModel();
            dataGrid.ItemsSource = DynamicCollection;
        }

        public ObservableCollection<dynamic> DynamicCollection { get; set; }
        public List<TableModel> DynamicJsonCollection { get; set; }

        public async void ViewModel()
        {
            DynamicJsonCollection = await TodoManager.GetTasksTableAsync();
            DynamicCollection = PopulateData();
        }

        private ObservableCollection<dynamic> PopulateData()
        {
            var data = new ObservableCollection<dynamic>();
            foreach (var item in DynamicJsonCollection)
            {
                data.Add(item);
            }
            return data;
        }

    }
}