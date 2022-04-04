using MyProjectStart.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyProjectStart.Views.ViewsEditContent.PopupsAdd
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PopupAddTema : Rg.Plugins.Popup.Pages.PopupPage
    {
        public PopupAddTema()
        {
            InitializeComponent();
        }

        private async void addbutton_Clicked(object sender, EventArgs e)
        {
            TemaServices temaServices = new TemaServices();
            bool result = await temaServices.AddTema(nametema.Text);
            if(result == true)
            {
                await Shell.Current.DisplayAlert("Добавление темы", "Добавление темы прошло успешно", "ОК");
            }
        }
    }
}