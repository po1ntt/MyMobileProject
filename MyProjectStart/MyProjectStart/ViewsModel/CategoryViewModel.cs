using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using MyProjectStart.Views;
using System.Collections.ObjectModel;

using MyProjectStart.Models;
using MyProjectStart.Services;


using Xamarin.Essentials;
using System.Threading.Tasks;

namespace MyProjectStart.ViewsModel
{
    class CategoryViewModel : BaseViewModel
    {
        private string _Color_test;
        public string Color_test
        {
            set
            {
                _Color_test = value;
                OnPropertyChanged();
            }
            get
            {
                return _Color_test;
            }
        }
        private static Cathegory _SelectedCateg;
        public  Cathegory SelectedCateg
        {
            set
            {
                _SelectedCateg = value;
                OnPropertyChanged();
                  
            }
            get
            {
                return _SelectedCateg;

            }
        }
        public ObservableCollection<TestsModel> TestByCathegory { get; set; }
        public ObservableCollection<Results> AlreadyDone { get; set; }

        private int _TotalTest;
        public int TotalTest
        {
            set
            {
                _TotalTest = value;
                OnPropertyChanged();

            }
            get
            {
                return _TotalTest;

            }
        }
        public CategoryViewModel(Cathegory cathegory)
        {
            SelectedCateg = cathegory;
            TestByCathegory = new ObservableCollection<TestsModel>();
            AlreadyDone = new ObservableCollection<Results>();
            int idcat = cathegory.CathegoryId;
            GetTestsItems(SelectedCateg.CathegoryId);
            GetTestsItemsResult(SelectedCateg.CathegoryId);
            Color_test = "Green";
        }

        private async void GetTestsItems(int cathegoryId)
        {
            var data = await new Services.TestItemServices().GetTestByCathegoryAsync(cathegoryId);
            TestByCathegory.Clear();
            foreach(var item in data)
            {
                string login = Preferences.Get("Login", string.Empty);
                ResultsService resultsService = new ResultsService();
                if(await resultsService.IsResultExists(login,item.Name,item.CategoryId) == false)
                {
                    TestByCathegory.Add(item);
                }

            }
            TotalTest = TestByCathegory.Count;
        }
        private async void GetTestsItemsResult(int cathegoryId)
        {
            var data = await new Services.ResultsService().GetTestResultByCathegoryAsync(cathegoryId);
            AlreadyDone.Clear();
            foreach (var item in data)
            {
               
                 AlreadyDone.Add(item);
           
            }
            TotalTest = AlreadyDone.Count;
        }
    }
}
