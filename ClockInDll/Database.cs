using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data.SQLite;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;

namespace ClockInDll
{
    public class Database
    {
        DataTable timecard;
        string connection_string;
        List<string> users;

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

            connection_string = "Data Source = ClockInDB.db; Version = 3;";
            using (SQLiteConnection connection = new SQLiteConnection(connection_string))
            {
                try
                {
                    connection.Open();
                }
                catch (Exception x)
                {
                    MessageBox.Show("Failed to connect to the database. Please try again. " + x.ToString());
                }
            }

            ReadUsersFromDatabase();
            PopulateFullTimecard();
        }

        /// <summary>
        /// Builds Database. Generates .db file in bin/debug
        /// Used to create the necessary database if it doesn't already exist
        /// </summary>
        private void BuildDB()
        {
            if(!File.Exists("ClockInDB.db"))
            {
                SQLiteConnection.CreateFile("ClockInDB.db");
            }
        }

        /// <summary>
        /// Retrieve a list of all the users and add them to a list.
        /// </summary>
        private void ReadUsersFromDatabase()
        {
            using(SQLiteConnection connection = new SQLiteConnection(connection_string))
            {
                using(SQLiteCommand command = new SQLiteCommand(connection))
                {
                    SQLiteDataReader reader;
                    command.CommandText = "SELECT * FROM Users";
                    users = new List<string>();

                    reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        users.Add(reader.GetString(0));
                    }
                }
            }
        }

        /// <summary>
        /// Populates DataTable data member with the full timecard 
        /// (for launch screen)
        /// </summary>
        private void PopulateFullTimecard()
        {
            using (SQLiteConnection connection = new SQLiteConnection(connection_string))
            {
                using(SQLiteCommand command = new SQLiteCommand(connection))
                {
                    using(SQLiteDataAdapter adapter = new SQLiteDataAdapter(command))
                    {
                        timecard = new DataTable();
                        adapter.Fill(timecard);
                    }
                }
            }
        }

        /// <summary>
        /// Adds the users name to the Users table
        /// </summary>
        /// <param name="UserName"></param>
        public void CreateUser(string UserName)
        {
            using (SQLiteConnection connection = new SQLiteConnection(connection_string))
            {
                using (SQLiteCommand command = new SQLiteCommand())
                {
                    command.CommandText = "INSERT INTO TABLE Users (name) VALUES('" + UserName + "');";
                    try
                    {
                        command.ExecuteNonQuery();
                    }
                    catch (Exception x)
                    {
                        MessageBox.Show("Failed to add user. Please try again. " + x.ToString());
                    }
                }
            }
            
        }
    }
}
