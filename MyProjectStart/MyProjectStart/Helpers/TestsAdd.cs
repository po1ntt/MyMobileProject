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
        public List<TestsModel> tests { get; set; }
        public TestsAdd()
        {
            tests = new List<TestsModel>()
            { new TestsModel()
                {
                    TestId = 1,
                     Name = "Введение"

                },
                new TestsModel()
                {

                },

            };
        }
    }

    
}

