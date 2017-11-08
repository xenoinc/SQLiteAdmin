/* Copyright Xeno Innovations, Inc. 2011-2017
 * Author:  Damian Suess
 * Date:    2017-3-8
 * File:    MSSqlProvider.cs
 * Description:
 *
 * To Do:
 * Change Log:
 *  2017-38 * Initial creation
 */

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Xeno.SQLiteAdmin.Data.Provider
{
  public class MSSqlProvider : IDatabaseProvider
  {
    private SqlCommand _currentCommand;

    public MSSqlProvider()
    {
      this.Properties = new Dictionary<DatabaseProperty, string>();
    }

    public string ConnectionString { get; set; }

    public Dictionary<DatabaseProperty, string> Properties { get; set; }

    public DatabaseProvider ProviderType { get { return DatabaseProvider.MSSQL; } }

    public void Close()
    {
    }

    /// <summary>Stop executing current command execution</summary>
    /// <returns>Success or failure</returns>
    public bool StopExecuting()
    {
      try
      {
        _currentCommand.Cancel();
        return true;
      }
      catch
      {
        return false;
      }
    }

    public int ExecuteNonQuery(string query, out Exception ex)
    {
      //string connString = @"Integrated Security=SSPI;Persist Security Info=False;" +
      //                    @"Initial Catalog=ccwebgrity;" +
      //                    @"Data Source=SURAJIT\SQLEXPRESS";
      //SqlConnection conn = new SqlConnection(sqlConnectionString);
      //Server server = new Server(new ServerConnection(conn));
      //server.ConnectionContext.ExecuteNonQuery(script);

      throw new NotImplementedException();
      return 0;
    }

    public DataSet ExecuteQuery(string query)
    {
      throw new NotImplementedException();

      var ds = new DataSet();
      return ds;
    }
  }
}
