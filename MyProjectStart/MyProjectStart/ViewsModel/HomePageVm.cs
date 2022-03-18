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
    class HomePageVm : BaseViewModel
    {
        private string _Login;
        public string Login
        {
            set
            {
                _Login = value;
                OnPropertyChanged();
            }
            get
            {
                return _Login;
            }
        }

        public ObservableCollection<Cathegory> Cathegories { get; set; }
        public ObservableCollection<TestsModel> LatestItems { get; set; }

        public ICommand LogoutCommand { get; private set; }

    
        public HomePageVm()
        {
            var login = Preferences.Get("Login", string.Empty);
            if (string.IsNullOrEmpty(login))
                Login = "Гость";
            else
                Login = login;
            Cathegories = new ObservableCollection<Cathegory>();
            LatestItems = new ObservableCollection<TestsModel>();
            GetCategories();
            GetLatestItems();
        }

        private async void GetLatestItems()
        {
            var data = await new Services.TestItemServices().GetLatestTestsAsunc();
            LatestItems.Clear();
            foreach(var item in data)
            {
                LatestItems.Add(item);
            }
        }

        private async void GetCategories()
        {
            var data = await new Services.СathegoryServices().GetCathegoryAsync();
            Cathegories.Clear();
            foreach (var item in data)
            {
                Cathegories.Add(item);
            }
        }


       
        
    }
}
