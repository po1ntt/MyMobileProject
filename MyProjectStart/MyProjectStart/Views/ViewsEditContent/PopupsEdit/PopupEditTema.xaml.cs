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
    public partial class PopupEditTema : Rg.Plugins.Popup.Pages.PopupPage
    {
        public PopupEditTema()
        {
            InitializeComponent();
        }

        private void temapicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            SaveButton.IsEnabled = true;
            SaveButton.BackgroundColor = Color.Yellow;
        }

        private  async void SaveButton_Clicked(object sender, EventArgs e)
        {
            TemaServices temaServices = new TemaServices();
            var seltema = temapicker.SelectedItem as Tema;
            bool result = await temaServices.UpdateTema(txbNameTema.Text,seltema.TemaID);
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