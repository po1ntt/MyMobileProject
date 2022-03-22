﻿using System;
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
    class ResultsPageVm : BaseViewModel
    {
        private Cathegory _SelectedCathegory;

        public Cathegory SelectedCathegory
        {
            get { return _SelectedCathegory; }
            set { _SelectedCathegory = value;
                string login = Preferences.Get("Login", string.Empty);
                if(_SelectedCathegory != null)
                {
                    GetItemsForCathegory(_SelectedCathegory.CathegoryId, login);

                }
                OnPropertyChanged();
            }
        }
        private Tema _SelectedTema;

        public Tema SelectedTema
        {
            get { return _SelectedTema; }
            set { _SelectedTema = value;
                if(_SelectedTema != null)
                {
                    GetCategories(SelectedTema.TemaID);
                }
                OnPropertyChanged();
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


        public ResultsPageVm()
        {
          
            ResultsService resultsService = new ResultsService();
            Cathegories = new ObservableCollection<Cathegory>();
            CathegoriesItems = new ObservableCollection<Results>();
            TemaList = new ObservableCollection<Tema>();
            GetTemaList();
        }
        public ObservableCollection<Cathegory> Cathegories { get; set; }
        public ObservableCollection<Results> CathegoriesItems { get; set; }
        public ObservableCollection<Tema> TemaList { get; set; }
        private async void GetCategories(int tema_id)
        {
            var data = await new Services.СathegoryServices().GetCathegoryBuTema(tema_id);
            Cathegories.Clear();
            foreach (var item in data)
            {
                Cathegories.Add(item);
            }
        }
        private async void GetItemsForCathegory(int id_cathegory,string user_login)
        {

            var data = await new Services.ResultsService().GetTestResultByCathegoryAsync(id_cathegory,user_login);
            CathegoriesItems.Clear();
            foreach (var item in data)
            {
                CathegoriesItems.Add(item);
            }
        }

    }
}
