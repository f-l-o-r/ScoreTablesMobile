using Newtonsoft.Json;
using ScoreTableMobile.Backend.Data;
using ScoreTableMobile.Backend.Model;
using ScoreTableMobile.Utils;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace ScoreTableMobile.ViewModels
{
    public class MasterPageDetailViewModel : INotifyPropertyChanged
    {
        public ICommand createLeagueCommand { get; private set; }

        public ICommand addTeamCommand { get; private set; }
        
        public ICommand deleteTeamCommand { get; private set; }

        public List<string> leagues = new List<string>();

        public ObservableCollection<TeamModel> Teams { get; set; }

        public string json = "{ \"ID\":\"COPA5\", \"Title\":\"COPA\", \"MatchDayAmount\":8, \"Teams\": [ {\"ID\":\"Pablo\",\"Team\":\"Saprissa\"}, {\"ID\":\"Sergio\",\"Team\":\"Heredia\"}, {\"ID\":\"Marvin\",\"Team\":\"Cartago\"} ] }";

        bool canCreateLeague = true;

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

        private string teamId = string.Empty;

        public string TeamId
        {
            get { return teamId; }
            set
            {
                if (!teamId.Equals(value))
                {
                    teamId = value;
                    OnPropertyChanged(nameof(TeamId));
                }
            }
        }

        private string teamName = string.Empty;

        public string TeamName
        {
            get { return teamName; }
            set
            {
                if (!teamName.Equals(value))
                {
                    teamName = value;
                    OnPropertyChanged(nameof(TeamName));
                }
            }
        }

        private string teamImageURL = string.Empty;

        public string TeamImageURL
        {
            get { return teamImageURL; }
            set
            {
                if (!teamImageURL.Equals(value))
                {
                    teamImageURL = value;
                    OnPropertyChanged(nameof(TeamImageURL));
                }
            }
        }

        public MasterPageDetailViewModel()
        {
            createLeagueCommand = new Command(async () => await CreateLeagueCommand(), () => canCreateLeague);

            addTeamCommand = new Command(AddTeamCommand);

            deleteTeamCommand = new Command<TeamModel>(DeleteTeamCommand);

            string leagueIds = Settings.Current.Email;

            leagues.AddRange(leagueIds.Split(','));

            Teams = new ObservableCollection<TeamModel>();
        }

        private async Task CreateLeagueCommand()
        {
            CanCreateLeague(false);

            LeagueModel league = new LeagueModel() { ID = leagueId, Title = leagueTitle, MatchDayAmount = leagueMatchdayCount};
            league.Teams.AddRange(Teams);

            TeamRestService service = new TeamRestService();
            bool result = await service.postDataAsync(league);

            MessagingCenter.Send(this, "postComplete", result);

            CanCreateLeague(true);
        }

        void CanCreateLeague(bool value)
        {
            canCreateLeague = value;
            ((Command)createLeagueCommand).ChangeCanExecute();
        }

        private void AddTeamCommand()
        {
            TeamModel team = new TeamModel() { ImageURL = TeamImageURL, Team = TeamName, ID = TeamId };

            Teams.Add(team);
        }

        private void DeleteTeamCommand(TeamModel item)
        {
            Teams.Remove(item);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
