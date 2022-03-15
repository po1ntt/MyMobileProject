using Firebase.Database;
using MyProjectStart.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Firebase.Database.Query;
using System.Collections.ObjectModel;
using MyProjectStart.Services;

namespace MyProjectStart.Services
{
    
    public class QuestionService
    {
        
        FirebaseClient client;
        public QuestionService()
        {
            client = new FirebaseClient("https://victorinaproject-default-rtdb.firebaseio.com/");
        }
        public async Task<List<Questions>> GetQuestionsAsync()
        {
            var questions = (await client.Child("Questions").OnceAsync<Questions>()).Select(f => new Questions
            {
                id_quest= f.Object.id_quest,
                id_test = f.Object.id_test,
                quest_answer1 = f.Object.quest_answer1,
                quest_answer2 = f.Object.quest_answer2,
                quest_answer3 = f.Object.quest_answer3,
                quest_answer4 = f.Object.quest_answer4,
                TextQuest = f.Object.TextQuest,
                quest_rightanswer =f.Object.quest_rightanswer
                


            }).ToList();
            return questions;
        }
        public async Task<ObservableCollection<Questions>> GetQuestionsAsyncBYTest(int test_id)
        {
            var QuestionsByTest = new ObservableCollection<Questions>();
            var items = (await GetQuestionsAsync()).Where(p => p.id_test == test_id).ToList();
            foreach (var item in items)
            {
                QuestionsByTest.Add(item);
               
            }
            return QuestionsByTest;
        }
        
       
      
    }
}
