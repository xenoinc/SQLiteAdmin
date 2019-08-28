/* Copyright Xeno Innovations, Inc. 2019
 * Date:    2019-8-28
 * Author:  Damian Suess
 * File:    SqliteNetPclEngine.cs
 * Description:
 *  SQLite-Net-PCL engine implementation
 */

using System;
using System.Data;

namespace Xeno.SQLiteAdmin.Engines.SQLiteNetPcl
{
  public class SqliteNetPclEngine : ISqlEngine
  {
    /// <summary>Connection string</summary>
    public string ConnectionString { get; set; }

    //public void Connect()
    //{
    //  throw new NotImplementedException();
    //}
    //
    //public void Connect(string connectionString)
    //{
    //  throw new NotImplementedException();
    //}
    //
    //public void Disconnect()
    //{
    //}

    public int ExecuteNonQuery(string query)
    {
      throw new NotImplementedException();
    }

    public DataSet ExecuteQuery(string query)
    {
      throw new NotImplementedException();
    }
  }
}
