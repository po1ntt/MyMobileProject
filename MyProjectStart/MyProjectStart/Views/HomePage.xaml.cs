using Android.Service.Controls;
using MyProjectStart.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MyProjectStart.Services;
using MyProjectStart.ViewsModel;
using MyProjectStart.Views.Popups;
using Rg.Plugins.Popup.Extensions;

namespace MyProjectStart.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        HomePageVm cvm;
        public HomePage()
        {
            InitializeComponent();
             cvm = new HomePageVm();
            
        }
         

        async void CollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var category = e.CurrentSelection.FirstOrDefault() as Cathegory;
            if (category == null)
                return;
            await Shell.Current.Navigation.PushAsync(new CategoryView(category));
            ((CollectionView)sender).SelectedItem = null;
        }

         void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            Navigation.PushPopupAsync(new PopupAccount());
        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            ((ListView)sender).SelectedItem = null;
        }

       
    }
}