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

namespace WindowsPhone7App.SearchSamples
{
    public partial class BusLineSearch : PhoneApplicationPage
    {
        public BusLineSearch()
        {
            InitializeComponent();
        }

        private void map_MapLoaded(object sender, MapEventArgs e)
        {
            // BusLineSearchWithOption();
        }
        private void BusLineSearchWithOption()
        {
            MBusLineSearchOption busLineSearchOpt = new MBusLineSearchOption();
            busLineSearchOpt.Batch = 1;//bug 显示的第1000页没有查询结果
            busLineSearchOpt.CityCode = cityCode.Text; //设置了个不存在的城市代码，也能搜出结果
            busLineSearchOpt.Config = "BusLine";
            busLineSearchOpt.Encode = "GBK";
            //busLineSearchOpt.Ids = "";
            busLineSearchOpt.Number = 1;
            busLineSearchOpt.ResData = 0;
            //  busLineSearchOpt.BusName = "运通113";
            busLineSearchOpt.StationName = station.Text;
            MBusLineSearch.BusLineSearchWithOption(busLineSearchOpt, CallBack);
        }


        void CallBack(MBusLineSearchResult sender)
        {
            //  MessageBox.Show("通过查询参数类搜索公交引导信息 如下：\nCount：" + sender.Count.ToString() + " Record：" + sender.Record.ToString() + " SearchTime：" + sender.SearchTime.ToString() + " Total：" + sender.Total.ToString() + " BusLineList.count：" + sender.BusLineList.Count);

            if (sender.Erro == null)
            {

                for (int i = 0; i < sender.BusLineList.Count; i++)
                {
                    string url = "Air：" + sender.BusLineList[i].Air + "\n" + "AutoTicket：" + sender.BusLineList[i].AutoTicket + "\n" + "BasicPrice：" + sender.BusLineList[i].BasicPrice + "\n" + "CommutationTicket：" + sender.BusLineList[i].CommutationTicket + "\n" + "Company：" + sender.BusLineList[i].Company + "\n" + "CoorDesc：" + sender.BusLineList[i].CoorDesc + "\n" + "DataSource：" + sender.BusLineList[i].DataSource + "\n" + "Description：" + sender.BusLineList[i].Description + "\n" + "DoubleDeck：" + sender.BusLineList[i].DoubleDeck + "\n" + "EndTime：" + sender.BusLineList[i].EndTime + "\n" + "ExpressWay：" + sender.BusLineList[i].ExpressWay + "\n" + "FrontName：" + sender.BusLineList[i].FrontName + "\n" + "FrontSpell：" + sender.BusLineList[i].FrontSpell + "\n" + "IcCard：" + sender.BusLineList[i].IcCard + "\n" + "Interval1：" + sender.BusLineList[i].Interval1 + "\n" + "Interval2：" + sender.BusLineList[i].Interval2 + "\n" + "Interval3：" + sender.BusLineList[i].Interval3 + "\n" + "Interval4：" + sender.BusLineList[i].Interval4 + "\n" + "Interval5：" + sender.BusLineList[i].Interval5 + "\n" + "Interval6：" + sender.BusLineList[i].Interval6 + "\n" + "Interval7：" + sender.BusLineList[i].Interval7 + "\n" + "Interval8：" + sender.BusLineList[i].Interval8 + "\n" + "KeyName：" + sender.BusLineList[i].KeyName + "\n" + "Length：" + sender.BusLineList[i].Length + "\n" + "LineId：" + sender.BusLineList[i].LineId + "\n" + "Loop：" + sender.BusLineList[i].Loop + "\n" + "Name：" + sender.BusLineList[i].Name + "\n" + "ServicePeriod：" + sender.BusLineList[i].ServicePeriod + "\n" + "Speed：" + sender.BusLineList[i].Speed + "\n" + "StartTime：" + sender.BusLineList[i].StartTime + "\n" + "StationDesc：" + sender.BusLineList[i].StationDesc + "\n" + "Status：" + sender.BusLineList[i].Status + "\n" + "TerminalName：" + sender.BusLineList[i].TerminalName + "\n" + "TerminalSpell：" + sender.BusLineList[i].TerminalSpell + "\n" + "TimeDesc：" + sender.BusLineList[i].TimeDesc + "\n" + "TimeInterval1：" + sender.BusLineList[i].TimeInterval1 + "\n" + "TimeInterval2：" + sender.BusLineList[i].TimeInterval2 + "\n" + "TimeInterval3：" + sender.BusLineList[i].TimeInterval3 + "\n" + "TimeInterval4：" + sender.BusLineList[i].TimeInterval4 + "\n" + "TimeInterval5：" + sender.BusLineList[i].TimeInterval5 + "\n" + "TimeInterval6：" + sender.BusLineList[i].TimeInterval6 + "\n" + "TimeInterval7：" + sender.BusLineList[i].TimeInterval7 + "\n" + "TimeInterval8：" + sender.BusLineList[i].TimeInterval8 + "\n" + "TotalPrice：" + sender.BusLineList[i].TotalPrice + "\n" + "Type：" + sender.BusLineList[i].Type;
                    MessageBox.Show("第" + i + "个BusLine信息如下：\n" + url);

                    searchBusInfoById(sender.BusLineList[i].LineId, cityCode.Text);
                }


            }
            else
            {
                MessageBox.Show(sender.Erro.Message);
            }
        }

        /// <summary>
        /// 根据公交id查询公交引导信息搜索  
        /// </summary>
        /// <param name="id"></param>
        /// <param name="city"></param>
        private void searchBusInfoById(string id, string city)
        {
            MBusLineSearch.BusSearchByBusId(id, city, busInfoByIdCallBack);      //110100011424：26路lineid               
        }
        void busInfoByIdCallBack(MBusLineSearchResult sender)
        {
            if (sender.Erro == null)
            {
                string url = "";
                List<MOverlay> list = new List<MOverlay>();

                for (int i = 0; i < sender.BusLineList.Count; i++)
                {
                    url = "Air：" + sender.BusLineList[i].Air + "\n" + "AutoTicket：" + sender.BusLineList[i].AutoTicket + "\n" + "BasicPrice：" + sender.BusLineList[i].BasicPrice + "\n" + "CommutationTicket：" + sender.BusLineList[i].CommutationTicket + "\n" + "Company：" + sender.BusLineList[i].Company + "\n" + "CoorDesc：" + sender.BusLineList[i].CoorDesc + "\n" + "DataSource：" + sender.BusLineList[i].DataSource + "\n" + "Description：" + sender.BusLineList[i].Description + "\n" + "DoubleDeck：" + sender.BusLineList[i].DoubleDeck + "\n" + "EndTime：" + sender.BusLineList[i].EndTime + "\n" + "ExpressWay：" + sender.BusLineList[i].ExpressWay + "\n" + "FrontName：" + sender.BusLineList[i].FrontName + "\n" + "FrontSpell：" + sender.BusLineList[i].FrontSpell + "\n" + "IcCard：" + sender.BusLineList[i].IcCard + "\n" + "Interval1：" + sender.BusLineList[i].Interval1 + "\n" + "Interval2：" + sender.BusLineList[i].Interval2 + "\n" + "Interval3：" + sender.BusLineList[i].Interval3 + "\n" + "Interval4：" + sender.BusLineList[i].Interval4 + "\n" + "Interval5：" + sender.BusLineList[i].Interval5 + "\n" + "Interval6：" + sender.BusLineList[i].Interval6 + "\n" + "Interval7：" + sender.BusLineList[i].Interval7 + "\n" + "Interval8：" + sender.BusLineList[i].Interval8 + "\n" + "KeyName：" + sender.BusLineList[i].KeyName + "\n" + "Length：" + sender.BusLineList[i].Length + "\n" + "LineId：" + sender.BusLineList[i].LineId + "\n" + "Loop：" + sender.BusLineList[i].Loop + "\n" + "Name：" + sender.BusLineList[i].Name + "\n" + "ServicePeriod：" + sender.BusLineList[i].ServicePeriod + "\n" + "Speed：" + sender.BusLineList[i].Speed + "\n" + "StartTime：" + sender.BusLineList[i].StartTime + "\n" + "StationDesc：" + sender.BusLineList[i].StationDesc + "\n" + "Status：" + sender.BusLineList[i].Status + "\n" + "TerminalName：" + sender.BusLineList[i].TerminalName + "\n" + "TerminalSpell：" + sender.BusLineList[i].TerminalSpell + "\n" + "TimeDesc：" + sender.BusLineList[i].TimeDesc + "\n" + "TimeInterval1：" + sender.BusLineList[i].TimeInterval1 + "\n" + "TimeInterval2：" + sender.BusLineList[i].TimeInterval2 + "\n" + "TimeInterval3：" + sender.BusLineList[i].TimeInterval3 + "\n" + "TimeInterval4：" + sender.BusLineList[i].TimeInterval4 + "\n" + "TimeInterval5：" + sender.BusLineList[i].TimeInterval5 + "\n" + "TimeInterval6：" + sender.BusLineList[i].TimeInterval6 + "\n" + "TimeInterval7：" + sender.BusLineList[i].TimeInterval7 + "\n" + "TimeInterval8：" + sender.BusLineList[i].TimeInterval8 + "\n" + "TotalPrice：" + sender.BusLineList[i].TotalPrice + "\n" + "Type：" + sender.BusLineList[i].Type;


                    // MessageBox.Show("通过公交线路id搜索公交引导信息 如下：\nCount：" + sender.Count.ToString() + " Record：" + sender.Record.ToString() + " SearchTime：" + sender.SearchTime.ToString() + " Total：" + sender.Total.ToString() + " BusLineList信息：" + url);

                    MPolyline mp;
                    map.Children.Add(mp = new MPolyline()
                    {
                        LngLats = sender.BusLineList[i].LngLats,
                        LineColor = Colors.Green,
                        LineThickness = 6
                    });
                    list.Add(mp);
                    map.Children.Add(new MMarker()
                {
                    LngLat = mp.LngLats[0],
                    IsEditable = true,
                    IconURL = "/bus_start_pic.jpg",
                    Anchor = new Point(0.5, 1)
                });
                    map.Children.Add(new MMarker()
                    {
                        LngLat = mp.LngLats[mp.LngLats.Count - 1],
                        IconURL = "/bus_end_pic.jpg",
                        Anchor = new Point(0.5, 1)
                    });

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
            BusLineSearchWithOption();
        }
    }
}