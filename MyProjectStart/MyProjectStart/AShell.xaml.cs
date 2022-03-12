using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MyProjectStart.Views;

namespace MyProjectStart
{
   
    public partial class AShell : Shell
    {
        public AShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(HomePage), typeof(HomePage));
            Routing.RegisterRoute(nameof(LoginPage), typeof(LoginPage));
            Routing.RegisterRoute(nameof(ResultsProgressPage), typeof(ResultsProgressPage));
            Routing.RegisterRoute(nameof(ContactsPage), typeof(ContactsPage));

        }
    }
}