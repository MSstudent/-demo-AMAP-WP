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
using Com.AMap.Maps.Api.Events;
using Com.AMap.Maps.Api.BaseTypes;
using System.Diagnostics;

namespace PhoneToolkitSample.Samples
{
    public partial class GestureDrawType : PhoneApplicationPage
    {
        public GestureDrawType()
        {
            InitializeComponent();
            
        }
        private void map_loaded(object sender, MapEventArgs e)
        {
            MyMap.GestureDrawStep += new EventHandler<GestureDrawEventArgs>(MyMap_GestureDrawEvent);
            MyMap.GestureDrawEnd += new EventHandler<GestureDrawEventArgs>(MyMap_GestureDrawEvent);
            MyMap.RemoveGestureDrawOverlay += new EventHandler<GestureDrawEventArgs>(MyMap_GestureDrawEvent);
        }

        void MyMap_GestureDrawEvent(object sender, GestureDrawEventArgs e)
        {
            if (e.OriginLngLat != null)
            {
                Debug.WriteLine(sender.ToString() + "|" + e.Type + "|" + e.OriginLngLat.ToString());
            }
            else
            {
                Debug.WriteLine(sender.ToString() + "|" + e.Type );
            }
            if (e.Type.Equals("GestureDrawEnd"))
            {
                MyMap.GestureType = Com.AMap.Maps.Api.Enums.MapGestureType.PanAndZoom;
            }
        }
        /// <summary>
        /// 添加标注
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_AddMarker_Click(object sender, RoutedEventArgs e)
        {
            MyMap.GestureType = Com.AMap.Maps.Api.Enums.MapGestureType.AddMarker;
        }
        /// <summary>
        /// 鼠标画线
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_DrawLine_Click(object sender, RoutedEventArgs e)
        {
            MyMap.GestureType = Com.AMap.Maps.Api.Enums.MapGestureType.DrawLine;
        }
        /// <summary>
        /// 鼠标画多边形
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_DrawPolygon_Click(object sender, RoutedEventArgs e)
        {
            MyMap.GestureType = Com.AMap.Maps.Api.Enums.MapGestureType.DrawPolygon;
        }
        /// <summary>
        /// 鼠标画矩形
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_DrawRectangle_Click(object sender, RoutedEventArgs e)
        {
            MyMap.GestureType = Com.AMap.Maps.Api.Enums.MapGestureType.DrawRectangle;
        }
        /// <summary>
        ///  测直线距离
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Ruler_Click(object sender, RoutedEventArgs e)
        {
            MyMap.GestureType = Com.AMap.Maps.Api.Enums.MapGestureType.Ruler;
        }
        /// <summary>
        /// 鼠标画圆
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_DrawCircle_Click(object sender, RoutedEventArgs e)
        {
            MyMap.GestureType = Com.AMap.Maps.Api.Enums.MapGestureType.DrawCircle;
        }

    }
}