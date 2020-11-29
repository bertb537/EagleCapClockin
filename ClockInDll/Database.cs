using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data.SQLite;
using System.Windows.Forms;

namespace ClockInDll
{
    public class Database
    {
        SQLiteConnection connection;
        SQLiteCommand cmd;
        public enum Clocked 
        {
            IN, OUT 
        }

        public enum TimeCategory
        {
            DAY, WEEK, MONTH, QUARTER
        }

        /// <summary>
        /// C'tor for the Database class.
        /// </summary>
        public Database()
        {
            connection = new SQLiteConnection("Data Source = ClockInDB.db; Version = 3;");
            cmd = connection.CreateCommand();
            try
            {
                connection.Open();
            }
            catch(Exception)
            {
                MessageBox.Show("Failed to Connect to the Database. Please try again.");
            }
        }

        /// <summary>
        /// Builds Database. Generates .db file in bin/debug
        /// Used to create the necessary database if it doesn't already exist
        /// </summary>
        public void BuildDB()
        {
            if(!File.Exists("ClockInDB.db"))
            {
                SQLiteConnection.CreateFile("ClockInDB.db");
            }
        }

        
    }
}
