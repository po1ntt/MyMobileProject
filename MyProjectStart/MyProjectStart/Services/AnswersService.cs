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
    public class AnswersService
    {
        FirebaseClient client;
        public AnswersService()
        {
            client = new FirebaseClient("https://victorinaproject-default-rtdb.firebaseio.com/");
        }
        public async Task<List<Answers>> GetAnswersAsync()
        {
            var answers = (await client.Child("Answers").OnceAsync<Answers>()).Select(f => new Answers
            {
                id_answer= f.Object.id_answer,
                id_question = f.Object.id_question,
                text_answer = f.Object.text_answer,
                

            }).ToList();
            return answers;
        }
        public async Task<ObservableCollection<Answers>> GetAnswersAsyncBYQuest(int question_id)
        {
            var AnswersByQuest = new ObservableCollection<Answers>();
            var items = (await GetAnswersAsync()).Where(p => p.id_question == question_id).ToList();
            foreach (var item in items)
            {
                AnswersByQuest.Add(item);
            }
            return AnswersByQuest;
        }

    }
}
