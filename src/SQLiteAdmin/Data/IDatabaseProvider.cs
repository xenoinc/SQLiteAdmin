/* Copyright Xeno Innovations, Inc. 2011-2017
 * Author:  Damian Suess
 * Date:    2017-3-8
 * File:    IDatabase.cs
 * Description:
 *  Interface for all database providers so we can
 *  have a uniform command set
 *
 * Change Log:
 *  2017-0308 * Initial creation
 */

using System;
using System.Collections.Generic;
using System.Data;
using Xeno.SQLiteAdmin.Data.Provider;

namespace Xeno.SQLiteAdmin.Data
{
  public interface IDatabaseProvider
  {
    /// <summary>Name of known DB engine</summary>
    DatabaseProvider ProviderType { get; }

    /// <summary>Custom database properties</summary>
    Dictionary<DatabaseProperty, string> Properties { get; set; }

    string ConnectionString { get; set; }

    void Close();

    int ExecuteNonQuery(string query, out Exception ex);

    DataSet ExecuteQuery(string query);

    /// <summary>Stop current execution</summary>
    /// <returns>If successful or not</returns>
    bool StopExecuting();
  }
}
