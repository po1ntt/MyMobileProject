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
        public async Task<bool> UpdateCathegory(string namecathegory, int cathegoryId)
        {
            var cat = (await client.Child("Cathegories")
                .OnceAsync<Cathegory>())
                .FirstOrDefault
                (a => a.Object.CathegoryId == cathegoryId); 

            Cathegory cathegory1 = new Cathegory() {CathegoryName = namecathegory , CathegoryId = cathegoryId, TemaID = cat.Object.TemaID };
            await client.Child("Cathegories")
                .Child(cat.Key)
                .PutAsync(cathegory1);

            return true;
        }
        public async Task<bool> AddCategory(string nameCathegoy, Tema tema)
        {
            var cathegories = await GetCathegoryAsync();
            await client.Child("Cathegories").PostAsync(new Cathegory()
            {
                CathegoryName = nameCathegoy,
                CathegoryId = cathegories.Count + 1,
                TemaID = tema.TemaID

            });
            return true;
        }
        public async Task<bool> DeleteCathegory(int cathegoryId)
        {
            var keytodelete = (await client.Child("Cathegories").OnceAsync<Cathegory>()).FirstOrDefault(a => a.Object.CathegoryId == cathegoryId);
            await client.Child("Cathegories").Child(keytodelete.Key).DeleteAsync();
            return true;
        }

    }
}
