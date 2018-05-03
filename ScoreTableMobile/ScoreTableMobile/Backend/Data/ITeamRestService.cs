﻿using System;
using System.Collections.Generic;
using System.Text;
using ScoreTableMobile.Backend.Model;
using System.Threading.Tasks;


namespace ScoreTableMobile.Backend.Data
{
    public interface ITeamRestService
    {
        //Task<List<LeagueModel>> getDataLeagueAsync();

        Task<List<TableModel>> getDataTableAsync();

        Task<LeagueModel> getDataLeagueAsync();

        Task<List<ScheduleModel>> getDataScheduleAsync();
        //Task SaveTeamModelAsync(TodoItem item, bool isNewItem);

        /// Task<List<TeamModel>> getTeamById(string id);
    }
}
