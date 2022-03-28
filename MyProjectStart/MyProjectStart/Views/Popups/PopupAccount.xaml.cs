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
    public partial class PopupAccount : Rg.Plugins.Popup.Pages.PopupPage
    {
        public PopupAccount()
        {
            InitializeComponent();
        }

        private void PopupPage_BackgroundClicked(object sender, EventArgs e)
        {
            Navigation.PopPopupAsync();
        }

        private void OutButton_Clicked(object sender, EventArgs e)
        {
            Preferences.Clear();
            Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
            Shell.Current.Navigation.PopPopupAsync();
        }

        private void ChangePass_Clicked(object sender, EventArgs e)
        {
            Shell.Current.Navigation.PushPopupAsync(new PopupPasswordAccount());
        }
    }
}