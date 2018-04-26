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

        public Task<LeagueModel> GetTasksLeagueAsync()
        {
            return restService.getDataLeagueAsync();
        }

        public Task<List<TableModel>> GetTasksTableAsync()
        {
            return restService.getDataTableAsync();
        }

    }
        
}
