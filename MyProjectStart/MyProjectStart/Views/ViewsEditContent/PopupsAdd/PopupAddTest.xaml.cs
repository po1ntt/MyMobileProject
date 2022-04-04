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
    public partial class PopupAddTest : Rg.Plugins.Popup.Pages.PopupPage
    {
        public PopupAddTest()
        {
            InitializeComponent();
        }

        private async void AddTest_Clicked(object sender, EventArgs e)
        {
            TestItemServices testItemServices = new TestItemServices();
            bool result = await testItemServices.AddTest(TxbNameTest.Text, txbDescription.Text, catpicker.SelectedItem as Cathegory);
            if(result == true)
            {
                await Shell.Current.DisplayAlert("Добавление теста", "Добавление теста прошло успешно", "ОК");
            }
        }

        private void catpicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            AddTest.IsEnabled = true;
            AddTest.BackgroundColor = Color.Yellow;
        }
    }
}