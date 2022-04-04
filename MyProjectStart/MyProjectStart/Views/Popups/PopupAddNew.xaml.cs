using Rg.Plugins.Popup.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MyProjectStart.Views.ViewsEditContent.PopupsAdd;

namespace MyProjectStart.Views.Popups
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PopupAddNew : Rg.Plugins.Popup.Pages.PopupPage
    {
        public PopupAddNew()
        {
            InitializeComponent();
        }
        private void ClickOnFrame_Tapped(object sender, EventArgs e)
        {
            string name = ((Frame)sender).ClassId;
            if (name == "AddTema")
            {
                Navigation.PushPopupAsync(new PopupAddTema());
            }
            else if (name == "AddQuestion")
            {
                Navigation.PushAsync(new AddAnswersForTest());

                Navigation.PopPopupAsync();

            }
            else if (name == "AddTest")
            {
                Navigation.PushPopupAsync(new PopupAddTest());
            }
            else if (name == "AddCategory")
            {
                Navigation.PushPopupAsync(new PopupAddCategory());
            }
        }
    }
}