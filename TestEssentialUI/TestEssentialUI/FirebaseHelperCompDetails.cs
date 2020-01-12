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
                  Participant = item.Object.Participant,
                  Competition = item.Object.Competition,
                  Work = item.Object.Work
              }).ToList();
        }

        public async Task AddWork(string competition, string participant, string work)
        {
            var allCompDetails = await GetWork(competition, participant);
            int prevWorkInt =  Convert.ToInt32(allCompDetails.Work);
            int currentWorkInt = Convert.ToInt32(work);
            int resultWork = prevWorkInt + currentWorkInt;
            await firebase
                .Child("CompDetails")
                .PostAsync(new CompetitonDetailPageModel
                {
                    Competition = competition,
                    Participant = participant,
                    Work = resultWork.ToString()
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
            return allWork.Where(a => a.Competition == competition && a.Participant == participant).FirstOrDefault();
        }

        public async Task AddCompDetail(string competition, string pariticipant)
        {
            await firebase
                .Child("CompDetails")
                .PostAsync(new CompetitonDetailPageModel
                {
                    Participant = pariticipant,
                    Competition = competition,
                    Work = 0.ToString()
                }) ;
        }
    }
}
