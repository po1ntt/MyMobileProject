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
    public class LearningCategoryService
    {
        FirebaseClient client;
        public LearningCategoryService()
        {
            client = new FirebaseClient("https://victorinaproject-default-rtdb.firebaseio.com/");
        }
        public async Task<List<LerningCategories>> GetCategoryLearningAsunc()
        {
            var lerningCategories = (await client.Child("LerningCategories").OnceAsync<LerningCategories>()).Select(f => new LerningCategories
            {
               id_learncat = f.Object.id_learncat,
               ImageLearnCat = f.Object.ImageLearnCat,
               NameLernCategory = f.Object.NameLernCategory

            }).ToList();
            return lerningCategories;
        }
    }
}
