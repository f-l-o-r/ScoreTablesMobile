using ScoreTableMobile.Utils;
using ScoreTableMobile.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ScoreTableMobile
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MastePageDetail : ContentPage
    {
        MasterPageDetailViewModel vm;
        MasterPageDetailViewModel ViewModel => vm ?? (vm = BindingContext as MasterPageDetailViewModel);

        public MastePageDetail()
        {
            InitializeComponent();

            BindingContext = new MasterPageDetailViewModel();
        }
        
    }
}