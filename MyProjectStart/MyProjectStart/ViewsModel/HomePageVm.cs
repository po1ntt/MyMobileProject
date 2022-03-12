using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using MyProjectStart.Views;
using System.Collections.ObjectModel;

using MyProjectStart.Models;

namespace MyProjectStart.ViewsModel
{
    class HomePageVm : BaseViewModel
    {
        public ICommand LogoutCommand { get; private set; }

        private ObservableCollection<TestsData> Tests;
        public ObservableCollection<TestsData> tests
        {
            get { return Tests; }
            set { Tests = value;
                NotifyPropertyChanged(nameof(tests));
            }
        }
        public HomePageVm()
        {
            LogoutCommand = new Command(Logout);
            tests = new ObservableCollection<TestsData>();
            addData();

        }
        private async void Logout()
        {
            await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
        }
        private void addData()
        {
            tests.Add(new TestsData
            {
                id = 1,
                title = "TestExample1",
                language ="с#"
                
                
                        
            });
            tests.Add(new TestsData
            {
                id = 2,
                title = "TestExample2",
                language = "с#"


            });
            tests.Add(new TestsData
            {
                id = 3,
                title = "TestExample3",
                language = "с#"


            });
            tests.Add(new TestsData
            {
                id = 4,
                title = "TestExample4",
                language = "с#"


            });
            tests.Add(new TestsData
            {
                id = 5,
                title = "TestExample5",
                language = "с#"


            });
        }
    }
}
