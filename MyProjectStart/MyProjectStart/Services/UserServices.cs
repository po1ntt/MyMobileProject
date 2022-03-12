using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Firebase.Database;
using MyProjectStart.Models;
using System.Linq;
using Firebase.Database.Query;

namespace MyProjectStart.Services
{

   public class UserServices
    {
        FirebaseClient client;
        public UserServices()
        {
            client = new FirebaseClient("https://victorinaproject-default-rtdb.firebaseio.com/");
        }
        public async Task<bool> IsUserExists(string login)
        {
            var user = (await client.Child("Users").OnceAsync<UserModel>()).Where(u => u.Object.Login == login).FirstOrDefault();
            return (user != null);
        }
        public async Task<bool> RegisterUser(string login, string password, string email)
        {
            if(await IsUserExists(login) == false)
            {
                await client.Child("Users").PostAsync(new UserModel()
                {
                    Login = login,
                    Password = password,
                    Email = email
                });
                return true;

            }
            else
            {
                return false;
            }
        }
        public async Task<bool> LoginUser(string login, string password)
        {
            var user = (await client.Child("Users").OnceAsync<UserModel>()).Where(u => u.Object.Login == login)
                .Where(u => u.Object.Password == password).FirstOrDefault();
            return (user != null);
        }
        
    }
}
