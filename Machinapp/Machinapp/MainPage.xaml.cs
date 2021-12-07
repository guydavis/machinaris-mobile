using Microcharts;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Machinapp.Model;
using Xamarin.Essentials;
using Xamarin.Forms;
using ChartEntry = Microcharts.ChartEntry;

namespace Machinapp
{
    public partial class MainPage : ContentPage
    {
       // public ObservableCollection<AlertList> AlertList { get; set; } = new ObservableCollection<AlertList>();
        public MainPage()
        {
            InitializeComponent();
        }

        async void RefreshView_Refreshing(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(Preferences.Get("IP", String.Empty)))
            {
                await DisplayAlert("Alert", "Please set Machinaris IP address in Settings first.", "OK");
                myRefreshView.IsRefreshing = false;
            }
            else
            {
                GetDataAsync();
            }       
        }

        async void OnSettingsTapped(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new MySettings());
        }

        async void OnInfoTapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MyInfo());
        }

        public async void GetDataAsync()
        {
            String MachIP = Preferences.Get("IP", String.Empty);

            try
            {
                
                
                var httpClientExch = new HttpClient();
                var resultJsonExch = await httpClientExch.GetStringAsync("https://min-api.cryptocompare.com/data/price?fsym=XCH&tsyms=USD");
                var resultExch = JsonConvert.DeserializeObject<Exch[]>("["+resultJsonExch+"]");

                var httpClient = new HttpClient();
                var resultJsonFarms = await httpClient.GetStringAsync("http://"+MachIP+":8927/farms/");
                var resultFarms = JsonConvert.DeserializeObject<Farms[]>(resultJsonFarms);
                var resultJsonPlottings = await httpClient.GetStringAsync("http://" + MachIP + ":8927/plottings/");
                var resultPlottings = JsonConvert.DeserializeObject<Plottings[]>(resultJsonPlottings);
                var resultJsonWallets = await httpClient.GetStringAsync("http://" + MachIP + ":8927/wallets/");
                var resultWallets = JsonConvert.DeserializeObject<Wallets[]>(resultJsonWallets);
                
                var resultJsonChallenges = await httpClient.GetStringAsync("http://" + MachIP + ":8927/challenges/?page_size=100&page=1");

                for (int i = 2; i < 11; i++)
                {   
                    String TempResult = await httpClient.GetStringAsync("http://" + MachIP + ":8927/challenges/?page_size=100&page=" + i.ToString());
                
                    if (TempResult.Contains("[]")) break;
                    resultJsonChallenges += TempResult;

                }

                String temp = resultJsonChallenges.Replace("\n", "").Replace("\r", "").Replace("][", ",");

                var resultChallenges = JsonConvert.DeserializeObject<Challenges[]>(temp);

                var resultJsonBlockchains = await httpClient.GetStringAsync("http://" + MachIP + ":8927/blockchains/");
                var resultBlockchains = JsonConvert.DeserializeObject<Blockchains[]>(resultJsonBlockchains);
                var resultJsonAlerts = await httpClient.GetStringAsync("http://" + MachIP + ":8927/alerts/?page_size=20");
                var resultAlerts = JsonConvert.DeserializeObject<Alerts[]>(resultJsonAlerts);
                var resultJsonPools = await httpClient.GetStringAsync("http://" + MachIP + ":8927/pools/");
                var resultPools = JsonConvert.DeserializeObject<Pools[]>(resultJsonPools);
                
                if (resultExch != null)
                {
                lExch.Text = " XCH $" + resultExch[0].USD;
                }

                if (resultFarms != null)
                {
                    if (resultFarms[0].status == "Farming") lFarmStatus.TextColor = Color.FromHex("#3aac59"); else lFarmStatus.TextColor = Color.FromHex("#c7c7c7");
                    lFarmStatus.Text = resultFarms[0].status;

                    lTotalPlots.Text = resultFarms[0].plot_count.ToString();
                    lTotalPlotsSize.Text = (resultFarms[0].plots_size / 1024).ToString() + " TiB";
                    lXCHFarmed.Text = resultFarms[0].total_coins.ToString();
                    lXCHNetspace.Text = (resultFarms[0].netspace_size / 1073741824).ToString("n3") + " EiB";
                    lETW.Text = resultFarms[0].expected_time_to_win;
                    lUpdated.Text = "Last updated: " + resultFarms[0].updated_at.ToString();
                }

                if (resultPlottings.Length > 0)
                {
                    lPlottingsStatus.TextColor = Color.FromHex("#3aac59");
                    lPlottingsStatus.Text = "Active";
                }
                else
                {
                    lPlottingsStatus.TextColor = Color.FromHex("#c7c7c7");
                    lPlottingsStatus.Text = "Idle";
                }

                if (resultWallets != null)
                {
                // lXCHBalance.Text = resultWallets[0].cold_balance.ToString("n3");
                lXCHBalance.Text = "0.01";
                var resultstr1 = resultWallets[0].details.ToString().Split(new string[] { "\n" }, StringSplitOptions.None);
                
                string finalstr = resultstr1[1].Substring(resultstr1[1].IndexOf(':') + 1);

                if (finalstr.Trim() == "Synced") lXCHWalletStatus.TextColor = Color.FromHex("#3aac59"); else lXCHWalletStatus.TextColor = Color.Red;
                lXCHWalletStatus.Text = finalstr.Trim();

                }

                if (resultBlockchains != null)
                {
                    
                    var resultstr1 = resultBlockchains[0].details.ToString().Split(new string[] { "\n" }, StringSplitOptions.None);

                    string finalstr = resultstr1[0].Substring(resultstr1[0].IndexOf(':') + 1);

                    if (finalstr.Trim() == "Full Node Synced") lXCHBlockchainStatus.TextColor = Color.FromHex("#3aac59"); else lXCHBlockchainStatus.TextColor = Color.Red;
                    lXCHBlockchainStatus.Text = finalstr.Trim();

                }

                if (resultChallenges != null)
                {
                    List<ChartEntry> entries = new List<ChartEntry>();

                    double[] times = new double[resultChallenges.Length];

                    foreach (var OneResult in resultChallenges)
                    {
                        String TimeTaken = OneResult.time_taken.ToString();
                        TimeTaken = TimeTaken.Substring(0, TimeTaken.Length - 5);

                    ChartEntry myEntry = new ChartEntry((float)Convert.ToDouble(TimeTaken))
                    {
                        Color = SkiaSharp.SKColor.Parse("#3aac59"),
                      //  ValueLabel = (Math.Round((float)Convert.ToDouble(TimeTaken),1)).ToString(),
                      //  ValueLabelColor = SkiaSharp.SKColor.Parse("#c7c7c7"),
                      //  Label = (entries.Count + 1).ToString(),
                        

                    };

                    times[entries.Count] = Convert.ToDouble(TimeTaken);
                    entries.Add(myEntry);
                    

                    }

                chChallenges.Chart = new Microcharts.PointChart {

                    Entries = entries,
                    BackgroundColor = SkiaSharp.SKColor.Parse("#212529"),
                    AnimationDuration = TimeSpan.FromMilliseconds(500),

                   // LabelOrientation = (Orientation.Vertical),
                   // LabelColor = SkiaSharp.SKColor.Parse("#c7c7c7"),


                    };

                    if (times.Average() >= 5) lAverageTime.TextColor = Color.Orange;
                    else if (times.Average() >= 20) lAverageTime.TextColor = Color.Red;
                    else lAverageTime.TextColor = Color.FromHex("#3aac59");

                    if (times.Max() >= 5) lMaxTime.TextColor = Color.Orange;
                    else if (times.Max() >= 20) lMaxTime.TextColor = Color.Red;
                    else lMaxTime.TextColor = Color.FromHex("#3aac59");

                    lMaxTime.Text = "  Max response time: " + Math.Round(times.Max(),2).ToString() + "s";
                    lAverageTime.Text = "  Average response time: " + Math.Round(times.Average(), 2).ToString() + "s";

                double tempc = resultChallenges.Length/6;

                lNumChallenges.Text = resultChallenges.Length.ToString() + " challenges, last " + Math.Round(tempc,0).ToString() + " min. ";

                }

                if (resultPools != null)
                {
                    
                    var resultstr1 = resultPools[0].pool_state.ToString().Split(new string[] { ", \"" }, StringSplitOptions.None);

                    string finalstrdiff = resultstr1[1].Substring(resultstr1[1].IndexOf(':') + 2);
                    string PointsAckSinceStart = resultstr1[7].Substring(resultstr1[7].IndexOf(':') + 2);
                    string PointsFoundSinceStart = resultstr1[9].Substring(resultstr1[9].IndexOf(':') + 2);
                    double percent_successful = (Convert.ToDouble(PointsFoundSinceStart) * 100) / Convert.ToDouble(PointsAckSinceStart);

                lPoolDifficulty.Text = finalstrdiff.ToString();

                if (percent_successful > 80) lPoolPercentage.TextColor = Color.FromHex("#3aac59"); else lPoolPercentage.TextColor = Color.Red;
                lPoolPercentage.Text = Math.Round(percent_successful,2).ToString() + " %";


                }

                if (resultAlerts != null)
                {
                    
                    string[] final_alerts = new string[10];

                    for (int i=0; i<10; i++)
                    {
                        final_alerts[i] = resultAlerts[i].created_at.ToString() + " " + resultAlerts[i].message;
                    }

                    listAlerts.ItemsSource = final_alerts;
                
                }

            myRefreshView.IsRefreshing = false;
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "OK");
                myRefreshView.IsRefreshing = false;
                //  throw ex;
            }

        }

       
    }
    
}
