﻿#pragma checksum "F:\archieves\app staff\New\VaginosisApp\VaginosisApp\VaginosisApp\DevicePage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "F89A6FC850B15D107C1AB5617A98CF71"
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
    
    
    public partial class DevicePage : Microsoft.Phone.Controls.PhoneApplicationPage {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Controls.Button ConnectAppToDeviceButton;
        
        internal System.Windows.Controls.Button RedButton;
        
        internal System.Windows.Controls.TextBox DeviceName;
        
        internal System.Windows.Controls.TextBlock BodyDetectionStatus_Copy;
        
        internal System.Windows.Controls.TextBox bluetoothStatus;
        
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
            System.Windows.Application.LoadComponent(this, new System.Uri("/VaginosisApp;component/DevicePage.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.ConnectAppToDeviceButton = ((System.Windows.Controls.Button)(this.FindName("ConnectAppToDeviceButton")));
            this.RedButton = ((System.Windows.Controls.Button)(this.FindName("RedButton")));
            this.DeviceName = ((System.Windows.Controls.TextBox)(this.FindName("DeviceName")));
            this.BodyDetectionStatus_Copy = ((System.Windows.Controls.TextBlock)(this.FindName("BodyDetectionStatus_Copy")));
            this.bluetoothStatus = ((System.Windows.Controls.TextBox)(this.FindName("bluetoothStatus")));
        }
    }
}

