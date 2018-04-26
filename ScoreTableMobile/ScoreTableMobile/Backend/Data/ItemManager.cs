using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ScoreTableMobile.Backend.Model;

namespace ScoreTableMobile.Backend.Data
{
    public class ItemManager
    {
        ITeamRestService restService;

        public ItemManager(ITeamRestService service)
        {
            restService = service;
        }

        public Task<List<LeagueModel>> GetTasksAsync()
        {
            return restService.getDataAsync();
        }

        //public Task<List<TeamModel>> GetTeamById()
        //{
        //    return restService.getDataAsync();
        //}
    }
        
}
