using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace GridViewDataField
{
    public class TimeCardInterface
    {
        public enum TimeCategory
        {
            DAY, WEEK, MONTH, QUARTER
        }
        public TimeCardInterface(DataTable table) 
        {
            timeCard = table;
        }

        // Public Methods
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

        // Private Methods

        // Getters/Setters
        public String Username {get; set;}
        public List<String> Users { get; set; }

        // Member Data
        private DataTable timeCard;
        private String username;
        private List<String> users;
    }
}
