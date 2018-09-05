using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ScoreTableMobile
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MastePageMaster : ContentPage
    {
        public ListView ListView;
        public string userName;

        public MastePageMaster()
        {
            InitializeComponent();

            BindingContext = new MastePageMasterViewModel();
            ListView = MenuItemsListView;
            userName = lblHeaderName.Text;
        }

        class MastePageMasterViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<MastePageMenuItem> MenuItems { get; set; }
            
            public MastePageMasterViewModel()
            {
                MenuItems = new ObservableCollection<MastePageMenuItem>(new[]
                {
                    new MastePageMenuItem { Id = "Create", Title = "Create League" },
                    new MastePageMenuItem { Id = "Tables", Title = "Tables" },
                    new MastePageMenuItem { Id = "Schedule", Title = "Schedule" },
                    new MastePageMenuItem { Id = "Teams", Title = "Teams" },
                    new MastePageMenuItem { Id = "About", Title = "About" },
                });
            }
            
            #region INotifyPropertyChanged Implementation
            public event PropertyChangedEventHandler PropertyChanged;
            void OnPropertyChanged([CallerMemberName] string propertyName = "")
            {
                if (PropertyChanged == null)
                    return;

                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
            #endregion
        }
    }
}