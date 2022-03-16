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

namespace MyProjectStart.ViewsModel
{
    class TestViewModel : BaseViewModel
    {
        public int numberForCollection = 0;
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
                return _currentQuestionIndex < QestionsByTest.Count ? QestionsByTest[_currentQuestionIndex] : null;
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
        public Command RegisterResultCommand { get; private set; }
        public TestViewModel(TestsModel tests)
        {
            SelectedTest = tests;
            QestionsByTest = new ObservableCollection<Questions>();
            getQuestionsBuTest(tests.TestId);
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
                Result = await resultservice.RegisterResult(SelectedTest.Name, Login, SelectedTest.CategoryId);
                if (Result)
                {
                    await Shell.Current.DisplayAlert("Успешно,Тест пройден", "Результат сохранен", "OK");
                    await Shell.Current.Navigation.PopAsync();

                }
                else
                {
                    await Shell.Current.DisplayAlert("Успешно,Тест пройден", "Рузультат не сохранен, так как уже существует", "OK");
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

        private async void getQuestionsBuTest(int test_id)
        {
            var data = await new Services.QuestionService().GetQuestionsAsyncBYTest(test_id);
            QestionsByTest.Clear();
            foreach (var item in data)
            {
                QestionsByTest.Add(item);

            }
            
        }

       
    }
}
