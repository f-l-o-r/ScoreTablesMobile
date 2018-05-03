using System;
using System.Collections.Generic;
using System.Text;
using ScoreTableMobile.Backend.Model;
using System.Threading.Tasks;


namespace ScoreTableMobile.Backend.Data
{
    public interface ITeamRestService
    {
        Task<List<LeagueModel>> getDataAsync();

        Task<bool> postDataAsync(LeagueModel model);

        //Task SaveTeamModelAsync(TodoItem item, bool isNewItem);

        /// Task<List<TeamModel>> getTeamById(string id);
    }
}
