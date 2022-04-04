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
    public partial class AddAnswersForTest : ContentPage
    {
        public AddAnswersForTest()
        {
            InitializeComponent();
        }

        private void testpicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            SaveButton.IsEnabled = true;
            SaveButton.BackgroundColor = Color.Yellow;
        }

        private async void SaveButton_Clicked(object sender, EventArgs e)
        {
            string rightanswer;
            QuestionService question = new QuestionService();
            if (NumberRightQuest.Text == "1")
            {
                rightanswer = txbFirstQuest.Text;
            }
            else if (NumberRightQuest.Text == "2")
            {
                rightanswer = txbSecondQuest.Text;
            }
            else if (NumberRightQuest.Text == "3")
            {
                rightanswer = txbThirdQuest.Text;
            }
            else
            {
                rightanswer = txbFourQuest.Text;
            }
           bool result =  await question.AddQuest(txbTextQuest.Text, txbFirstQuest.Text, txbSecondQuest.Text, txbThirdQuest.Text, txbFourQuest.Text, rightanswer, testpicker.SelectedItem as TestsModel);
            if(result == true)
            {
                await Shell.Current.DisplayAlert("Добавление", "успешно добален новый вопрос", "ок");

            }
        }
    }
}