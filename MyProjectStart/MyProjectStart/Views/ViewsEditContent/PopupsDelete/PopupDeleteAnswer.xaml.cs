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
    public partial class PopupDeleteAnswer : Rg.Plugins.Popup.Pages.PopupPage
    {
        public PopupDeleteAnswer()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            var selectequest = selectedQuestion.SelectedItem as Questions;
            QuestionService questionService = new QuestionService();
            await questionService.DeleteQuest(selectequest.id_quest);
        }

        private void selectedQuestion_SelectedIndexChanged(object sender, EventArgs e)
        {
            DelButton.IsEnabled = true;
            DelButton.BackgroundColor = Color.Yellow;
        }
    }
}