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
            SeconAnswer.BorderColor = Color.Blue;
            ThirdAnswer.BorderColor = Color.Blue;
            FourButton.BorderColor = Color.Blue;
            questions = TestViewModel.questions;
            lenghtCarousel = cvm.QestionsByTest.Count;
            cvm.CurrentPos = posforinte;
        }

        private void Button_test_clicked(object sender, EventArgs e)
        {
            if(((Button)sender).Text == FirstAnswer.Text)
            {
               
                FirstAnswer.BorderColor = Color.Yellow;
                SeconAnswer.BorderColor = Color.Blue;
                ThirdAnswer.BorderColor = Color.Blue;
                FourButton.BorderColor = Color.Blue;
                NextButton.IsEnabled = true;
                OverButton.IsEnabled = true;
                OverButton.BackgroundColor = Color.Yellow;
                NextButton.BackgroundColor = Color.Yellow;


            }
            else if(((Button)sender).Text == SeconAnswer.Text)
            {
               
                SeconAnswer.BorderColor = Color.Yellow;
                ThirdAnswer.BorderColor = Color.Blue;
                FourButton.BorderColor = Color.Blue;
                FirstAnswer.BorderColor = Color.Blue;
                NextButton.IsEnabled = true;
                OverButton.IsEnabled = true;
                OverButton.BackgroundColor = Color.Yellow;
                NextButton.BackgroundColor = Color.Yellow;

            }
            else if(((Button)sender).Text == ThirdAnswer.Text)
            {
               
                ThirdAnswer.BorderColor = Color.Yellow;
                FourButton.BorderColor = Color.Blue;
                FirstAnswer.BorderColor = Color.Blue;
                SeconAnswer.BorderColor = Color.Blue;
                NextButton.IsEnabled = true;
                OverButton.IsEnabled = true;
                OverButton.BackgroundColor = Color.Yellow;
                NextButton.BackgroundColor = Color.Yellow;
              

            }
            else if(((Button)sender).Text == FourButton.Text)
            {
                
                FourButton.BackgroundColor = Color.Yellow;
                FirstAnswer.BorderColor = Color.Blue;
                SeconAnswer.BorderColor = Color.Blue;
                ThirdAnswer.BorderColor = Color.Blue;
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
                cvm.GetQuestInfo(Test.TestId);

                if (currentPos < lenghtCarousel - 2)
                {
                    currentPos++;
                }
                if (FirstAnswer.BorderColor == Color.Yellow)
                {
                    var data = cvm.QestionsByTest.ToList();
                    foreach (var item in data)
                    {
                        if (item.quest_rightanswer == FirstAnswer.Text)
                        {
                            score++;
                            break;
                        }
                    }
                }
                else if(SeconAnswer.BorderColor == Color.Yellow)
                {
                    var data = cvm.QestionsByTest.ToList();
                    foreach (var item in data)
                    {
                        if (item.quest_rightanswer == SeconAnswer.Text)
                        {
                            score++;
                            break;
                        }
                    }
                }
                else if(ThirdAnswer.BorderColor == Color.Yellow)
                {
                    var data = cvm.QestionsByTest.ToList();
                    foreach (var item in data)
                    {
                        if (item.quest_rightanswer == ThirdAnswer.Text)
                        {
                            score++;
                            break;
                        }
                    }

                }
                else if(FourButton.BorderColor == Color.Yellow)
                {
                    var data = cvm.QestionsByTest.ToList();
                    foreach (var item in data)
                    {
                        if (item.quest_rightanswer == FourButton.Text)
                        {
                            score++;
                            break;
                        }
                    }
                }
                cvm.CurrentPos = posforinte + currentPos;
                FirstAnswer.BorderColor = Color.Blue;
                SeconAnswer.BorderColor = Color.Blue;
                ThirdAnswer.BorderColor = Color.Blue;
                FourButton.BorderColor = Color.Blue;
            }
            else if (lenghtCarousel - 2 == currentPos)
            {
                cvm.GetQuestInfo(Test.TestId);
                cvm.CurrentPos = posforinte + currentPos + 1;
                if (FirstAnswer.BorderColor == Color.Yellow)
                {
                    var data = cvm.QestionsByTest.ToList();
                    foreach (var item in data)
                    {
                        if (item.quest_rightanswer == FirstAnswer.Text)
                        {
                            score++;
                            break;
                        }
                    }
                }
                else if (SeconAnswer.BorderColor == Color.Yellow)
                {
                    var data = cvm.QestionsByTest.ToList();
                    foreach (var item in data)
                    {
                        if (item.quest_rightanswer == SeconAnswer.Text)
                        {
                            score++;
                            break;
                        }
                    }
                }
                else if (ThirdAnswer.BorderColor == Color.Yellow)
                {
                    var data = cvm.QestionsByTest.ToList();
                    foreach (var item in data)
                    {
                        if (item.quest_rightanswer == ThirdAnswer.Text)
                        {
                            score++;
                            break;
                        }
                    }

                }
                else if (FourButton.BorderColor == Color.Yellow)
                {
                    var data = cvm.QestionsByTest.ToList();
                    foreach (var item in data)
                    {
                        if (item.quest_rightanswer == FourButton.Text)
                        {
                            score++;
                            break;
                        }
                    }
                }
                
                NextButton.IsVisible = false;
                NextButton.IsEnabled = false;
                OverButton.IsEnabled = false;
                FirstAnswer.BorderColor = Color.Blue;
                SeconAnswer.BorderColor = Color.Blue;
                ThirdAnswer.BorderColor = Color.Blue;
                FourButton.BorderColor = Color.Blue;
                NextButton.BackgroundColor = Color.Gray;
                OverButton.BackgroundColor = Color.Gray;
                OverButton.IsVisible = true;

            }
        }

        private void OverButton_Clicked(object sender, EventArgs e)
        {
            cvm.CurrentPos = posforinte + currentPos + 1;
            if (FirstAnswer.BorderColor == Color.Yellow)
            {
                var data = cvm.QestionsByTest.ToList();
                foreach (var item in data)
                {
                    if (item.quest_rightanswer == FirstAnswer.Text)
                    {
                        score++;
                        break;
                    }
                }
            }
            else if (SeconAnswer.BorderColor == Color.Yellow)
            {
                var data = cvm.QestionsByTest.ToList();
                foreach (var item in data)
                {
                    if (item.quest_rightanswer == SeconAnswer.Text)
                    {
                        score++;
                        break;
                    }
                }
            }
            else if (ThirdAnswer.BorderColor == Color.Yellow)
            {
                var data = cvm.QestionsByTest.ToList();
                foreach (var item in data)
                {
                    if (item.quest_rightanswer == ThirdAnswer.Text)
                    {
                        score++;
                        break;
                    }
                }

            }
            else if (FourButton.BorderColor == Color.Yellow)
            {
                var data = cvm.QestionsByTest.ToList();
                foreach (var item in data)
                {
                    if (item.quest_rightanswer == FourButton.Text)
                    {
                        score++;
                        break;
                    }
                }
            }
            scorepercent = 0;
            scorepercent = score / cvm.QestionsByTest.Count * 100;
            cvm.CurrentPos = posforinte + currentPos;
            FirstAnswer.BorderColor = Color.Blue;
            SeconAnswer.BorderColor = Color.Blue;
            ThirdAnswer.BorderColor = Color.Blue;
            FourButton.BorderColor = Color.Blue;
            Test = null;
        }
    }
}   
        

        
  
