using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MyProjectStart.Services;
using MyProjectStart.Models;

namespace MyProjectStart.Views.ViewsEditContent.PopupsEdit
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PopupEditTest : Rg.Plugins.Popup.Pages.PopupPage
    {
        public PopupEditTest()
        {
            InitializeComponent();
        }

        private void TestPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            SaveButton.IsEnabled = true;
            SaveButton.BackgroundColor = Color.Yellow;
        }

        private async void SaveButton_Clicked(object sender, EventArgs e)
        {
            TestItemServices test = new TestItemServices();
            var seltest = TestPicker.SelectedItem as TestsModel;
            bool result = await test.UpdateTest(txbNameTest.Text, txbDescr.Text, seltest.TestId);
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