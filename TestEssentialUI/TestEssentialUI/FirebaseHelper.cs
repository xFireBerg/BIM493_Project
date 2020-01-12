using Firebase.Database;
using Firebase.Database.Query;
using BIM493_Project.Model;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Collections.Generic;
using System;
namespace BIM493_Project.Helper
{
    public class FirebaseHelper
    {
        FirebaseClient firebase = new FirebaseClient("https://growtogether-14120.firebaseio.com/");
        public async Task<List<CompetitionPageModel>> GetAllCompetitions()
        {

            return (await firebase
              .Child("Competitions")
              .OnceAsync<CompetitionPageModel>()).Select(item => new CompetitionPageModel
              {
                  CompetitionName = item.Object.CompetitionName,
                  CompetitionID = item.Object.CompetitionID,
                  Target = item.Object.Target,
                  DueDate = item.Object.DueDate,
                  Participant1 = item.Object.Participant1,
                  Participant2 = item.Object.Participant2
              }).ToList();
        }

        public async Task AddCompetition(string competitionID, string competitionName, int target,
            DateTime dueDate, string participant1, string participant2 )
        {
            await firebase
                .Child("Compeitions")
                .PostAsync(new CompetitionPageModel()
                {
                    CompetitionID = competitionID,
                    CompetitionName = competitionName,
                    Target = target,
                    DueDate = dueDate,
                    Participant1 = participant1,
                    Participant2 = participant2
                });
        }

        public async Task DeleteCompetition(string competitionID)
        {
            var toDeleteCompetition = (await firebase
              .Child("Competitions")
              .OnceAsync<CompetitionPageModel>()).Where(a => a.Object.CompetitionID == competitionID).FirstOrDefault();
            await firebase.Child("Competitions").Child(toDeleteCompetition.Key).DeleteAsync();

        }


        public async Task<CompetitionPageModel> GetCompetition(string competitionID)
        {
            var allCompetitions = await GetAllCompetitions();
            await firebase
              .Child("Competitions")
              .OnceAsync<CompetitionPageModel>();
            return allCompetitions.Where(a => a.CompetitionID == competitionID).FirstOrDefault();
        }
    }
}