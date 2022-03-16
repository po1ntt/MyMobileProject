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
        private bool _EnabledButt1;
        public bool EnabledButt1
        {
            set
            {
                _EnabledButt1 = value;
                OnPropertyChanged();
            }
            get
            {
                return _EnabledButt1;
            }
        }
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

        private int _currentQuestionIndex = -1;
        public Questions CurrentQuestion
        {
            get
            {
                return _currentQuestionIndex < QestionsByTest.Count ? QestionsByTest[_currentQuestionIndex] : null;
            }
        }
        public Questions NextQuest()
        {
            _currentQuestionIndex++;
            return CurrentQuestion;
        }
        public bool isLastQuest()
        {
            return _currentQuestionIndex == QestionsByTest.Count - 1;
        }
        public void Reset()
        {
            _currentQuestionIndex = -1;
        }
        public TestViewModel(TestsModel tests)
        {
            SelectedTest = tests;
            QestionsByTest = new ObservableCollection<Questions>();
            EnabledButt1 = false;
            getQuestionsBuTest(tests.TestId);
             

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

       
    }
}
