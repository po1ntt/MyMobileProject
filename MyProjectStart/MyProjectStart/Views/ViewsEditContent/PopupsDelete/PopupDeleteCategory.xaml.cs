using MyProjectStart.Models;
using MyProjectStart.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MyProjectStart.Services;

namespace MyProjectStart.Views.ViewsEditContent.PopupsDelete
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PopupDeleteCategory : Rg.Plugins.Popup.Pages.PopupPage
    {
        public PopupDeleteCategory()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            var selectequest = SelectedCat.SelectedItem as Cathegory;
            СathegoryServices сathegoryService = new СathegoryServices();
            await сathegoryService.DeleteCathegory(selectequest.CathegoryId);
            await Shell.Current.DisplayAlert("Удаление", "Категория успешно удалена", "Ок");
            EditingPopupsVM editing = new EditingPopupsVM();
            editing.GetCategories();
            SelectedCat.ItemsSource = null;
            SelectedCat.ItemsSource = editing.CathegoriesList;
        }

        private void SelectedCat_SelectedIndexChanged(object sender, EventArgs e)
        {
            DelButton.IsEnabled = true;
            DelButton.BackgroundColor = Color.Yellow;
        }
    }
}