using System;
using System.Collections.Generic;
using System.Text;
using Android.Webkit;
using MyProjectStart.Models;
using Firebase.Database;
using Firebase.Database.Query;

using Xamarin.Forms;
using System.Threading.Tasks;

namespace MyProjectStart.Helpers
{
    public class TestsAdd
    {
        FirebaseClient client;

        public List<TestsModel> tests { get; set; }
        public TestsAdd()
        {
            client = new FirebaseClient("https://victorinaproject-default-rtdb.firebaseio.com/");
            tests = new List<TestsModel>()
            { new TestsModel()
                {
                     TestId = 1,
                     Name = "Введение",
                     Description = "TestDescription",
                     CategoryId = 1
                     
                     

                },
                new TestsModel()
                {
                    TestId = 2,
                     Name = "Основы",
                     Description = "TestDescription",
                     CategoryId = 1
                },
                 new TestsModel()
                {
                    TestId = 3,
                     Name = "TestExample",
                     Description = "TestDescription",
                     CategoryId = 1
                },
                  new TestsModel()
                {
                    TestId = 4,
                     Name = "TestEmample2",
                     Description = "TestDescription",
                     CategoryId = 1
                },
                   new TestsModel()
                {
                    TestId = 5,
                     Name = "TestExample",
                     Description = "TestDescription",
                     CategoryId = 2
                },
                    new TestsModel()
                {
                    TestId = 6,
                     Name = "TestExample",
                     Description = "TestDescription",
                     CategoryId = 2
                },
                     new TestsModel()
                {
                    TestId = 7,
                     Name = "TestExample",
                     Description = "TestDescription",
                     CategoryId = 2
                },

            };
        }
        public async Task AddTestData()
        {
            try
            {
                foreach(var tests in tests)
                {
                    await client.Child("Tests").PostAsync(new TestsModel()
                    {
                        Name = tests.Name,
                        CategoryId = tests.CategoryId,
                        Description = tests.Description,
                        TestId = tests.TestId

                    });
                        
                }
            }
            catch(Exception ex)
            {
                await Shell.Current.DisplayAlert("Error", ex.Message, "ок");
            }
        }
    }

    
}

