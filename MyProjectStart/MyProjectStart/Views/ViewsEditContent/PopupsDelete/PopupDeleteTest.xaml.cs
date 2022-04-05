using MyProjectStart.Models;
using MyProjectStart.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyProjectStart.Views.ViewsEditContent.PopupsDelete
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PopupDeleteTest : Rg.Plugins.Popup.Pages.PopupPage
    {
        public PopupDeleteTest()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            var selectedtest = SelectedTest.SelectedItem as TestsModel;
             TestItemServices testService = new TestItemServices();
            await testService.DeleteTest(selectedtest.TestId);
        }
    }
}