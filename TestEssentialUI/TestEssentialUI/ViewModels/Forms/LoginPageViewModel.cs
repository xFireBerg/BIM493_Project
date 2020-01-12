using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Essentials;
using Firebase.Database;
using BIM493_Project.HelperUser;
using BIM493_Project.Model;
namespace BIM493_Project.ViewModels.Forms
{
    /// <summary>
    /// ViewModel for login page.
    /// </summary>
    [Preserve(AllMembers = true)]
    public class LoginPageViewModel : LoginViewModel
    {
        #region Fields
        private string name;
        private string password;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance for the <see cref="LoginPageViewModel" /> class.
        /// </summary>
        public LoginPageViewModel()
        {
            this.LoginCommand = new Command(this.LoginClicked);
            this.SignUpCommand = new Command(this.SignUpClicked);
            this.ForgotPasswordCommand = new Command(this.ForgotPasswordClicked);
            this.SocialMediaLoginCommand = new Command(this.SocialLoggedIn);
        }

        FirebaseHelperUser firebaseHelperUser = new FirebaseHelperUser();

        #endregion

        #region property

        /// <summary>
        /// Gets or sets the property that is bound with an entry that gets the password from user in the login page.
        /// </summary>
        public string Password
        {
            get
            {
                return this.password;
            }

            set
            {
                if (this.password == value)
                {
                    return;
                }

                this.password = value;
                this.NotifyPropertyChanged();
            }
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                if (this.name == value)
                {
                    return;
                }

                this.name = value;
                this.NotifyPropertyChanged();
            }
        }

        #endregion

        #region Command

        /// <summary>
        /// Gets or sets the command that is executed when the Log In button is clicked.
        /// </summary>
        public Command LoginCommand { get; set; }

        /// <summary>
        /// Gets or sets the command that is executed when the Sign Up button is clicked.
        /// </summary>
        public Command SignUpCommand { get; set; }

        /// <summary>
        /// Gets or sets the command that is executed when the Forgot Password button is clicked.
        /// </summary>
        public Command ForgotPasswordCommand { get; set; }

        /// <summary>
        /// Gets or sets the command that is executed when the social media login button is clicked.
        /// </summary>
        public Command SocialMediaLoginCommand { get; set; }

        #endregion

        #region methods

        /// <summary>
        /// Invoked when the Log In button is clicked.
        /// </summary>
        /// <param name="obj">The Object</param>
        async private void LoginClicked(object obj)
        {
            // Do something
            Page page = Application.Current.MainPage;
            INavigation nav = page.Navigation;
            //try
            //{
            //    if (Preferences.ContainsKey("email") && Preferences.Get("email", "") == Email && Preferences.ContainsKey("password") && Preferences.Get("password", "") == Password)
            //    //if (emailEntered.Text == Preferences.Get(emailEntered.Text, "") && passwordEntered.Text == Preferences.Get(passwordEntered.Text, ""))
            //    {

            //        if (await page.DisplayAlert("Login Process", "Username and password match", "Continue", "Cancel"))
            //            await nav.PushAsync(new MainPage());
            //    }
            //    else
            //        await page.DisplayAlert("Login Process", "Please make sure you have entered the right credentials.", "OK");
            //}
            //catch
            //{
            //    await page.DisplayAlert("Login Process", "Please fill in E-mail and Password fields", "OK");
            //}
            try {
                var userCred = await firebaseHelperUser.GetUserCredentials(Name, Password);
                if (userCred.UserName == Name && userCred.Password == Password)
                {
                    if (await page.DisplayAlert("Login Process", "Username and password match", "Continue", "Cancel"))
                        await nav.PushAsync(new MainPage());
                }
                else
                    await page.DisplayAlert("Login Process", "Please make sure you have entered the right credentials.", "OK");
            }
            catch
            {
                await page.DisplayAlert("Login Process", "Please make sure you have entered the right credentials.", "OK");
            }
            }

        /// <summary>
        /// Invoked when the Sign Up button is clicked.
        /// </summary>
        /// <param name="obj">The Object</param>
        async private void SignUpClicked(object obj)
        {
            INavigation nav = Application.Current.MainPage.Navigation;          
            // Do something
            await nav.PopAsync();
            await nav.PushAsync(new Views.Forms.SignUpPage());
        }

        /// <summary>
        /// Invoked when the Forgot Password button is clicked.
        /// </summary>
        /// <param name="obj">The Object</param>
        private async void ForgotPasswordClicked(object obj)
        {
            var label = obj as Label;
            label.BackgroundColor = Color.FromHex("#70FFFFFF");
            await Task.Delay(100);
            label.BackgroundColor = Color.Transparent;
        }

        /// <summary>
        /// Invoked when social media login button is clicked.
        /// </summary>
        /// <param name="obj">The Object</param>
        private void SocialLoggedIn(object obj)
        {
            // Do something
        }

        #endregion
    }
}