using System;
using System.Collections.Generic;
using System.Text;

namespace ScoreTableMobile.Backend.Model
{
    public class ScheduleModel
    {
        public String ID { get; set; }
        public int MatchDay { get; set; }
        public int HomeScore { get; set; } = -1;
        public int AwayScore { get; set; } = -1;
        public TeamModel HomeTeam { get; set; }  = new TeamModel();
        public TeamModel AwayTeam { get; set; }  = new TeamModel();
    }


}
