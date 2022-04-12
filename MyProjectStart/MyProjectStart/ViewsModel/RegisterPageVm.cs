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
        private string _Phone;

        public string Phone
        {
            get { return _Phone; }
            set { _Phone = value;
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

        public string Surname
        {
            get { return _SurName; }
            set { _SurName = value;
                OnPropertyChanged();
            }
        }
        private string _Password2;

        public string Password2
        {
            get { return _Password2; }
            set { _Password2 = value; }
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
                if (Login != null && Password != null && Email != null && Name != null && Surname != null && Phone != null)
                {
                    
                    if(Password != Password2)
                    {
                        await Shell.Current.DisplayAlert("Ошибка", "Пароли не совпадают", "Ок");

                    }
                    else
                    {
                        bool result = await userServices.RegisterUser(Login, Password, Email, Name, Surname, Phone);
                        if(result == true)
                        {
                            await Shell.Current.DisplayAlert("Регистрация", "Регистрация прошла успешно", "Ок");
                            await Shell.Current.Navigation.PopAsync();
                        }
                        else
                        {
                            await Shell.Current.DisplayAlert("Ошибка", "Пользователь с таким логином уже существует", "Ок");
                        }
                       
                    }
                }
                else
                {
                    await Shell.Current.DisplayAlert("Ошибка", "Проверьте ввод данных.", "Ок");
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
