using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Machinapp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MyInfo : ContentPage
    {
        public MyInfo()
        {
            InitializeComponent();
        }

        private async void bClose_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}