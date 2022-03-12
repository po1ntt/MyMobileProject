using System;
using System.Collections.Generic;
using System.Text;
using Android.Webkit;
using MyProjectStart.Models;
using Firebase.Database;
using Firebase.Database.Query;
using static System.Net.Mime.MediaTypeNames;
using Xamarin.Forms;
using System.Threading.Tasks;

namespace MyProjectStart.Helpers
{

    public class AddDataToCathegory
    {
        public List<Cathegory> Cathegories { get; set; }

        FirebaseClient client;

        public AddDataToCathegory()
        {
            client = new FirebaseClient("https://victorinaproject-default-rtdb.firebaseio.com/");
            Cathegories = new List<Cathegory>()
            {
                new Cathegory()
                {
                    CathegoryId = 1,
                    CathegoryName = "Введение"

                },
                new Cathegory()
                {
                    CathegoryId = 2,
                    CathegoryName = "Условия,Циклы"
                },
                new Cathegory()
                {
                    CathegoryId = 3,
                    CathegoryName ="Задачи"
                },
                new Cathegory()
                {
                    CathegoryId = 4,
                    CathegoryName ="WPF"
                },
                new Cathegory()
                {
                    CathegoryId =5,
                    CathegoryName = "Работа с бд"
                }

            };
        }
        public async Task AddCathegories()
        {
            try
            {
                foreach (var cathegory in Cathegories)
                {
                    await client.Child("Cathegories").PostAsync(new Cathegory()
                    {
                        CathegoryId = cathegory.CathegoryId,
                        CathegoryName = cathegory.CathegoryName
                    });
                }
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Error", ex.Message, "Ok");
            }
        }
    }
}
