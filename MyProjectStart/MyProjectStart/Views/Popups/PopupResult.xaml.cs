using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyProjectStart.Views.Popups
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PopupResult : Rg.Plugins.Popup.Pages.PopupPage
    {
        public PopupResult(double scopercent, string imagemedal)
        {
            InitializeComponent();
            ScorePercenLabel.Text = "Процент правильных ответов: " + scopercent + "%";
            ImageMedal.Source = imagemedal;
        }
    }
}