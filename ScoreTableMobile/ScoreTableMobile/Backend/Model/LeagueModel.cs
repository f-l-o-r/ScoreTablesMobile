using System;
using System.Collections.Generic;
using System.Text;

namespace ScoreTableMobile.Backend.Model
{
    public class LeagueModel
    {
        public string ID { get; set; }
        public string Title { get; set; }
        public string  MatchDayAmount { get; set; }
        public List<TeamModel> Teams = new List<TeamModel>();
}
}
