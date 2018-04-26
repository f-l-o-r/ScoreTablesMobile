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

        public List<LeagueModel> Items { get; set; }

        public TeamRestService()
        {
            //var authData = string.Format("{0}:{1}", Constants.Username, Constants.Password);
            //var authHeaderValue = Convert.ToBase64String(Encoding.UTF8.GetBytes(authData));

            client = new HttpClient();
            client.MaxResponseContentBufferSize = 256000;

            //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", authHeaderValue);
        }

        public async Task<List<LeagueModel>> getDataAsync() {
            Items = new List<LeagueModel>();
            var uri = new Uri(string.Format(Constants.RestUrl, string.Empty));

            try
            {
                var response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    Items = JsonConvert.DeserializeObject<List<LeagueModel>>(content);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"ERROR {0}", ex.Message);
            }

            return Items;

            //    // RestUrl = https://scoretables.herokuapp.com/api/leagues
            //    var uri = new Uri(string.Format(Constants.RestUrl, string.Empty));

            //    try
            //    {
            //        var response = await client.GetAsync(uri);
            //        if (response.IsSuccessStatusCode)
            //        {
            //            var content = await response.Content.ReadAsStringAsync();
            //            Items = JsonConvert.DeserializeObject<List<TodoItem>>(content);
            //        }
            //    }
            //    catch (Exception ex)
            //    {
            //        Debug.WriteLine(@"				ERROR {0}", ex.Message);
            //    }

            //    return Items;
        }
    }
}
