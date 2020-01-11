using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BIM493_Project.Views.Forms
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CompetitionPage : ContentPage
    {
        public CompetitionPage()
        {
            InitializeComponent();
            BindingContext = new ViewModels.Forms.CompetitionPageViewModel();
        }
    }
}