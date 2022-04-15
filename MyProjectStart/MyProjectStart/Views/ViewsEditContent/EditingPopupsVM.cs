using MyProjectStart.Models;
using MyProjectStart.Services;
using MyProjectStart.ViewsModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace MyProjectStart.Views.ViewsEditContent
{
    class EditingPopupsVM : BaseViewModel
    {
        private TestsModel _SelectedTest;

        public TestsModel SeletedTest
        {
            get { return _SelectedTest; }
            set { _SelectedTest = value;
                OnPropertyChanged();
                if(_SelectedTest != null)
                {
                    GetQuestionByTest(_SelectedTest.TestId);
                }
            }
        }
        private Cathegory _SelectedCategory;

        public Cathegory SelectedCategory
        {
            get { return _SelectedCategory; }
            set { _SelectedCategory = value;
                OnPropertyChanged();
                if (_SelectedCategory != null)
                {
                    GetTestsItems(_SelectedCategory.CathegoryId);
                }
                
            }
        }
     
       

       
        public ObservableCollection<Cathegory> CathegoriesList { get; set; }
        public ObservableCollection<TestsModel> TestsList { get; set; }
        public ObservableCollection<Questions> QuestionsList { get; set; }
        public EditingPopupsVM()
        {
            CathegoriesList = new ObservableCollection<Cathegory>();
            TestsList = new ObservableCollection<TestsModel>();
            QuestionsList = new ObservableCollection<Questions>();
            GetCategories();
        }

        public async void GetCategories()
        {
            var data = await new Services.СathegoryServices().GetCathegoryAsync();
            CathegoriesList.Clear();
            foreach (var item in data)
            {
                CathegoriesList.Add(item);
            }
        }
        public async void GetTestsItems(int cathegoryId)
        {
            var data = await new Services.TestItemServices().GetTestByCathegoryAsync(cathegoryId);
            TestsList.Clear();
            foreach (var item in data)
            {
              
                   TestsList.Add(item);
                

            }
           
        }
        public async void GetQuestionByTest(int testid)
        {
            var data = await new Services.QuestionService().GetQuestionsAsyncBYTest(testid);
            QuestionsList.Clear();
            foreach (var item in data)
            {

                QuestionsList.Add(item);


            }

        }

    }
}
