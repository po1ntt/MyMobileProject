using Rg.Plugins.Popup.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MyProjectStart.Views.ViewsEditContent.PopupsDelete;

namespace MyProjectStart.Views.Popups
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PopupDelete : Rg.Plugins.Popup.Pages.PopupPage
    {
        public PopupDelete()
        {
            InitializeComponent();
        }

        private void ClickOnFrame_Tapped(object sender, EventArgs e)
        {
            string name = ((Frame)sender).ClassId;
            if (name == "TemaDel")
            {
                Navigation.PushPopupAsync(new PopupDeleteTema());
            }
            else if (name == "CategoryDel")
            {
                Navigation.PushPopupAsync(new PopupDeleteCategory());

            }
            else if (name == "TestDel")
            {
                Navigation.PushPopupAsync(new PopupDeleteTest());
            }
            else if (name == "QuestionsDell")
            {
                Navigation.PushPopupAsync(new PopupDeleteAnswer());
            }
        }
    }
}