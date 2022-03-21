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
        public static double TestScore { get; set; }
        public Results GetResultsForTest(string nametest, string userlogin, int CathegoryId)
        {
           var collection = client.Child("Results").AsObservable<Results>().AsObservableCollection().Where(p => p.NameTestDone == nametest && p.User_login == userlogin && p.CathegoryId == CathegoryId) as Results;
           return collection;
        }
        public async Task<List<Results>> GetQuestionsAsync()
        {
            var results = (await client.Child("Results").OnceAsync<Results>()).Select(f => new Results
            {
               TestId = f.Object.TestId,
               NameTestDone = f.Object.NameTestDone,
               User_login = f.Object.User_login,
               CathegoryId = f.Object.CathegoryId
               
               
               



            }).ToList();
            return results;
        }
        public async Task<List<Results>> GetTestsResultsModelsAsync()
        {
            var tests = (await client.Child("Results").OnceAsync<Results>()).Select(f => new Results
            {
                CathegoryId = f.Object.CathegoryId,
                TestId = f.Object.TestId,
                NameTestDone = f.Object.NameTestDone,
                Scoreprecennt = f.Object.Scoreprecennt,
                LearningUrlTestDone = f.Object.LearningUrlTestDone,
                User_login = f.Object.User_login

            }).ToList();
            return tests;
        }
        public async Task<bool> IsResultExists(string login,string NameTest, int CathegoryID)
        {
            var result = (await client.Child("Results").OnceAsync<Results>()).Where(u => u.Object.User_login == login && u.Object.NameTestDone == NameTest && u.Object.CathegoryId == CathegoryID).FirstOrDefault();
            return (result != null);
        }
        public async Task<bool> IsResultScorePercentChanged(string login, string NameTest, int CathegoryID, double ScorePercent)
        {
            var result = (await client.Child("Results").OnceAsync<Results>()).Where(u => u.Object.User_login == login && u.Object.NameTestDone == NameTest && u.Object.CathegoryId == CathegoryID).FirstOrDefault();
            return (result != null);
        }
        public async Task<bool> RegisterResult( string NameTest, string user_login, int CathegoryId, double Scorepercent, int test_id)
        {
            if (await IsResultExists(user_login,NameTest,CathegoryId) == false)
            {
                
                await client.Child("Results").PostAsync(new Results()
                {
                    TestId = test_id ,
                    NameTestDone = NameTest,
                    User_login = user_login,
                    CathegoryId = CathegoryId,
                    Scoreprecennt = Scorepercent
                    
                    
                });
                return true;

            }
            else
            {
                
              return false;

            }
        }
        public async Task<ObservableCollection<Results>> GetTestResultByCathegoryAsync(int categoryID, string userlogin)
        {
            var TestItemsByCathegoryResult = new ObservableCollection<Results>();
            var items = (await GetTestsResultsModelsAsync()).Where(p => p.CathegoryId == categoryID && p.User_login == userlogin).ToList();
            foreach (var item in items)
            {
                TestItemsByCathegoryResult.Add(item);
            }
            return TestItemsByCathegoryResult;
        }
        public async Task<bool> UpdateResult(string nametest,int cathegory_id, string user_login, double scorepercent, int test_id)
        {
            var toUpdateResult = (await client.Child("Results")
                .OnceAsync<Results>())
                .FirstOrDefault
                (a => a.Object.NameTestDone == nametest && a.Object.CathegoryId == cathegory_id && a.Object.User_login == user_login);
            if(toUpdateResult.Object.Scoreprecennt < scorepercent)
            {
                Results s = new Results() { Scoreprecennt = scorepercent, NameTestDone = nametest, CathegoryId = cathegory_id, User_login = user_login, TestId = test_id };
                await client.Child("Results")
                    .Child(toUpdateResult.Key)
                    .PutAsync(s);
                return true;
            }
            else
            {
                return false;
            }
           
        }
        public async void GetTestResult(string nametest, int cathegory_id, string userlogin)
        {
            var toUpdateResult = (await client.Child("Results")
               .OnceAsync<Results>())
               .FirstOrDefault
               (a => a.Object.NameTestDone == nametest && a.Object.CathegoryId == cathegory_id && a.Object.User_login == userlogin);
           
        }
      
    }
}
