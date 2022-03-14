using Firebase.Database;
using MyProjectStart.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Firebase.Database.Query;
using System.Linq;

namespace MyProjectStart.Services
{
    public class СathegoryServices
    {
        FirebaseClient client;
        public СathegoryServices()
        {
            client = new FirebaseClient("https://victorinaproject-default-rtdb.firebaseio.com/");

        }
        public async Task<List<Cathegory>> GetCathegoryAsync()
        {
            var categories = (await client.Child("Cathegories").OnceAsync<Cathegory>())
                .Select(c => new Cathegory
                {
                    CathegoryId = c.Object.CathegoryId,
                    CathegoryName = c.Object.CathegoryName,
                    ImageUrl = c.Object.ImageUrl
                    

                }).ToList();
            return categories;
                
        }
    }
}
