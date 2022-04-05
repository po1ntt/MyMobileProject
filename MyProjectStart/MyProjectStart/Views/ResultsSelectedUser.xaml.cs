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
    public partial class ResultsSelectedUser : ContentPage
    {
        
        public ResultsSelectedUser(UserModel user)
        {
            InitializeComponent();
            NameSurnametxb.Text = $"{user.Name} " + user.SurName;
        }
    }
}