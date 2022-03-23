using System;
using System.Collections.Generic;
using System.Text;
using MyProjectStart.Views;
using MyProjectStart.ViewsModel;
using Xamarin.Essentials;
using MyProjectStart.Services;
using MyProjectStart.Models;

namespace MyProjectStart.Views.Popups.ViewModelForPopup
{
    class PopupAccountVM : BaseViewModel
    {
        private string _Login;

        public string Login
        {
            get { return _Login; }
            set { _Login = value;
                OnPropertyChanged();
            }
        }
        private string _Name;

        public string Name
        {
            get { return _Name; }
            set { _Name = value;
                OnPropertyChanged();
            }
        }
        private string _SurName;

        public string SurName
        {
            get { return _SurName; }
            set { _SurName = value;
                OnPropertyChanged();
            }
        }
        private string _Email;

        public string Email
        {
            get { return _Email; }
            set { _Email = value;
                OnPropertyChanged();
            }
        }
        private DateTime _BirtDay;

        public DateTime BirtDay
        {
            get { return _BirtDay; }
            set { _BirtDay = value;
                OnPropertyChanged();
            }
        }
        public PopupAccountVM()
        {
            getuserinfo();


        }
        public async void getuserinfo()
        {
            UserServices userServices = new UserServices();
            string login = Preferences.Get("Login", string.Empty);

            var user = (await userServices.SelectUsers()).Find(p => p.Login == login);
            Login = user.Login;
            Email = user.Email;
        }



    }
}
