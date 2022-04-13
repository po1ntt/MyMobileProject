using Rg.Plugins.Popup.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MyProjectStart.Views.ViewsEditContent.PopupsEdit;

namespace MyProjectStart.Views.Popups
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PopupEditing : Rg.Plugins.Popup.Pages.PopupPage
    {
        public PopupEditing()
        {
            InitializeComponent();
        }
        private void ClickOnFrame_Tapped(object sender, EventArgs e)
        {
            string name = ((Frame)sender).ClassId;
            
            if (name == "EditQuestion")
            {
                Navigation.PushAsync(new EditAnswerView());
                Navigation.PopPopupAsync();

            }
            else if (name == "EditTest")
            {
                Navigation.PushPopupAsync(new PopupEditTest());
            }
            else if (name == "EditCategory")
            {
                Navigation.PushPopupAsync(new PopupEditCategory());
            }
        }
    }
}