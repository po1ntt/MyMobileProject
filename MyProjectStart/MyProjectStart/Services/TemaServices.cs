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
    }
}
