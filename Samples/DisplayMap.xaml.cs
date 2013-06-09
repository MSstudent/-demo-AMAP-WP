using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Com.AMap.Maps.Api;
using Com.AMap.Maps.Api.BaseTypes;
using Com.AMap.Maps.Api.Enums;
using Com.AMap.Maps.Api.Events;
using Com.AMap.Maps.Api.Layers;
using Com.AMap.Maps.Api.Overlays;
using Com.AMap.Search.API;
using Com.AMap.Search.API.Options;
using Microsoft.Phone.Controls;
using System.Device.Location;
namespace PhoneToolkitSample.Samples
{

    public partial class DisplayMap : PhoneApplicationPage
    {
        public DisplayMap()
        {
            InitializeComponent();
        }
    }
}