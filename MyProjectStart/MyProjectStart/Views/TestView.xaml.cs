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
using System.Collections.Generic;
using MyProjectStart.Services;
using Xamarin.Essentials;

namespace MyProjectStart.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]

    public partial class TestView : ContentPage
    {
        public TestsModel test { get; set; }
        public static int lenghtCarousel = 0;
        public static int currentPos = 0;
        TestViewModel cvm;

        public TestView(TestsModel tests)
        {
            cvm = new TestViewModel(tests);
            InitializeComponent();
            this.BindingContext = cvm;
            currentPos = 0;
            test = tests;

        }

        private void Button_test_clicked(object sender, EventArgs e)
        {
            string textanswer = ((Button)sender).Text;
            var data = cvm.QestionsByTest.ToList();
            lenghtCarousel = cvm.QestionsByTest.Count;
            foreach (var item in data)
            {
                if (textanswer == item.quest_rightanswer)
                {
                    ((Button)sender).BackgroundColor = Color.Green;
                    NextButton.IsEnabled = true;
                    OverButton.IsEnabled = true;
                    OverButton.BackgroundColor = Color.Yellow;
                    NextButton.BackgroundColor = Color.Yellow;
                    if (currentPos < lenghtCarousel - 1)
                    {
                        currentPos = currentPos + 1;
                    }
                    break;
                }
                else
                {
                    ((Button)sender).BackgroundColor = Color.Red;

                }

            }

        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            if (currentPos < lenghtCarousel - 1)
            {
                NextButton.IsEnabled = false;
                NextButton.BackgroundColor = Color.Gray;
                cvm.GetQuestInfo(test.TestId);
                FirstAnswer.BackgroundColor = Color.White;
                SeconAnswer.BackgroundColor = Color.White;
                ThirdAnswer.BackgroundColor = Color.White;
                FourButton.BackgroundColor = Color.White;
            }
            else if (lenghtCarousel - 1 == currentPos)
            {
                NextButton.IsVisible = false;
                NextButton.IsEnabled = false;
                cvm.GetQuestInfo(test.TestId);
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
    }
}   
        

        
  
