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
       

        public TestViewModel(TestsModel tests)
        {
            SelectedTest = tests;
            QestionsByTest = new ObservableCollection<Questions>();
            
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
