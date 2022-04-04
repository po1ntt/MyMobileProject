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
   public class TemaServices
    {
        FirebaseClient client;
        public TemaServices()
        {
            client = new FirebaseClient("https://victorinaproject-default-rtdb.firebaseio.com/");

        }
        public async Task<List<Tema>> GetListTemaAsunc()
        {
            var tema = (await client.Child("Tema").OnceAsync<Tema>())
                .Select(c => new Tema
                {
                    TemaID = c.Object.TemaID,
                    NameTema = c.Object.NameTema

                }).ToList();
            return tema;

        }
        public async Task<bool> UpdateTema(string nameTema, int temaid)
        {
            var keytema = (await client.Child("Tema")
                .OnceAsync<Tema>())
                .FirstOrDefault
                (a => a.Object.TemaID == temaid);

            Tema tema = new Tema() { NameTema = nameTema, TemaID = temaid};
            await client.Child("Tema")
                .Child(keytema.Key)
                .PutAsync(tema);

            return true;
        }
        public async Task<bool> AddTema(string nameTema)
        {
            var temas = await GetListTemaAsunc();
            await client.Child("Tema").PostAsync(new Tema()
            {
                NameTema = nameTema,
                TemaID = temas.Count + 1
            });
            return true;
        }
        public async Task<bool> DeleteTema(int TemaId)
        {
            var keytodelete = (await client.Child("Tema").OnceAsync<Tema>()).FirstOrDefault(a => a.Object.TemaID == TemaId);
            await client.Child("Tema").Child(keytodelete.Key).DeleteAsync();
            return true;
        }
    }
}
