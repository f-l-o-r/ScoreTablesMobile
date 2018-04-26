using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ScoreTableMobile.Tables
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class TableView : ContentPage
	{
		public TableView ()
		{
			InitializeComponent ();
		}
	}
}