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
using Com.AMap.Search.API;
using Com.AMap.Search.API.Options;
using Com.AMap.Maps.Api.Events;
using Com.AMap.Maps.Api.Overlays;
using Com.AMap.Maps.Api.BaseTypes;
using Com.AMap.Maps.Api;

namespace WindowsPhone7App.SearchSamples
{
    public partial class POISearch : PhoneApplicationPage
    {
        public POISearch()
        {
            InitializeComponent();
        }
        private void map_MapLoaded(object sender, MapEventArgs e)
        {
           // RunPOISearch();
           // POISearchWithOption();
        }

        /// <summary>
        /// 根据MPOISearchOption对象设置搜索参数进行POI搜索。
        /// </summary>
        private void POISearchWithOption()
        {
            MPOISearchOption mPOISearchOption = new MPOISearchOption();
            mPOISearchOption.Batch = 1;
            mPOISearchOption.CenName = "肯德基";
            mPOISearchOption.CenX = 0.0;
            mPOISearchOption.CenY = 0.0;
            mPOISearchOption.CityCode = "010";
            mPOISearchOption.Config = "BELSBN";//固定值
          //  mPOISearchOption.Encode = "GBK";//utf-8 
            mPOISearchOption.Naviflag = 1;
            mPOISearchOption.Number = 20;
            mPOISearchOption.Range = 3000;
            mPOISearchOption.SearchName = "肯德基";
            mPOISearchOption.SearchType = "";
            mPOISearchOption.Sr = 0;//1按距离排序
            mPOISearchOption.SrcType = "POI";
            MPOISearch.PoiSearchWithOption(mPOISearchOption, searchCallBack); //bug total 和对象数组也不相同
        }

        void searchCallBack(MPOISearchResult sender)
        {
            // MessageBox.Show("关键字查询信息如下：\nCount：" + sender.Count.ToString() + " Record：" + sender.Record.ToString() + " Total：" + sender.Total.ToString() + " POIs.count：" + sender.POIs.Count);
            if (sender.Erro == null)
            {
                List<MOverlay> list = new List<MOverlay>();
                for (int i = 0; i < sender.POIs.Count; i++)
                {
                    MMarker mk;
                    //string url = "Address：" + sender.POIs[i].Address + "\n" + "Code：" + sender.POIs[i].Code + "\n" + "Distance：" + sender.POIs[i].Distance + "\n" + "DriverDistance：" + sender.POIs[i].DriverDistance + "\n" + "Match：" + sender.POIs[i].Match + "\n" + "Name：" + sender.POIs[i].Name + "\n" + "Pguid：" + sender.POIs[i].Pguid + "\n" + "Tel：" + sender.POIs[i].Tel + "\n" + "Type：" + sender.POIs[i].Type + "\n" + "Url：" + sender.POIs[i].Url + "\n" + "X：" + sender.POIs[i].X + "\n" + "Y：" + sender.POIs[i].Y + "\n";
                    //MessageBox.Show("第" + i + "个" + "关键字(肯德基)查询信息 如下：\n" + url);
                    map.Children.Add(mk = new MMarker()
                    {
                        LngLat = new MLngLat(sender.POIs[i].X, sender.POIs[i].Y),
                        TipFrameworkElement = new MTip() { Title = sender.POIs[i].Name, ContentText = sender.POIs[i].Address }
                    });
                    list.Add(mk);
                }

                //根据覆盖物来调整视野
                map.SetFitview(list);
            }
            else
            {
                MessageBox.Show(sender.Erro.Message);
            }
        }

        private void Rbut_Click(object sender, RoutedEventArgs e)
        {
            
            MPOISearch.PoiSearchByKeywords(RangABox.Text, cityCode.Text, searchCallBack);
        }
    }
}