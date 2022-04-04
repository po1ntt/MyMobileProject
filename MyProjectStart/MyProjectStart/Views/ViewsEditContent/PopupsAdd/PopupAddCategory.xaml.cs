using MyProjectStart.Models;
using MyProjectStart.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyProjectStart.Views.ViewsEditContent.PopupsAdd
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PopupAddCategory : Rg.Plugins.Popup.Pages.PopupPage
    {
        public PopupAddCategory()
        {
            InitializeComponent();
        }

        private void temapicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            addButton.IsEnabled = true;
            addButton.BackgroundColor = Color.Yellow;
        }

        private async void addButton_Clicked(object sender, EventArgs e)
        {
            СathegoryServices сathegoryServices = new СathegoryServices();
            bool result = await сathegoryServices.AddCategory(txbNameCat.Text, temapicker.SelectedItem as Tema);
            if(result == true)
            {
                await Shell.Current.DisplayAlert("Добавление категории", "Добавление категории прошло успешно", "Ок");
            }
        }
    }
}