using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace PowerCSharp.OperationSystem
{
    class MyEventLog
    {
        public void test()
        {
            // 方法一，全部抓回來再filter
            GetEventLog();

            // 方法二，可以遠端filter
            QueryRemoteEventLog();

        }


        // 只能全部抓回來再filter
        public static void GetEventLog()
        {
            // EventLogEntryCollection.Item[Int32] Property
            // https://docs.microsoft.com/zh-tw/dotnet/api/system.diagnostics.eventlogentrycollection.item?view=netframework-4.7.1

            // Create a new EventLog object.
            //EventLog myEventLog1 = new EventLog();
            //myEventLog1.Log = "Application";

            EventLog myEventLog1 = new EventLog("Application", "TPEREPL1");
            // Obtain the Log Entries of the Event Log
            EventLogEntryCollection myEventLogEntryCollection = myEventLog1.Entries;
            Console.WriteLine("The number of entries in 'Application' = " +
                                    myEventLogEntryCollection.Count);
            // Display the 'Message' property of EventLogEntry.
            for (int i = 0; i < myEventLogEntryCollection.Count; i++)
            {
                Console.WriteLine("The Message of the EventLog is :" +
                                        myEventLogEntryCollection[i].Message);
            }
        }


        public static void QueryRemoteEventLog()
        {
            //string queryString = "*[System/Level=2]"; // XPATH Query
            //string queryString = "<QueryList>" +
            //                                    "<Query Id=\"0\" Path=\"Application\">" +
            //                                    "<Select Path=\"Application\">*[System[(EventID=14151) and TimeCreated[@SystemTime&gt;='2017-11-21T18:00:00.000Z']]]</Select>" +
            //                                    "</Query>" +
            //                                    "</QueryList>";


            string startTime = DateTime.Now.AddSeconds(-90).ToString("yyyy-MM-ddTHH:mm:ss.fffZ");
            string endTime = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss.fffZ");


            string queryString = "<QueryList>" +
                                                 "<Query Id=\"0\" Path=\"Application\">" +
                                                 "<Select Path=\"Application\">*[System[(EventID=14151) and TimeCreated[@SystemTime&gt;='" + startTime + "' and @SystemTime&lt;='" + endTime + "']]]</Select>" +
                                                 "</Query>" +
                                                 "</QueryList>";

            Console.WriteLine(queryString);

            SecureString pw = GetPassword();

            EventLogSession session = new EventLogSession(
                "TPEREPL1",                               // Remote Computer
                "TUTORABC",                                  // Domain
                "bradchen",                                // Username
                pw,
                SessionAuthentication.Default);

            pw.Dispose();

            // Query the Application log on the remote computer.
            EventLogQuery query = new EventLogQuery("Application", PathType.LogName, queryString);
            query.Session = session;

            try
            {
                EventLogReader logReader = new EventLogReader(query);

                // Display event info
                DisplayEventAndLogInformation(logReader);
            }
            catch (EventLogException e)
            {
                Console.WriteLine("Could not query the remote computer! " + e.Message);
                return;
            }
        }

        /// <summary>
        /// Displays the event information and log information on the console for 
        /// all the events returned from a query.
        /// </summary>
        private static void DisplayEventAndLogInformation(EventLogReader logReader)
        {
            for (EventRecord eventInstance = logReader.ReadEvent();
                null != eventInstance; eventInstance = logReader.ReadEvent())
            {
                if (eventInstance.Id == 14151)
                {
                    Console.WriteLine("-----------------------------------------------------");
                    Console.WriteLine("Event ID: {0}", eventInstance.Id);
                    Console.WriteLine("Publisher: {0}", eventInstance.ProviderName);
                }

                try
                {
                    Console.WriteLine("Description: {0}", eventInstance.FormatDescription());
                }
                catch (EventLogException e)
                {
                    Console.WriteLine(e.Message);
                    // The event description contains parameters, and no parameters were 
                    // passed to the FormatDescription method, so an exception is thrown.

                }

                // Cast the EventRecord object as an EventLogRecord object to 
                // access the EventLogRecord class properties
                EventLogRecord logRecord = (EventLogRecord)eventInstance;
                Console.WriteLine("Container Event Log: {0}", logRecord.ContainerLog);
            }
        }

        /// <summary>
        /// Read a password from the console into a SecureString
        /// </summary>
        /// <returns>Password stored in a secure string</returns>
        public static SecureString GetPassword()
        {
            SecureString password = new SecureString();
            Console.WriteLine("Enter password: ");

            // get the first character of the password
            ConsoleKeyInfo nextKey = Console.ReadKey(true);

            while (nextKey.Key != ConsoleKey.Enter)
            {
                if (nextKey.Key == ConsoleKey.Backspace)
                {
                    if (password.Length > 0)
                    {
                        password.RemoveAt(password.Length - 1);

                        // erase the last * as well
                        Console.Write(nextKey.KeyChar);
                        Console.Write(" ");
                        Console.Write(nextKey.KeyChar);
                    }
                }
                else
                {
                    password.AppendChar(nextKey.KeyChar);
                    Console.Write("*");
                }

                nextKey = Console.ReadKey(true);
            }

            Console.WriteLine();

            // lock the password down
            password.MakeReadOnly();
            return password;
        }


    }
}
