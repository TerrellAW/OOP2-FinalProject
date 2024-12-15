using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotNetEnv;
using ManagementSystem.Components.Pages;
using ManagementSystem.Exceptions;
using Microsoft.Maui.Graphics;
using MySqlConnector;

namespace ManagementSystem
{
    internal class DBManager
    {
        private string dbConnString = "";

        public string DbConnString
        {
            get
            {
                return dbConnString;
            }
        }

        internal DBManager()
        {
        }

        // Import the connection string from the environment variables
        public void SetConnStr()
        {
            // Load environment variables
            Env.Load();

            // Fetch Database connection string
            dbConnString = Environment.GetEnvironmentVariable("CONNECTION_STRING");
        }

        // Create the database if it does not exist
        public static void CreateDatabase(string connStr)
        {
            using (var conn = new MySqlConnection(connStr))
            {
                // Attempt to create the database if it does not exist
                try
                {
                    // Open the connection
                    conn.Open();

                    // Confirm the connection in the debug console
                    Debug.WriteLine("Database connection established.");

                    // Create the database if it does not exist
                    MySqlCommand createDB = new MySqlCommand(
                        "CREATE DATABASE IF NOT EXISTS EventManagementDatabase", 
                        conn);

                    // Execute the SQL command
                    createDB.ExecuteNonQuery();

                    // Close the connection
                    conn.Close();

                    // Confirm the database creation in the debug console
                    Debug.WriteLine("Database created successfully.");
                }
                catch (MySqlException e)
                {
                    Debug.WriteLine("Connection failed: " + e.Message);
                }
            }
        }

        // Create the table if it does not exist
        public static void CreateTable(string connStr)
        {
            using (var conn = new MySqlConnection(connStr))
            {
                try
                {
                    // Open the connection
                    conn.Open();

                    // Create the SQL command to create the table
                    MySqlCommand createTable = new MySqlCommand(
                        "CREATE TABLE IF NOT EXISTS EventManagementDatabase.Events (" +
                        "EventID INT PRIMARY KEY AUTO_INCREMENT, " +
                        "EventName VARCHAR(255), " +
                        "EventDate DATE, " +
                        "EventLocation VARCHAR(255), " +
                        "EventDescription TEXT)", 
                        conn);

                    // Execute the SQL command
                    createTable.ExecuteNonQuery();

                    // Close the connection
                    conn.Close();

                    // Confirm the table creation in the debug console
                    Debug.WriteLine("Table created successfully.");
                }
                catch (MySqlException e)
                {
                    Debug.WriteLine("Connection failed: " + e.Message);
                }
            }
        }

        // Get the maximum ID from the database
        public static int GetMaxID(MySqlConnection conn)
        {
            string getMaxIDQueryStr = "SELECT MAX({EventID}) FROM EventManagementDatabase.Events";

            try
            {
                using (var getMaxID = new MySqlCommand(getMaxIDQueryStr, conn))
                {
                    return (int)getMaxID.ExecuteScalar();
                }
            }
            catch (MySqlException e)
            {
                Debug.WriteLine("Error getting max ID " + e.Message);
                return 0;
            }
        }

        // Insert an event into the database
        public static void InsertEvent(string eventName, string eventDate, string eventLocation, string eventDescription, string connStr)
        {
            string insertEventQueryStr = "INSERT INTO EventManagementDatabase.Events(EventID, EventName, EventDate, EventLocation, EventDescription) VALUES (@EventID, @EventName, @EventDate, @EventLocation, @EventDescription)";

            using (var conn = new MySqlConnection(connStr))
            {
                try
                {
                    // Create the SQL command to Insert the Event
                    MySqlCommand insertEvent = new MySqlCommand(insertEventQueryStr, conn);

                    // Open the connection
                    conn.Open();

                    int maxID = GetMaxID(conn);
                    int currID;
                    
                    if (maxID == 0)
                    {
                        currID = 0;
                    }
                    else
                    {
                        currID = maxID++;
                    }

                    insertEvent.Parameters.AddWithValue("@EventID", currID);
                    insertEvent.Parameters.AddWithValue("@EventName", eventName);
                    insertEvent.Parameters.AddWithValue("@EventDate", eventDate);
                    insertEvent.Parameters.AddWithValue("@EventLocation", eventLocation);
                    insertEvent.Parameters.AddWithValue("@EventDescription", eventDescription);

                    // Execute the SQL command
                    insertEvent.ExecuteNonQuery();

                    // Close the connection
                    conn.Close();

                    //Confrim the event creation in the debug console
                    Debug.WriteLine("Event inserted successfully.");
                }
                catch (MySqlException e)
                {
                    Debug.WriteLine("Error inserting event " + e.Message);
                }
            }
        }

        // Remove an event from the database
        public static void RemoveEvent(string eventName, string eventDate, string connStr)
        {
            string removeEventQueryStr = "DELETE FROM EventManagementDatabase.Events WHERE EventName = @EventName AND EventDate = @EventDate";

            using (var conn = new MySqlConnection(connStr))
            {
                try
                {
                    // Create the SQL command to remove the event
                    MySqlCommand removeEvent = new MySqlCommand(removeEventQueryStr, conn);

                    // Open the connection
                    conn.Open();

                    removeEvent.Parameters.AddWithValue("@EventName", eventName);
                    removeEvent.Parameters.AddWithValue("@EventDate", eventDate);

                    // Execute the SQL command
                    removeEvent.ExecuteNonQuery();

                    // Close the connection
                    conn.Close();

                    // Confirm the event removal in the debug console
                    Debug.WriteLine("Event removed successfully.");
                }
                catch (MySqlException e)
                {
                    Debug.WriteLine("Error removing event " + e.Message);
                }
            }
        }

        public static void ReadDatabase(string connStr)
        {
            string readDatabaseQueryStr = "SELECT * FROM EventManagementDatabase.Events";

            using (var conn = new MySqlConnection(connStr))
            {
                try
                {
                    // Create the SQL command to read the database
                    MySqlCommand readDatabase = new MySqlCommand(readDatabaseQueryStr, conn);

                    // Clear the event list
                    Event.eventList = new SLL();

                    // Open the connection
                    conn.Open();

                    // Execute the SQL command
                    using (var reader = readDatabase.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Event @event = new Event(reader["EventName"].ToString(), reader["EventDate"].ToString().Substring(0, 10), reader["EventLocation"].ToString(), reader["EventDescription"].ToString());
                            Debug.WriteLine(reader["EventID"] + " " + reader["EventName"] + " " + reader["EventDate"] + " " + reader["EventLocation"] + " " + reader["EventDescription"]);
                            Event.eventList.Add(@event);
                        }
                    }

                    // Close the connection
                    conn.Close();

                    // Confirm the database read in the debug console
                    Debug.WriteLine("Database read successfully.");
                }
                catch (MySqlException e)
                {
                    Debug.WriteLine("Error reading database " + e.Message);
                }
            }
        }
    }
}
