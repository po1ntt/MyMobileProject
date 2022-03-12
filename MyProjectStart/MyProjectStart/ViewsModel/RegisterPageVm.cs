using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using MyProjectStart.Views;
using System.Threading.Tasks;
using MyProjectStart.Services;
using Xamarin.Essentials;

namespace MyProjectStart.ViewsModel
{
    class RegisterPageVm : BaseViewModel
    {
        private string _Login;
        public string Login
        {
            get
            {
                return this._Login;
            }
            set
            {
                this._Login = value;
                NotifyPropertyChanged(nameof(_Login));
            }
        }
        private string _Password;
        public string Password
        {
            get
            {
                return this._Password;
            }
            set
            {
                this._Password = value;
                NotifyPropertyChanged(nameof(_Password));
            }
        }
        private bool _Isbusy;
        public bool Isbusy
        {
            get
            {
                return this._Isbusy;
            }
            set
            {
                this._Isbusy = value;
                NotifyPropertyChanged(nameof(_Isbusy));
            }
        }
        private bool _Result;
        public bool Result

         
        {
            get
            {
                return this._Result;
            }
            set
            {
                this._Result = value;
                NotifyPropertyChanged(nameof(_Result));
            }
        }
        private string _Email;
        public string Email
        {
            get
            {
                return this._Email;
            }
            set
            {
                this._Email = value;
                NotifyPropertyChanged(nameof(_Email));
            }
        }

        public Command RegCommand { get; private set; }
        public RegisterPageVm()
        {
            RegCommand = new Command(async () => await RegCommandAsync());
        }

        private async Task RegCommandAsync()
        {
            if (Isbusy)
                return;
            try
            {
                Isbusy = true;
                var userServices = new UserServices();
                Result = await userServices.RegisterUser(Login, Password, Email);
                if (Result)
                {
                    await Shell.Current.DisplayAlert("Успешно", "Пользователь создан!", "OK");
                    await Shell.Current.GoToAsync("..");
                }
                else
                {
                    await Shell.Current.DisplayAlert("Ошибка", "Пользователь уже существует", "OK");
                }
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Error", ex.Message, "Ok");
            }
            finally
            {
                Isbusy = false;
            }
        }
    }
}
