using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using VaginosisApp.Resources;
using Windows.Networking.Sockets;
using Windows.Networking.Proximity;
using System.Diagnostics;
using Windows.Storage.Streams;
using System.Threading.Tasks;
using BluetoothConnectionManager;
using System.Windows.Media;
using System.ComponentModel;
using Windows.Networking;
using Microsoft.Phone.Tasks;
using System.IO;

namespace VaginosisApp
{
    public partial class DevicePage : PhoneApplicationPage
    {
        StreamSocket socket = new StreamSocket();
        DataReader _dataReader;


        // Constructor
        public DevicePage()
        {
            InitializeComponent();
           

        }


        private async void checkBluetooth()
        {
            

            SolidColorBrush statuscolor = new SolidColorBrush();
            try
            {
                PeerFinder.AlternateIdentities["Bluetooth:Paired"] = "";
                var devices = await PeerFinder.FindAllPeersAsync();
                bluetoothStatus.Text = "Online";
                statuscolor.Color = Colors.Green;
                bluetoothStatus.Foreground = statuscolor;

                if (devices.Count == 0)
                {
                    MessageBox.Show("No paired bluetooth devices have been found, please pair with a bluetooth device!");
                    await Windows.System.Launcher.LaunchUriAsync(new Uri("ms-settings-bluetooth:"));
                    var task = new ConnectionSettingsTask();
            task.ConnectionSettingsType = ConnectionSettingsType.Bluetooth;
            task.Show();
                }

                PeerInformation peerInfo = devices.FirstOrDefault(c => c.DisplayName.Contains(DeviceName.Text));
                DeviceName.Text = peerInfo.DisplayName;
                
                if (peerInfo == null)
                {
                    MessageBox.Show("No paired device please pair with a device!");
                    await Windows.System.Launcher.LaunchUriAsync(new Uri("ms-settings-bluetooth:"));
                }

               
                await socket.ConnectAsync(peerInfo.HostName, "1");
                DeviceName.Text = peerInfo.ServiceName.ToString();

                await socket.ConnectAsync(peerInfo.HostName, peerInfo.ServiceName);


            }
            catch (Exception ex)
            {
                if ((uint)ex.HResult == 0x8007048F)
                {
                    bluetoothStatus.Text = "Offline";
                    statuscolor.Color = Colors.Red;
                    bluetoothStatus.Foreground = statuscolor;
                }
            }
        }
        private IBuffer GetBufferFromByteArray(byte[] package)
        {
            using (DataWriter dw = new DataWriter())
            {
                dw.WriteBytes(package);
                return dw.DetachBuffer();
            }
           
        }

        private void ConnectAppToDeviceButton_Click(object sender, RoutedEventArgs e)
        {
            checkBluetooth();
          //  showMe();
        }

        private async void buttonDiscoverDevices_Click(object sender, RoutedEventArgs e)
        {
           
        }

        private async void  RedButton_Click(object sender, RoutedEventArgs e)
        {
            var buffer = new Windows.Storage.Streams.Buffer(128);
            System.Diagnostics.Debug.WriteLine("message: " + buffer);
            if (buffer==null){
                System.Diagnostics.Debug.WriteLine("message"+buffer.ToString());
              //  MessageBox.Show("no incoming message");
            
            }
            MessageBox.Show("no incoming message: "+buffer);
            var receivedSize = await socket.InputStream.ReadAsync(buffer, 128, InputStreamOptions.None);
            using (var dr = DataReader.FromBuffer(buffer))
            {
              var  varsyncByte0 = dr.ReadByte();
                var syncByte1 = dr.ReadByte();
                // etc
                MessageBox.Show(varsyncByte0.ToString());
                MessageBox.Show(syncByte1.ToString());
            }

        }
        public async void showMe() {

            await _dataReader.LoadAsync(4);
            uint messageLen = (uint)_dataReader.ReadInt32();
            await _dataReader.LoadAsync(messageLen);
            byte[] buffer = new byte[messageLen];
            _dataReader.ReadBytes(buffer);
            MemoryStream ms = new MemoryStream(buffer);
            MessageBox.Show(ms.ToString());
        }

       
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            showMe();
        }
              

        
    }
}