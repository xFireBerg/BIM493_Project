using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace BIM493_Project.Model
{
    public class CompetitonDetailPageModel
    {
        public string Competition  {get; set; }
        public string Participant1 { get; set; }
        public string Work1 { get; set; }
        public string Participant2 { get; set; }
        public string Work2 { get; set; }

        public int Target{ get; set; }

        public DateTime DueDate{ get; set; }
    }
    
}