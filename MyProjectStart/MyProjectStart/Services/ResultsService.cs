using Firebase.Database;
using MyProjectStart.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Firebase.Database.Query;
using System.Collections.ObjectModel;

namespace MyProjectStart.Services
{
    public class ResultsService
    {
        FirebaseClient client;
        public ResultsService()
        {
            client = new FirebaseClient("https://victorinaproject-default-rtdb.firebaseio.com/");
        }
        public async Task<List<Results>> GetQuestionsAsync()
        {
            var results = (await client.Child("Results").OnceAsync<Results>()).Select(f => new Results
            {
               id_result = f.Object.id_result,
               NameTestDone = f.Object.NameTestDone,
               User_login = f.Object.User_login,
               CathegoryId = f.Object.CathegoryId,
               TemaId = f.Object.TemaId
               
               



            }).ToList();
            return results;
        }
        public async Task<bool> IsResultExists(string login,string NameTest, int CathegoryID)
        {
            var result = (await client.Child("Results").OnceAsync<Results>()).Where(u => u.Object.User_login == login && u.Object.NameTestDone == NameTest && u.Object.CathegoryId == CathegoryID).FirstOrDefault();
            return (result != null);
        }
        public async Task<bool> RegisterResult( string NameTest, string user_login, int CathegoryId)
        {
            if (await IsResultExists(user_login,NameTest,CathegoryId) == false)
            {
                await client.Child("Results").PostAsync(new Results()
                {
                    id_result = 1,
                    NameTestDone = NameTest,
                    User_login = user_login,
                    CathegoryId = CathegoryId

                    
                });
                return true;

            }
            else
            {
                return false;
            }
        }
    }
}
