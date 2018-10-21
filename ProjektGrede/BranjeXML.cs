using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Xml;
using ProjektGrede.Models;
using System.Xml.Serialization;

namespace ProjektGrede
{
    public class BranjeXML
    {
        //1l/m2=1mm
        //http://agromet.mkgp.gov.si/APP/Content/Exports/11_20181001000000_20181031235959_24_MVal.dat
        //prebere vse podatke, ne glede na datum
        public static Vreme Branje()
        {
            HttpClient client = new HttpClient();
            //List<string> vsiPodatki = new List<string>();
            DateTime sedaj = DateTime.Now;
            int leto = sedaj.Year;int mesec = sedaj.Month;string m;
            if (mesec < 10)
                m = "0" + mesec;
            else
                m =""+ mesec;
            int zadnji = DateTime.DaysInMonth(leto, mesec);
            string naslov = "http://agromet.mkgp.gov.si/APP/Content/Exports/11_" + leto + m + "01000000_" + leto + m + zadnji + "235959_24_.xml";
            HttpResponseMessage response = client.GetAsync(new Uri(naslov)).Result;
            List<AGROMETDATA> vsiPodatki = new List<AGROMETDATA>();
            Vreme podatek = new Vreme();
            if (response.IsSuccessStatusCode)
            {
                var xmlMeteo = response.Content.ReadAsStreamAsync().Result;
                XmlSerializer xml = new XmlSerializer(typeof(AGROMET));
                AGROMET vseSkupaj = (AGROMET)xml.Deserialize(xmlMeteo);
                vsiPodatki = vseSkupaj.DATA.ToList<AGROMETDATA>();
               
                int zadnjiP = vsiPodatki.Count - 1;
                var x = vsiPodatki[zadnjiP];
                podatek.Date = x.Date;
                podatek.Humidity2 = x.Humidity2;
                podatek.Leafwetness2 = x.Leafwetness2;
                podatek.Temp2 = x.Temp2;
                podatek.Precipitation = x.Precipitation;
            }
                    return podatek;         
            }
        public static decimal BranjePadavin(DateTime d1, DateTime d2)
        {
            HttpClient client = new HttpClient();
            decimal vsotaPadavin = 0;
            List<AGROMETDATA> vsiPodatki = new List<AGROMETDATA>();
            List<AGROMETDATA> vsiPodatki1 = new List<AGROMETDATA>();
            TimeSpan ts = d2 - d1;
            //če sta dauma v različnih mesecih, moram brati dve datoteki
            int mesec = d2.Month; string m;
            if (mesec < 10)
                m = "0" + mesec;
            else
                m = "" + mesec;
            int mesec1 = d1.Month; string m1;
            if (mesec1 < 10)
                m1 = "0" + mesec1;
            else
                m1 = "" + mesec1;
            string naslov = ""; string naslov1 = "";
            int zadnji2 = DateTime.DaysInMonth(d2.Year, d2.Month);
            if (d1.Month == d2.Month)
            {

                naslov = "http://agromet.mkgp.gov.si/APP/Content/Exports/11_" + d2.Year + m + "01000000_" + d2.Year + m + zadnji2 + "235959_24_.xml";
            }
            else
            {
                int zadnji1 = DateTime.DaysInMonth(d1.Year, d1.Month);
                naslov = "http://agromet.mkgp.gov.si/APP/Content/Exports/11_" + d1.Year + m1 + "01000000_" + d1.Year + m1 + zadnji1 + "235959_24_.xml";
                naslov1 = "http://agromet.mkgp.gov.si/APP/Content/Exports/11_" + d2.Year + m + "01000000_" + d2.Year + m + zadnji2 + "235959_24_.xml";

            }

            HttpResponseMessage response = client.GetAsync(new Uri(naslov)).Result;
            if (response.IsSuccessStatusCode)
            {
               
                    var xmlMeteo = response.Content.ReadAsStreamAsync().Result;
                    XmlSerializer xml = new XmlSerializer(typeof(AGROMET));
                    AGROMET vseSkupaj = (AGROMET)xml.Deserialize(xmlMeteo);
                    vsiPodatki = vseSkupaj.DATA.ToList<AGROMETDATA>();
               
            }

           //preskok meseca
            if (!String.IsNullOrEmpty(naslov1))
                {
                    HttpResponseMessage response1 = client.GetAsync(new Uri(naslov1)).Result;
                    if (response1.IsSuccessStatusCode)
                    {
                        var xmlMeteo1 = response1.Content.ReadAsStreamAsync().Result;
                        XmlSerializer xml1 = new XmlSerializer(typeof(AGROMET));
                        AGROMET vseSkupaj1 = (AGROMET)xml1.Deserialize(xmlMeteo1);
                        vsiPodatki1 = vseSkupaj1.DATA.ToList<AGROMETDATA>();

                    }
                }
            //trenutno ne vem, če rabim
            //zapiši v bazo vse padavine 
            //GredeEntities ge = new GredeEntities();
            foreach (var x in vsiPodatki)
            {
                if (x.Date >= d1 && x.Date <= d2)
                {
                    //PrevzemArso p = new PrevzemArso();
                    //p.Datum = x.Date;
                    //p.Padavine = x.Precipitation;
                    //ge.PrevzemArso.Add(p);
                    vsotaPadavin += x.Precipitation;
                }
            }

            foreach (var x in vsiPodatki1)
            {
                if (x.Date >= d1 && x.Date <= d2)
                {
                    //PrevzemArso p = new PrevzemArso();
                    //p.Datum = x.Date;
                    //p.Padavine = x.Precipitation;
                    //ge.PrevzemArso.Add(p);
                    vsotaPadavin += x.Precipitation;
                }
            }
            //ge.SaveChanges();
            return vsotaPadavin;
            }
        }
    }
  
