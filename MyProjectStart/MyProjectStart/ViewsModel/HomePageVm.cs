using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using MyProjectStart.Views;
using System.Collections.ObjectModel;

using MyProjectStart.Models;
using MyProjectStart.Services;

using Xamarin.Essentials;
using System.Threading.Tasks;

namespace MyProjectStart.ViewsModel
{
    class HomePageVm : BaseViewModel
    {
        private Tema _SelectedTema;

        public Tema SelectedTema
        {
            get { return _SelectedTema; }
            set { _SelectedTema = value;
                if(_SelectedTema != null)
                {
                    GetCategories(_SelectedTema.TemaID);
                    GetLearningCategories(_SelectedTema.TemaID);
                }
                OnPropertyChanged();
            }
        }

        private ItemLearnCategory _SelectedItemLearningCategory;
        public ItemLearnCategory SelectedItemLearningCategory
        {
            get
            {
                return _SelectedItemLearningCategory;
            }
            set
            {
                _SelectedItemLearningCategory = value;
                if(_SelectedItemLearningCategory != null)
                {
                    Launcher.OpenAsync(_SelectedItemLearningCategory.Url_toLerningSite);
                    

                }
                OnPropertyChanged();
            }
        }
        private LerningCategories _SelectedLearningCategory;
        public LerningCategories SelectedLearningCategory
        {
            get
            {
                return _SelectedLearningCategory;
            }
            set
            {
                _SelectedLearningCategory = value;
                GetItemsLearningCategory(_SelectedLearningCategory.id_learncat);
                OnPropertyChanged();
            }
        }
        private string _Login;
        public string Login
        {
            set
            {
                _Login = value;
                OnPropertyChanged();
            }
            get
            {
                return _Login;
            }
        }

        public ObservableCollection<Cathegory> Cathegories { get; set; }
        public ObservableCollection<LerningCategories> lerningCategories { get; set; }
        public ObservableCollection<ItemLearnCategory> itemofLerningCategory { get; set; }
        public ObservableCollection<Tema> TemaList { get; set; }

        public ICommand LogoutCommand { get; private set; }
    
        public HomePageVm()
        {
            var login = Preferences.Get("Login", string.Empty);
            if (string.IsNullOrEmpty(login))
                Login = "Гость";
            else
                Login = login;
            itemofLerningCategory = new ObservableCollection<ItemLearnCategory>();
            Cathegories = new ObservableCollection<Cathegory>();
            lerningCategories = new ObservableCollection<LerningCategories>();
            TemaList = new ObservableCollection<Tema>();
            GetTemaList();


        }

        private async void GetItemsLearningCategory(int id_learncat)
        {

            var data = await new Services.ItemLearningService().GetItemsLeanCategoriesAsunc(id_learncat);
            itemofLerningCategory.Clear();
            foreach(var item in data)
            {
                itemofLerningCategory.Add(item);
            }
        }
        public async void GetTemaList()
        {
            var data = await new Services.TemaServices().GetListTemaAsunc();
            TemaList.Clear();
            foreach(var item in data)
            {
                TemaList.Add(item);
            }
        }

        private async void GetLearningCategories(int tema_id)
        {
            var data = await new Services.LearningCategoryService().GetLearningCathegoryBuTema(tema_id);
            lerningCategories.Clear();
            foreach(var item in data)
            {
                lerningCategories.Add(item);
            }
        }

        private async void GetCategories(int tema_id)
        {
            var data = await new Services.СathegoryServices().GetCathegoryBuTema(tema_id);
            Cathegories.Clear();
            foreach (var item in data)
            {
                Cathegories.Add(item);
            }
        }


       
        
    }
}
