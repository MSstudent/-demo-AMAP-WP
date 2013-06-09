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

    public partial class AddEditMarker : PhoneApplicationPage
    {
        public AddEditMarker()
        {
            InitializeComponent();
            map.MapLoaded += new EventHandler<MapEventArgs>(map_MapLoaded);
        }

        void map_MapLoaded(object sender, MapEventArgs e)
        {
            MMarker editMarker;
            map.Children.Add(editMarker = new MMarker() {
                LngLat=map.Center,
                IsEditable=true,
                Anchor=new Point(0.5,1)
            });
            editMarker.EditStart += new EventHandler<MapEventArgs>(editMarker_EditStart);
            editMarker.Editing += new EventHandler<MapEventArgs>(editMarker_Editing);
            editMarker.EditEnd += new EventHandler<MapEventArgs>(editMarker_EditEnd);
           
        }

        void editMarker_EditEnd(object sender, MapEventArgs e)
        {
            MMarker mk = sender as MMarker;
            showEdit.Text = "编辑结束：" + mk.LngLat;
        }

        void editMarker_Editing(object sender, MapEventArgs e)
        {
            MMarker mk = sender as MMarker;
            showEdit.Text = "编辑中：" + mk.LngLat;
        }

        void editMarker_EditStart(object sender, MapEventArgs e)
        {
            MMarker mk = sender as MMarker;
            showEdit.Text = "编辑开始："+mk.LngLat;
        }
    }
}