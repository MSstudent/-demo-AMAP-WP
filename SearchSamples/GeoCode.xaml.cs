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
using Com.AMap.Search.API.Options;
using Com.AMap.Search.API;
using Com.AMap.Maps.Api.Overlays;
using Com.AMap.Maps.Api.BaseTypes;
using Com.AMap.Maps.Api;

namespace WindowsPhone7App.SearchSamples
{
    public partial class GeoCode : PhoneApplicationPage
    {
        public GeoCode()
        {
            InitializeComponent();
        }

        private void map_MapLoaded(object sender, MapEventArgs e)
        {
           // GeoCodeToAddressWithOption();
        }

        private void GeoCodeToAddressWithOption()
        {
            MGeoCodingOption geoCodingOpt = new MGeoCodingOption();
            geoCodingOpt.Address = addressBox.Text;
            //geoCodingOpt.Config = "";
            //geoCodingOpt.Encode = "";
            //geoCodingOpt.PoiNumber = 6;
            MGeoCode.AddressToGeoCodeWithOption(geoCodingOpt, CallBack);
        }

        void CallBack(MGeoCodingResult sender)
        {
            if (sender.Erro == null)
            {
                List<MOverlay> list = new List<MOverlay>();

               // MessageBox.Show("根据参数选项信息进行地理编码 如下：\n" + "count：" + sender.Count.ToString() + " GeoCodingList.count：" + sender.GeoCodingList.Count);
                for (int i = 0; i < sender.GeoCodingList.Count; i++)
                {
                    //MessageBox.Show("第" + i + "个" + "MGeoPOI信息如下：\n" + "Address" + sender.GeoCodingList[i].Address + "\nCity" + sender.GeoCodingList[i].City + "\nDistrict" + sender.GeoCodingList[i].District + "\nEaddress" + sender.GeoCodingList[i].Eaddress + "\nECity" + sender.GeoCodingList[i].ECity + "\nEdistrict" + sender.GeoCodingList[i].Edistrict + "\nEname" + sender.GeoCodingList[i].Ename + "\nEprovince" + sender.GeoCodingList[i].Eprovince + "\nLevel" + sender.GeoCodingList[i].Level + "\nName" + sender.GeoCodingList[i].Name + "\nProvince" + sender.GeoCodingList[i].Province + "\nRange" + sender.GeoCodingList[i].Range + "\nX" + sender.GeoCodingList[i].X + "\nY" + sender.GeoCodingList[i].Y);

                    MMarker mk;
                    
                    map.Children.Add(mk = new MMarker()
                    {
                        LngLat = new MLngLat(sender.GeoCodingList[i].X, sender.GeoCodingList[i].Y),
                        TipFrameworkElement = new MTip() { Title = sender.GeoCodingList[i].Name, ContentText = sender.GeoCodingList[i].Address }
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
            GeoCodeToAddressWithOption();
        }

    }
}