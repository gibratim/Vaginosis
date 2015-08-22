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
using Microsoft.Phone.Tasks;
using System.IO;
using System.Windows.Media.Imaging;
using System.Net.Http;
using System.IO.IsolatedStorage;

namespace VaginosisApp
{
    public partial class RegisterPage : PhoneApplicationPage
    {
        

        public class Register
        {

            public string status { get; set; }

            public string username { get; set; }

            public string login { get; set; }
        }
        ProgressIndicator prog;
        public RegisterPage()
        {
            InitializeComponent();
            photoChooserTask = new PhotoChooserTask();
            photoChooserTask.Completed += new EventHandler<PhotoResult>(OnPhotoChooserTaskCompleted);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
           // NavigationService.Navigate(new Uri("/HomePage.xaml", UriKind.Relative));

            if (string.IsNullOrEmpty(this.username.Text))
            {
                MessageBox.Show("Please input (Username)");
                return;
            }
            if (string.IsNullOrEmpty(this.txtPassword.Password.ToString()))
            {
                MessageBox.Show("Please input (Password)");
                return;
            }
            if (string.IsNullOrEmpty(this.txtConPassword.Password.ToString()))
            {
                MessageBox.Show("Please input (Confirm Username)");
                return;
            }
            if (this.txtPassword.Password.ToString() != this.txtConPassword.Password.ToString())
            {
                MessageBox.Show("Password Not Match!");
                return;
            }
           
            if (string.IsNullOrEmpty(this.email.Text))
            {
                MessageBox.Show("Please input (Email)");
                return;
            }
           // string url = "http://localhost/vaginosis/online/mregistration";
            string url = "http://www.novariss.com/vaginosis/index.php/Online/mregistration";
            Uri uri = new Uri(url, UriKind.Absolute);
            StringBuilder postData = new StringBuilder();
            postData.AppendFormat("{0}={1}", "username", HttpUtility.UrlEncode(this.username.Text));
            postData.AppendFormat("&{0}={1}", "password", HttpUtility.UrlEncode(this.txtPassword.Password.ToString()));        
           
            postData.AppendFormat("&{0}={1}", "email", HttpUtility.UrlEncode(this.email.Text));

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

        }
        private void client_UploadProgressChanged(object sender, UploadProgressChangedEventArgs e)
        {
            //Me.txtResult.Text = "Uploading.... " & e.ProgressPercentage & "%"
        }

        private void client_UploadStringCompleted(object sender, UploadStringCompletedEventArgs e)
        {
            if (e.Cancelled == false & e.Error == null)
            {
                List<Register> l = JsonConvert.DeserializeObject<List<Register>>(e.Result);
                //  MessageBox.Show(l.ElementAt(0).login);
                prog.IsVisible = false;

                if (l.ElementAt(0).login == "T")
                {                 

                    MessageBox.Show("Registration successful continue");
                    NavigationService.Navigate(new Uri("/LoginPage.xaml", UriKind.Relative));

                }
                else
                {
                    MessageBox.Show("Registration failed" + l.ElementAt(0).status);
                }

                prog.IsVisible = false;
            }
        }
        private void ApplicationBarIconButton_Click_1(object sender, EventArgs e)
        {


            UploadFile();
            if (string.IsNullOrEmpty(this.username.Text))
            {
                MessageBox.Show("Please input (Username)");
                return;
            }
            if (string.IsNullOrEmpty(this.txtPassword.Password.ToString()))
            {
                MessageBox.Show("Please input (Password)");
                return;
            }
            if (string.IsNullOrEmpty(this.txtConPassword.Password.ToString()))
            {
                MessageBox.Show("Please input (Confirm Username)");
                return;
            }
            if (this.txtPassword.Password.ToString() != this.txtConPassword.Password.ToString())
            {
                MessageBox.Show("Password Not Match!");
                return;
            }

            if (string.IsNullOrEmpty(this.email.Text))
            {
                MessageBox.Show("Please input (Email)");
                return;
            }

            /*store application info**/
            IsolatedStorageSettings settings = IsolatedStorageSettings.ApplicationSettings;
            // txtInput is a TextBox defined in XAML.
            if (!settings.Contains("Image"))
            {              
                settings.Add("Image", imgTxtBx.Text);
            }
            else
            {                
                settings["Image"] = imgTxtBx.Text;
            }
            settings.Save();
            /***/
            // string url = "http://localhost/vaginosis/online/mregistration";
            string url = "http://www.novariss.com/vaginosis/index.php/Online/mregistration";
            Uri uri = new Uri(url, UriKind.Absolute);
            StringBuilder postData = new StringBuilder();
            postData.AppendFormat("{0}={1}", "username", HttpUtility.UrlEncode(this.username.Text));
            postData.AppendFormat("&{0}={1}", "password", HttpUtility.UrlEncode(this.txtPassword.Password.ToString()));

            postData.AppendFormat("&{0}={1}", "email", HttpUtility.UrlEncode(this.email.Text));

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
        }
        private MemoryStream photoStream;
        private string fileName;
        PhotoChooserTask photoChooserTask;

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            photoChooserTask.Show();
        }
        private void OnChoosePicture(object sender, System.Windows.Input.GestureEventArgs e)
        {
            photoChooserTask.Show();
        }
        private void OnPhotoChooserTaskCompleted(object sender, PhotoResult e)
        {
            // Hide text messages
         //   txtError.Visibility = Visibility.Collapsed;
           // txtMessage.Visibility = Visibility.Collapsed;
            // Make sure the PhotoChooserTask is resurning OK
            if (e.TaskResult == TaskResult.OK)
            {
                // initialize the result photo stream
                photoStream = new MemoryStream();
                // Save the stream result (copying the resulting stream)
                e.ChosenPhoto.CopyTo(photoStream);
                // save the original file name
                fileName = e.OriginalFileName;
              
                // display the chosen picture
                var bitmapImage = new BitmapImage();
                bitmapImage.SetSource(photoStream);
                img.Source = bitmapImage;
                imgTxtBx.Text = fileName.ToString();
                // enable the upload button
              //  btnUpload.IsEnabled = true;
            }
            else
            {
                // if result is not ok, make sure user can't upload
                //btnUpload.IsEnabled = false;
            }
        }
        private void OnUpload(object sender, System.Windows.Input.GestureEventArgs e)
        {
            UploadFile();
        }
        private async void UploadFile()
        {
            try
            {
                // Make sure there is a picture selected
                if (photoStream != null)
                {
                    // initialize the client
                    // need to make sure the server accepts network IP-based
                    // requests. 
                    // ensure correct IP and correct port address
                    var fileUploadUrl = @"http://www.novariss.com/vaginosis/uploads";
                    var client = new HttpClient();
                    // Reset the photoStream position
                    // If you don't reset the position, the content lenght
                    // sent will be 0
                    photoStream.Position = 0;
                    // This is the postdata
                
                    MultipartFormDataContent content = new MultipartFormDataContent();
                    content.Add(new StreamContent(photoStream), "file", fileName);
                    // upload the file sending the form info and ensure a result.
                    // it will throw an exception if the service doesn't return 
                    // a valid successful status code
                    await client.PostAsync(fileUploadUrl, content)
                        .ContinueWith((postTask) =>
                        {
                            postTask.Result.EnsureSuccessStatusCode();
                        });
                }
                // Disable the Upload button
                // btnUpload.IsEnabled = false;
                // reset the image control
                img.Source = null;
                // Display the Uploaded message
                // txtMessage.Visibility = Visibility.Visible;
            }
            catch
            {
                // Display the Uploaded message
                //txtError.Visibility = Visibility.Visible;
            }
        }
       
    }
}