﻿/* Copyright Xeno Innovations, Inc. 2019
 * Date:    2019-8-28
 * Author:  Damian Suess
 * File:    DatabaseService.cs
 * Description:
 *
 */

using System.Data;
using SQLite;
using Xeno.SQLiteAdmin.Engines;

namespace Xeno.SQLiteAdmin.Services
{
  public class DatabaseService : IDatabaseService  //, ISqlEngine
  {
    private string _connectionString;
    private ISqlEngine _sqlEngine;

    public DatabaseService()
    {
      DatabaseEngine = new Engines.SQLiteNetPcl.SqliteNetPclEngine();

      // ConnectionString = @"Data Source={'C:\Temp\test.db3'};New=False;Version=3";
      ConnectionString = @"Data Source={'C:\Temp\test.db3'};New=True;Version=3";
    }

    //public DatabaseService(ISqlEngine sqlEngine)
    //{
    //  DatabaseEngine = sqlEngine;
    //
    //  // ConnectionString = @"Data Source={'C:\Temp\test.db3'};New=False;Version=3";
    //  ConnectionString = @"Data Source={'C:\Temp\test.db3'};New=True;Version=3";
    //}

    public string ConnectionString
    {
      get => _connectionString;
      set => _connectionString = value;
    }

    public ISqlEngine DatabaseEngine
    {
      get => _sqlEngine;
      set => _sqlEngine = value;
    }

    public int ExecuteNonQuery(string query)
    {
      //// return _sqlEngine.ExecuteNonQuery(query);

      using (var conn = new SQLiteConnection(ConnectionString))
      {
        int rowCount = conn.Execute(query);
      }

      return 0;
    }

    public DataSet ExecuteQuery(string query)
    {
      //    // Use the SQL Engine Adapter
      //// return _sqlEngine.ExecuteQuery(query);

      DataSet dataSet = new DataSet();

      // This will execute a CREATE TABLE
      using (var conn = new SQLiteConnection(@"C:\temp\SqliteAdmin.db3"))
      {
        var cmd = new SQLite.SQLiteCommand(conn);
        cmd.CommandText = query;
        var x = cmd.ExecuteQuery<DataSet>();
      }

      // Returns NULL on both CREATE TABLE and SELECT
      //using (var conn = new SQLiteConnection(@"C:\temp\SqliteAdmin.db3"))
      //{
      //  dataSet = conn.ExecuteScalar<DataSet>(query);
      //}
      //
      // // Same as above, but without the ~dtr
      //var conn = new SQLiteConnection(@"C:\temp\SqliteAdmin.db3");
      //dataSet = conn.ExecuteScalar<DataSet>(query);

      return dataSet;
    }

    ////public void Connect()
    ////{
    ////  //_sqlEngine.Connect(ConnectionString);
    ////}
    ////
    ////public void Connect(string connectionString)
    ////{
    ////  //_sqlEngine.Connect(connectionString);
    ////}
  }
}
