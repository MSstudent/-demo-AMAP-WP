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

    public partial class AddOverlays : PhoneApplicationPage
    {
        public AddOverlays()
        {
            InitializeComponent();
        }

        private void MMarkerButton_Click(object sender, RoutedEventArgs e)
        {
            MMarker mk;
            map.Children.Add(mk = new MMarker()
            {
                LngLat = map.Center,
                TipFrameworkElement = new MTip() { Title ="测试名称", ContentText = "测试内容"}
            });
            //map.Children.Remove(mk);删除方法
        }

        private void PolylineButton_Click(object sender, RoutedEventArgs e)
        {
            MPolyline mp;
            MLngLatCollection xys=new MLngLatCollection();

            xys.Add(map.Center);
            xys.Add(new MLngLat(map.Center.LngX + 0.0001, map.Center.LatY + 0.0001));
            xys.Add(new MLngLat(map.Center.LngX - 0.0041, map.Center.LatY - 0.0001));
            xys.Add(new MLngLat(map.Center.LngX + 0.0021, map.Center.LatY + 0.0031));
            xys.Add(new MLngLat(map.Center.LngX + 0.0051, map.Center.LatY - 0.0031));
            map.Children.Add(mp = new MPolyline()
            {
                LngLats = xys,
                LineColor = Colors.Green,
                LineThickness = 4
            });
        }

        private void PolygonButton_Click(object sender, RoutedEventArgs e)
        {
            MPolygon mp;
            MLngLatCollection xys = new MLngLatCollection();
            xys.Add(map.Center);
            xys.Add(new MLngLat(map.Center.LngX + 0.0001, map.Center.LatY + 0.0001));
            xys.Add(new MLngLat(map.Center.LngX - 0.0041, map.Center.LatY - 0.0001));
            xys.Add(new MLngLat(map.Center.LngX + 0.0021, map.Center.LatY + 0.0031));
            xys.Add(new MLngLat(map.Center.LngX + 0.0051, map.Center.LatY - 0.0031));
            map.Children.Add(mp = new MPolygon()
            {
                LngLats = xys,
                LineColor = Colors.Green,
                LineThickness = 4
            });
        }

        private void RectangleButton_Click(object sender, RoutedEventArgs e)
        {
            MRectangle mp;
            MLngLatCollection xys = new MLngLatCollection();
            xys.Add(map.Center);

            xys.Add(new MLngLat(map.Center.LngX + 0.0151, map.Center.LatY - 0.0131));
            map.Children.Add(mp = new MRectangle()
            {
                LngLats = xys,
                LineColor = Colors.Green,
                LineThickness = 4
            });
        }

        private void CircleButton_Click(object sender, RoutedEventArgs e)
        {
            MCircle mp;
            MLngLatCollection xys = new MLngLatCollection();
            xys.Add(map.Center);

            xys.Add(new MLngLat(map.Center.LngX + 0.0151, map.Center.LatY - 0.0131));
            map.Children.Add(mp = new MCircle()
            {
                LngLats = xys,
                LineColor = Colors.Green,
                LineThickness = 4
            });
        }
    }
}