using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using Com.AMap.Maps.Api;
using Com.AMap.Maps.Api.Overlays;
using Com.AMap.Maps.Api.Events;
using Com.AMap.Maps.Api.Layers;
using System.Collections.ObjectModel;
using Com.AMap.Maps.Api.BaseTypes;
using Com.AMap.Maps.Api.Enums;
using System.Diagnostics;
using System.Text;
using Microsoft.Phone.Shell;
using Com.AMap.Search.API;
using Com.AMap.Search.API.Options;
using System.Device.Location;

namespace WindowsPhone7App
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();
            AMapConfig.Key = "用户KEY";
        }
        private void MainPage_OnLoaded(object sender, RoutedEventArgs e)
        {

        }




    }
}