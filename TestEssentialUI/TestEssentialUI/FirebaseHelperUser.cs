using Firebase.Database;
using Firebase.Database.Query;
using BIM493_Project.Model;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Collections.Generic;
using System;
namespace BIM493_Project.HelperUser
{
    class FirebaseHelperUser
    {
        FirebaseClient firebase = new FirebaseClient("https://growtogether-14120.firebaseio.com/");

        public async Task<List<UserPageModel>> GetAllUsers()
        {

            return (await firebase
              .Child("Users")
              .OnceAsync<UserPageModel>()).Select(item => new UserPageModel
              {
                  UserName = item.Object.UserName,
                  Email = item.Object.Email,
                  Password = item.Object.Password  
              }).ToList();
        }

        public async Task AddUser(string userName, string email, string password)
        {
            await firebase
                .Child("Users")
                .PostAsync(new UserPageModel
                {
                    UserName = userName,
                    Email = email,
                    Password = password
                }) ;
        }

        public async Task DeleteUser(string userName)
        {
            var toDeleteUser = (await firebase
              .Child("Users")
              .OnceAsync<UserPageModel>()).Where(a => a.Object.UserName== userName).FirstOrDefault();
            await firebase.Child("Users").Child(toDeleteUser.Key).DeleteAsync();

        }

        public async Task<UserPageModel> GetUser(string userName)
        {
            var allUsers = await GetAllUsers();
            await firebase
              .Child("Users")
              .OnceAsync<UserPageModel>();
            return allUsers.Where(a => a.UserName == userName).FirstOrDefault();
        }

        public async Task<UserPageModel> GetUserCredentials(string userName, string password)
        {
            var allUsers = await GetAllUsers();
            await firebase
              .Child("Users")
              .OnceAsync<UserPageModel>();
            return allUsers.Where(a => a.UserName == userName && a.Password == password)
              .FirstOrDefault();
           
        }
    }
}
