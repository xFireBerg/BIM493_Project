using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Firebase.Database;
using Firebase.Database.Query;
using Xamarin.Forms;

namespace BIM493_Project.Model
{
    public class UserPageModel

    {
        public string UserName { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        
    }
}