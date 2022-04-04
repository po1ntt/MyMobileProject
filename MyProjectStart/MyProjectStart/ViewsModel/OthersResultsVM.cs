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
        private UserModel _SelectedUser;

        public UserModel SelectedUser
        {
            get { return _SelectedUser; }
            set { _SelectedUser = value;
                OnPropertyChanged();
            }
        }
        public ObservableCollection<UserModel> ListUsers { get; set; }
        public OthersResultsVM()
        {
            ListUsers = new ObservableCollection<UserModel>();
            GetUsers();
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
       

    }
}
