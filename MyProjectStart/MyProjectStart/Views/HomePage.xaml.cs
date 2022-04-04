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

        private async void ContentPage_Appearing(object sender, EventArgs e)
        {
            if(ToolbarItems.Count < 3)
            {
                UserServices userServices = new UserServices();
                string login = Preferences.Get("Login", string.Empty);
                var users = (await userServices.SelectUsers()).Where(p => p.Login == login).FirstOrDefault();

                if (users.RoleId == 1)
                {

                }
                else
                {

                    ToolbarItem add = new ToolbarItem { IconImageSource = "https://cdn4.iconfinder.com/data/icons/eon-ecommerce-i-1/32/plus_add_circle-256.png" };
                    add.Clicked += Add_Clicked;
                    ToolbarItem edit = new ToolbarItem { IconImageSource = "https://cdn3.iconfinder.com/data/icons/glypho-free/64/pen-checkbox-256.png" };
                    edit.Clicked += Edit_Clicked;
                    ToolbarItem delete = new ToolbarItem { IconImageSource = "https://cdn3.iconfinder.com/data/icons/google-material-design-icons/48/ic_highlight_remove_48px-256.png" };
                    delete.Clicked += Delete_Clicked;

                    ToolbarItems.Add(add);
                    ToolbarItems.Add(edit);
                    ToolbarItems.Add(delete);

                }
            }
          
        }
        void Add_Clicked(object sender, EventArgs e)
        {
            Navigation.PushPopupAsync(new PopupAddNew());
        }
        void Edit_Clicked(object sender, EventArgs e)
        {
            Navigation.PushPopupAsync(new PopupEditing());
        }
        void Delete_Clicked(object sender, EventArgs e)
        {
            Navigation.PushPopupAsync(new PopupDelete());
        }
    }
}