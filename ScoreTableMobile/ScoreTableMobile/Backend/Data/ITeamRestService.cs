using System;
using System.Collections.Generic;
using System.Text;
using ScoreTableMobile.Backend.Model;
using System.Threading.Tasks;


namespace ScoreTableMobile.Backend.Data
{
    public interface ITeamRestService
    {
        Task<bool> postDataAsync(string apiMethod, object model);

        Task<bool> putDataAsync(string apiMethod, string id, object model);

        Task<List<TableModel>> getDataTableAsync();

        Task<LeagueModel> getDataLeagueAsync();

        Task<List<ScheduleModel>> getDataScheduleAsync();
    }
}
