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
            GetTestsItems(cathegory.CathegoryId);
            Color_test = "Green";
        }

        private async void GetTestsItems(int cathegoryId)
        {
            var data = await new Services.TestItemServices().GetTestByCathegoryAsync(cathegoryId);
            TestByCathegory.Clear();
            foreach(var item in data)
            {
                TestByCathegory.Add(item);

            }
            TotalTest = TestByCathegory.Count;
        }
    }
}
