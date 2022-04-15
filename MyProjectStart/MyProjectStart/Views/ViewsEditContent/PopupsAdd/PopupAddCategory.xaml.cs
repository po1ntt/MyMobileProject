using MyProjectStart.Models;
using MyProjectStart.Services;
using MyProjectStart.ViewsModel;
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

     

        private async void addButton_Clicked(object sender, EventArgs e)
        {
            СathegoryServices сathegoryServices = new СathegoryServices();
            bool result = await сathegoryServices.AddCategory(txbNameCat.Text);
            if(result == true)
            {
               
                await Shell.Current.DisplayAlert("Добавление категории", "Добавление категории прошло успешно", "Ок");
              
            }
        }

        private void txbNameCat_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(txbNameCat.Text != null)
            {
                addButton.IsEnabled = true;
                addButton.BackgroundColor = Color.Yellow;

            }
            else
            {
                addButton.IsEnabled = false;
                addButton.BackgroundColor = Color.Gray;
            }
        }
    }
}