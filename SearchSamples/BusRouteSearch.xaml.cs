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
using Com.AMap.Search.API;
using Com.AMap.Search.API.Options;
using Com.AMap.Maps.Api.Overlays;
using Com.AMap.Maps.Api.BaseTypes;

namespace WindowsPhone7App.SearchSamples
{
    public partial class BusRouteSearch : PhoneApplicationPage
    {
        public BusRouteSearch()
        {
            InitializeComponent();
        }
        MLngLat start;
        MLngLat end;
        private void map_MapLoaded(object sender, MapEventArgs e)
        {
            map.Tap += new EventHandler<System.Windows.Input.GestureEventArgs>(map_Tap);
            //RunBusSearch();
            //  BusSearchWithOption();
        }

        void map_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            Point p = e.GetPosition(map);//获得在map容器的像素坐标
            if (start == null)
            {
                start = map.FromScreenPixelToLngLat(p);//确定起点
                startText.Text = start.ToString();
                map.Children.Add(new MMarker()
                {
                    LngLat = start,
                    IsEditable = true,
                    IconURL = "/bus_start_pic.jpg",
                    Anchor = new Point(0.5, 1)
                });
            }
            else if (end == null)
            {
                end = map.FromScreenPixelToLngLat(p);//确定终点
                endText.Text = start.ToString();
                map.Children.Add(new MMarker()
                {
                    LngLat = end,
                    IconURL = "/bus_end_pic.jpg",
                    Anchor = new Point(0.5, 1)
                });
            }
        }

        //private void RunBusSearch()
        //{
        //    MBusRouteSearch.BusSearchByTwoPoi(116.418986262493, 39.9716071016544, 116.313314531309, 39.8535816388256, "010", CallBack);
        //}

        /// <summary>
        /// 另一种调用方式
        /// </summary>
        private void BusSearchWithOption()
        {
            MBusRouteSearchOption m_BusRouteSearchOption = new MBusRouteSearchOption();
            m_BusRouteSearchOption.CityCode = "010";
            m_BusRouteSearchOption.Config = "BR";//固定值
            m_BusRouteSearchOption.Encode = "GBK";
            m_BusRouteSearchOption.RouteType = 0;
            m_BusRouteSearchOption.X1 = 116.38969318005;
            m_BusRouteSearchOption.Y1 = 39.9048015978361;
            m_BusRouteSearchOption.X2 = 116.323902107975;
            m_BusRouteSearchOption.Y2 = 39.907648620322;
            MBusRouteSearch.BusRouteSearchWithOption(m_BusRouteSearchOption, CallBack);
        }


        void CallBack(MBusRouteSearchResult sender)
        {
            // MessageBox.Show("通过参数类对象进行公交导航搜索信息 如下：\nCount：" + sender.Count.ToString() + " Routes.count：" + sender.Routes.Count + " SearchTime：" + sender.SearchTime.ToString());
            if (sender.Erro == null)
            {
                List<MOverlay> list = new List<MOverlay>();

                for (int routescount = 0; routescount < sender.Routes.Count; routescount++)
                {
                    //   string url = "Bounds：" + sender.Routes[routescount].Bounds + "\n" + "Expense：" + sender.Routes[routescount].Expense + "\n" + "FootEndLength：" + sender.Routes[routescount].FootEndLength + "\n";
                    //   MessageBox.Show("第" + routescount + "个MBus信息 如下：\n" + url);

                    for (int segmentArraycount = 0; segmentArraycount < sender.Routes[routescount].SegmentArray.Count; segmentArraycount++)
                    {
                        //  string url1 = "BusName：" + sender.Routes[routescount].SegmentArray[segmentArraycount].BusName + "\n" + "DriveLength：" + sender.Routes[routescount].SegmentArray[segmentArraycount].DriveLength + "\n" + "EndName：" + sender.Routes[routescount].SegmentArray[segmentArraycount].EndName + "\n" + "FootLength：" + sender.Routes[routescount].SegmentArray[segmentArraycount].FootLength + "\n" + "PassDeportCoordinate：" + sender.Routes[routescount].SegmentArray[segmentArraycount].PassDeportCoordinate + "\n" + "CoordinateList：" + sender.Routes[routescount].SegmentArray[segmentArraycount].LngLats.Count + "\n" + "PassDeportCount：" + sender.Routes[routescount].SegmentArray[segmentArraycount].PassDeportCount + "\n" + "PassDeportName：" + sender.Routes[routescount].SegmentArray[segmentArraycount].PassDeportName + "\n" + "StartName：" + sender.Routes[routescount].SegmentArray[segmentArraycount].StartName + "\n";
                        //  MessageBox.Show("第" + routescount + "个的第" + segmentArraycount + "个" + "路段信息 如下：\n" + url1);

                        if (segmentArraycount == 0)//只显示第一条
                        {
                            MPolyline mp;
                            map.Children.Add(mp = new MPolyline()
                            {
                                LngLats = sender.Routes[routescount].SegmentArray[segmentArraycount].LngLats,
                                LineColor = Colors.Green,
                                LineThickness = 6
                            });
                            //根据覆盖物来调整视野
                            map.SetFitview(list);
                            list.Add(mp);
                            return;
                        }
                    }
                }
                ////根据覆盖物来调整视野
                //map.SetFitview(list);
            }
        }

        private void Rbut_Click(object sender, RoutedEventArgs e)
        {
            if (start == null || end == null)
            {
                MessageBox.Show("请在地图上点击确认起点终点！");
                return;
            }
            MBusRouteSearch.BusSearchByTwoPoi(start.LngX, start.LatY, end.LngX, end.LatY, cityCode.Text, CallBack);
        }
    }
}