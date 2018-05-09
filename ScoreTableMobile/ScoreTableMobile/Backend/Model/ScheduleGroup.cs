using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;

namespace ScoreTableMobile.Backend.Model
{
    public class  ScheduleGroup<K, ScheduleModel> : ObservableCollection<ScheduleModel>
    {
        // NB: This is the GroupDisplayBinding above for displaying the header
        public string Key { get; private set; }
        public string ShortName { get; set; } //will be used for jump lists
        
        public ScheduleGroup(K key, IEnumerable<ScheduleModel> items)
        {
            ShortName = key.ToString();
            Key = "Matchday " + key;
            foreach (var item in items)
                this.Items.Add(item);
        }
    }
}
