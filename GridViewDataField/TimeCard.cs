using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace GridViewDataField
{
    public class TimeCard
    {
        public enum TimeCategory
        { 
            DAY, WEEK, MONTH, QUARTER
        }
        public TimeCard() { }
        public void ClockIn()
        {
            throw new NotImplementedException("ClockIn method not implimented yet");
        }
        public void ClockOut()
        {
            throw new NotImplementedException("ClockOut method not implimented yet");
        }
        private void SetDescription()
        {
            throw new NotImplementedException("SetDescription method not implimented yet");
        }
        public float GetTime(DateTime fromDate, DateTime toDate)
        {
            throw new NotImplementedException("GetTime(DateTime) method not implimented yet");
        }

        public float GetTime(DateTime fromDate, TimeCategory timeCategory, int timeOffset)
        {
            throw new NotImplementedException("GetTime(TimeCategory) method not implimented yet");
        }

        // Member Data
        private TimeCardDataset m_timecard;
        public String Username { get; set; }
        private List<String> Users;
        private String XmlPath = "TimeCardXML.xml";
    }
}
