using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ManagementSystem.Exceptions;
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
    }
}
