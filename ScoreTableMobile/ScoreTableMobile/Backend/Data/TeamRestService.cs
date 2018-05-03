using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using System.Net.Http.Headers;
using ScoreTableMobile.Backend.Model;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Threading.Tasks;

namespace ScoreTableMobile.Backend.Data
{
    class TeamRestService : ITeamRestService
    {
        HttpClient client;

        public List<LeagueModel> ItemLeague { get; set; }
        public List<TableModel> ItemTable { get; set; }
        public List<ScheduleModel> ItemSchedule { get; set; }

        public TeamRestService()
        {
            //var authData = string.Format("{0}:{1}", Constants.Username, Constants.Password);
            //var authHeaderValue = Convert.ToBase64String(Encoding.UTF8.GetBytes(authData));

            client = new HttpClient();
            client.MaxResponseContentBufferSize = 256000;

            //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", authHeaderValue);
        }

        public async Task<LeagueModel> getDataLeagueAsync() {
            LeagueModel ItemLeague = new LeagueModel();
            var uri = new Uri(string.Format(Constants.restUrlLegues, string.Empty));

            try
            {
                var response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    ItemLeague = JsonConvert.DeserializeObject<LeagueModel>(content);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"ERROR {0}", ex.Message);
            }

            return ItemLeague;
        }

        public async Task<List<TableModel>> getDataTableAsync()
        {
            ItemTable = new List<TableModel>();
            var uri = new Uri(string.Format(Constants.restUrlTable, string.Empty));

            try
            {
                var response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    ItemTable = JsonConvert.DeserializeObject<List<TableModel>>(content);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"ERROR {0}", ex.Message);
            }

            return ItemTable;
        }

        public async Task<List<ScheduleModel>> getDataScheduleAsync()
        {
            ItemSchedule = new List<ScheduleModel>();
            var uri = new Uri(string.Format(Constants.restUrlSchedule, string.Empty));

            try
            {
                var response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    ItemSchedule = JsonConvert.DeserializeObject<List<ScheduleModel>>(content, new JsonSerializerSettings
                    {
                        NullValueHandling = NullValueHandling.Ignore
                    });
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"ERROR {0}", ex.Message);
            }

            return ItemSchedule;
        }
    }
}
