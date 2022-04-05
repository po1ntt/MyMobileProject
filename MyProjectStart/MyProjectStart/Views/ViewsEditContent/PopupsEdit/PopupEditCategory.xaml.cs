using MyProjectStart.Models;
using MyProjectStart.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyProjectStart.Views.ViewsEditContent.PopupsEdit
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PopupEditCategory : Rg.Plugins.Popup.Pages.PopupPage
    {
        public PopupEditCategory()
        {
            InitializeComponent();
        }

        private void catpicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            SaveButton.IsEnabled = true;
            SaveButton.BackgroundColor = Color.Yellow;
        }

        private async void SaveButton_Clicked(object sender, EventArgs e)
        {
            СathegoryServices сathegory = new СathegoryServices();
            var selcat = catpicker.SelectedItem as Cathegory;
            bool result = await сathegory.UpdateCathegory(txbNameCat.Text, selcat.CathegoryId);
            if (result == true)
            {
                await Shell.Current.DisplayAlert("Изменение", "Изменение прошло успешно", "ОК");

            }
            else
            {
                await Shell.Current.DisplayAlert("Изменение", "Ошибка", "ОК");

            }
        }
    }
}