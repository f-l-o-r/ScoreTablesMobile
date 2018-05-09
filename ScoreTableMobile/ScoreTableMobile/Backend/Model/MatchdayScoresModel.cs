using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ScoreTableMobile.Backend.Model
{
    class MatchdayScoresModel
    {
        public int HomeScore { get; set; } = 0;
        public int AwayScore { get; set; } = 0;
    }
}
