using MyProjectStart.Models;
using MyProjectStart.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace MyProjectStart.ViewsModel
{
    class OthersResultsVM : BaseViewModel
    {
        
        public static UserModel userSelected { 
            get;
            set; }
        private UserModel _SelectedUser;

        public UserModel SelectedUser
        {
            get { return _SelectedUser; }
            set { _SelectedUser = value;
                if(_SelectedUser != null)
                {
                    userSelected = _SelectedUser;
                }
                OnPropertyChanged();
            }
        }
        private Cathegory _SelectedCathegory;

        public Cathegory SelectedCathegory
        {
            get { return _SelectedCathegory; }
            set
            {
                _SelectedCathegory = value;
                if (_SelectedCathegory != null && userSelected != null)
                {
                    GetItemsForCathegory(_SelectedCathegory.CathegoryId, userSelected.Login);

                }
                OnPropertyChanged();
            }
        }
        private Tema _SelectedTema;

        public Tema SelectedTema
        {
            get { return _SelectedTema; }
            set
            {
                _SelectedTema = value;
                if (_SelectedTema != null)
                {
                    GetCategories(SelectedTema.TemaID);
                }
                OnPropertyChanged();
            }
        }
        public ObservableCollection<UserModel> ListUsers { get; set; }
        public ObservableCollection<Cathegory> Cathegories { get; set; }
        public ObservableCollection<Results> CathegoriesItems { get; set; }
        public ObservableCollection<Tema> TemaList { get; set; }

        public OthersResultsVM()
        {
            ListUsers = new ObservableCollection<UserModel>();
            Cathegories = new ObservableCollection<Cathegory>();
            CathegoriesItems = new ObservableCollection<Results>();
            TemaList = new ObservableCollection<Tema>();
            GetUsers();
            GetTemaList();
        }
        public async void GetUsers()
        {
            UserServices userServices = new UserServices();
            var data = await userServices.UserBuRoleId();
            ListUsers.Clear();
            foreach(var item in data)
            {
                ListUsers.Add(item);
            }
            
        }
        private async void GetTemaList()
        {
            var data = await new Services.TemaServices().GetListTemaAsunc();
            TemaList.Clear();
            foreach (var item in data)
            {
                TemaList.Add(item);
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
        private async void GetItemsForCathegory(int id_cathegory, string user_login)
        {

            var data = await new Services.ResultsService().GetTestResultByCathegoryAsync(id_cathegory, user_login);
            CathegoriesItems.Clear();
            foreach (var item in data)
            {
                CathegoriesItems.Add(item);
            }
        }


    }
}
