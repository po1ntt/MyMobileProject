using MyProjectStart.Services;
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
    public partial class ResultsProgressPage : ContentPage
    {
        public ResultsProgressPage()
        {
            InitializeComponent();
        }

        private async void ContentPage_Appearing(object sender, EventArgs e)
        {
            if (ToolbarItems.Count < 1)
            {
                UserServices userServices = new UserServices();
                string login = Preferences.Get("Login", string.Empty);
                var users = (await userServices.SelectUsers()).Where(p => p.Login == login).FirstOrDefault();

                if (users.RoleId == 1)
                {

                }
                else
                {

                    ToolbarItem othersresults = new ToolbarItem { Text ="Просмотр чужих результатов" };
                    othersresults.Clicked += resultothers_Clicked;
                    ToolbarItems.Add(othersresults);
                    

                }
            }
        }

        private void resultothers_Clicked(object sender, EventArgs e)
        {

        }
    }
}