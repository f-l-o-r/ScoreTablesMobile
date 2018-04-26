using System;
using System.Collections.Generic;
using System.Text;

namespace ScoreTableMobile.Backend.Model
{
    public class TableModel
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public int PlayedMatches { get; set; }
        public int Wins { get; set; }
        public int Draws { get; set; }
        public int Losses { get; set; }
        public int GoalsInFavor { get; set; }
        public int GoalsAgainst { get; set; }
        public int GoalDifference { get; set; }
        public int Points { get; set; }
    }
}
