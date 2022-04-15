using MyProjectStart.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyProjectStart.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MyProjectStart.ViewsModel;
using System.Windows.Input;
using MyProjectStart.Services;
using Xamarin.Essentials;
using Rg.Plugins.Popup.Extensions;
using MyProjectStart.Views.Popups;

namespace MyProjectStart.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]

    public partial class TestView : ContentPage
    {
        public TestsModel Test { get; set; }
        public static int lenghtCarousel = 0;
        public static int currentPos = 0;
        public static int posforinte = 1;
        public static double score = 0;
        public static double scorepercent = 0;
        public static string imageMedal = null;
        public List<Questions> questions;
        TestViewModel cvm;

        public TestView(TestsModel tests, Cathegory cathegory)
        {
            cvm = new TestViewModel(tests,cathegory);
            InitializeComponent();
            this.BindingContext = cvm;
            currentPos = 0;
            Test = null;
            Test = tests;
            score = 0;
            FirstAnswer.BorderColor = Color.Blue;
            FirstAnswer.BackgroundColor = Color.Transparent;
            SeconAnswer.BorderColor = Color.Blue;
            SeconAnswer.BackgroundColor = Color.Transparent;
            ThirdAnswer.BorderColor = Color.Blue;
            ThirdAnswer.BackgroundColor = Color.Transparent;
            FourButton.BorderColor = Color.Blue;
            FourButton.BackgroundColor = Color.Transparent;
            questions = TestViewModel.questions;
            lenghtCarousel = cvm.QestionsByTest.Count;
            cvm.CurrentPos = posforinte;
        }

        private void Button_test_clicked(object sender, EventArgs e)
        {
            if(((Button)sender).Text == FirstAnswer.Text)
            {
               
                FirstAnswer.BorderColor = Color.Yellow;
                FirstAnswer.BackgroundColor = Color.Yellow;
                SeconAnswer.BorderColor = Color.Blue;
                SeconAnswer.BackgroundColor = Color.Transparent;
                ThirdAnswer.BorderColor = Color.Blue;
                ThirdAnswer.BackgroundColor = Color.Transparent;
                FourButton.BorderColor = Color.Blue;
                FourButton.BackgroundColor = Color.Transparent;
                NextButton.IsEnabled = true;
                OverButton.IsEnabled = true;
                OverButton.BackgroundColor = Color.Yellow;
                NextButton.BackgroundColor = Color.Yellow;


            }
            else if(((Button)sender).Text == SeconAnswer.Text)
            {
               
                SeconAnswer.BorderColor = Color.Yellow;
                SeconAnswer.BackgroundColor = Color.Yellow;
                ThirdAnswer.BorderColor = Color.Blue;
                ThirdAnswer.BackgroundColor = Color.Transparent;
                FourButton.BorderColor = Color.Blue;
                FourButton.BackgroundColor = Color.Transparent;
                FirstAnswer.BorderColor = Color.Blue;
                FirstAnswer.BackgroundColor = Color.Transparent;
                NextButton.IsEnabled = true;
                OverButton.IsEnabled = true;
                OverButton.BackgroundColor = Color.Yellow;
                NextButton.BackgroundColor = Color.Yellow;

            }
            else if(((Button)sender).Text == ThirdAnswer.Text)
            {
               
                ThirdAnswer.BorderColor = Color.Yellow;
                ThirdAnswer.BackgroundColor = Color.Yellow;
                FourButton.BorderColor = Color.Blue;
                FourButton.BackgroundColor = Color.Transparent;
                FirstAnswer.BorderColor = Color.Blue;
                FirstAnswer.BackgroundColor = Color.Transparent;
                SeconAnswer.BorderColor = Color.Blue;
                SeconAnswer.BackgroundColor = Color.Transparent;
                NextButton.IsEnabled = true;
                OverButton.IsEnabled = true;
                OverButton.BackgroundColor = Color.Yellow;
                NextButton.BackgroundColor = Color.Yellow;
              

            }
            else if(((Button)sender).Text == FourButton.Text)
            {
                
                FourButton.BorderColor = Color.Yellow;
                FourButton.BackgroundColor = Color.Yellow;
                FirstAnswer.BorderColor = Color.Blue;
                FirstAnswer.BackgroundColor = Color.Transparent;
                SeconAnswer.BorderColor = Color.Blue;
                SeconAnswer.BackgroundColor = Color.Transparent;
                ThirdAnswer.BorderColor = Color.Blue;
                ThirdAnswer.BackgroundColor = Color.Transparent;
                NextButton.IsEnabled = true;
                OverButton.IsEnabled = true;
                OverButton.BackgroundColor = Color.Yellow;
                NextButton.BackgroundColor = Color.Yellow;
   
            }
           

        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            lenghtCarousel = cvm.QestionsByTest.Count;
            if (currentPos < lenghtCarousel - 2)
            {
                NextButton.IsEnabled = false;
                NextButton.BackgroundColor = Color.Gray;
                

                if (currentPos < lenghtCarousel - 2)
                {
                    currentPos++;
                }
                if (FirstAnswer.BorderColor == Color.Yellow)
                {
                    var data = cvm.CurrentQuest;
                    if(FirstAnswer.Text == data.quest_rightanswer)
                    {
                        score++;
                    }
                }
                else if(SeconAnswer.BorderColor == Color.Yellow)
                {
                    var data = cvm.CurrentQuest;
                    if (SeconAnswer.Text == data.quest_rightanswer)
                    {
                        score++;
                    }
                }
                else if(ThirdAnswer.BorderColor == Color.Yellow)
                {
                    var data = cvm.CurrentQuest;
                    if (ThirdAnswer.Text == data.quest_rightanswer)
                    {
                        score++;
                    }

                }
                else if(FourButton.BorderColor == Color.Yellow)
                {
                    var data = cvm.CurrentQuest;
                    if (FourButton.Text == data.quest_rightanswer)
                    {
                        score++;
                    }
                }
                cvm.CurrentPos = posforinte + currentPos;
                FirstAnswer.BorderColor = Color.Blue;
                FirstAnswer.BackgroundColor = Color.Transparent;
                SeconAnswer.BorderColor = Color.Blue;
                SeconAnswer.BackgroundColor = Color.Transparent;
                ThirdAnswer.BorderColor = Color.Blue;
                ThirdAnswer.BackgroundColor = Color.Transparent;
                FourButton.BorderColor = Color.Blue;
                FourButton.BackgroundColor = Color.Transparent;
                cvm.GetQuestInfo(Test.TestId);
            }
            else if (lenghtCarousel - 2 == currentPos)
            {
                
                cvm.CurrentPos = posforinte + currentPos + 1;
                if (FirstAnswer.BorderColor == Color.Yellow)
                {
                    var data = cvm.CurrentQuest;
                    if (FirstAnswer.Text == data.quest_rightanswer)
                    {
                        score++;
                    }
                }
                else if (SeconAnswer.BorderColor == Color.Yellow)
                {
                    var data = cvm.CurrentQuest;
                    if (SeconAnswer.Text == data.quest_rightanswer)
                    {
                        score++;
                    }
                }
                else if (ThirdAnswer.BorderColor == Color.Yellow)
                {
                    var data = cvm.CurrentQuest;
                    if (ThirdAnswer.Text == data.quest_rightanswer)
                    {
                        score++;
                    }

                }
                else if (FourButton.BorderColor == Color.Yellow)
                {
                    var data = cvm.CurrentQuest;
                    if (FourButton.Text == data.quest_rightanswer)
                    {
                        score++;
                    }
                }

                NextButton.IsVisible = false;
                NextButton.IsEnabled = false;
                OverButton.IsEnabled = false;
                FirstAnswer.BorderColor = Color.Blue;
                FirstAnswer.BackgroundColor = Color.Transparent;
                SeconAnswer.BorderColor = Color.Blue;
                SeconAnswer.BackgroundColor = Color.Transparent;
                ThirdAnswer.BorderColor = Color.Blue;
                ThirdAnswer.BackgroundColor = Color.Transparent;
                FourButton.BorderColor = Color.Blue;
                FourButton.BackgroundColor = Color.Transparent;
                NextButton.BackgroundColor = Color.Gray;
                OverButton.BackgroundColor = Color.Gray;
                OverButton.IsVisible = true;
                cvm.GetQuestInfo(Test.TestId);
            }
        }

        private async void OverButton_Clicked(object sender, EventArgs e)
        {
            cvm.CurrentPos = posforinte + currentPos + 1;
            if (FirstAnswer.BorderColor == Color.Yellow)
            {
                var data = cvm.CurrentQuest;
                if (FirstAnswer.Text == data.quest_rightanswer)
                {
                    score++;
                }
            }
            else if (SeconAnswer.BorderColor == Color.Yellow)
            {
                var data = cvm.CurrentQuest;
                if (SeconAnswer.Text == data.quest_rightanswer)
                {
                    score++;
                }
            }
            else if (ThirdAnswer.BorderColor == Color.Yellow)
            {
                var data = cvm.CurrentQuest;
                if (ThirdAnswer.Text == data.quest_rightanswer)
                {
                    score++;
                }

            }
            else if (FourButton.BorderColor == Color.Yellow)
            {
                var data = cvm.CurrentQuest;
                if (FourButton.Text == data.quest_rightanswer)
                {
                    score++;
                }
            }
            scorepercent = 0;
            scorepercent = score / cvm.QestionsByTest.Count * 100;
            if (scorepercent > 40 && TestView.scorepercent < 60)
            {
                imageMedal = "https://cdn3.iconfinder.com/data/icons/awards-achievements-2/96/Bronze-8-512.png";
            }
            else if (TestView.scorepercent > 60 && TestView.scorepercent < 85)
            {
                imageMedal = "https://cdn3.iconfinder.com/data/icons/awards-achievements-2/96/Silver-7-512.png";
            }
            else if (TestView.scorepercent >= 85)
            {
                imageMedal = "https://cdn3.iconfinder.com/data/icons/awards-achievements-2/96/Gold-8-512.png";
            }
            else if (TestView.scorepercent <= 40)
            {
                imageMedal = "https://cdn4.iconfinder.com/data/icons/interactions/64/interaction_interact_preferences_preformance_medal_award_reward_bad-512.png";
            }
            var resultservice = new ResultsService();
            var login = Preferences.Get("Login", string.Empty);
            string Login = login;

            bool Result = await resultservice.RegisterResult(cvm.SelectedTest.Name, Login, cvm.SelectedTest.CategoryId, Math.Round(TestView.scorepercent, 1), cvm.SelectedTest.TestId, TestView.imageMedal);
            if (Result)
            {

                await Shell.Current.Navigation.PushPopupAsync(new PopupResult(Math.Round(TestView.scorepercent, 1), TestView.imageMedal));
            }
            else
            {


                if (await resultservice.UpdateResult(cvm.SelectedTest.Name, cvm.SelectedCathegory.CathegoryId, Login, Math.Round(TestView.scorepercent, 1), cvm.SelectedTest.TestId, TestView.imageMedal))
                {
                    await Shell.Current.Navigation.PushPopupAsync(new PopupResult(Math.Round(TestView.scorepercent, 1), TestView.imageMedal));
                }
                else
                {
                    await Shell.Current.DisplayAlert("Тест пройден", "Результат не сохранен, процент правильных ответов не изменился" + "\n" + Math.Round(TestView.scorepercent, 1) + "%", "OK");
                    await Shell.Current.Navigation.PopAsync();
                }

            }
            cvm.CurrentPos = posforinte + currentPos;
            FirstAnswer.BorderColor = Color.Blue;
            FirstAnswer.BackgroundColor = Color.Transparent;
            SeconAnswer.BorderColor = Color.Blue;
            SeconAnswer.BackgroundColor = Color.Transparent;
            ThirdAnswer.BorderColor = Color.Blue;
            ThirdAnswer.BackgroundColor = Color.Transparent;
            FourButton.BorderColor = Color.Blue;
            FourButton.BackgroundColor = Color.Transparent;
            Test = null;
            
        }
    }
}   
        

        
  
