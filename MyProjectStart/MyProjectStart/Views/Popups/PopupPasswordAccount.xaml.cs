using MyProjectStart.Services;
using Rg.Plugins.Popup.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyProjectStart.Views.Popups
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PopupPasswordAccount : Rg.Plugins.Popup.Pages.PopupPage
    {
        public PopupPasswordAccount()
        {
            InitializeComponent();
            ChangePas.Border.Color = Color.Gray;
        }

        private void PopupPage_BackgroundClicked(object sender, EventArgs e)
        {
            Navigation.PopPopupAsync();
        }

        private async void OldCheck_Clicked(object sender, EventArgs e)
        {
            string login = Preferences.Get("Login", string.Empty);
            UserServices userServices = new UserServices();
            var user = (await userServices.SelectUsers()).Where(p => p.Login == login).FirstOrDefault();
             if(txbOldPas.Text == user.Password)
            {
                ChangePas.IsEnabled = true;
                ChangePas.Border.Color = Color.Blue;
            }
            else
            {
               await Shell.Current.DisplayAlert("Ошибка", "Неправильный пароль", "ОК");
            }
        }

        private async void SavePass_Clicked(object sender, EventArgs e)
        {
            string login = Preferences.Get("Login", string.Empty);

            UserServices userServices = new UserServices();
            var user = (await userServices.SelectUsers()).Where(p => p.Login == login).FirstOrDefault();
            await userServices.UpdateUser(user.Name, user.RoleId, user.Login, user.BirtDay.ToString(), user.SurName, user.Phone, user.Email, txbPass1.Text);
            await Shell.Current.DisplayAlert("Пароль изменен", "Изменение пароля прошло успешно", "Ок");
            await Shell.Current.Navigation.PopPopupAsync();
        }

        private void txbPass1_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(txbPass1.Text == txbPass2.Text && txbPass1.Text != null && txbPass2.Text != null)
            {
                SaveBtn.IsEnabled = true;
                SaveBtn.BackgroundColor = Color.Yellow;
            }
            else
            {
                SaveBtn.IsEnabled = false;
                SaveBtn.BackgroundColor = Color.Gray;
            }
        }
    }
}