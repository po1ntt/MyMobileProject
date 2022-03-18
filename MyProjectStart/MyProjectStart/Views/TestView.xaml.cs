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
            Test = tests;
            score = 0;
            FirstAnswer.BackgroundColor = Color.White;
            SeconAnswer.BackgroundColor = Color.White;
            ThirdAnswer.BackgroundColor = Color.White;
            FourButton.BackgroundColor = Color.White;
            questions = TestViewModel.questions;
            lenghtCarousel = cvm.QestionsByTest.Count;
            cvm.CurrentPos = posforinte;
        }

        private void Button_test_clicked(object sender, EventArgs e)
        {
            if(((Button)sender).Text == FirstAnswer.Text)
            {
               
                FirstAnswer.BackgroundColor = Color.Yellow;
                SeconAnswer.BackgroundColor = Color.White;
                ThirdAnswer.BackgroundColor = Color.White;
                FourButton.BackgroundColor = Color.White;
                NextButton.IsEnabled = true;
                OverButton.IsEnabled = true;
                OverButton.BackgroundColor = Color.Yellow;
                NextButton.BackgroundColor = Color.Yellow;


            }
            else if(((Button)sender).Text == SeconAnswer.Text)
            {
               
                SeconAnswer.BackgroundColor = Color.Yellow;
                ThirdAnswer.BackgroundColor = Color.White;
                FourButton.BackgroundColor = Color.White;
                FirstAnswer.BackgroundColor = Color.White;
                NextButton.IsEnabled = true;
                OverButton.IsEnabled = true;
                OverButton.BackgroundColor = Color.Yellow;
                NextButton.BackgroundColor = Color.Yellow;

            }
            else if(((Button)sender).Text == ThirdAnswer.Text)
            {
               
                ThirdAnswer.BackgroundColor = Color.Yellow;
                FourButton.BackgroundColor = Color.White;
                FirstAnswer.BackgroundColor = Color.White;
                SeconAnswer.BackgroundColor = Color.White;
                NextButton.IsEnabled = true;
                OverButton.IsEnabled = true;
                OverButton.BackgroundColor = Color.Yellow;
                NextButton.BackgroundColor = Color.Yellow;
              

            }
            else if(((Button)sender).Text == FourButton.Text)
            {
                
                FourButton.BackgroundColor = Color.Yellow;
                FirstAnswer.BackgroundColor = Color.White;
                SeconAnswer.BackgroundColor = Color.White;
                ThirdAnswer.BackgroundColor = Color.White;
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
                if (FirstAnswer.BackgroundColor == Color.Yellow)
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
                else if(SeconAnswer.BackgroundColor == Color.Yellow)
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
                else if(ThirdAnswer.BackgroundColor == Color.Yellow)
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
                else if(FourButton.BackgroundColor == Color.Yellow)
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
                FirstAnswer.BackgroundColor = Color.White;
                SeconAnswer.BackgroundColor = Color.White;
                ThirdAnswer.BackgroundColor = Color.White;
                FourButton.BackgroundColor = Color.White;
            }
            else if (lenghtCarousel - 2 == currentPos)
            {
                cvm.GetQuestInfo(Test.TestId);
                cvm.CurrentPos = posforinte + currentPos + 1;
                if (FirstAnswer.BackgroundColor == Color.Yellow)
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
                else if (SeconAnswer.BackgroundColor == Color.Yellow)
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
                else if (ThirdAnswer.BackgroundColor == Color.Yellow)
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
                else if (FourButton.BackgroundColor == Color.Yellow)
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
                FirstAnswer.BackgroundColor = Color.White;
                SeconAnswer.BackgroundColor = Color.White;
                ThirdAnswer.BackgroundColor = Color.White;
                FourButton.BackgroundColor = Color.White;
                NextButton.BackgroundColor = Color.Gray;
                OverButton.BackgroundColor = Color.Gray;
                OverButton.IsVisible = true;

            }
        }

        private void OverButton_Clicked(object sender, EventArgs e)
        {
            cvm.CurrentPos = posforinte + currentPos + 1;
            if (FirstAnswer.BackgroundColor == Color.Yellow)
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
            else if (SeconAnswer.BackgroundColor == Color.Yellow)
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
            else if (ThirdAnswer.BackgroundColor == Color.Yellow)
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
            else if (FourButton.BackgroundColor == Color.Yellow)
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
            FirstAnswer.BackgroundColor = Color.White;
            SeconAnswer.BackgroundColor = Color.White;
            ThirdAnswer.BackgroundColor = Color.White;
            FourButton.BackgroundColor = Color.White;
        }
    }
}   
        

        
  
