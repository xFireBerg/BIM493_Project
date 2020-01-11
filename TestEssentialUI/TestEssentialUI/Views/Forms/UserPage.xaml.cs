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
    public partial class UserPage : ContentPage
    {
        public UserPage()
        {
            InitializeComponent();
            this.BindingContext = this;
            this.newCompCommand = new Command(this.newCompClickedDone);
        }

        async private void newCompClickedDone(object obj)
        {
            // We need to save-send data here ?????


            INavigation nav = Application.Current.MainPage.Navigation;
            // Do something

            await nav.PopAsync();
            await nav.PushAsync(new Views.Forms.CompetitionDetail());

        }

        public List<TempList> Weathers { get => Data(); }
        public Command newCompCommand { get; set; }

        private List<TempList> Data()
        {
            var tempList = new List<TempList>();
            tempList.Add(new TempList { Temp = "12", Date = "Sunday 11" });
            tempList.Add(new TempList { Temp = "21", Date = "Monday 12"});
            tempList.Add(new TempList { Temp = "16", Date = "Tuesday 13"});
            tempList.Add(new TempList { Temp = "14", Date = "Wednesday 14" });
            tempList.Add(new TempList { Temp = "11", Date = "Thursday 15" });
            tempList.Add(new TempList { Temp = "20", Date = "Friday 16" });
            tempList.Add(new TempList { Temp = "16", Date = "Tuesday 13" });
            tempList.Add(new TempList { Temp = "14", Date = "Wednesday 14" });
            tempList.Add(new TempList { Temp = "11", Date = "Thursday 15" });
            tempList.Add(new TempList { Temp = "20", Date = "Friday 16" });
            tempList.Add(new TempList { Temp = "16", Date = "Tuesday 13" });
            tempList.Add(new TempList { Temp = "14", Date = "Wednesday 14" });
            tempList.Add(new TempList { Temp = "11", Date = "Thursday 15" });
            tempList.Add(new TempList { Temp = "20", Date = "Friday 16" });

            return tempList;
        }

        public class TempList
        {
            public string Temp { get; set; }
            public string Date { get; set; }
            
        }
    }
}