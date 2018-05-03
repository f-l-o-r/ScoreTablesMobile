using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ScoreTableMobile.Backend.Data;
using ScoreTableMobile.Backend.Model;
using System.Collections.ObjectModel;

namespace ScoreTableMobile.Schedule
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ScheduleView : ContentPage
	{
        public static ItemManager TodoManager { get; private set; }
        public static ObservableCollection<ScheduleGroup<string, ScheduleModel>> ScheduleGrouped { get; set; }

        public ScheduleView ()
		{
            TodoManager = new ItemManager(new TeamRestService());
            InitializeComponent ();
            
        }
        protected async override void OnAppearing() {
            var groups = new ObservableCollection<ScheduleGroup<string, ScheduleModel>>();

            List<ScheduleModel> listSchedule = await TodoManager.GetTasksScheduleAsync();

            var sorted = from schedule in listSchedule
                         orderby schedule.MatchDay
                         group schedule by schedule.MatchDay into scheduleGroup
                         select new ScheduleGroup<string, ScheduleModel>(scheduleGroup.Key.ToString(), scheduleGroup);

            //create a new collection of groups
            ScheduleGrouped = new ObservableCollection<ScheduleGroup<string, ScheduleModel>>(sorted);

            GroupedView.ItemsSource = ScheduleGrouped;
        }
	}
}