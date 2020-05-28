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

/*
*   Author: Brett Bertrand
*   Project: EagleCapClockIn
*   Date: 5/27/2020
*   Purpose: This objects purpose is to interface with the dataTable in the database
*/
namespace TimeCardGUI
{
    /// <summary>
    /// TimeCard Database Interface Object
    /// </summary>
    public class TimeCardInterface
    {
        public enum TimeCategory
        {
            DAY, WEEK, MONTH, QUARTER
        }
        public enum Clocked { IN, OUT }
        public TimeCardInterface(DataTable table)
        {
            timeCard = table;
        }

        // Public Methods

        /// <summary>
        /// Punches the Time Clock (Clock in or out dependent on users current state and returns that state)
        /// </summary>
        /// <returns>int</returns>
        public int TimePunch()
        {
            throw new NotImplementedException("TimePunch method not implimented yet");
        }

        /// <summary>
        /// Prompt user for description and write to the TimeCard
        /// </summary>
        /// <param name="description">String</param>
        private void SetDescription(String description)
        {
            throw new NotImplementedException("SetDescription method not implimented yet");
        }

        /// <summary>
        /// Returns a float representing the hours worked
        /// </summary>
        /// <param name="startDate">DateTime</param>
        /// <param name="stopDate">DateTime</param>
        /// <returns>float</returns>
        public float GetTime(DateTime startDate, DateTime stopDate)
        {
            throw new NotImplementedException("GetTime(DateTime) method not implimented yet");
        }

        /// <summary>
        /// Returns a float representing the hours worked
        /// </summary>
        /// <param name="startDate">DateTime</param>
        /// <param name="timeCategory">TimeCategory</param>
        /// <param name="timeOffset">Int</param>
        /// <returns></returns>
        public float GetTime(DateTime startDate, TimeCategory timeCategory, int timeOffset)
        {
            throw new NotImplementedException("GetTime(TimeCategory) method not implimented yet");
        }

        // Private Methods

        /// <summary>
        /// Clocks User In
        /// </summary>
        public void ClockIn()
        {
            throw new NotImplementedException("ClockIn method not implimented yet");
        }

        /// <summary>
        /// Clocks User Out
        /// </summary>
        public void ClockOut()
        {
            throw new NotImplementedException("ClockOut method not implimented yet");
        }

        // Getters/Setters
        public String Username { get; set; }
        public List<String> Users { get; set; }

        // Member Data
        private DataTable timeCard;
        private String username;
        private List<String> users;
        public Clocked UserState = Clocked.OUT;
    }
}
