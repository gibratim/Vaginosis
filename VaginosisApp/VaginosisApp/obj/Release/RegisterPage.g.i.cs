﻿#pragma checksum "F:\archieves\app staff\New\VaginosisApp\VaginosisApp\VaginosisApp\RegisterPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "BDDC97682A99C2C3ACD7ED76DCBE4CAA"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34209
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Microsoft.Phone.Controls;
using System;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Automation.Peers;
using System.Windows.Automation.Provider;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Resources;
using System.Windows.Shapes;
using System.Windows.Threading;


namespace VaginosisApp {
    
    
    public partial class RegisterPage : Microsoft.Phone.Controls.PhoneApplicationPage {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Controls.Grid ContentPanel;
        
        internal Microsoft.Phone.Controls.PhoneTextBox email;
        
        internal Microsoft.Phone.Controls.PhoneTextBox username;
        
        internal System.Windows.Controls.PasswordBox txtPassword;
        
        internal System.Windows.Controls.PasswordBox txtConPassword;
        
        internal System.Windows.Controls.Image img;
        
        internal System.Windows.Controls.TextBox imgTxtBx;
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Windows.Application.LoadComponent(this, new System.Uri("/VaginosisApp;component/RegisterPage.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.ContentPanel = ((System.Windows.Controls.Grid)(this.FindName("ContentPanel")));
            this.email = ((Microsoft.Phone.Controls.PhoneTextBox)(this.FindName("email")));
            this.username = ((Microsoft.Phone.Controls.PhoneTextBox)(this.FindName("username")));
            this.txtPassword = ((System.Windows.Controls.PasswordBox)(this.FindName("txtPassword")));
            this.txtConPassword = ((System.Windows.Controls.PasswordBox)(this.FindName("txtConPassword")));
            this.img = ((System.Windows.Controls.Image)(this.FindName("img")));
            this.imgTxtBx = ((System.Windows.Controls.TextBox)(this.FindName("imgTxtBx")));
        }
    }
}

