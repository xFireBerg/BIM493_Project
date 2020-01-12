using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms;

namespace BIM493_Project.ViewModels.Forms
{
    public class CompetitionPageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }


        string pertUserName1;
        string pertUserName2;
        string compName;
        string targetNumber;
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

        
        public string PertUserName1
        {
            get { return pertUserName1; }
            set
            {
                pertUserName1 = value;
                OnPropertyChanged();
            }
        }


        public string PertUserName2
        {
            get { return pertUserName2; }
            set
            {
                pertUserName2 = value;
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

        public string TargetNumber
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