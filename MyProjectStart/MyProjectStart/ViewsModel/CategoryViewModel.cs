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
        private Cathegory _SelectedCateg;
        public Cathegory SelectedCateg
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
        public ObservableCollection<TestsModel> testByCathegory { get; set; }
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
            testByCathegory = new ObservableCollection<TestsModel>();
            getTestsItems(cathegory.CathegoryId);
        }

        private async void getTestsItems(int cathegoryId)
        {
            var data = await new Services.TestItemServices().GetTestByCathegoryAsync(cathegoryId);
            testByCathegory.Clear();
            foreach(var item in data)
            {
                testByCathegory.Add(item);

            }
            TotalTest = testByCathegory.Count;
        }
    }
}
