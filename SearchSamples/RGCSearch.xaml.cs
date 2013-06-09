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
namespace PhoneToolkitSample.SearchSamples
{

    public partial class RGCSearch : PhoneApplicationPage
    {
        public RGCSearch()
        {
            InitializeComponent();
            map.Zoom = 14;
            RunGeoCoordinateWatcher();
        }

        private void map_MapLoaded(object sender, MapEventArgs e)
        {
            map.ZoomEnded += new EventHandler<MapEventArgs>(map_ZoomChanged);
        }

        void map_ZoomChanged(object sender, MapEventArgs e)
        {
            if (map.Zoom >= 13)
            {
                centerCircle.Visibility = System.Windows.Visibility.Visible;
            }
            else
            {
                centerCircle.Visibility = System.Windows.Visibility.Collapsed;
            }
        }
        /// <summary>
        /// 定位开始
        /// </summary>
        public void RunGeoCoordinateWatcher()
        {
            GeoCoordinateWatcher _watcher = new GeoCoordinateWatcher(GeoPositionAccuracy.Default);
            _watcher.PositionChanged += new EventHandler<GeoPositionChangedEventArgs<GeoCoordinate>>(_watcher_PositionChanged);
            _watcher.Start();
        }
        MMarker centerMarker;
        MCircle centerCircle;
        void _watcher_PositionChanged(object sender, GeoPositionChangedEventArgs<GeoCoordinate> e)
        {
            MRGCSearch.GPSToOffset(new double[] { e.Position.Location.Longitude }, new double[] { e.Position.Location.Latitude }, (o) =>
            {
                if (o.Erro == null)
                {
                    if (centerMarker == null)
                    {
                        map.Children.Add(centerMarker = new MMarker()
                        {
                            LngLat = o.RGCItemList[0],
                            IconURL = "/location_on.png",
                            Anchor=new Point(0.5,0.5)
                        });
                        map.Children.Add(centerCircle = new MCircle() {});
                        centerCircle.SetCenterAndRadius(o.RGCItemList[0],500);
                    }
                    else
                    {
                        centerMarker.LngLat = o.RGCItemList[0];
                        centerCircle.SetCenterAndRadius(o.RGCItemList[0], 500);
                    }
                    map.Center = o.RGCItemList[0];
                    
                }
            });
        }
    }
}