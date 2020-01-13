using Firebase.Database;
using Firebase.Database.Query;
using BIM493_Project.Model;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Collections.Generic;
using System;
namespace BIM493_Project.HelperCompDetails
{
    class FirebaseHelperCompDetails
    {
        FirebaseClient firebase = new FirebaseClient("https://growtogether-14120.firebaseio.com/");

        public async Task<List<CompetitonDetailPageModel>> GetAllCompDetails()
        {

            return (await firebase
              .Child("CompDetails")
              .OnceAsync<CompetitonDetailPageModel>()).Select(item => new CompetitonDetailPageModel
              {
                  Participant1 = item.Object.Participant1,
                  Competition = item.Object.Competition,
                  Work1 = item.Object.Work1,
                  Participant2 = item.Object.Participant2,
                  Work2 = item.Object.Work2
              }).ToList();
        }

        public async Task AddWork(string competition, string participant1, string participant2, string work)
        {
            var allCompDetails1 = await GetWork(competition, participant1);
            var allCompDetails2 = await GetWork(competition, participant2);
            int prevWorkInt1 =  Convert.ToInt32(allCompDetails1.Work1);
            int currentWorkInt1 = Convert.ToInt32(work);
            int resultWor1 = prevWorkInt1 + currentWorkInt1;
            int prevWorkInt2 = Convert.ToInt32(allCompDetails2.Work2);
            int currentWorkInt2 = Convert.ToInt32(work);
            int resultWor2 = prevWorkInt2 + currentWorkInt2;
            await firebase
                .Child("CompDetails")
                .PostAsync(new CompetitonDetailPageModel
                {
                    Competition = competition,
                    Participant1 = participant1,
                    Work1 = resultWor1.ToString(),
                    Participant2 = participant2,
                    Work2 = resultWor2.ToString()
                }) ;
        }

        public async Task<CompetitonDetailPageModel> GetCompDetail(string competition)
        {
            var compDetails = await GetAllCompDetails();
            await firebase
              .Child("CompDetails")
              .OnceAsync<CompetitonDetailPageModel>();
            return compDetails.Where(a => a.Competition== competition).FirstOrDefault();
        }

        public async Task<CompetitonDetailPageModel> GetWork(string competition, string participant)
        {
            var allWork = await GetAllCompDetails();
            await firebase.Child("CompDetails").OnceAsync<CompetitonDetailPageModel>();
            return allWork.Where(a => a.Competition == competition && a.Participant1 == participant || a.Participant2 == participant).FirstOrDefault();
        }

        public async Task AddCompDetail(string competition, string pariticipant1, string participant2, int target, DateTime dueDate)
        {
            await firebase
                .Child("CompDetails")
                .PostAsync(new CompetitonDetailPageModel
                {
                    Participant1 = pariticipant1,
                    Competition = competition,
                    Work1 = 90.ToString(),
                    Participant2 = participant2,
                    Work2 = 20.ToString(),
                    Target = target,
                    DueDate = dueDate
                }) ;
        }
    }
}
