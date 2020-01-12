using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Firebase.Database;
using Firebase.Database.Query;
using Xamarin.Forms;

namespace BIM493_Project.Model
{
    public class CompetitionPageModel
    {
      
        //public String CompetitionID { get; set; }
        public String CompetitionName { get; set; }
        public int Target { get; set; }
        public DateTime DueDate { get; set; }
        public String Participant1 { get; set; }
        public String Participant2 { get; set; }

       

    }
}