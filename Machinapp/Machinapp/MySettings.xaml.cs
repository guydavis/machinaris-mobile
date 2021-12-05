using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Machinapp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MySettings : ContentPage
    {
        public MySettings()
        {
            InitializeComponent();

            
            eIPAddress.Text = Preferences.Get("IP",String.Empty);
            sInterval.Value = Preferences.Get("Interval", 2.0);
            lInterval.Text = "Widget refresh interval: " + sInterval.Value.ToString();


        }

        private async void BCancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        private async void BSave_Clicked(object sender, EventArgs e)
        {
            IPAddress ip;

            bool ValidateIP = IPAddress.TryParse(eIPAddress.Text, out ip);
            if (ValidateIP)
            {
                Preferences.Set("IP", eIPAddress.Text);
                Preferences.Set("Interval", sInterval.Value);
                await Navigation.PopAsync();
            }
            else
            {
                await DisplayAlert("Error", "Please enter valid IP address.", "OK");
                eIPAddress.Text = Preferences.Get("IP", String.Empty);
            }
        }

        private void sInterval_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            sInterval.Value = Math.Round(sInterval.Value, 0);
            lInterval.Text = "Widget refresh interval: " + sInterval.Value.ToString();

        }
    }
}