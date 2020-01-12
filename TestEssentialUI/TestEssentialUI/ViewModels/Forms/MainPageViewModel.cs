using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms.Xaml;
using Xamarin.Forms.Internals;
using Xamarin.Essentials;
using Xamarin.Forms;
using BIM493_Project.HelperUser;
using BIM493_Project.Model;

namespace BIM493_Project.ViewModels.Forms
{
    public class MainPageViewModel : BaseViewModel
    {
        

        FirebaseHelper firebaseHelper = new FirebaseHelper();




        #region Constructor

        /// <summary>
        /// Initializes a new instance for the <see cref="LoginPageViewModel" /> class.
        /// </summary>
        public MainPageViewModel()
        {
            this.newCompCommand = new Command(this.newCompClicked);
            this.SearchCompCommand = new Command(this.SeachCompClicked);
            
        }

        #endregion

        #region property

        string name;
        string id;
        public string CompID
        {
            get { return  id; }
            set 
            {
                id = value;
                this.NotifyPropertyChanged();
            }
        }

        public string CompName
        {
            get { return name; }
            set
            {
                name = value;
                this.NotifyPropertyChanged();
            }
        }



        List<String> compList;
        public List<String> CompList
        {
            get { return compList; }
            set
            {
                compList = value;
                this.NotifyPropertyChanged();
            }
        }

        #endregion

        #region Command
        public Command newCompCommand { get; set; }
        public Command SearchCompCommand { get; set; }


        #endregion

        #region methods

        async private void newCompClicked(object obj)
        {
            // SHOULD CHECK 
            INavigation nav = Application.Current.MainPage.Navigation;

            // Do something
            await nav.PopAsync();
            await nav.PushAsync(new Views.Forms.CompetitionPage());

        }


        async private void SeachCompClicked(object obj)
        {
            
            var competition = await firebaseHelper.GetCompetition(CompName.ToString());
            if (competition != null)
            {
                //CompID = competition.CompetitionID.ToString();
                CompName = competition.CompetitionName.ToString();
              
                await Application.Current.MainPage.DisplayAlert("Success", "Competition found", "OK");

            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Error", "No competition with the name available", "OK");
            }
            //throw new NotImplementedException();
            
        }

        #endregion


        #region test_list
        public List<TempList> Weathers { get => Data(); }
        public Command testList { get; set; }

        private List<TempList> Data()
        {
            var tempList = new List<TempList>();

            tempList.Add(new TempList { Temp = "Reading Competition" ,ID="24537" });
            tempList.Add(new TempList { Temp = "Sport Compettion", ID = "63528" });
            tempList.Add(new TempList { Temp = "Can we Finish Competition", ID = "25687" });
            tempList.Add(new TempList { Temp = "MObile Comp", ID = "24512" });
            tempList.Add(new TempList { Temp = "1 Bilion Line Code ", ID = "75288" });
            tempList.Add(new TempList { Temp = "48 Hour Non-Stop Code", ID = "22544" });
            tempList.Add(new TempList { Temp = "Reading Competition", ID = "69851" });
            tempList.Add(new TempList { Temp = "Sport Compettion", ID = "01245" });
            tempList.Add(new TempList { Temp = "Can we Finish Competition", ID = "01255" });
            tempList.Add(new TempList { Temp = "Reading Competition", ID = "75864" });
            tempList.Add(new TempList { Temp = "Sport Compettion", ID = "22515" });
            tempList.Add(new TempList { Temp = "Can we Finish Competition", ID = "89754" });


            return tempList;
        }

        public class TempList
        {
            public string Temp { get; set; }
            public string ID { get; set; }

        }



        #endregion



    }

}