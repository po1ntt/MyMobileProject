﻿using MyProjectStart.Models;
using MyProjectStart.ViewsModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyProjectStart.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CategoryView : ContentPage
    {
        CategoryViewModel cvm;
        public Cathegory cathegory1;
        public CategoryView(Cathegory cathegory)
        {
            InitializeComponent();
            cvm = new CategoryViewModel(cathegory);
            this.BindingContext = cvm;
            cathegory1 = cathegory;
            
        }

        private async void ImageButton_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.Navigation.PopModalAsync();
        }

        async void CollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedTest = e.CurrentSelection.FirstOrDefault() as TestsModel;
            if (selectedTest == null)
             return;
            await Shell.Current.Navigation.PushAsync(new TestView(selectedTest, cathegory1));
            ((CollectionView)sender).SelectedItem = null;
           
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            if(TestDone.IsVisible == false)
            {
                TestNotDone.IsVisible = false;
                TestDone.IsVisible = true;
                ((Button)sender).Text = "Показать не завершенные тесты";
            }
            else
            {
                TestNotDone.IsVisible = true;
                TestDone.IsVisible = false;
                ((Button)sender).Text = "Показать завершенные тесты";
            }
        }
    }
}