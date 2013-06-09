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
using Com.AMap.Maps.Api.BaseTypes;
using Com.AMap.Maps.Api.Overlays;
using Com.AMap.Maps.Api;

namespace WindowsPhone7App.SearchSamples
{
    public partial class ReGeoCode : PhoneApplicationPage
    {
        public ReGeoCode()
        {
            InitializeComponent();
            map.Tap += new EventHandler<System.Windows.Input.GestureEventArgs>(map_Tap);
        }

        void map_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            Point p = e.GetPosition(map);//获得在map容器的像素坐标
            MLngLat xy = map.FromScreenPixelToLngLat(p);//确定经纬度
            x = xy.LngX;
            y = xy.LatY;
            ReGeoCodeToAddressWithOption();
            map.Tap -= new EventHandler<System.Windows.Input.GestureEventArgs>(map_Tap);
        }

        private void map_MapLoaded(object sender, MapEventArgs e)
        {
            //ReGeoCodeToAddressWithOption();
        }

        double x = 116.324735831984;
        double y = 39.9081397215191;

        private void ReGeoCodeToAddressWithOption()
        {
            MReverseGeocodingOption opt = new MReverseGeocodingOption();
            opt.Config = "SPAS";
            opt.CrossNumber = 1;
            opt.Encode = "GBK";
            opt.MultiPoint = 1;
            opt.Pattern = 1;
            opt.PoiNumber = 20;
            opt.Range = 10000;
            opt.RoadNumber = 1;
            //opt.X = 116.415611575797;
            //opt.Y = 39.9266989496153;
            opt.XCoors = new double[] { x };
            opt.YCoors = new double[] { y };
            opt.RoadLevel = 1;
            MReGeoCode.GeoCodeToAddressWithOption(opt, CallBack);
        }

        void CallBack(MReverseGeoCodingResult sender)
        {
            if (sender.Erro == null)
            {
             //   MessageBox.Show("resultList.count：" + sender.resultList.Count.ToString());
                List<MOverlay> list = new List<MOverlay>();
                for (int i = 0; i < sender.resultList.Count; i++)
                {
                    //MessageBox.Show("City" + sender.resultList[i].City + "\nCrosses.count" + sender.resultList[i].Crosses.Count + "\nDistrict\n" + "Bounds" + sender.resultList[i].District.Bounds + "Code" + sender.resultList[i].District.Code + "Name" + sender.resultList[i].District.Name + "X" + sender.resultList[i].District.X + "Y" + sender.resultList[i].District.Y + "\nPois.count" + sender.resultList[i].Pois.Count + "\nProvince\n" + "Code" + sender.resultList[i].Province.Code + "Code" + sender.resultList[i].Province.Name + "\nRoads.Count" + sender.resultList[i].Roads.Count.ToString());
                    //for (int j = 0; j < sender.resultList[i].Crosses.Count; j++)
                    //{
                    //    MessageBox.Show("第" + j + "个" + "Crosses信息 如下：\n" + "Name" + sender.resultList[i].Crosses[j].Name + ",X" + sender.resultList[i].Crosses[j].X + ",Y" + sender.resultList[i].Crosses[j].Y);
                    //}
                    //for (int k = 0; k < sender.resultList[i].Pois.Count; k++)
                    //{
                    //    MessageBox.Show("第" + k + "个" + "Pois信息 如下：\n" + "Address" + sender.resultList[i].Pois[k].Address + ",Code" + sender.resultList[i].Pois[k].Code + ",Distance" + sender.resultList[i].Pois[k].Distance + ",DriverDistance" + sender.resultList[i].Pois[k].DriverDistance + ",Match" + sender.resultList[i].Pois[k].Match + ",Name" + sender.resultList[i].Pois[k].Name + ",Pguid" + sender.resultList[i].Pois[k].Pguid + ",Tel" + sender.resultList[i].Pois[k].Tel + ",Type" + sender.resultList[i].Pois[k].Type + ",Url" + sender.resultList[i].Pois[k].Url + ",X" + sender.resultList[i].Pois[k].X + ",Y" + sender.resultList[i].Pois[k].Y);
                    //}
                    //for (int m = 0; m < sender.resultList[i].Roads.Count; m++)
                    //{
                    //    MessageBox.Show("第" + m + "个" + "Roads信息 如下：\n" + "Direction" + sender.resultList[i].Roads[m].Direction + ",Distance" + sender.resultList[i].Roads[m].Distance + ",Ename" + sender.resultList[i].Roads[m].Ename + ",Id" + sender.resultList[i].Roads[m].Id + ",Level" + sender.resultList[i].Roads[m].Level + ",Name" + sender.resultList[i].Roads[m].Name + ",Width" + sender.resultList[i].Roads[m].Width);
                    //}



                    for (int j = 0; j < sender.resultList[i].Pois.Count; j++)
                    {

                        MMarker mk;

                        map.Children.Add(mk = new MMarker()
                        {
                            LngLat = new MLngLat(sender.resultList[i].Pois[j].X, sender.resultList[i].Pois[j].Y),
                            TipFrameworkElement = new MTip() { Title = sender.resultList[i].Pois[j].Name, ContentText = sender.resultList[i].Pois[j].Address }
                        });
                        list.Add(mk);
                    }

                }
                //根据覆盖物来调整视野
                map.SetFitview(list);
            }
            else
            {
                MessageBox.Show(sender.Erro.Message);
            }
        }

    }
}