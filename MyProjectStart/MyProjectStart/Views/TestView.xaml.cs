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


namespace MyProjectStart.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
   
    public partial class TestView : ContentPage
    {

        public static int lenghtCarousel = 0;
        public static int currentPos = 0;
        TestViewModel cvm;

        public TestView(TestsModel tests)
        {
            cvm = new TestViewModel(tests);
            InitializeComponent();
            this.BindingContext = cvm;
            currentPos = 0;
  
        }

        private void Button_test_clicked(object sender, EventArgs e)
        {
            string textanswer = ((Button)sender).Text;
            var data = cvm.QestionsByTest.ToList();
            lenghtCarousel = cvm.QestionsByTest.Count;
            foreach (var item in data)
            {
                if(textanswer == item.quest_rightanswer)
                {
                    ((Button)sender).BackgroundColor = Color.Green;
                    NextButton.IsEnabled = true;
                    NextButton.BackgroundColor = Color.Yellow;
                    if(currentPos < lenghtCarousel-1)
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

        private void Button_Clicked(object sender, EventArgs e)
        {
            if (currentPos < lenghtCarousel-1)
            {
                Carousel.Position = currentPos;
                NextButton.IsEnabled = false;
                NextButton.BackgroundColor = Color.Gray;
            }
            else if (lenghtCarousel-1 == currentPos)
            {
               if(NextButton.Text == "Завершить тест")
                {
                    Shell.Current.DisplayAlert("Тест успешно завершен", "text-example", "OK");
                }
                    
                Carousel.Position = currentPos;
                NextButton.Text = "Завершить тест";
                NextButton.IsEnabled = false;
                NextButton.BackgroundColor = Color.Gray;
            }
            
            
        }

        
    }
}