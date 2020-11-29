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
        SQLiteCommand command;
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
            BuildDB();
            connection = new SQLiteConnection("Data Source = ClockInDB.db; Version = 3;");
            command = connection.CreateCommand();
            try
            {
                connection.Open();
            }
            catch(Exception x)
            {
                MessageBox.Show("Failed to connect to the database. Please try again. " + x.ToString());
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

        /// <summary>
        /// Adds the users name to the Users table
        /// </summary>
        /// <param name="UserName"></param>
        public void CreateUser(string UserName)
        {
            command.CommandText = "INSERT INTO TABLE Users (name) VALUES('" + UserName + "');";
            try
            {
                command.ExecuteNonQuery();
            }
            catch(Exception x)
            {
                MessageBox.Show("Failed to add user. Please try again. " + x.ToString());
            }
        }
    }
}
