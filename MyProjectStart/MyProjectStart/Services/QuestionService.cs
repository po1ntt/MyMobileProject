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
        public List<Answers> Anslist { get; set; }
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
                id_rightanswer = f.Object.id_rightanswer,
                TextQuest = f.Object.TextQuest


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
        public async Task<List<Answers>> GetAnswersAsync(int quest_id)
        {
            var answers = (await client.Child("Answers").OnceAsync<Answers>()).Select(f => new Answers
            {
                id_answer = f.Object.id_answer,
                id_question = f.Object.id_question,
                text_answer = f.Object.text_answer,


            }).Where(p => p.id_question == quest_id).ToList();
            return answers;
        }
       
        public async Task<List<Answers>> GetAnswersForQUest(int test_id)
        {
            var answersByquest = new List<Answers>();
            var items = (await GetQuestionsAsync()).Where(p => p.id_test == test_id).ToList();
            foreach(var item in items)
            {
                var answers = await GetAnswersAsync(item.id_quest);
                foreach(var answer in answers)
                {
                    answersByquest.Add(answer);
                }
            };
            Anslist = answersByquest;
            return answersByquest;

        }
       
    }
}
