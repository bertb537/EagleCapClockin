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
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.CodeDom;

namespace ClockInDll
{
    public class Database
    {
        private DataTable timecard;
        private DataRow new_row;
        private List<string> users;
        private string connection_string;
        private string current_user;

        public DataTable Timecard
        { get { return timecard; } }

        public string CurrentUser
        { get { return current_user; } }

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
                    MessageBox.Show("Failed to connect to the database. \nPlease try again. \n" + x.ToString());
                }
            }

            ReadUsersFromDatabase();
            PopulateFullTimecard();
        }

        /// <summary>
        /// Builds Database. Generates .db file in bin/debug. 
        /// Used to create the necessary database if it doesn't already exist.
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
        /// Populates DataTable data member with the full timecard.
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
                        command.CommandText = "SELECT * FROM Timecard;";
                        timecard = new DataTable();
                        try
                        {
                            adapter.Fill(timecard);
                        }
                        catch(Exception x)
                        {
                            MessageBox.Show("There was an error retrieving data from the database. \nPlease try again. \n" + x.ToString());
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Adds the users name to the Users table.
        /// </summary>
        /// <param name="Username">string</param>
        public void CreateUser(string Username)
        {
            using (SQLiteConnection connection = new SQLiteConnection(connection_string))
            {
                using (SQLiteCommand command = new SQLiteCommand(connection))
                {
                    command.CommandText = "INSERT INTO TABLE Users (name) VALUES('" + Username + "');";
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

        /// <summary>
        /// Swap users and update the datatable.
        /// </summary>
        /// <param name="Username">string</param>
        /// <returns>DataTable</returns>
        public DataTable SwitchUser(string Username)
        {
            using(SQLiteConnection connection = new SQLiteConnection(connection_string))
            {
                using(SQLiteCommand command = new SQLiteCommand(connection))
                {
                    using(SQLiteDataAdapter adapter = new SQLiteDataAdapter(command))
                    {
                        command.CommandText = "SELECT * FROM Timecard WHERE name='" + Username + "';";
                        try
                        {
                            timecard = new DataTable();
                            adapter.Fill(timecard);
                        }
                        catch(Exception x)
                        {
                            MessageBox.Show("Failed to retrieve new user from the database. \nPlease try again. \n" + x.ToString());
                            return null;
                        }
                    }
                }
            }
            current_user = Username;
            return timecard;
        }

        /// <summary>
        /// Creates the first part of the new row and returns the time.
        /// </summary>
        /// <returns>DateTime</returns>
        public DateTime ClockIn()
        {
            DateTime now = DateTime.Now;
            new_row = timecard.NewRow();
            new_row["name"] = current_user;
            new_row["time_in"] = now;

            return now;
        }

        /// <summary>
        /// Fills in the rest of the row, adds it to the timecard, and returns it.
        /// </summary>
        /// <returns></returns>
        public DataTable ClockOut()
        {
            DateTime now = DateTime.Now;
            new_row["time_out"] = now;
            new_row["description"] = "";
            timecard.Rows.Add(new_row);

            return timecard;
        }
    }
}
