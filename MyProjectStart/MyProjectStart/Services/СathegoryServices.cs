using Firebase.Database;
using MyProjectStart.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Firebase.Database.Query;
using System.Linq;
using System.Collections.ObjectModel;

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
                    ImageUrl = c.Object.ImageUrl,
                    TemaID = c.Object.TemaID
                    

                }).ToList();
            return categories;
                
        }
        
        public async Task<ObservableCollection<Cathegory>> GetCathegoryBuTema(int temaId)
        {
            var CathegoryBuTema = new ObservableCollection<Cathegory>();
            var items = (await GetCathegoryAsync()).Where(p => p.TemaID == temaId).ToList();
            foreach (var item in items)
            {
                CathegoryBuTema.Add(item);
            }
            return CathegoryBuTema;
        }
    }
}
