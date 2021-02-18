using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DalApi.DO
{
    [Serializable]
   public class LineTrip
    {
        [XmlIgnore]
        public TimeSpan StartAt { get; set; }
        public int LindId { get; set; }
        public int Frequency { get; set; }
        [XmlIgnore]
        public TimeSpan FinishAt { get; set; }
        [XmlElement("FinishAt")]
        public string finishAt { get => FinishAt.ToString(); set { FinishAt = TimeSpan.Parse(value); } }
        [XmlElement("StartAt")]
        public String startAt { get => StartAt.ToString();set { StartAt = TimeSpan.Parse(value); } }
    }
}
