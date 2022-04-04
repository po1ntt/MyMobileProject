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
        private Tema _SelectedTema;

        public Tema SelectedTema
        {
            get { return _SelectedTema; }
            set { _SelectedTema = value;
                OnPropertyChanged();
                if(_SelectedTema != null)
                {
                    GetCategories(_SelectedTema.TemaID);
                }
            }
        }
       

        public ObservableCollection<Tema> TemaList { get; set; }
        public ObservableCollection<Cathegory> CathegoriesList { get; set; }
        public ObservableCollection<TestsModel> TestsList { get; set; }
        public ObservableCollection<Questions> QuestionsList { get; set; }
        public EditingPopupsVM()
        {
            TemaList = new ObservableCollection<Tema>();
            CathegoriesList = new ObservableCollection<Cathegory>();
            TestsList = new ObservableCollection<TestsModel>();
            QuestionsList = new ObservableCollection<Questions>();
            GetTemaList();
        }
        public async void GetTemaList()
        {
            TemaServices tema = new TemaServices();
            var data = await tema.GetListTemaAsunc();
            TemaList.Clear();
            foreach(var item in data)
            {
                TemaList.Add(item);
            }
        }
        private async void GetCategories(int tema_id)
        {
            var data = await new Services.СathegoryServices().GetCathegoryBuTema(tema_id);
            CathegoriesList.Clear();
            foreach (var item in data)
            {
                CathegoriesList.Add(item);
            }
        }
        private async void GetTestsItems(int cathegoryId)
        {
            var data = await new Services.TestItemServices().GetTestByCathegoryAsync(cathegoryId);
            TestsList.Clear();
            foreach (var item in data)
            {
              
                   TestsList.Add(item);
                

            }
           
        }
        private async void GetQuestionByTest(int testid)
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
