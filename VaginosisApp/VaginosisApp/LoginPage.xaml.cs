using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.Text;
using Newtonsoft.Json;
using System.IO.IsolatedStorage;

namespace VaginosisApp
{
    public class Login
    {
       
        public string status { get; set; }
         
        public string username { get; set; }
       
        public string login { get; set; }
    }
    public partial class LoginPage : PhoneApplicationPage
    {
        ProgressIndicator prog;
        public LoginPage()
        {
            InitializeComponent();
           
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {/**
            string url = "http://www.novariss.com/vaginosis/index.php/Online/mlogin";
            Uri uri = new Uri(url, UriKind.Absolute);

            StringBuilder postData = new StringBuilder();
            postData.AppendFormat("{0}={1}", "username", HttpUtility.UrlEncode(this.username.Text));
            postData.AppendFormat("&{0}={1}", "password", HttpUtility.UrlEncode(this.txtPassword.Password.ToString()));

            WebClient client = default(WebClient);
            client = new WebClient();
            client.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
            client.Headers[HttpRequestHeader.ContentLength] = postData.Length.ToString();

            client.UploadStringCompleted += client_UploadStringCompleted;
            client.UploadProgressChanged += client_UploadProgressChanged;

            client.UploadStringAsync(uri, "POST", postData.ToString());

            prog = new ProgressIndicator();
            prog.IsIndeterminate = true;
            prog.IsVisible = true;
            prog.Text = "Loading....";
            SystemTray.SetProgressIndicator(this, prog);
            **/
             NavigationService.Navigate(new Uri("/DevicePage.xaml", UriKind.Relative));

        }
        private void client_UploadProgressChanged(object sender, UploadProgressChangedEventArgs e)
        {
            //Me.txtResult.Text = "Uploading.... " & e.ProgressPercentage & "%"
        }

        private void client_UploadStringCompleted(object sender, UploadStringCompletedEventArgs e)
        {
            if (e.Cancelled == false & e.Error == null)
            {
               // MessageBox.Show(e.Result);
              ///  NavigationService.Navigate(new Uri("/HomePage.xaml?sMemberID=" + " ", UriKind.Relative));
                List<Login> l = JsonConvert.DeserializeObject<List<Login>>(e.Result);
              //  MessageBox.Show(l.ElementAt(0).login);
                prog.IsVisible = false;

                if (l.ElementAt(0).login=="F")
                {
                    MessageBox.Show("Invalid user");                    
                   
                }
                else
                {
                    /*store application info**/
                    IsolatedStorageSettings settings = IsolatedStorageSettings.ApplicationSettings;

                    if (!settings.Contains("Username"))
                    {
                        settings.Add("Username", username.Text);
                    }
                    else
                    {
                        settings["Username"] = username.Text;
                        settings.Save();
                    }


                    NavigationService.Navigate(new Uri("/HomePage.xaml", UriKind.Relative));
                }

            }
        }
        private void ApplicationBarIconButton_Click(object sender, EventArgs e)
        {
            string url = "http://www.novariss.com/vaginosis/index.php/Online/mlogin";
            Uri uri = new Uri(url, UriKind.Absolute);

            StringBuilder postData = new StringBuilder();
            postData.AppendFormat("{0}={1}", "username", HttpUtility.UrlEncode(this.username.Text));
            postData.AppendFormat("&{0}={1}", "password", HttpUtility.UrlEncode(this.txtPassword.Password.ToString()));

            WebClient client = default(WebClient);
            client = new WebClient();
            client.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
            client.Headers[HttpRequestHeader.ContentLength] = postData.Length.ToString();

            client.UploadStringCompleted += client_UploadStringCompleted;
            client.UploadProgressChanged += client_UploadProgressChanged;

            client.UploadStringAsync(uri, "POST", postData.ToString());

            prog = new ProgressIndicator();
            prog.IsIndeterminate = true;
            prog.IsVisible = true;
            prog.Text = "Loading....";
            SystemTray.SetProgressIndicator(this, prog);

           // NavigationService.Navigate(new Uri("/HomePage.xaml", UriKind.Relative));
        }
    }
}