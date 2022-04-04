using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Firebase.Database;
using MyProjectStart.Models;
using System.Linq;
using Firebase.Database.Query;
using System.Collections.ObjectModel;

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
        public async Task<bool> RegisterUser(string login, string password, string email, string name , string surname, string phone)
        {
            if (await IsUserExists(login) == false)
            {
                await client.Child("Users").PostAsync(new UserModel()
                {
                    Login = login,
                    Password = password,
                    Email = email,
                    Name = name,
                    SurName = surname,
                    Phone = phone,
                    RoleId = 1
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
        public async Task<List<UserModel>> SelectUsers()
        {
            var users = (await client.Child("Users").OnceAsync<UserModel>())
                .Select(c => new UserModel
                {
                    Login = c.Object.Login,
                    SurName = c.Object.SurName,
                    BirtDay = c.Object.BirtDay,
                    Password = c.Object.Password,
                    RoleId = c.Object.RoleId,
                    Name = c.Object.Name,
                    Phone = c.Object.Phone,
                    Email = c.Object.Email


                }).ToList();
            return users;

        }
        public async Task<ObservableCollection<UserModel>> UserBuRoleId()
        {
            var userbyroleid = new ObservableCollection<UserModel>();
            var items = (await SelectUsers()).Where(p => p.RoleId == 1).ToList();
            foreach(var item in items)
            {
                userbyroleid.Add(item);
            }
            return userbyroleid;
        }
        public async Task<ObservableCollection<UserModel>> GetUserByLogin(string userlogin)
        {
            var UserBylogin = new ObservableCollection<UserModel>();
            var items = (await SelectUsers()).Where(p => p.Login == userlogin).ToList();
            foreach (var item in items)
            {
                UserBylogin.Add(item);
            }
            return UserBylogin;
        }
        public async Task<bool> UpdateUser(string name, int role_id, string login, string birthday, string surname, string phone, string email, string password)
        {
            var toUpdateUser = (await client.Child("Users")
                .OnceAsync<UserModel>())
                .FirstOrDefault
                (a => a.Object.Login == login);

            UserModel s = new UserModel() { Name = name, Login = login, RoleId = role_id, SurName = surname, Email = email, BirtDay = Convert.ToDateTime(birthday), Password = password, Phone = phone };
            await client.Child("Users")
                .Child(toUpdateUser.Key)
                .PutAsync(s);

            return true;
        }


    }
}
