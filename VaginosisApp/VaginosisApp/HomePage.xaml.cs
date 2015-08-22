using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.Collections.ObjectModel;
using Windows.Networking.Sockets;
using Windows.Networking.Proximity;
using Microsoft.Phone.Tasks;
using VaginosisApp.Resources;
using System.Windows.Input;
using System.IO.IsolatedStorage;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace VaginosisApp
{
    public partial class HomePage : PhoneApplicationPage
    {
        ObservableCollection<PairedDeviceInfo> _pairedDevices;  // a local copy of paired device information 
        StreamSocket _socket; // socket object used to communicate with the device 
 
        public HomePage()
        {
            InitializeComponent();
            if (IsolatedStorageSettings.ApplicationSettings.Contains("Username"))
            {
                Welcome.Text += IsolatedStorageSettings.ApplicationSettings["Username"] as string;
                // string ImageSource += IsolatedStorageSettings.ApplicationSettings["Image"] as string;

                var fullFilePath = IsolatedStorageSettings.ApplicationSettings["Image"] as string;

                var uris = new System.Uri(fullFilePath);
                var converted = uris.AbsoluteUri;

                Uri uri = new Uri(converted, UriKind.Absolute);
               

                ImageSource imgSource = new BitmapImage(uri);
                img.Source = imgSource;
                More.Text = "For Trichomoniasis Yellow \n\n green, frothy discharge Foul odor with discharge Increased amount of discharge Increased frequency of urination Inflammation of vulva/vagina Itching \n\n For Yeast infection/Candida albicans \n Increased amount of discharge White clumpy, cottage-cheese like discharge Redness Itching Stomach and back pain Vomiting or fever associated with the vaginal discharge.Burning on skin during urination  \n\n For UTI (Urinary Tract Infection \n A strong, persistent urge to urinate A burning sensation when urinating Passing frequent, small amounts of urine Urine that appears cloudy Urine that appears red, bright pink or cola-colored or a sign of blood in the urine Strong-smelling urine Pelvic pain in women ";
              
            }

        }
       

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

        }
        private async void RefreshPairedDevicesList()
        {
            try
            {
                // Search for all paired devices
                PeerFinder.AlternateIdentities["Bluetooth:Paired"] = "";
                var peers = await PeerFinder.FindAllPeersAsync();

                // By clearing the backing data, we are effectively clearing the ListBox
                _pairedDevices.Clear();

                if (peers.Count == 0)
                {
                    MessageBox.Show(AppResources.Msg_NoPairedDevices);
                }
                else
                {
                    // Found paired devices.
                    foreach (var peer in peers)
                    {
                        _pairedDevices.Add(new PairedDeviceInfo(peer));
                    }
                }
            }
            catch (Exception ex)
            {
                if ((uint)ex.HResult == 0x8007048F)
                {
                    var result = MessageBox.Show(AppResources.Msg_BluetoothOff, "Bluetooth Off", MessageBoxButton.OKCancel);
                    if (result == MessageBoxResult.OK)
                    {
                        ShowBluetoothcControlPanel();
                    }
                }
                else if ((uint)ex.HResult == 0x80070005)
                {
                    MessageBox.Show(AppResources.Msg_MissingCaps);
                }
                else
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
       
        

        private void ShowBluetoothcControlPanel()
        {
            ConnectionSettingsTask connectionSettingsTask = new ConnectionSettingsTask();
            connectionSettingsTask.ConnectionSettingsType = ConnectionSettingsType.Bluetooth;
            connectionSettingsTask.Show();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Connections.xaml", UriKind.Relative));
        }

        private void ConnectToSelected_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/DevicePage.xaml", UriKind.Relative));
        }
        private void ApplicationBarIconButton_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/Connections.xaml", UriKind.Relative));
        }

        private void ApplicationBarIconButton_Click_1(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/DevicePage.xaml", UriKind.Relative));
        }
    }

    
    
}