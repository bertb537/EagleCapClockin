using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Media.Animation;
using System.Xml.Serialization;
using TimeCardGUI;

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
    public class TimeCardInterface : TimeCardDataSet
    {
        public enum TimeCategory
        {
            DAY, WEEK, MONTH, QUARTER
        }

        public enum Clocked { IN, OUT }

        public TimeCardInterface(ref TimeCardGUI.TimeCardDataSet timeCardDataSet_, 
            ref TimeCardGUI.TimeCardDataSetTableAdapters.TimeCardTableAdapter timeCardDataSetTimeCardTableAdapter_,
            ref System.Windows.Data.CollectionViewSource timeCardViewSource_)
        {
            userState = Clocked.OUT;
            timeCard = TimeCard;
            username = "Brett Bertrand";

            timeCardDataSet = timeCardDataSet_;
            timeCardDataSetTimeCardTableAdapter = timeCardDataSetTimeCardTableAdapter_;
            timeCardViewSource = timeCardViewSource_;
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
        /// Clocks User In
        /// </summary>
        public void ClockIn()
        {
            newRow = timeCardDataSet.TimeCard.NewRow();
            newRow[0] = username;
            newRow[1] = DateTime.Now.ToString();
            newRow[3] = "";
            timeCardDataSet.TimeCard.Rows.Add(newRow);
            userState = Clocked.IN;
            //timeCardDataSet.TimeCard.AddTimeCardRow((TimeCardRow)newRow);
        }

        /// <summary>
        /// Clocks User Out
        /// </summary>
        public void ClockOut()
        {
            newRow[2] = DateTime.Now.ToString();
            newRow[3] = "<Description>";
            userState = Clocked.OUT;
        }

        /// <summary>
        /// Prompt user for description and write to the TimeCard
        /// </summary>
        /// <param name="description">String</param>
        public void SetDescription(String description)
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

        // Getters/Setters
        public String Username { get; set; }
        public List<String> Users { get; set; }
        public Clocked UserState
        {
            get{ return userState; }
        }
        // Member Data
        private DataTable timeCard;
        private String username;
        private List<String> users;
        private Clocked userState;
        private DataRow newRow;

        private TimeCardGUI.TimeCardDataSet timeCardDataSet;
        private TimeCardGUI.TimeCardDataSetTableAdapters.TimeCardTableAdapter timeCardDataSetTimeCardTableAdapter;
        private System.Windows.Data.CollectionViewSource timeCardViewSource;
    }
}