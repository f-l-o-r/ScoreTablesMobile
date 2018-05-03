using Newtonsoft.Json;
using ScoreTableMobile.Backend.Data;
using ScoreTableMobile.Backend.Model;
using ScoreTableMobile.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace ScoreTableMobile.ViewModels
{
    public class MasterPageDetailViewModel : INotifyPropertyChanged
    {
        public ICommand eventcommand { get; private set; }

        public List<string> leagues = new List<string>();

        public string json = "{ \"ID\":\"COPA5\", \"Title\":\"COPA\", \"MatchDayAmount\":8, \"Teams\": [ {\"ID\":\"Pablo\",\"Team\":\"Saprissa\"}, {\"ID\":\"Sergio\",\"Team\":\"Heredia\"}, {\"ID\":\"Marvin\",\"Team\":\"Cartago\"} ] }";

        private string leagueId = string.Empty;

        public string LeagueId
        {
            get { return leagueId; }
            set
            {
                if (!leagueId.Equals(value))
                {
                    leagueId = value;
                    OnPropertyChanged(nameof(LeagueId));
                }
            }
        }

        private string leagueTitle = string.Empty;

        public string LeagueTitle
        {
            get { return leagueTitle; }
            set
            {
                if (!leagueTitle.Equals(value))
                {
                    leagueTitle = value;
                    OnPropertyChanged(nameof(LeagueTitle));
                }
            }
        }

        private string leagueMatchdayCount = string.Empty;

        public string LeagueMatchdayCount
        {
            get { return leagueMatchdayCount; }
            set
            {
                if (!leagueMatchdayCount.Equals(value))
                {
                    leagueMatchdayCount = value;
                    OnPropertyChanged(nameof(LeagueMatchdayCount));
                }
            }
        }

        public MasterPageDetailViewModel()
        {
            eventcommand = new Command(EventCommand);

            string leagueIds = Settings.Current.Email;

            leagues.AddRange(leagueIds.Split(','));
        }

        private void EventCommand()
        {
            //LeagueId = "new value";
            LeagueModel league = JsonConvert.DeserializeObject<LeagueModel>(json);

            TeamRestService service = new TeamRestService();
            service.postDataAsync(league);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
