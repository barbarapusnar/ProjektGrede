using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Xml;

namespace ProjektGrede
{
    public class BranjeXML
    {
        public static Vreme Branje()
        {
            HttpClient client = new HttpClient();
            //client.DefaultRequestHeaders.Accept.Add(
            //   new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/xml"));
            DateTime sedaj = DateTime.Now;
            int leto = sedaj.Year;int mesec = sedaj.Month;string m;
            if (mesec < 10)
                m = "0" + mesec;
            else
                m =""+ mesec;
            int zadnji = DateTime.DaysInMonth(leto, mesec);
            string naslov = "http://agromet.mkgp.gov.si/APP/Content/Exports/11_" + leto + m + "01000000_" + leto + m + zadnji + "235959_30_.xml";
            HttpResponseMessage response = client.GetAsync(new Uri(naslov)).Result;
            if (response.IsSuccessStatusCode)
            {
                try
                {
                    Vreme podatek = new Vreme();
                    var xmlMeteo = response.Content.ReadAsStreamAsync().Result;
                    string xmlString = new StreamReader(xmlMeteo).ReadToEnd();
                    using (XmlReader reader = XmlReader.Create(new StringReader(xmlString)))
                    {
                        while (reader.Read())
                        {
                            if (reader.IsStartElement())
                            {
                                switch (reader.Name)
                                {
                                    case "Date":
                                        podatek.Date = DateTime.Parse(reader.ReadElementContentAsString());
                                        break;
                                    case "Temp2":
                                        podatek.Temp2 =decimal.Parse(reader.ReadElementContentAsString());
                                        break;
                                    case "Humidity2":
                                        podatek.Humidity2 = decimal.Parse(reader.ReadElementContentAsString());
                                        break;
                                    case "Precipitation":
                                        podatek.Precipitation = decimal.Parse(reader.ReadElementContentAsString());
                                        break;
                                    //mogoče še omočenost listov, min, max vrednosti
                                }
                            }
                        }
                    }
                    return podatek;
                }
                catch { return null; }
            }
            else
            { return null; }
        }
    }
}