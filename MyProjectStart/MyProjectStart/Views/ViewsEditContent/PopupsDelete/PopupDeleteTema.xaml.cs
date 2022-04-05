using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MyProjectStart.Services;
using MyProjectStart.Models;

namespace MyProjectStart.Views.ViewsEditContent.PopupsDelete
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PopupDeleteTema : Rg.Plugins.Popup.Pages.PopupPage
    {
        public PopupDeleteTema()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            var selectedtema = SelectedTema.SelectedItem as Tema;
            TemaServices TemaService = new TemaServices();
            await TemaService.DeleteTema(selectedtema.TemaID);
        }
    }
}