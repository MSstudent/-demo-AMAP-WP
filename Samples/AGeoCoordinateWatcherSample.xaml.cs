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

    public partial class AGeoCoordinateWatcherSample : PhoneApplicationPage
    {
        MMarker mk;
        public AGeoCoordinateWatcherSample()
        {
            InitializeComponent();

            AGeoCoordinateWatcher amapGeoCoordinateWatcher = new AGeoCoordinateWatcher();

            amapGeoCoordinateWatcher.PositionChanged += amapGeoCoordinateWatcher_PositionChanged;
            amapGeoCoordinateWatcher.StatusChanged += amapGeoCoordinateWatcher_StatusChanged;
            amapGeoCoordinateWatcher.Start();
        }

        void amapGeoCoordinateWatcher_StatusChanged(object sender, GeoPositionStatusChangedEventArgs e)
        {
         
        }

        void amapGeoCoordinateWatcher_PositionChanged(object sender, AGeoPositionChangedEventArgs e)
        {
            if (mk==null)
            {
                mk = new MMarker() { LngLat = e.LngLat };
            }
            if (!map.Children.Contains(mk))
            {
                map.Children.Add(mk);
            }
            else
            {
                mk.LngLat = e.LngLat;
            }
            map.Center = e.LngLat;
        }

       
        
  
    }
}