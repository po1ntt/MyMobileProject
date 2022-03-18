using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MyProjectStart.Views;
using MyProjectStart.Models;
using Xamarin.Essentials;

namespace MyProjectStart
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            if (Preferences.ContainsKey("Login"))
            {
                MainPage = new AshellWithLogin();
            }
            else
            {
                MainPage = new AShell();
            }
        }
       
        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
