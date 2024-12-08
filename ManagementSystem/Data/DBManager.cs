using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ManagementSystem.Components.Pages;
using ManagementSystem.Exceptions;
using Microsoft.Maui.Graphics;
using MySqlConnector;

namespace ManagementSystem
{
    internal class DBManager
    {
        internal DBManager()
        {
        }

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
                catch (DBConnectionException e)
                {
                    Debug.WriteLine("Connection failed: " + e.Message);
                }
            }
        }

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
                catch (DBConnectionException e)
                {
                    Debug.WriteLine("Connection failed: " + e.Message);
                }
            }
        }

        public static void InsertEvent(string eventName, string eventDate, string eventLocation, string eventDescription, string connStr)
        {
            string insertEventQueryStr = "INSERT INTO EventManagementDatabase.Events(EventName, EventDate, EventLocation, EventDescription) VALUES (@EventName, @EventDate, @EventLocation, @EventDescription)";

            using (var conn = new MySqlConnection(connStr))
            {
                try
                {
                    // Create the SQL command to Insert the Event
                    MySqlCommand insertEvent = new MySqlCommand(insertEventQueryStr, conn);

                    // Open the connection
                    conn.Open();

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
                catch (Exception e)
                {
                    Debug.WriteLine("Error inserting event " + e.Message);
                }
            }
        }
    }
}
