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
    class LoginPageVm : BaseViewModel
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
                OnPropertyChanged();
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
                OnPropertyChanged();
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
                OnPropertyChanged();
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
                OnPropertyChanged();
            }
        }

        private  bool _IsVisible;

        public  bool IsVisible
        {
            get { return _IsVisible; }
            set {
                _IsVisible = value;
                OnPropertyChanged();
            }
        }

        public Command LoginCommand { get; private set; }
        
        public Command GoToRegistration { get; private set; }
        public LoginPageVm()
        {
            LoginCommand = new Command(async () => await LoginCommandAsync());

            GoToRegistration = new Command(async () => await GoToRegistrationAsync());
            IsVisible = false;
        }

        private async Task GoToRegistrationAsync()
        {

            if (Isbusy)
                return;
            try
            {
                Isbusy = true;
                await Shell.Current.Navigation.PushModalAsync(new RegistrationPage());
            }
            catch(Exception ex)
            {
                await Shell.Current.DisplayAlert("Error", ex.Message, "Ok");
            }
            finally
            {
                Isbusy = false;
            }
        }

        private async Task LoginCommandAsync()
        {
            if (Isbusy)
                return;
            try
            {
                Isbusy = true;
                IsVisible = true;
                LoginPage loginPage = new LoginPage();
               
                var userservices = new UserServices();
                Result = await userservices.LoginUser(Login, Password);
                if(Result)
                {
                    Preferences.Set("Login", Login);
                    await Shell.Current.GoToAsync($"//{nameof(HomePage)}");
                    IsVisible = false;
                }
                else
                {
                    await Shell.Current.DisplayAlert("Error", "Invalid Login or Password", "OK");
                    IsVisible = false;
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
