using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace DalApi.DO
{
    [Serializable]
    public class AdjacentStations
    { 
        public  int Station1 { get; set; }
        public  int Station2 { get; set; }
        public double Distance { get; set;  }
        [XmlIgnore]
        public TimeSpan Time { get; set; }
        [XmlElement("Time")]
        public string TimeToString { get
            {
                return Time.ToString();
            }
            set
            {
                Time=  TimeSpan.Parse(value);
            }
        }
    }
}
