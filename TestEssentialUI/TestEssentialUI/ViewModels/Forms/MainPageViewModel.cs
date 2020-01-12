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
using BIM493_Project.Helper;
using BIM493_Project.Model;

namespace BIM493_Project.ViewModels.Forms
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        FirebaseHelper firebaseHelper = new FirebaseHelper();


        void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }



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
        public string CompID
        {
            get { return  name; }
            set 
            {
                name = value;
                OnPropertyChanged();
            }
        }


        
        List<String> compList;
        public List<String> CompList
        {
            get { return compList; }
            set
            {
                compList = value;
                OnPropertyChanged();
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
            var competition = await firebaseHelper.GetCompetition(obj.ToString());
            if (competition != null)
            {
                CompID = competition.CompetitionID.ToString();
              
                //await DisplayAlert("Success", "Competition Retrieved Successfully", "OK");

            }
            else
            {
                //await DisplayAlert("Error", "No Competition Available", "OK");
            }
            //throw new NotImplementedException();
            
        }

        #endregion



    }

}