using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using MyProjectStart.Views;
using System.Collections.ObjectModel;

using MyProjectStart.Models;
using MyProjectStart.Services;

namespace MyProjectStart.ViewsModel
{
    class TestViewModel : BaseViewModel
    {
        public ObservableCollection<Answers> AnsList { get; set; }
        private TestsModel _SelectedTest;
        public TestsModel SelectedTest
        {
            set
            {
                _SelectedTest = value;
                OnPropertyChanged();

            }
            get
            {
                return _SelectedTest;

            }
        }
        public ObservableCollection<Questions> QestionsByTest { get; set; }
        public ObservableCollection<Answers> answersByQuestion { get; set; }
        public ObservableCollection<Answers> ansforquest { get; set; }


        public TestViewModel(TestsModel tests)
        {
            SelectedTest = tests;
            QestionsByTest = new ObservableCollection<Questions>();
            answersByQuestion = new ObservableCollection<Answers>();
            getQuestionsBuTest(tests.TestId);
            getAnswersByQuest(tests.TestId);

        }

        private async void getAnswersByQuest(int test_id)
        {
            var data = await new Services.QuestionService().GetAnswersForQUest(test_id);
            answersByQuestion.Clear();
            foreach (var item in data)
            {
               answersByQuestion.Add(item);

            }
        }

        private async void getQuestionsBuTest(int test_id)
        {
            var data = await new Services.QuestionService().GetQuestionsAsyncBYTest(test_id);
            QestionsByTest.Clear();
            foreach (var item in data)
            {
                QestionsByTest.Add(item);

            }
            
        }
        private void GetQuestForTEST(int questId)
        {
            var data = answersByQuestion;
            foreach(var item in data)
            {
                if(item.id_question == questId)
                {
                    ansforquest.Add(item);
                }

            }
        }
    }
}
