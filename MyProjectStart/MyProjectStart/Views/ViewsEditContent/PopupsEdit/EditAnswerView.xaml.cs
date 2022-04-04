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
    public partial class EditAnswerView : ContentPage
    {
        public EditAnswerView()
        {
            InitializeComponent();
        }
        private void Picker_SelectedIndexChanged(object sender, EventArgs e)
        {
            var quest = ((Picker)sender).SelectedItem as Questions;
            txbTextQuest.Text = quest.TextQuest;
            txbFirstAnswer.Text = quest.quest_answer1;
            txbSecondAnswer.Text = quest.quest_answer2;
            txbThirdAnswer.Text = quest.quest_answer3;
            txbFourAnswer.Text = quest.quest_answer4;
            if (quest.quest_rightanswer == quest.quest_answer1)
            {
                NumberRightAnswer.Text = "1";
            }
            else if (quest.quest_rightanswer == quest.quest_answer2)
            {
                NumberRightAnswer.Text = "2";
            }
            else if (quest.quest_rightanswer == quest.quest_answer3)
            {
                NumberRightAnswer.Text = "3";
            }
            else if (quest.quest_rightanswer == quest.quest_answer4)
            {
                NumberRightAnswer.Text = "4";
            }
            SaveButton.IsEnabled = true;
            SaveButton.BackgroundColor = Color.Yellow;

        }

       private async void Edit_Clicked(object sender, EventArgs e)
        {
            EditingPopupsVM editing = new EditingPopupsVM();
            string rightanswer;
            var quest = questpicker.SelectedItem as Questions;
            var selectedtest =testpicker.SelectedItem as TestsModel;
            if (NumberRightAnswer.Text == "1")
            {
                rightanswer = txbFirstAnswer.Text;
            }
            else if (NumberRightAnswer.Text == "2")
            {
                rightanswer = txbSecondAnswer.Text;
            }
            else if (NumberRightAnswer.Text == "3")
            {
                rightanswer = txbThirdAnswer.Text;
            }
            else
            {
                rightanswer = txbFourAnswer.Text;
            }
            QuestionService question = new QuestionService();
            bool result = await question.UpdateQuestions(quest.id_quest, txbTextQuest.Text, txbFirstAnswer.Text, txbSecondAnswer.Text, txbThirdAnswer.Text, txbFourAnswer.Text, rightanswer, selectedtest);
            if(result == true)
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