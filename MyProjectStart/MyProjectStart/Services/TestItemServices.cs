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
    public class TestItemServices
    {
        FirebaseClient client;
        public TestItemServices()
        {
            client = new FirebaseClient("https://victorinaproject-default-rtdb.firebaseio.com/");
        }
        public async Task<List<TestsModel>> GetTestsModelsAsync()
        {
            var tests = (await client.Child("Tests").OnceAsync<TestsModel>()).Select(f => new TestsModel
            {
                CategoryId = f.Object.CategoryId,
                Description = f.Object.Description,
                Name = f.Object.Name,
                TestId = f.Object.TestId
        
                
                
                
            }).ToList();
            return tests;
        }
        public async Task<ObservableCollection<TestsModel>> GetTestByCathegoryAsync(int categoryID)
        {
            var TestItemsByCathegory = new ObservableCollection<TestsModel>();
            var items = (await GetTestsModelsAsync()).Where(p => p.CategoryId == categoryID).ToList();
            foreach(var item in items)
            {
                TestItemsByCathegory.Add(item);
            }
            return TestItemsByCathegory;
        }
        public async Task<ObservableCollection<TestsModel>> GetLatestTestsAsunc()
            
        {
            var latestTestItems = new ObservableCollection<TestsModel>();
            var items = (await GetTestsModelsAsync()).OrderByDescending(f => f.TestId).Take(3);
            foreach(var item in items)
            {
                latestTestItems.Add(item);
            }
            return latestTestItems;

        }
        public async Task<Results> GetResultsTestByUserLogin(string user_login, string nametest, int cathegoryid)
        {
            var result = (await client.Child("Results").OnceAsync<Results>()).Select(f => new Results
            {
                Scoreprecennt = f.Object.Scoreprecennt
            }).FirstOrDefault(p => p.User_login == user_login && p.NameTestDone == nametest && p.CathegoryId == cathegoryid);
            return result;
        }
        public async Task<TestsModel> GetTestById(int TestId)
        {
            var test = (await GetTestsModelsAsync()).Where(p => p.TestId == TestId).FirstOrDefault() as TestsModel;
            return test;
        }
        public async Task<bool> UpdateTest(string nametest, string description, int testid)
        {
            var tests12 = (await client.Child("Tests")
                .OnceAsync<TestsModel>())
                .FirstOrDefault
                (a => a.Object.TestId == testid);

            TestsModel tests = new TestsModel() {Name = nametest, Description = description, TestId = testid, CategoryId = tests12.Object.CategoryId  };
            await client.Child("Tests")
                .Child(tests12.Key)
                .PutAsync(tests);

            return true;
        }
        public async Task<bool> AddTest(string nametest,string description , Cathegory cathegory)
        {
            var cathegories = await GetTestsModelsAsync();
            await client.Child("Tests").PostAsync(new TestsModel()
            {
                Name = nametest,
                CategoryId = cathegory.CathegoryId,
                Description = description
            });
            return true;
        }
        public async Task<bool> DeleteTest(int testid)
        {
            var keytodelete = (await client.Child("Tests").OnceAsync<TestsModel>()).FirstOrDefault(a => a.Object.TestId == testid);
            await client.Child("Tests").Child(keytodelete.Key).DeleteAsync();
            return true;
        }

    }
}
