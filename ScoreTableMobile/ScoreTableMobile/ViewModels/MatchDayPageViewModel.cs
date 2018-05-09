using ScoreTableMobile.Backend.Data;
using ScoreTableMobile.Backend.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace ScoreTableMobile.ViewModels
{
    public class MatchDayPageViewModel : INotifyPropertyChanged
    {
        public ICommand updateMatchdayCommand { get; private set; }
        
        private bool canUpdateMatchday = true;

        public string MatchdayID { get; set; }

        public string MatchdayCount { get; set; }

        private ScheduleModel matchday = null;

        public ScheduleModel Matchday
        {
            get { return matchday; }
            set
            {
                if (matchday == null || !matchday.Equals(value))
                {
                    matchday = value;
                    OnPropertyChanged(nameof(Matchday));
                }
            }
        }

        public MatchDayPageViewModel(ScheduleModel matchday)
        {
            Matchday = matchday;

            MatchdayID = "ID " + Matchday.ID;
            MatchdayCount = "Matchday " + Matchday.MatchDay;

            updateMatchdayCommand = new Command(async () => await UpdateMatchdayCommand(), () => canUpdateMatchday);
        }

        private async Task UpdateMatchdayCommand()
        {
            CanUpdateMatchday(false);

            MatchdayScoresModel model = new MatchdayScoresModel() { HomeScore = Matchday.HomeScore, AwayScore = Matchday.AwayScore };

            TeamRestService service = new TeamRestService();
            bool result = await service.putDataAsync("matchdays", Matchday.ID, model);

            MessagingCenter.Send(this, "putComplete", result);

            CanUpdateMatchday(true);
        }

        void CanUpdateMatchday(bool value)
        {
            canUpdateMatchday = value;
            ((Command)updateMatchdayCommand).ChangeCanExecute();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
