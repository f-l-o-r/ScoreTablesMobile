using System;
using System.Collections.Generic;
using System.Text;

namespace ScoreTableMobile.Backend
{
    public class Constants
    {
        // URL of REST service
        public static string RestUrl = "https://scoretables.herokuapp.com/api/";
        // Credentials that are hard coded into the REST service
        public static string restUrlLegues = "https://scoretables.herokuapp.com/api/leagues/ACLMayo";
        public static string restUrlTable = "https://scoretables.herokuapp.com/api/scoretables/ACLMayo";
        public static string restUrlSchedule = RestUrl + "matchdays/ACLMayo";
        public static string Username = "Xamarin";
        public static string Password = "Pa$$w0rd";
    }
}
