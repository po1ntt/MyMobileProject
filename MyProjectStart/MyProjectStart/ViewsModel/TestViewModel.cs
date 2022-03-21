using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using MyProjectStart.Views;
using System.Collections.ObjectModel;

using MyProjectStart.Models;
using MyProjectStart.Services;
using System.Threading.Tasks;
using Xamarin.Essentials;
using System.Linq;

namespace MyProjectStart.ViewsModel
{
    internal class TestViewModel : BaseViewModel
    {
        public int numberForCollection = 0;
        private  int _CurrentPos;
        public int CurrentPos
        {
            get
            {
                return this._CurrentPos;
            }
            set
            {
                this._CurrentPos = value;
                OnPropertyChanged();
            }
        }
        private string _Login;
        public string Login
        {
            get
            {
                return this._Login;
            }
            set
            {
                this._Login = value;
                NotifyPropertyChanged(nameof(_Login));
            }
        }
        private bool _Isbusy;
        public bool Isbusy
        {
            get
            {
                return this._Isbusy;
            }
            set
            {
                this._Isbusy = value;
                NotifyPropertyChanged(nameof(_Isbusy));
            }
        }
        private bool _Result;
        public bool Result


        {
            get
            {
                return this._Result;
            }
            set
            {
                this._Result = value;
                NotifyPropertyChanged(nameof(_Result));
            }
        }
        private string _question;
        public string Question
        {
            set
            {
                _question = value;
                OnPropertyChanged();
            }
            get
            {
                return _question;
            }
        }
        private string _answer1;
        public string Answer1
        {
            set
            {
                _answer1 = value;
                OnPropertyChanged();
            }
            get
            {
                return _answer1;
            }
        }
        private string _answer2;
        public string Answer2
        {
            set
            {
                _answer2 = value;
                OnPropertyChanged();
            }
            get
            {
                return _answer2;
            }
        }
        private string _answer3;
        public string Answer3
        {
            set
            {
                _answer3 = value;
                OnPropertyChanged();
            }
            get
            {
                return _answer3;
            }
        }
        private string _answer4;
        public string Answer4
        {
            set
            {
                _answer4 = value;
                OnPropertyChanged();
            }
            get
            {
                return _answer4;
            }
        }
        private string _answerright;
        public string AnswerRight
        {
            set
            {
                _answerright = value;
                OnPropertyChanged();
            }
            get
            {
                return _answerright;
            }
        }
        private TestsModel _SelectedTest;
        public TestsModel SelectedTest
        {
            set
            {
                _SelectedTest = value;
                OnPropertyChanged();

            }
            get
            {
                return _SelectedTest;

            }
        }

        private Questions _CurrentQuest;
        public Questions CurrentQuest
        {
            get
            {
                return _CurrentQuest;
            }
            set
            {     
                _CurrentQuest = value;
                OnPropertyChanged();
            }
        }
        public ObservableCollection<Questions> QestionsByTest { get; set; }

        private int _currentQuestionIndex = -1;
    
        public Questions NextQuest()
        {
            _currentQuestionIndex++;
            CurrentQuest = QestionsByTest[_currentQuestionIndex];
            return CurrentQuest;
        }
        public bool isLastQuest()
        {
            return _currentQuestionIndex == QestionsByTest.Count - 1;
        }
        public void Reset()
        {
            _currentQuestionIndex = -1;
        }
        private Cathegory _SelectedCathegory;
        public Cathegory SelectedCathegory
        {
            set
            {
                _SelectedCathegory = value;
                OnPropertyChanged();

            }
            get
            {
                return _SelectedCathegory;

            }
        }
        public Command RegisterResultCommand { get; private set; }
        public TestViewModel(TestsModel tests,Cathegory cathegory)
        {
            questions = null;
            SelectedTest = tests;
            SelectedCathegory = cathegory;
            QestionsByTest = new ObservableCollection<Questions>();
            GetQuestionsBuTest(tests.TestId);
            GetQuestInfo(tests.TestId);
           
            RegisterResultCommand = new Command(async () => await RegisterResultCommandasync());
        }

        

        private async Task RegisterResultCommandasync()
        {
            if (Isbusy)
                return;
            try
            {
                Isbusy = true;
                var resultservice = new ResultsService();
                var login = Preferences.Get("Login", string.Empty);
                string Login = login;
                
                Result = await resultservice.RegisterResult(SelectedTest.Name, Login, SelectedTest.CategoryId,TestView.scorepercent,SelectedTest.TestId);
                if (Result)
                {
                    
                    await Shell.Current.DisplayAlert("Тест пройден", "Новый результат сохранен!" + "\n" + TestView.scorepercent + "%", "OK");
                    await Shell.Current.Navigation.PopAsync();

                }
                else
                {

                    
                    if (await resultservice.UpdateResult(SelectedTest.Name, SelectedCathegory.CathegoryId, Login, TestView.scorepercent, SelectedTest.TestId))
                    {
                        await Shell.Current.DisplayAlert("Тест пройден", "Результат сохранен" + "\n" + TestView.scorepercent + "%", "OK");
                        await Shell.Current.GoToAsync("..");
                    }
                    else
                    {
                        await Shell.Current.DisplayAlert("Тест пройден", "Результат не сохранен, процент правильных ответов не изменился" + "\n" + TestView.scorepercent + "%", "OK");
                        await Shell.Current.GoToAsync("..");
                    }

                }
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Error", ex.Message, "Ok");
            }
            finally
            {
                Isbusy = false;
            }
        }


        private async void GetQuestionsBuTest(int test_id)
        {
            var data = await new Services.QuestionService().GetQuestionsAsyncBYTest(test_id);
            QestionsByTest.Clear();
            foreach (var item in data)
            {
                QestionsByTest.Add(item);

            }
            
        }
        public static List<Questions> questions { get; set; }
        public async void GetQuestInfo(int test_id)
        {
            QuestionService questionService = new QuestionService();
            if(questions == null)
            {
                CurrentQuest = null;
                questions = (await questionService.GetQuestionsAsync()).Where(p => p.id_test == test_id).ToList();
                foreach (var item in questions.ToList())
                {
                    CurrentQuest = item;
                    questions.Remove(item);
                    break;
                }
            }
            else
            {
                foreach (var item in questions.ToList())
                {
                    CurrentQuest = item;
                    questions.Remove(item);
                    if(questions.Count == 0)
                    {
                        questions = null;
                    }
                    break;
                }
            }
           
        }

       
    }
}
