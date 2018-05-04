using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;

namespace ScoreTableMobile.Backend.Model
{
    public class  ScheduleGroup<K, ScheduleModel> : ObservableCollection<ScheduleModel>
    {
        public string Title { get; set; }
        public string ShortName { get; set; } //will be used for jump lists
        private ScheduleGroup(string title, string shortName)
        {
            Title = title;
            ShortName = shortName;
        }

        // NB: This is the GroupDisplayBinding above for displaying the header
        public K GroupKey { get; private set; }

        public ScheduleGroup(K key, IEnumerable<ScheduleModel> items)
        {
            GroupKey = key;
            foreach (var item in items)
                this.Items.Add(item);
        }
    }
}
