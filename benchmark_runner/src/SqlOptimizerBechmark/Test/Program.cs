using System;
using System.Collections.Generic;
using System.Data.H2;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using SqlOptimizerBechmark.DbProviders;

namespace Test
{
    class Program
    {

        static void Main(string[] args)
        {
            DateTime t1 = DateTime.MinValue;
            DateTime t2;
            string connectionString = "Server=bayer.cs.vsb.cz;Database=SQLBench;Uid=sqlbench;Pwd=n3cUmubsbo;ConnectionReset=True;";

            MySqlConnection.ClearAllPools();

            MySqlConnection connection = new MySqlConnection();
            connection.ConnectionString = connectionString;
            connection.Open();

            MySqlCommand cmdTimeout = connection.CreateCommand();
            cmdTimeout.CommandText = "SET SESSION MAX_EXECUTION_TIME = 1000";
            cmdTimeout.ExecuteNonQuery();

            MySqlCommand theCmd = null;

            MySqlDataReader reader2 = null;

            for (int i = 0; i < 100; i++)
            {
                try
                {
                    Console.WriteLine("Loop {0} ...", i);

                    if (connection.State != System.Data.ConnectionState.Open)
                    {
                        connection.Open();
                    }

                    using (MySqlCommand cmdTimeoutRead = connection.CreateCommand())
                    {
                        cmdTimeoutRead.CommandText = "SHOW SESSION VARIABLES LIKE 'max_execution_time'";
                        MySqlDataReader reader = cmdTimeoutRead.ExecuteReader();
                        if (reader.Read())
                        {
                            object o = reader[1];
                            Console.WriteLine("MAX_EXECUTION_TIME = {0}", o);
                        }
                        reader.Close();
                    }

                    theCmd = connection.CreateCommand();
                    theCmd.CommandText = "SELECT a1.id, a1.groupby, a1.fkb, a1.search, a1.padding FROM A a1 JOIN B ON a1.fkb > B.id WHERE a1.search = 1 and B.search = 1";
                    theCmd.CommandTimeout = 0;
                    Console.WriteLine("Start of execution, timeout = {0}", theCmd.CommandTimeout);
                    t1 = DateTime.Now;

                    reader2 = theCmd.ExecuteReader();
                    int resultSize = 0;
                    while (reader2.Read())
                    {
                        DateTime tx = DateTime.Now;
                        TimeSpan sp = tx - t1;
                        if (sp.TotalMilliseconds > 1000)
                        {
                            Console.WriteLine("Interrupt query: {0}", resultSize);
                            break;
                        }
                        resultSize++;
                    }
                    reader2.Close();
                    reader2 = null;

                    Console.WriteLine("End of execution");

                    Console.WriteLine("Completed");
                }
                catch (MySqlException mySqlEx)
                {
                    Console.WriteLine("MySqlException: {0}", mySqlEx.Message);

                    if (theCmd != null)
                    {
                        theCmd.Cancel();
                    }

                    if (mySqlEx.Number == 3024)
                    {
                        Console.WriteLine("TIMEOUT");
                        t2 = DateTime.Now;
                        TimeSpan span = t2 - t1;
                        Console.WriteLine("span = {0}", span);
                        
                        //if (theCmd != null)
                        //{
                        //    connection.Close();
                        //    MySqlConnection.ClearAllPools();
                        //    connection.Open();
                        //}

                        //connection = new MySqlConnection();
                        //connection.ConnectionString = connectionString;
                        //connection.Open();
                        //Console.WriteLine("CONNECTION RESET");

                        using (MySqlCommand cmdTimeoutRead = connection.CreateCommand())
                        {
                            cmdTimeoutRead.CommandText = "SHOW SESSION VARIABLES LIKE 'max_execution_time'";
                            MySqlDataReader reader = cmdTimeoutRead.ExecuteReader();
                            if (reader.Read())
                            {
                                object o = reader[1];
                                Console.WriteLine("MAX_EXECUTION_TIME = {0}", o);
                            }
                            reader.Close();

                            reader2 = null;
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Other exception: {0}", ex.Message);
                }
                finally
                {
                    //if (reader2 != null && !reader2.IsClosed)
                    //{
                    //    reader2.Close();
                    //}
                }
                Console.WriteLine("Next");
            }
            

            connection.Close();
        }
    }
}
