using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms;
using Firebase.Database;
using BIM493_Project.Helper;
using BIM493_Project.Model;

namespace BIM493_Project.ViewModels.Forms
{
    public class CompetitionPageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        FirebaseHelper firebaseHelper = new FirebaseHelper();

        string partUserName1;
        string partUserName2;
        string compName;
        int targetNumber;
        // ! date shoul check
        DateTime dueDate;



        #region Constructor

        /// <summary>
        /// Initializes a new instance for the <see cref="LoginPageViewModel" /> class.
        /// </summary>
        public CompetitionPageViewModel()
        {
            this.newCompCommand = new Command(this.newCompClickedDone);
            this.tempraryCommand = new Command(this.tempraryClicked);

        }

        #endregion


        #region property

        
        public string PartUserName1
        {
            get { return partUserName1; }
            set
            {
                partUserName1 = value;
                OnPropertyChanged();
            }
        }


        public string PartUserName2
        {
            get { return partUserName2; }
            set
            {
                partUserName2 = value;
                OnPropertyChanged();
            }
        }

        public string CompName
        {
            get { return compName; }
            set
            {
                compName = value;
                OnPropertyChanged();
            }
        }

        public int TargetNumber
        {
            get { return targetNumber; }
            set
            {
                targetNumber = value;
                OnPropertyChanged();
            }
        }
        
        public DateTime DueDate
        {
            get { return dueDate; }
            set
            {
                dueDate = value;
                OnPropertyChanged();
            }
        }




        #endregion

        #region Command
        public Command newCompCommand { get; set; }
        public Command tempraryCommand { get; set; }
        



        #endregion

        #region methods

async private void newCompClickedDone(object obj)
        {
            // We need to save-send data here ?????


            INavigation nav = Application.Current.MainPage.Navigation;
            // Do something

            await firebaseHelper.AddCompetition(CompName, TargetNumber, DueDate, PartUserName1, PartUserName2);
            //compName = string.Empty;
            //targetNumber = 0;
            //partUserName1 = string.Empty;
            //partUserName2 = string.Empty;
            await Application.Current.MainPage.DisplayAlert("Success", "Competition Added Successfully", "OK");
            var allCompeitions = await firebaseHelper.GetAllCompetitions();
            //lstPersons.ItemsSource = allCompeitions;

            await nav.PopAsync();
            await nav.PushAsync(new Views.Forms.CompetitionDetail());

        }

        // THİS İS JUST FOR TRY WE NEED TO CHANGE THİS
        async private void tempraryClicked(object obj)
        {
            // We need to save-send data here ?????


            INavigation nav = Application.Current.MainPage.Navigation;
            // Do something

            await nav.PopAsync();
            await nav.PushAsync(new Views.Forms.UserPage());

        }


        #endregion
    }
}