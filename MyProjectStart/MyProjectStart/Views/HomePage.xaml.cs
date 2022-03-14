using Android.Service.Controls;
using MyProjectStart.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace MyProjectStart.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : TabbedPage
    {
        public HomePage()
        {
            InitializeComponent();
        }

        private void TapToTest(object sender, EventArgs e)
        {
            string nametest = this.ClassId.ToString();
          
        }

        async void CollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var category = e.CurrentSelection.FirstOrDefault() as Cathegory;
            if (category == null)
                return;
            await Shell.Current.Navigation.PushModalAsync(new CategoryView(category));
            ((CollectionView)sender).SelectedItem = null;
        }
    }
}